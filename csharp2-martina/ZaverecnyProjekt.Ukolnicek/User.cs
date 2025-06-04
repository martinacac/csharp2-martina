using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class User : GeneralUser
{
    public string Name { get; set; }
    public string Password { get; private set; }
    public List<Task> Tasks { get; set; }
    public User(string name = "Null", string password = "Null") : base(name, password)
    {
    }
    public User(string name, List<Task> tasks) : base(name)
    {
        Tasks = tasks;
    }
    public void UserMenu()
    {
        bool IsValidInput = false;
        while (!IsValidInput)
        {
            Console.Clear();

            Console.WriteLine("1) List Tasks");
            Console.WriteLine("2) Find Tasks");
            Console.WriteLine("3) Mark Task as Completed");
            Console.WriteLine("0) Log out");
            Console.Write("Your choice (0-3): ");
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
                        MarkTaskAsCompleted();
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
    public void MarkTaskAsCompleted()
    {
        ListTasks();
        Console.Write("Input number of task to be marked as completed: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < Tasks.Count)
        {
            Tasks[index].Completed = true;
            SaveTasks(Tasks);
            Console.WriteLine("Task marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
        Console.ReadKey();
    }

    public void SaveTasks(List<Task> tasks)
    {
        var rows = new List<string>();
        foreach (var t in tasks)
        {
            rows.Add($"{t.Description};{t.HighPriority};{t.DueDate.ToString("dd.MM.yyyy")};{t.Completed}");
        }
        File.WriteAllLines($"{Name}.txt", rows);
    }

    public List<Task> GetTasksOfUser()
    {
        var tasks = new List<Task>();
        string path = $"{Name}.txt";

        if (!File.Exists(path))
        {
            throw new Exception("Tasks not found.");
            //return tasks;
        }

        foreach (var row in File.ReadAllLines(path))
        {
            var data = row.Split(';');
            tasks.Add(new Task
            {
                Description = data[0],
                HighPriority = bool.Parse(data[1]),
                DueDate = DateTime.Parse(data[2]),
                Completed = bool.Parse(data[3])
            });
        }

        return tasks;
    }

}
