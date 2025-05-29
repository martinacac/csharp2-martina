using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class Uzivatel
{
    public string Jmeno { get; private set; }
    public string Heslo { get; private set; }
    public Uzivatel(string jmeno = "Null", string heslo = "Null")
    {
        Jmeno = jmeno;
        Heslo = heslo;
    }
}
