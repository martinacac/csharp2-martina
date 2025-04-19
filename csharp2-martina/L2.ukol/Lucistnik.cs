using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace L2.ukol;

public class Lucistnik
{
    // Definujte public třídu Lucistnik.
    // Vlastnosti: Třída by měla uchovávat informace o lučištníkovi: Jmeno, PocetSipu

    private string Jmeno { get; set; }

    public int PocetSipu { get; set; }

    //Konstruktor: Vytvořte konstruktor (public Lucistnik(...)), který při vytváření instance lučištníka nastaví jeho Jmeno a počáteční PocetSipu podle předaných argumentů.
    public Lucistnik(string jmeno, int pocetSipu)
    {
        Jmeno = jmeno;
        PocetSipu = pocetSipu;
    }
    //Implementujte public void metodu Vystrel.
    //Co má dělat: Pokud má lučištník dostatek šípů, sníží jejich počet o jeden a vypíše zprávu o úspěšném výstřelu. Pokud šípy nemá, vypíše odpovídající zprávu.
    public void Vystrel()
    {
        if (PocetSipu > 0)
        {
            System.Console.WriteLine("Vystřelil jsem.");
            PocetSipu--;
        }
        else
        {
            System.Console.WriteLine("Nemám šípy.");
        }
    }
    //Implementujte public void metodu PridejSipy, která přijímá počet šípů k přidání.
    //Co má dělat: Zvýší lučištníkovi PocetSipu o zadaný pocet (mělo by fungovat jen pro kladný počet). Vypíše zprávu o výsledku akce.

    public void PridejSipy(int pocet)
    {
        if (pocet > 0)
        {
            PocetSipu = PocetSipu + pocet;
            System.Console.WriteLine($"Přidal jsem {pocet} šípů a mám jich celkem {PocetSipu}.");
        }
        else
        {
            System.Console.WriteLine("Šípy nebyly přidány.");
        }
    }
    //Implementujte public void metodu ZobrazStav.
    //Co má dělat: Vypíše na konzoli aktuální jméno lučištníka a jeho počet šípů.
    public void ZobrazStav()
    {
        System.Console.WriteLine($"Jsem lučištník {Jmeno} a mám {PocetSipu} šípů.");
    }
}
