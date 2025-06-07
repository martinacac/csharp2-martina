namespace L9.TextSoubory.BR1.TelSeznam;

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;



public class Clovek
{
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    public int TelCislo { get; set; }

    public Clovek(string jmeno, string prijmeni, int telCislo)
    {
        Jmeno = jmeno;
        Prijmeni = prijmeni;
        TelCislo = telCislo;
    }
}

public class TelefonniSeznam
{
    public List<Clovek> Lide { get; set; } = new List<Clovek>();

}

public class Program
{
    public static void Main()
    {
        var telefonniSeznam = new TelefonniSeznam
        {
            Lide = new List<Clovek>
            {
                new Clovek("Jarda", "Kadlec", 777123456),
                new Clovek("Honza", "Kratochvila", 777987654),
                new Clovek("Petr", "Novak", 778111222)
            }
        };

        //nebo varianta bez class TelefonniSeznam:
        List<Clovek> telefonniSeznam2 = new List<Clovek>
        {
                new Clovek("Jarda", "Kadlec", 777123456),
                new Clovek("Honza", "Kratochvila", 777987654),
                new Clovek("Petr", "Novak", 778111222)

        };
        //1. Vytvorte slozku TelefonniSeznam v adresari Appdata pro konkretniho uzivatele
        //2. Do souboru telefonniSeznam.csv ulozte obsah seznamu telefonniSeznam tak,
        //   ze kazdy zaznam bude na jednom radku a oddelene budou carkami
        //3. Napiste cyklus, ktery soubor precte a zpatky ho ulozi do noveho seznamu

        // 1. Vytvoření složky v AppData
        string adresar = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TelefonniSeznam");
        Console.WriteLine(adresar);
        Directory.CreateDirectory(adresar);

        // 2. Uložení do CSV pomocí LINQ Select
        string soubor = Path.Combine(adresar, "TelefonniSeznam.csv");
        var radky = telefonniSeznam.Lide.Select(clovek => $"{clovek.Jmeno}, {clovek.Prijmeni}, {clovek.TelCislo}"); //odděluji pomocí ,
        // var radky2 = telefonniSeznam2.Select(clovek => $"{clovek.Jmeno}, {clovek.Prijmeni}, {clovek.TelCislo}"); 
        File.AppendAllLines(soubor, radky);

        // 3. Čtení ze souboru
        if (File.Exists(soubor))
        {
            var nacteneZeSouboru = File.ReadAllLines(soubor);
            foreach (var radek in nacteneZeSouboru)
            {
                System.Console.WriteLine(radek);
            }
        }
        else
        {
            System.Console.WriteLine("Soubor nenalezen.");
        }
    }
}

