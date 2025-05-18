using System.Data;

namespace L6.Opakovani.Obdelnik;

class Obdelnik
{
    private int Sirka;
    private int Vyska;
    public Obdelnik(int sirka, int vyska)
    {
        Sirka = sirka;
        Vyska = vyska;
    }
    public Obdelnik(int strana) : this(strana, strana)
    { }
    public void VypisParameteryObdelniku()
    {
        System.Console.WriteLine($"sirka: {Sirka}, vyska: {Vyska}");
    }

}
class Program
{
    static void Main(string[] args)
    {
        // BREAKOUT ROOM 1
        //  Vytvoř třídu Obdelnik (tak, aby byla v samostatnem souboru Obdelnik.cs), která bude mít dva fieldy: Sirka a Vyska.
        //  Vytvoř konstruktor třídy Obdelnik s parametry sirka a vyska.
        //  Přidej do třídy ještě jeden typ konstruktoru pro speciální případ obdelníku(čtverec) s jedním parametrem, který bude volat první konstruktor.
        //  Obdelniku vytvorte funkci Vypis informace, ktery vypise vysku a sirku.
        //  Vytvoř několik instancí třídy Obdelnik (například 2) a vypiš jejich vlastnosti pomoci metody VypisParameteryObdelniku.

        Obdelnik obd1 = new Obdelnik(5);
        Obdelnik obd2 = new Obdelnik(5, 7);
        obd1.VypisParameteryObdelniku();
        obd2.VypisParameteryObdelniku();

        
    }
}
