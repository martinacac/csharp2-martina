using System;
using System.Xml;
using System.Xml.Serialization;

namespace ZaverecnyProjekt.Ukolnicek;

public class User : GeneralUser
{
    public List<Task> Tasks { get; set; }
    private readonly XmlSerializer tasksSerializer;
    public User()
    {
        tasksSerializer = new XmlSerializer(typeof(List<Task>)); //pak už není nutné v kódu mít XmlSerializer taskSerializer = new XmlSerializer(typeof(List<Task>));
    }
    //public User() { } 

    public User(string name, string password) : base(name, password)
    {
    }

    public void UserMenu()
    {
        bool endUserMenu = false;
        do
        {
            Console.Clear();
            string hyphens = new string('-', 27 + Name.Length);
            Console.WriteLine(hyphens);
            Console.WriteLine($"TASK TRACKER - User Menu - {Name}");
            Console.WriteLine(hyphens);
            Console.WriteLine("1) List Tasks");
            Console.WriteLine("2) Find Tasks");
            Console.WriteLine("3) Mark Task as Completed");
            Console.WriteLine("0) Return to Main Menu");
            Console.WriteLine(hyphens);
            Console.Write("Your choice (0-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    {
                        ListTasks();
                        break;
                    }
                case "2":
                    {
                        FindTasks();
                        break;
                    }
                case "3":
                    {
                        MarkTaskAsCompleted();
                        break;
                    }
                case "0":
                    {
                        endUserMenu = true;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                    }
            }
        } while (!endUserMenu);
    }
    public void MarkTaskAsCompleted()
    {
        ListTasks();
        bool validIndex = false;
        int index;
        do
        {
            Console.Write("Input number of task to be marked as completed: ");
            validIndex = int.TryParse(Console.ReadLine(), out index);
            if (!validIndex) Console.WriteLine("Invalid number. Try again.");
            else index--;
        } while (!validIndex);

        //Confirm task to mark as completed
        System.Console.Write($"Mark as completed task: {(index + 1).ToString().PadRight(3, ' ')} - ");
        Tasks[index].WriteTaskInConsole();
        System.Console.Write(" ? (y/n): ");

        //Mark task and save
        if (Console.ReadLine().ToLower() == "y")
            if (index >= 0 && index < Tasks.Count)
            {
                Tasks[index].Completed = true;
                SaveTasks(Tasks);
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        Utils.WaitForEnter();
    }

    public void SaveTasks(List<Task> tasks)
    {
        if (tasks != null)
        {
            if (!Directory.Exists(Utils.appRootDirectoryPath))
            {
                Directory.CreateDirectory(Utils.appRootDirectoryPath);
            }
            string userXmlFile = $"{Name}.xml";
            string pathToXmlFileInDirectory = Path.Combine(Utils.appRootDirectoryPath, userXmlFile);
            using (StreamWriter writer = new StreamWriter(pathToXmlFileInDirectory))
            {
                tasksSerializer.Serialize(writer, tasks);
            }
        }
        else System.Console.WriteLine("No tasks to be saved.");
        /*var rows = new List<string>();
            foreach (var t in tasks)
            {
                rows.Add($"{t.Description};{t.HighPriority};{t.DueDate.ToString("dd.MM.yyyy")};{t.Completed}");
            }
            File.WriteAllLines($"{Name}.txt", rows);*/
    }

    public List<Task> GetTasksOfUser()
    {
        if (!Directory.Exists(Utils.appRootDirectoryPath))
        {
            Directory.CreateDirectory(Utils.appRootDirectoryPath);
        }
        string userXmlFile = $"{Name}.xml";
        string pathToXmlFileInDirectory = Path.Combine(Utils.appRootDirectoryPath, userXmlFile);

        if (!File.Exists(pathToXmlFileInDirectory))
        {
            System.Console.WriteLine("Tasks not found.");
            Utils.WaitForEnter();
            return new List<Task>(); //return empty list (not null)
        }
        //check if file is empty
        var fileInfo = new FileInfo(pathToXmlFileInDirectory);
        if (fileInfo.Length == 0)
        {
            return new List<Task>();
        }
        try
        {
            using (StreamReader reader = new StreamReader(pathToXmlFileInDirectory))
            {
                return tasksSerializer.Deserialize(reader) as List<Task>;
            }
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine("Error in XML format: " + ex.Message);
            return new List<Task>();
        }
        catch (XmlException ex)
        {
            System.Console.WriteLine("Error while parsing XML: " + ex.Message);
            return new List<Task>();
        }
        catch (IOException ex)
        {
            System.Console.WriteLine("Error while reading file: " + ex.Message);
            return new List<Task>();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Unexpected error: " + ex.Message);
            return new List<Task>();
        }
    }

    /*List<Task> tasks = new List<Task>();
    string userFile = $"{Name}.txt";
    string pathToFileInDirectory = Path.Combine(pathToDirectory, userFile);
    if (!File.Exists(pathToFileInDirectory))
    {
        throw new Exception("Tasks not found.");
        //return tasks;
    }
    foreach (var row in File.ReadAllLines(pathToFileInDirectory))
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
    }*/
    public void ListTasks()
    {
        System.Console.WriteLine($"User: {Name} - List of tasks: ");
        int index = 1;
        if (Tasks.Count == 0)
        {
            System.Console.WriteLine("No tasks found.");
            Utils.WaitForEnter();
        }
        else
        {
            GetTasksOfUser();
            foreach (Task t in Tasks)
            {
                Console.Write($"Task number: {index++.ToString().PadRight(3, ' ')} - ");
                t.WriteTaskInConsole();
                System.Console.WriteLine();
            }
        }
        Utils.WaitForEnter();
    }

    public void FindTasks()
    {
        Console.Write("Input text to be found in task description: ");
        string findText = Console.ReadLine().ToLower();

        var foundTasks = GetTasksOfUser().FindAll(t => t.Description.ToLower().Contains(findText));

        if (foundTasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            int index = 0;
            System.Console.WriteLine("Found tasks: ");
            foreach (var t in foundTasks)
            {
                Console.Write($" {index++.ToString().PadRight(3, ' ')} - ");
                t.WriteTaskInConsole();
                System.Console.WriteLine();
            }
        }
        Utils.WaitForEnter();
    }
}


