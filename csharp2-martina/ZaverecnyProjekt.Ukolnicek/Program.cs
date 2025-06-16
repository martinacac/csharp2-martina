using System.Security.Cryptography.X509Certificates;

namespace ZaverecnyProjekt.Ukolnicek;

class Program
{
    static void Main(string[] args)
    {
        User? loggedUser = null;
        Manager? loggedManager = null;
        if (!Utils.ExistsTaskTrackerDirectory()) Directory.CreateDirectory(Utils.appRootDirectoryPath);
        if (!Utils.ExistsAllUsersFile()) File.Create(Utils.allUsersPathAndFile).Close();
        if (!Utils.ExistsAllManagersFile())
        {
            string managerAndCodedPassword = $"{Utils.defaultManagerName};{Utils.EncodePassword(Utils.defaultManagerPassword)}\n";
            File.WriteAllText(Utils.allManagersPathAndFile, managerAndCodedPassword);
        }

        do
        {
            if (loggedUser == null && loggedManager == null)
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("TASK TRACKER - Main Menu");
                Console.WriteLine("========================");
                Console.WriteLine("1) Log in as User");
                Console.WriteLine("2) Log in as Manager");
                Console.WriteLine("3) Sign up as new User");
                Console.WriteLine("4) Log out");
                Console.WriteLine("0) End program");
                Console.WriteLine("------------------------");
                Console.Write("Your choice (0-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            loggedManager = null;
                            loggedUser = Utils.LogInUser();
                            break;
                        }
                    case "2":
                        {
                            loggedUser = null;
                            loggedManager = Utils.LogInManager();
                            break;
                        }
                    case "3":
                        {
                            Utils.SignUpUser();
                            break;
                        }
                    case "4":
                        {
                            if (loggedUser != null) loggedUser.LogOut(); //inherited from GeneralUser
                            else if (loggedManager != null) loggedManager.LogOut();
                            else
                            {
                                System.Console.WriteLine("Logout successful.");
                                Utils.WaitForEnter();
                            }
                            break;
                        }
                    case "0":
                        {
                            System.Console.WriteLine("Ending program.");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
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
                loggedUser = null;

            }
            else if (loggedManager != null)
            {
                loggedManager.ManagerMenu();
                loggedManager = null;
            }
        } while (true);
    }
}
