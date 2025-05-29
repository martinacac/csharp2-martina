namespace L8.AbstraktniTridy.Princezna;

class Program
{
    static void Main(string[] args)
    {
        Human arabela = new Princess();
        Human krason = new Prince();
        Human gandalf = new Wizard();
        List<Human> humans = new List<Human> { arabela, krason, gandalf };

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
