namespace testovaci;

class Program
{
    static void Main(string[] args)
    {
        string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        Console.WriteLine(myDocumentsPath);
        int index = 1;
        System.Console.WriteLine(index++);
        System.Console.WriteLine(index++);
    }
}
