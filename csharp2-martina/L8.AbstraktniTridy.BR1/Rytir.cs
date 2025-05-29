using System;

namespace L8.AbstraktniTridy.BR1;

public class Rytir : PohadkovaBytost
{
    public Rytir(string jmeno) : base(jmeno) { }
    public override void NapisJakTravisVolnyCas()
    {
        System.Console.WriteLine($"{Jmeno}, rytíř. Chodím na turnaje.");
    }
}
