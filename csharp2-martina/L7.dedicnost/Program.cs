using L7.dedicnost;

namespace L7.dedicnost;

class Program
{
    public abstract class Zvire //base class for all animals
    {
        public string Jmeno { get; set; }
        public string Zvuk { get; set; }
        public Zvire(string jmeno, string zvuk)
        {
            Jmeno = jmeno;
            Zvuk = zvuk;
        }
        public virtual void VydavejZvuk()
        {
            System.Console.WriteLine(Zvuk);
        }
    }
    public class Kocka : Zvire
    {
        public Kocka(string name, string zvuk) : base(name, zvuk)
        {
        }
        public override void VydavejZvuk()
        {
            base.VydavejZvuk();
            System.Console.WriteLine($"Jsem kočka.");
        }
    }
    public class Pes : Zvire
    {
        public Pes(string name, string zvuk) : base(name, zvuk)
        {
        }
    }
    static void Main(string[] args)
    {
        //navrhnete vhodnou strukturu trid, ktera umozni v programu (v Mainu) vytvorit seznam zviratek v zoo koutku (List), 
        //ktery pak muzeme jednoduse projit cyklem (foreach) a zadat kazdemu z nich prikaz VydavejZvuk
        //pritom kazde zviratko bude vydavat jiny zvuk (vypise na konzoli Haf, haf nebo Mnau, mnau)
        //v ramci cyklu nechci resit, jake konkretni zviratko to je
        //vytvorte alespon 3 ruzna zviratka
        //hint: budete potrebovat vhodnou bazovou tridu a virtual/abstract a override

        Pes pes = new Pes("Hafik", "Haf haf!");
        Kocka kocka = new Kocka("Micka", "Mnau mnau!");
        List<Zvire> zoo = new List<Zvire>();
        zoo.Add(pes);
        zoo.Add(kocka);

        foreach (Zvire zviratko in zoo)
        {
            zviratko.VydavejZvuk();
        }
    }
}
