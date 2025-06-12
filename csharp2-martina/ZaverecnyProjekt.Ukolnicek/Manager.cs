using System;
using System.Globalization;
using System.Security.AccessControl;

namespace ZaverecnyProjekt.Ukolnicek;

public class Manager : GeneralUser
{
    public Manager(string name = "Null", string password = "Null") : base(name, password)
    {
    }
    public Manager() { }
    public void ListUsers()
    {
        if (!File.Exists(Utils.allUsersPathAndFile) || !Directory.Exists(Utils.pathToDirectory))
        {
            Console.WriteLine("No registered users found.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
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
        if (!File.Exists(Utils.allUsersPathAndFile) || !Directory.Exists(Utils.pathToDirectory))
        {
            Console.WriteLine("No registered users found.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
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
                else if (index < 0 || index > File.ReadAllLines(Utils.allUsersPathAndFile).Length)
                {
                    validIndex = false;
                    Console.WriteLine("Invalid index. Try again.");
                }
                else index--; //convert to zero-based index
            } while (!validIndex);

            //Console.WriteLine("Press Enter to continue...");
            //Console.ReadLine();

            string userLine = File.ReadAllLines(Utils.allUsersPathAndFile)[index];
            User selectedUser = new User
            {
                Name = userLine.Split(';')[0]
            };
            selectedUser.Tasks = selectedUser.GetTasksOfUser();
            return selectedUser;
        }
    }
    public void ManagerMenu()
    {
        bool endManagerMenu = false;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("TASK TRACKER - Manager Menu");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1) List Tasks");
            Console.WriteLine("2) Find Tasks");
            Console.WriteLine("3) Add Task");
            Console.WriteLine("4) Delete Task");
            Console.WriteLine("5) Sign up new Manager");
            Console.WriteLine("0) Log out");
            Console.WriteLine("---------------------------");
            Console.Write("Your choice (0-4): ");
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
                        ListUsers();
                        User? selectedUser = GetSelectedUser();
                        if (selectedUser != null)
                        {
                            selectedUser.FindTasks(); //of specific user
                        }
                        else System.Console.WriteLine("User not found.");
                        break;
                    }
                case "3":
                    {
                        AddTask();
                        break;
                    }
                case "4":
                    {
                        DeleteTask();
                        break;
                    }
                case "5":
                    {
                        Utils.SignUpManager();
                        break;
                    }
                case "0":
                    {
                        endManagerMenu = true;
                        LogOut(); //inherited from GeneralUser
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                    }
            }
        } while (!endManagerMenu);
    }
    public void AddTask()
    {
        //List all users
        ListUsers();
        System.Console.WriteLine();
        //Select a user by index
        User selectedUser = GetSelectedUser();
        if (selectedUser == null)
        {
            System.Console.WriteLine("No user selected.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return;
        }
        //Get task properties
        string description;
        do
        {
            System.Console.WriteLine("Enter task description: ");
            description = Console.ReadLine();
            if (string.IsNullOrEmpty(description))
            {
                System.Console.WriteLine("Description cannot be empty.");
            }
        } while (string.IsNullOrEmpty(description));

        DateTime dueDate;
        string[] formats = { "dd.MM.yyyy", "dd/MM/yyyy", "dd-MM-yyyy" };
        System.Console.Write("Enter due date (dd.MM.yyyy): ");
        while (!DateTime.TryParseExact(Console.ReadLine(), formats, null, System.Globalization.DateTimeStyles.None, out dueDate))
        {
            System.Console.WriteLine("Invalid date format. Please use dd.MM.yyyy or dd/MM/yyyy: ");
            System.Console.Write("Enter due date (dd.MM.yyyy): ");
        }

        System.Console.Write("Is this a high priority task? (y/n): ");
        bool highPriority = Console.ReadLine().ToLower() == "y";

        //Create and add the new task, save the task
        Task newTask = new Task(description, dueDate, highPriority);
        List<Task> userTasks = selectedUser.GetTasksOfUser() ?? new List<Task>();
        userTasks.Add(newTask);
        selectedUser.SaveTasks(userTasks);
        System.Console.WriteLine("Task added successfully.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    public void DeleteTask()
    {
        //List users
        ListUsers();
        System.Console.WriteLine();
        //Select user by index
        User selectedUser = GetSelectedUser();
        if (selectedUser == null)
        {
            System.Console.WriteLine("No user selected.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return;
        }
        //Load and list tasks of selected user
        List<Task> userTasks = selectedUser.GetTasksOfUser();
        if (userTasks == null || userTasks.Count == 0)
        {
            System.Console.WriteLine("No tasks found for this user.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return;
        }
        System.Console.WriteLine($"Tasks of user {selectedUser.Name}:");
        for (int i = 0; i < userTasks.Count; i++)
        {
            System.Console.WriteLine($"Task number: {(i + 1).ToString().PadRight(3, ' ')} - {userTasks[i].Description.PadRight(20, '.')} Due: {userTasks[i].DueDate:dd.MM.yyyy}, High priority:{(userTasks[i].HighPriority ? "Yes" : "No")} Completed: {(userTasks[i].Completed ? "Yes" : "No")}");
        }
        //Select task to delete
        bool validIndex = false;
        int index;
        do
        {
            System.Console.WriteLine("Input number of task to delete: ");
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
        System.Console.WriteLine($"Delete task {(index + 1).ToString().PadRight(3, ' ')} - {userTasks[index].Description.PadRight(20, '.')} Due: {userTasks[index].DueDate:dd.MM.yyyy}, Priority:{(userTasks[index].HighPriority ? "Yes" : "No")}? (y/n)");
        //Delete task and save
        if (Console.ReadLine().ToLower() == "y")
        {
            userTasks.RemoveAt(index);
            selectedUser.SaveTasks(userTasks);
            System.Console.WriteLine($"Task: {userTasks[index]} successfully deleted.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
        else System.Console.WriteLine("No task deleted.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }


}