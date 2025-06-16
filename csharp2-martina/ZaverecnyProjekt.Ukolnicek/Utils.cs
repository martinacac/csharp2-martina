using System;
using System.Text;
using System.Xml.Serialization;

namespace ZaverecnyProjekt.Ukolnicek;

public class Utils
{
    //for public static methods and var
    public static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public static string appRootDirectoryPath = Path.Combine(appDataPath, "TaskTracker");
    public static string allUsersFile = "users.txt";
    public static string allManagersFile = "managers.txt";
    public static string defaultManagerName = "firstmanager";
    public static string defaultManagerPassword = "bigboss";

    public static string allUsersPathAndFile = Path.Combine(appRootDirectoryPath, allUsersFile);
    public static string allManagersPathAndFile = Path.Combine(appRootDirectoryPath, allManagersFile);
    public static char[] invalidFileNameChar = Path.GetInvalidFileNameChars();
    public static string[] supportedDateFormats = { "dd.MM.yyyy", "dd/MM/yyyy", "dd-MM-yyyy", "d. M. yyyy", "d/M/yyyy", "d-M-yyyy" };

    public static string EncodePassword(string password)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
    }

    public static string DecodePassword(string codedPassword)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(codedPassword));
    }
    public static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // Backspace should remove the last character
            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
            // Ignore control keys except backspace (already handled)
            else if (!char.IsControl(key.KeyChar))
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        }
        while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }
    public static User? LogInUser()
    {
        //check if file is empty or non-existent
        var fileInfo = new FileInfo(Utils.allUsersPathAndFile);
        if (!File.Exists(allUsersPathAndFile) || !Directory.Exists(appRootDirectoryPath) || fileInfo.Length == 0)
        {
            Console.WriteLine("No registered users found.");
            Utils.WaitForEnter();
            return null;
        }
        Console.Write("Input user name: ");
        string name = Console.ReadLine();

        Console.Write("Input password: ");
        string password = ReadPassword();
        string codedPassword = EncodePassword(password);

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
                Utils.WaitForEnter();
                return loggedUser;
            }
        }
        Console.WriteLine("Invalid credentials.");
        Utils.WaitForEnter();
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
            password = ReadPassword();
            codedPassword = EncodePassword(password);
        } while (string.IsNullOrEmpty(password));
        if (!File.Exists(allManagersPathAndFile) || !Directory.Exists(appRootDirectoryPath))
        {
            Console.WriteLine("No registered managers found.");
            Utils.WaitForEnter();
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
                Utils.WaitForEnter();
                return loggedManager;
            }
        }
        Console.WriteLine("Invalid credentials.");
        Utils.WaitForEnter();
        return null;
    }
    public static void SignUpUser()
    {
        int minLength = 3;
        bool repeatInput;
        string name;
        string password;
        string codedPassword;
        do
        {
            repeatInput = false;
            Console.Write("Input new user name: ");
            name = Console.ReadLine();
            if (!HasRequiredMinLength(name, minLength))
            {
                System.Console.WriteLine($"User name must have at least {minLength} characters. Try again.");
                repeatInput = true;
            }
            if (ExistsUserName(name) || ExistsUserNameFile(name))
            {
                System.Console.WriteLine($"User name already exists. Try again.");
                repeatInput = true;
            }
            foreach (char i in name)
                foreach (char j in invalidFileNameChar)
                {
                    if (i == j)
                    {
                        repeatInput = true;
                        System.Console.Write($"User name must not contain characters: ");
                        foreach (char item in invalidFileNameChar)
                        {
                            Console.Write($"{item} ");
                        }
                        System.Console.WriteLine();
                    }
                }
        } while (repeatInput);
        do
        {
            repeatInput = false;
            Console.Write($"Input password (min {minLength} characters): ");
            password = Console.ReadLine();
            if (!HasRequiredMinLength(password, minLength))
            {
                System.Console.WriteLine($"Password must have at least {minLength} characters. Try again.");
                repeatInput = true;
                continue;
            }
            Console.Write($"Input password for verification: ");
            string password2 = Console.ReadLine();
            if (password != password2)
            {
                repeatInput = true;
                System.Console.WriteLine("Password does not match. Try again.");
            }
        } while (repeatInput);
        codedPassword = EncodePassword(password);

        string userAndCodedPassword = $"{name};{codedPassword}\n";
        string userFile = $"{name}.xml";
        string userPathAndFile = Path.Combine(appRootDirectoryPath, userFile);
        if (!ExistsUserNameFile(name))
        {
            File.AppendAllText(allUsersPathAndFile, userAndCodedPassword);
            File.Create(userPathAndFile).Close();
            List<Task> emptyTasks = new List<Task>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Task>));
            using (var stream = new FileStream(userPathAndFile, FileMode.Create))
            {
                serializer.Serialize(stream, emptyTasks);
            }
            Console.WriteLine($"Sign up of user {name} successfully completed.");
        }
        else
        {
            System.Console.WriteLine($"Warning: Sign up of user {name} failed.");
        }
    }
    public static void SignUpManager()
    {
        int minLength = 3;
        bool repeatInput;
        string name;
        string password;
        string codedPassword;
        do
        {
            repeatInput = false;
            Console.Write("Input new manager name: ");
            name = Console.ReadLine();
            if (!HasRequiredMinLength(name, minLength))
            {
                System.Console.WriteLine($"User name must have at least {minLength} characters. Try again.");
                repeatInput = true;
            }
            if (Utils.ExistsManagerName(name))
            {
                System.Console.WriteLine($"Manager name already exists. Try again.");
                repeatInput = true;
            }
            foreach (char i in name)
                foreach (char j in invalidFileNameChar)
                {
                    if (i == j)
                    {
                        repeatInput = true;
                        System.Console.Write($"Manager name must not contain characters: ");
                        foreach (char item in invalidFileNameChar)
                        {
                            Console.Write($"{item} ");
                        }
                        System.Console.WriteLine();
                    }
                }
        } while (repeatInput);
        do
        {
            repeatInput = false;
            Console.Write($"Input password (min {minLength} characters): ");
            password = Console.ReadLine();
            if (!HasRequiredMinLength(password, minLength))
            {
                System.Console.WriteLine($"Password must have at least {minLength} characters. Try again.");
                repeatInput = true;
                continue;
            }
            Console.Write($"Input password for verification: ");
            string password2 = Console.ReadLine();
            if (password != password2)
            {
                repeatInput = true;
                System.Console.WriteLine("Password does not match. Try again.");
            }
        } while (repeatInput);
        codedPassword = EncodePassword(password);

        string managerAndCodedPassword = $"{name};{codedPassword}\n";

        if (ExistsAllManagersFile() && File.ReadAllLines(allManagersPathAndFile)[0].Split(';')[0] == defaultManagerName)
        {
            File.WriteAllText(allManagersPathAndFile, managerAndCodedPassword);
        }
        else if (ExistsAllManagersFile() && File.ReadAllLines(allManagersPathAndFile)[0].Split(';')[0] != defaultManagerName)
        {
            File.AppendAllText(allManagersPathAndFile, managerAndCodedPassword);
            Console.WriteLine($"Sign up of manager {name} successfully completed.");
        }
        else
        {
            System.Console.WriteLine($"Warning: Sign up of manager {name} failed.");
        }
    }
    public static bool HasRequiredMinLength(string text, int minLength)
    {
        if (text.Length >= minLength) return true;
        else return false;
    }
    public static bool ExistsTaskTrackerDirectory()
    {
        if (Directory.Exists(appRootDirectoryPath)) return true;
        return false;
    }
    public static bool ExistsAllUsersFile()
    {
        if (File.Exists(allUsersPathAndFile)) return true;
        return false;
    }
    public static bool ExistsAllManagersFile()
    {
        if (File.Exists(allManagersPathAndFile)) return true;
        return false;
    }
    public static bool ExistsUserNameFile(string userName)
    {
        string userFile = $"{userName}.xml";
        string userPathAndFile = Path.Combine(appRootDirectoryPath, userFile);
        if (File.Exists(userPathAndFile)) return true;
        return false;
    }
    public static bool ExistsUserName(string userName)
    {
        if (!File.Exists(allUsersPathAndFile) || !Directory.Exists(appRootDirectoryPath)) return false;
        foreach (var row in File.ReadAllLines(allUsersPathAndFile))
        {
            var data = row.Split(';');
            if (data.Length >= 1 && data[0] == userName) return true;
        }
        return false;
    }
    public static bool ExistsManagerName(string managerName)
    {
        if (!File.Exists(allManagersPathAndFile) || !Directory.Exists(appRootDirectoryPath)) return false;
        foreach (var row in File.ReadAllLines(allManagersPathAndFile))
        {
            var data = row.Split(';');
            if (data.Length >= 1 && data[0] == managerName) return true;
        }
        return false;
    }
    public static void WaitForEnter()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    public static string PromptTaskFilterType()
    {
        Console.WriteLine("Choose task filter:");
        Console.WriteLine("1) All tasks");
        Console.WriteLine("2) Overdue tasks");
        Console.WriteLine("3) Completed tasks");
        Console.WriteLine("4) Not completed tasks");
        Console.WriteLine("5) High priority tasks");
        Console.Write("Your choice (1-5): ");
        return Console.ReadLine();
    }
    public static Func<Task, bool> GetTaskFilterPredicate(string filterChoice)
    {
        return filterChoice switch
        {
            "1" => t => true, // All tasks
            "2" => t => t.DueDate < DateTime.Today, // Overdue
            "3" => t => t.Completed, // Completed
            "4" => t => !t.Completed, // Not completed
            "5" => t => t.HighPriority, // High priority
            _ => t => true // Default to all if invalid input
        };
    }
}