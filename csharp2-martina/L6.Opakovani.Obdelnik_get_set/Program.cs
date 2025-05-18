using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace L6.Opakovani.Obdelnik_get_set;

class Obdelnik
{
    /* Vyuzij tridu Obdelnik z prvniho BR.
               Prepis fieldy Sirka a Vyska na properties.
               Nastavte properties tak, aby je nebylo mozne zmenit po vytvoreni instance.  
               Vytvorte property Obsah, ktera umozni ziskat obsah obdelniku.
               Vytvorte property Obvod, ktera umozni ziskat obvod obdelniku.
               Vytvorte funkci Zvetsi, ktera zvetsi obdelnik o sirku a vysku.
               Zajistete, aby nebylo mozne vytvorit obdelnik o obsahu 0 (vypiste hlasku a nastavte hodnotu na 1).
               Napiste program, ktery vytvori obdelnik, vypise jeho velikosti, obsah a obvod.
            */
    // Prepis fieldy Sirka a Vyska na properties.
    public int Sirka { get; private set; } //if private set; mohu měnit pomocí metody, if vynechám set úplně, nemůžu po prvotním nastavení měnit
    public int Vyska { get; private set; } //ak je to bez set -> dá sa to nastaviť iba raz a nemohli by sme spraviť funkciu Zvetsi
    private int _obsah; //field 
    private int _obvod; //field 
    public int Obsah //property
    {
        //get {return Sirka * Vyska; }
        get { return _obsah; }
    }
    public int Obvod //property
    {
        get { return _obvod; }
    }
    public Obdelnik(int sirka, int vyska)
    {
        if (sirka <= 0)
        {
            Console.WriteLine($"Toto: '{sirka}' je zla hodnota sirky ejj !");
            sirka = 1;
        }

        if (vyska <= 0)
        {
            Console.WriteLine($"Toto: '{vyska}' je spatna hodnota vysky ejj !");
            vyska = 1;
        }
        Sirka = sirka;
        Vyska = vyska;
        _obsah = sirka * vyska;
        _obvod = 2 * (Sirka + Vyska);
    }
    public Obdelnik(int strana) : this(strana, strana)
    { }
    public void VypisParameteryObdelniku()
    {
        Console.WriteLine($"Obdelnik ma rozmer {Sirka} x {Vyska} metrov.");
        Console.WriteLine("Obsah je " + Obsah + " metrov.");
        Console.WriteLine("Obvod je " + Obvod + " metrov.");
        Console.WriteLine("----------------------------");
    }
    public void Zvetsi(int doSirky, int doVysky) //nelze if nemám private set;
    {
        Console.WriteLine("Zvecsujem obdelnik ... ");
        Sirka += doSirky;
        Vyska += doVysky;
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
        //obd1.Sirka = 2; nelze protože mám private set
        obd1.Zvetsi(2, 2);
        obd1.VypisParameteryObdelniku();

        System.Console.WriteLine(obd1.Obsah);
        Console.WriteLine("----------------------------");

        // TEST zle zadaných vstupov 
        Obdelnik zlyObdelnik = new Obdelnik(-1);
        zlyObdelnik.VypisParameteryObdelniku();


    }
}
