using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class Manager : GeneralUser
{
    public string Name { get; private set; }
    public string Password { get; private set; }
    public Manager(string name = "Null", string password = "Null") : base(name, password)
    {
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
                        IsValidInput = true;
                        ListTasks(); //inherited from GeneralUser
                        break;
                    }
                case "2":
                    {
                        IsValidInput = true;
                        FindTasks(); //inherited from GeneralUser
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
}