namespace L8.AbstraktniTridy.Princezna;

class Program
{
    static void Main(string[] args)
    {
        Human arabela = new Princess(); //public class Princess : DancingHuman   public abstract class DancingHuman : Human => IHuman arabela = new Princess()
        Human krason = new Prince(); //public class Prince : DancingHuman => IHuman krason = new Prince()
        Human gandalf = new Wizard(); //public class Wizard : MagicHuman   public abstract class MagicHuman : Human => IHuman gandalf = new Wizard()
        List<Human> humans = new List<Human> { arabela, krason, gandalf }; //List<IHuman>

        foreach (Human human in humans)
        {
            human.PredstavSe();
        }

        foreach (DancingHuman dancingHuman in humans.OfType<DancingHuman>())
        {
            dancingHuman.StartDancing();
            dancingHuman.StopDancing();
        }

        //gandalf.BecomeInvisible() //nelze protože gandalf je typu Human a ne MagicHuman - nutno přetypovat
        ((MagicHuman)gandalf).BecomeInvisible();
        (gandalf as MagicHuman).BecomeInvisible();

    }
}
