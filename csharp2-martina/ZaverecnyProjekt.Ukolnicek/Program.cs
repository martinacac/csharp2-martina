namespace ZaverecnyProjekt.Ukolnicek;

class Program
{
    static void Main(string[] args)
    {
        GeneralUser loggedUser = new User();
        GeneralUser loggedManager = new Manager();
        string souborUzivatele = "uzivatele.txt";
        do
        {
            if (loggedUser == null && loggedManager == null)
            {
                Console.Clear();
                Console.WriteLine("----------------------");
                Console.WriteLine("TASK TRACKER - Main Menu");
                Console.WriteLine("----------------------");
                Console.WriteLine("1) Log in as User");
                Console.WriteLine("2) Log in as Manager");
                Console.WriteLine("3) Sign up as new User");
                Console.WriteLine("0) End program");
                Console.Write("Your choice (0-3): ");
                string choice = Console.ReadLine();

                //switch (choice)
            }
            else if (loggedUser != null)
            {
                (loggedUser as User).UserMenu();

            }
            else if (loggedManager != null)
            {
                (loggedManager as Manager).ManagerMenu();

            }
        } while (loggedUser == null && loggedManager == null);
    }
}
