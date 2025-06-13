using System;

namespace ZaverecnyProjekt.Ukolnicek;

public abstract class GeneralUser
{
    public string Name { get; set; }
    public string Password { get; private set; }
    //public GeneralUser(string? name = null, string? password = null)
    public GeneralUser() { }
    public GeneralUser(string name, string password)
    {
        string encodedPassword = Utils.EncodePassword(password);
        Name = name;
        Password = encodedPassword;
    }

    public virtual void LogOut()
    {
        System.Console.WriteLine("You have been logged out.");
        Utils.WaitForEnter();
    }
}
