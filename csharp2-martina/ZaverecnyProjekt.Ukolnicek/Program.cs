using System.Security.Cryptography.X509Certificates;

namespace ZaverecnyProjekt.Ukolnicek;

class Program
{
    static void Main(string[] args)
    {
        User loggedUser = new User();
        Manager loggedManager = new Manager();
        if (!Utils.ExistsDirectory()) Directory.CreateDirectory(Utils.pathToDirectory);
        if (!Utils.ExistsAllUsersFile()) File.Create(Utils.allUsersPathAndFile).Close();

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
                            Utils.SignUpUser();
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
                loggedUser.UserMenu();

            }
            else if (loggedManager != null)
            {
                loggedManager.ManagerMenu();
            }
        } while (true);
    }
}
