using System;

namespace ZaverecnyProjekt.Ukolnicek;

public abstract class GeneralUser
{
    public string Name { get; set; }
    public string Password { get; private set; }
    public GeneralUser(string name = "Null", string password = "Null")
    {
        Name = name;
        Password = password;
    }
    
    
    public void LogOut()
    {
        System.Console.WriteLine("Toto se ještě musí dodělat.");
    }
}
