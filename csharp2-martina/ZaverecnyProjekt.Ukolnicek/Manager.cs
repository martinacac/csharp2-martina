using System;
using System.Globalization;
using System.Security.AccessControl;

namespace ZaverecnyProjekt.Ukolnicek;

public class Manager : GeneralUser
{
    //public Manager(string? name = null, string? password = null) : base(name, password)
    public Manager(string name, string password) : base(name, password)
    {
    }
    public Manager() { }

    public void ManagerMenu()
    {
        bool endManagerMenu = false;
        do
        {
            Console.Clear();
            string hyphens = new string('-', 30 + Name.Length);
            Console.WriteLine(hyphens);
            Console.WriteLine($"TASK TRACKER - Manager Menu - {Name}");
            Console.WriteLine(hyphens);
            Console.WriteLine("1) List Tasks of Selected User");
            Console.WriteLine("2) List Tasks of All Users");
            Console.WriteLine("3) Find Tasks");
            Console.WriteLine("4) Add Task");
            Console.WriteLine("5) Delete Task");
            Console.WriteLine("6) Sign up New Manager");
            Console.WriteLine("0) Return to Main Menu");
            Console.WriteLine(hyphens);
            Console.Write("Your choice (0-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    {

                        ListUsers();
                        User? selectedUser = GetSelectedUser();
                        if (selectedUser != null)
                        {
                            selectedUser.ListTasks();

                            //List<Task> selectedUserTasks = selectedUser.GetTasksOfUser();
                        }
                        else System.Console.WriteLine("User not found.");
                        break;
                    }
                case "2":
                    {
                        ListAllTasksGroupedByUsersWithFilter();
                        break;
                    }
                case "3":
                    {
                        ListUsers();
                        User? selectedUser = GetSelectedUser();
                        if (selectedUser != null)
                        {
                            selectedUser.FindTasks(); //of specific user
                        }
                        else System.Console.WriteLine("User not found.");
                        break;
                    }
                case "4":
                    {
                        AddTask();
                        break;
                    }
                case "5":
                    {
                        DeleteTask();
                        break;
                    }
                case "6":
                    {
                        Utils.SignUpManager();
                        break;
                    }
                case "0":
                    {
                        endManagerMenu = true;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        Utils.WaitForEnter();
                        break;
                    }
            }
        } while (!endManagerMenu);
    }
    public void ListUsers()
    {
        if (!File.Exists(Utils.allUsersPathAndFile) || !Directory.Exists(Utils.appRootDirectoryPath) || File.ReadAllLines(Utils.allUsersPathAndFile).Length == 0)
        {
            Console.WriteLine("No registered users found.");
            Utils.WaitForEnter();
        }
        else
        {
            int index = 1;
            foreach (var row in File.ReadAllLines(Utils.allUsersPathAndFile))
            {
                var user = row.Split(';');
                System.Console.WriteLine($"User number: {index++} - {user[0]}");
            }
        }
    }
    public User? GetSelectedUser()
    {
        if (!File.Exists(Utils.allUsersPathAndFile) || !Directory.Exists(Utils.appRootDirectoryPath) || File.ReadAllLines(Utils.allUsersPathAndFile).Length == 0)
        {
            Console.WriteLine("No registered users found.");
            Utils.WaitForEnter();
            return null;
        }
        else
        {
            bool validIndex = false;
            int index;
            do
            {
                Console.Write("Input number of user to be selected: ");
                validIndex = int.TryParse(Console.ReadLine(), out index);
                if (!validIndex) Console.WriteLine("Invalid index. Try again.");
                else if (index < 1 || index > File.ReadAllLines(Utils.allUsersPathAndFile).Length)
                {
                    validIndex = false;
                    Console.WriteLine("Invalid index. Try again.");
                }
                else index--; //convert to zero-based index
            } while (!validIndex);

            //Utils.WaitForEnter();

            string userLine = File.ReadAllLines(Utils.allUsersPathAndFile)[index];
            User selectedUser = new User
            {
                Name = userLine.Split(';')[0]
            };
            selectedUser.Tasks = selectedUser.GetTasksOfUser();
            return selectedUser;
        }
    }
    public void AddTask()
    {
        //List all users
        ListUsers();
        System.Console.WriteLine();
        //Select a user by index
        if (File.ReadAllLines(Utils.allUsersPathAndFile).Length == 0) return;
        else
        {
            User selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                System.Console.WriteLine("No user selected.");
                Utils.WaitForEnter();
                return;
            }
            //Get task properties
            string description;
            do
            {
                System.Console.Write("Enter task description: ");
                description = Console.ReadLine();
                if (string.IsNullOrEmpty(description))
                {
                    System.Console.WriteLine("Description cannot be empty.");
                }
            } while (string.IsNullOrEmpty(description));

            DateTime dueDate;
            System.Console.Write("Enter due date (dd.MM.yyyy): ");
            while (!DateTime.TryParseExact(Console.ReadLine(), Utils.supportedDateFormats, null, System.Globalization.DateTimeStyles.None, out dueDate))
            {
                System.Console.WriteLine("Invalid date format. Please use dd.MM.yyyy or dd/MM/yyyy: ");
                System.Console.Write("Enter due date (dd.MM.yyyy): ");
            }
            if (dueDate < DateTime.Today)
            {
                System.Console.Write("Your due date is in the past. Do you want to continue? (y/n): ");
                if (Console.ReadLine() == "n") return;
            }

            System.Console.Write("Is this a high priority task? (y/n): ");
            bool highPriority = Console.ReadLine().ToLower() == "y";
            //Get confirmation
            Task newTask = new Task(description, dueDate, highPriority);
            System.Console.Write($"Add task: ");
            newTask.WriteTaskInConsole();
            System.Console.Write(" ? (y/n): ");
            //Create and add the new task, save the task
            if (Console.ReadLine().ToLower() == "y")
            {
                List<Task> userTasks = selectedUser.GetTasksOfUser() ?? new List<Task>();
                userTasks.Add(newTask);
                selectedUser.SaveTasks(userTasks);
                System.Console.WriteLine("Task added successfully.");
                Utils.WaitForEnter();
            }
        }

    }
    public void DeleteTask()
    {
        //List users
        ListUsers();
        System.Console.WriteLine();
        //Select user by index
        if (File.ReadAllLines(Utils.allUsersPathAndFile).Length == 0) return;
        User selectedUser = GetSelectedUser();
        if (selectedUser == null)
        {
            System.Console.WriteLine("No user selected.");
            Utils.WaitForEnter();
            return;
        }
        //Load and list tasks of selected user
        List<Task> userTasks = selectedUser.GetTasksOfUser();
        if (userTasks == null || userTasks.Count == 0)
        {
            System.Console.WriteLine("No tasks found for this user.");
            Utils.WaitForEnter();
            return;
        }
        System.Console.WriteLine($"User: {selectedUser.Name} - List of tasks: ");
        for (int i = 0; i < userTasks.Count; i++)
        {
            System.Console.Write($"Task number: {(i + 1).ToString().PadRight(3, ' ')} - ");
            userTasks[i].WriteTaskInConsole();
            System.Console.WriteLine();
            //{userTasks[i].Description.PadRight(20, '.')} Due: {userTasks[i].DueDate:dd.MM.yyyy}, High priority:{(userTasks[i].HighPriority ? "Yes" : "No")} Completed: {(userTasks[i].Completed ? "Yes" : "No")}");
        }
        //Select task to delete
        bool validIndex = false;
        int index;
        do
        {
            System.Console.Write("Input number of task to delete: ");
            validIndex = int.TryParse(Console.ReadLine(), out index);
            if (!validIndex || index < 1 || index > userTasks.Count)
            {
                validIndex = false;
                Console.WriteLine("Invalid index. Try again.");
            }
            else
            {
                validIndex = true;
                index--; //convert to zero-based index;
            }
        } while (!validIndex);
        //Confirm task to delete
        System.Console.Write($"Delete task {(index + 1).ToString().PadRight(3, ' ')} - ");
        userTasks[index].WriteTaskInConsole();
        System.Console.Write(" ? (y/n): ");
        //{ userTasks[index].Description.PadRight(20, '.')} Due: {userTasks[index].DueDate:dd.MM.yyyy}, Priority:{(userTasks[index].HighPriority ? "Yes" : "No")}? (y/n)");
        //Delete task and save
        if (Console.ReadLine().ToLower() == "y")
        {
            userTasks.RemoveAt(index);
            selectedUser.SaveTasks(userTasks);
            System.Console.WriteLine($"Task successfully deleted.");
        }
        else System.Console.WriteLine("No task deleted.");
        Utils.WaitForEnter();
    }
    public void ListAllTasksGroupedByUsersWithFilter()
    {
        if (!File.Exists(Utils.allUsersPathAndFile) || !Directory.Exists(Utils.appRootDirectoryPath))
        {
            Console.WriteLine("No registered users found.");
            Utils.WaitForEnter();
            return;
        }

        string filterChoice = Utils.PromptTaskFilterType();
        Func<Task, bool> filterPredicate = Utils.GetTaskFilterPredicate(filterChoice);

        var userLines = File.ReadAllLines(Utils.allUsersPathAndFile);
        foreach (var userLine in userLines)
        {
            string[] userData = userLine.Split(';');
            if (userData.Length >= 1)
            {
                string userName = userData[0];
                User user = new User { Name = userName };
                user.Tasks = user.GetTasksOfUser();

                var filteredTasks = user.Tasks.FindAll(t => filterPredicate(t));

                Console.WriteLine($"User: {userName} - List of tasks: ");
                if (filteredTasks.Count == 0)
                {
                    Console.WriteLine("  No matching tasks found.");
                }
                else
                {
                    foreach (var task in filteredTasks)
                    {
                        //Console.WriteLine($"  - {task.Description} (Due: {task.DueDate:dd.MM.yyyy}, Priority: {(task.HighPriority ? "High" : "Normal")}, Completed: {(task.Completed ? "Yes" : "No")})");

                        Console.Write("  - ");
                        task.WriteTaskInConsole();
                        System.Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
        }
        Utils.WaitForEnter();
    }

}