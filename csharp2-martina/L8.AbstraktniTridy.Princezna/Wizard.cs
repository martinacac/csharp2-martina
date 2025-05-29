using System;

namespace L8.AbstraktniTridy.Princezna;

public class Wizard : MagicHuman
{
    public override PredstavSe()
    {
        System.Console.WriteLine("I am wizard!");
    }
    public override void BecomeInvisible()
    {
        System.Console.WriteLine("I am an invible wizard.");
    }
    public override void BecomeVisible()
    {
        System.Console.WriteLine("I am a vible wizard.");
    }
}
