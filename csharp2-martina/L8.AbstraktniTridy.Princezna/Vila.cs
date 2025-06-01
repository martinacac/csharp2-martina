using System;

namespace L8.AbstraktniTridy.Princezna;

//public class Vila : DancingHuman, MagicHuman //nelze dědit ze 2 tříd
public class Vila : DancingHuman, IMagicHuman  //: IHuman, IDancingHuman, IMagicHuman 
{
    public override void PredstavSe()
    {
        System.Console.WriteLine("I am Fairy");
    }
    public override void StartDancing()
    {
        System.Console.WriteLine("Fairy is dancing");
    }
    public override void StopDancing()
    {
        System.Console.WriteLine("Fairy is not dancing");
    }
    public void BecomeInvisible() //nedávám sem override if interface
    {
        System.Console.WriteLine("Fairy is not visible");
    }
    public void BecomeVisible()
    {
        System.Console.WriteLine("Fairy is visible");
    }


}
