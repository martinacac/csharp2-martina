using System;
using System.Xml;
using System.Xml.Serialization;

namespace ZaverecnyProjekt.Ukolnicek;

public class User : GeneralUser
{
    public List<Task> Tasks { get; set; }
    public User() { }
    public User(string name = "Null", string password = "Null") : base(name, password)
    {
    }
    public User(string name, List<Task> tasks) : base(name)
    {
        Tasks = tasks;
    }
    public void UserMenu()
    {
        bool endUserMenu = false;
        do
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
                        LogOut(); //inherited from GeneralUser
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
        Console.ReadKey();
    }

    public void SaveTasks(List<Task> tasks)
    {
        if (tasks != null)
        {
            XmlSerializer taskSerializer = new XmlSerializer(typeof(List<Task>));
            //string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //string pathToDirectory = Path.Combine(appDataPath, "TaskTracker");
            if (!Directory.Exists(Utils.pathToDirectory))
            {
                Directory.CreateDirectory(Utils.pathToDirectory);
            }
            string userXmlFile = $"{Name}.xml";
            string pathToXmlFileInDirectory = Path.Combine(Utils.pathToDirectory, userXmlFile);
            using (StreamWriter writer = new StreamWriter(pathToXmlFileInDirectory))
            {
                taskSerializer.Serialize(writer, tasks);
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
        List<Task> tasks1 = new List<Task>();
        //string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //string pathToDirectory = Path.Combine(appDataPath, "TaskTracker");
        if (!Directory.Exists(Utils.pathToDirectory))
        {
            Directory.CreateDirectory(Utils.pathToDirectory);
        }
        string userXmlFile = $"{Name}.xml";

        string pathToXmlFileInDirectory = Path.Combine(Utils.pathToDirectory, userXmlFile);

        try
        {
            if (!File.Exists(pathToXmlFileInDirectory))
            {
                System.Console.WriteLine("Tasks not found.");
                Console.ReadKey();
                return null;
            }

            XmlSerializer taskSerializer = new XmlSerializer(typeof(List<Task>));
            using (StreamReader reader = new StreamReader(pathToXmlFileInDirectory))
            {
                tasks1 = taskSerializer.Deserialize(reader) as List<Task>;
            }
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine("Error in XML format: " + ex.Message);
        }
        catch (XmlException ex)
        {
            System.Console.WriteLine("Error while parsing XML: " + ex.Message);
        }
        catch (IOException ex)
        {
            System.Console.WriteLine("Error while reading file: " + ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Unexpected error: " + ex.Message);
        }
        return tasks1;
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
        foreach (Task t in Tasks)
        {
            System.Console.WriteLine($"Task number: {index++} - {t.Description}; High priority: {t.HighPriority}; Due date: {t.DueDate.ToString("dd.MM.yyyy")}; Completed: {t.Completed}");
        }
    }

    public void FindTasks()
    {
        System.Console.WriteLine("Toto se ještě musí dodělat.");
        Console.Write("Input text to be found in task description: ");
        string findText = Console.ReadLine().ToLower();

        var foundTasks = GetTasksOfUser().FindAll(t => t.Description.ToLower().Contains(findText));

        if (foundTasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            foreach (var t in foundTasks)
            {
                Console.WriteLine(t);
            }
        }
    }

}


