namespace testovaci;

class Program
{
    static void Main(string[] args)
    {
        string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        // Console.WriteLine(myDocumentsPath);
        // int index = 1;
        // System.Console.WriteLine(index++);
        // System.Console.WriteLine(index++);
        // char[] invalidFileNameChar = { '\\', '|', '/', ':', '<', '>', '*', '?', '"' };
        // System.Console.Write($"User name must not contain characters: ");
        // foreach (char item in invalidFileNameChar)
        // {
        //     Console.Write($"{item} ");
        // }
        // System.Console.WriteLine();

        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string pathToDirectory = Path.Combine(appDataPath, "TaskTracker");
        System.Console.WriteLine(pathToDirectory);
        Console.ReadKey();
        string allUsersFile = "users.txt";
        string allManagersFile = "managers.txt";
        string allUsersPathAndFile = Path.Combine(pathToDirectory, allUsersFile);
        string allManagersPathAndFile = Path.Combine(pathToDirectory, allManagersFile);
        string name = "Petr2";
        string password = "petr2";
        string userFile = $"{name}.xml";
        string userPathAndFile = Path.Combine(pathToDirectory, userFile);
        System.Console.WriteLine(userPathAndFile);
        //System.Console.WriteLine($"{name}.txt");

        //string userPathAndFile = Path.Combine(pathToDirectory, userFile);
        //public static string userAndCodedPassword = $"{name};{password}\n";
        //File.AppendAllText(pathToDirectory, userAndCodedPassword);

        string userAndCodedPassword = $"{name};{password}\n";
        //Directory.CreateDirectory(pathToDirectory);
        //File.Create(allUsersPathAndFile).Close();
        File.AppendAllText(allUsersPathAndFile, userAndCodedPassword);
        //File.AppendAllText(cestaUzivatele, $"{jmeno};{sifrovaneHeslo}\n");
        File.Create(userPathAndFile).Close();
        Console.WriteLine("Registrace úspěšná.");
    }
}
