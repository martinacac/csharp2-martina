using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class Manager : GeneralUser
{
    public string Jmeno { get; private set; }
    public string Heslo { get; private set; }
    public Manager(string name, string password) : base(name, password)
    {
    }
}