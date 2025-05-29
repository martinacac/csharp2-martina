using System;

namespace L8.AbstraktniTridy.Princezna;

public class Prince : DancingHuman
{

    public override void PredstavSe()
    {
        System.Console.WriteLine("Jsem princ.");
    }
    public override void StartDancing()
    {
        System.Console.WriteLine("I am a dancing prince.");
    }
    public override void StopDancing()
    {
        System.Console.WriteLine("I am not a dancing prince.");
    }

}
