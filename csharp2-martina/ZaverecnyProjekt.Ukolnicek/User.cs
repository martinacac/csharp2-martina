using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class User : GeneralUser
{
    public string Jmeno { get; private set; }
    public string Heslo { get; private set; }
    public User(string name, string password) : base(name, password)
    {
    }
}
