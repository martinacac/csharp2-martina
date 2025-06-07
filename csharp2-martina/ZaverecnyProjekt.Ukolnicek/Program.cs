using System.Security.Cryptography.X509Certificates;

namespace ZaverecnyProjekt.Ukolnicek;

class Program
{
    //public string souborUzivatele = "uzivatele.txt";
    static void Main(string[] args)
    {
        GeneralUser loggedUser = new User();
        GeneralUser loggedManager = new Manager();

        do
        {
            if (loggedUser == null && loggedManager == null)
            {
                Console.Clear();
                Console.WriteLine("------------------------");
                Console.WriteLine("TASK TRACKER - Main Menu");
                Console.WriteLine("------------------------");
                Console.WriteLine("1) Log in as User");
                Console.WriteLine("2) Log in as Manager");
                Console.WriteLine("3) Sign up as new User");
                Console.WriteLine("0) End program");
                Console.Write("Your choice (0-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            loggedUser = Utils.LogInUser();
                            break;
                        }
                    case "2":
                        {
                            loggedManager = Utils.LogInManager();
                            break;
                        }
                    case "3":
                        {
                            System.Console.WriteLine("To zatím neumím.");
                            break;
                        }
                    case "0":
                        {
                            System.Console.WriteLine("Ukončuji program.");
                            return;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid input. Try again.");
                            break;
                        }
                }
            }
            else if (loggedUser != null)
            {
                (loggedUser as User).UserMenu();

            }
            else if (loggedManager != null)
            {
                (loggedManager as Manager).ManagerMenu();
            }
        } while (true);
    }
}
