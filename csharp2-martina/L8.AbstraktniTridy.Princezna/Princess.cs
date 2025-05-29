using System;

namespace L8.AbstraktniTridy.Princezna;

public class Princess : DancingHuman
{

    public override void StartDancing()
    {
        System.Console.WriteLine("I am a dancing prince.");
    }
    public override void StopDancing()
    {
        System.Console.WriteLine("I am not a dancing prince.");
    }
}

