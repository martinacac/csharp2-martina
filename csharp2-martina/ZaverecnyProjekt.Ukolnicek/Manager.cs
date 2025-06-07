using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class Manager : GeneralUser
{
    public string Name { get; set; }
    public string Password { get; private set; }
    public Manager(string name = "Null", string password = "Null") : base(name, password)
    {
    }
    public void ListUsers()
    {
        foreach (var row in File.ReadAllLines(Utils.allUsersPathAndFile))
        {
            int index = 1;
            var user = row.Split(';');
            System.Console.WriteLine($"User number: {index++} - {user[0]}");
        }
    }
    public User? GetSelectedUser()
    {
        bool validIndex = false;
        int index;
        do
        {
            Console.Write("Input number of user to be selected: ");
            validIndex = int.TryParse(Console.ReadLine(), out index);
            if (!validIndex) Console.WriteLine("Try again.");
            else index--;
        } while (!validIndex);

        string userLine = File.ReadAllLines(Utils.allUsersPathAndFile)[index];
        User selectedUser = new User
        {
            Name = userLine.Split(';')[0]
        };
        selectedUser.Tasks = selectedUser.GetTasksOfUser();
        return selectedUser;
    }
    public void ManagerMenu()
    {
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            Console.Clear();

            Console.WriteLine("1) List Tasks");
            Console.WriteLine("2) Find Tasks");
            Console.WriteLine("3) Add Task");
            Console.WriteLine("4) Delete Task");
            Console.WriteLine("0) Log out");
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
                            IsValidInput = true;
                            List<Task> selectedUserTasks = selectedUser.GetTasksOfUser();
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
                            IsValidInput = true;
                            selectedUser.FindTasks(); //of specific user
                        }
                        else System.Console.WriteLine("User not found.");
                        break;
                    }
                case "3":
                    {
                        IsValidInput = true;
                        AddTask();
                        break;
                    }
                case "4":
                    {
                        IsValidInput = true;
                        DeleteTask();
                        break;
                    }
                case "0":
                    {
                        IsValidInput = true;
                        LogOut(); //inherited from GeneralUser
                        break;
                    }
                default:
                    {
                        IsValidInput = false;
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                    }
            }
        }
    }
    public void AddTask()
    {
        System.Console.WriteLine("Toto se ještě musí dodělat.");
    }
    public void DeleteTask()
    {
        System.Console.WriteLine("Toto se ještě musí dodělat.");
    }
}