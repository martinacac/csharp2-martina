using System;

namespace L8.AbstraktniTridy.BR1;

public class Princezna : PohadkovaBytost
{
    public Princezna(string jmeno) : base(jmeno) { }
    public override void NapisJakTravisVolnyCas()
    {
        System.Console.WriteLine($"{Jmeno}, princezna. Zkouším si šaty.");
    }
}
