using System;
using System.Text;

namespace ZaverecnyProjekt.Ukolnicek;

public class Utils
{
    //for public static methods and var
    public static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public static string pathToDirectory = Path.Combine(appDataPath, "TaskTracker");
    public static string allUsersFile = "users.txt";
    public static string allManagersFile = "managers.txt";
    public static string allUsersPathAndFile = Path.Combine(pathToDirectory, allUsersFile);
    public static string allManagersPathAndFile = Path.Combine(pathToDirectory, allManagersFile);

    public static string EncodePassword(string password)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
    }

    public static string DecodePassword(string codedPassword)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(codedPassword));
    }
    public static User? LogInUser()
    {

        Console.Write("Input user name: ");
        string name = Console.ReadLine();
        Console.Write("Input password: ");
        string password = Console.ReadLine();
        string codedPassword = EncodePassword(password);

        if (!File.Exists(allUsersPathAndFile) || !Directory.Exists(pathToDirectory))
        {
            Console.WriteLine("No registered users found.");
            Console.ReadKey();
            return null;
        }

        foreach (var row in File.ReadAllLines(allUsersPathAndFile))
        {
            var data = row.Split(';');
            if (data.Length >= 2 && data[0] == name && data[1] == codedPassword)
            {
                User loggedUser = new User
                {
                    Name = name
                };
                loggedUser.Tasks = loggedUser.GetTasksOfUser();
                Console.WriteLine($"Login successful, welcome {loggedUser.Name}.");
                Console.ReadKey();
                return loggedUser;
            }
        }
        Console.WriteLine("Invalid credentials.");
        Console.ReadKey();
        return null;
    }
    public static Manager? LogInManager()
    {
        string name;
        string password;
        string codedPassword;
        do
        {
            Console.Write("Input manager name: ");
            name = Console.ReadLine();
        } while (string.IsNullOrEmpty(name));
        do
        {
            Console.Write("Input password: ");
            password = Console.ReadLine();
            codedPassword = EncodePassword(password);
        } while (string.IsNullOrEmpty(password));
        if (!File.Exists(allManagersPathAndFile) || !Directory.Exists(pathToDirectory))
        {
            Console.WriteLine("No registered managers found.");
            Console.ReadKey();
            return null;
        }

        foreach (var row in File.ReadAllLines(allManagersPathAndFile))
        {
            var data = row.Split(';');
            if (data.Length >= 2 && data[0] == name && data[1] == codedPassword)
            {
                Manager loggedManager = new Manager
                {
                    Name = name
                };

                Console.WriteLine($"Login successful, welcome {loggedManager.Name}.");
                Console.ReadKey();
                return loggedManager;
            }
        }
        Console.WriteLine("Invalid credentials.");
        Console.ReadKey();
        return null;
    }
}