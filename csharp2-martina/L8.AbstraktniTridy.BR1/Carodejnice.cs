using System;

namespace L8.AbstraktniTridy.BR1;

public class Carodejnice : PohadkovaBytost
{
    public Carodejnice(string jmeno) : base(jmeno) { }
    public override void NapisJakTravisVolnyCas()
    {
        System.Console.WriteLine($"{Jmeno}, čarodějnice. Vařím lekvary.");
    }
}

