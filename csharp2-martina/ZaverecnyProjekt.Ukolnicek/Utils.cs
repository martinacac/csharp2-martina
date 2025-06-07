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

    static string EncodePassword(string password)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
    }

    static string DecodePassword(string codedPassword)
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
            if (data[0] == name && data[1] == codedPassword)
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

        Console.Write("Input manager name: ");
        string name = Console.ReadLine();
        Console.Write("Input password: ");
        string password = Console.ReadLine();
        string codedPassword = EncodePassword(password);

        if (!File.Exists(allManagersPathAndFile) || !Directory.Exists(pathToDirectory))
        {
            Console.WriteLine("No registered managers found.");
            Console.ReadKey();
            return null;
        }

        foreach (var row in File.ReadAllLines(allManagersFile))
        {
            var data = row.Split(';');
            if (data[0] == name && data[1] == codedPassword)
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
    /*public static void MenuUzivatele()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("1) Přidat úkol");
            Console.WriteLine("2) Vypsat úkoly");
            Console.WriteLine("3) Smazat úkol");
            Console.WriteLine("4) Odhlásit se");
            Console.WriteLine("5) Označit úkol jako splněný");
            Console.WriteLine("6) Hledat úkol");
            Console.WriteLine("7) Uložit úkoly");
            Console.WriteLine("8) Načíst úkoly");
            Console.Write("Zadejte volbu: ");
            string volba = Console.ReadLine();

            //switch (volba)
        }
    }
    public static void Registrace()
    {

    }
    public static void Prihlaseni()
    {

    }

    public static void PridatUkol()
    {

    }
    public static void VypsatUkoly()
    {

    }
    public static void SmazatUkol()
    {

    }
    public static void OznacitUkolJakoSplneny()
    {

    }
    public static void HledatUkol()
    {

    }
    public static void UlozitUkolyUzivatele(string jmeno, List<Task> ukoly)
    {

    }
    public static List<Task> NacistUkolyUzivatele(string jmeno)
    {

    }*/
}
