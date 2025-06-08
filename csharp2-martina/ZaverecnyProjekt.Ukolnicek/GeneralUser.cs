using System;

namespace ZaverecnyProjekt.Ukolnicek;

public abstract class GeneralUser
{
    public string Name { get; set; }
    public string Password { get; private set; }
    public GeneralUser(string name = "Null", string password = "Null")
    {
        string encodedPassword = Utils.EncodePassword(password);
        Name = name;
        Password = encodedPassword;
    }


    public void LogOut()
    {
        System.Console.WriteLine("Toto se ještě musí dodělat.");
    }
}
