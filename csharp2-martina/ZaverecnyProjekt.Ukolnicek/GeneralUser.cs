using System;

namespace ZaverecnyProjekt.Ukolnicek;

public abstract class GeneralUser
{
    public string Name { get; private set; }
    public string Password { get; private set; }
    public GeneralUser(string name = "Null", string password = "Null")
    {
        Name = name;
        Password = password;
    }
    public void ListTasks()
    {

    }
    public void FindTasks()
    {

    }
    public void LogOut()
    {

    }
}
