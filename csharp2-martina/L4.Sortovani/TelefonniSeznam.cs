using System;

namespace L4.Slovniky;

public class TelefonniSeznam
{
    /* Vytvorte tridu TelefonniSeznam
    - uvnitr ni budete ukladat dvojice Jmeno - Telefonni cislo
    - k tomu pouzijte Dictionary, jehoz klice budou stringy a hodnoty integery
    - v ramci konstruktoru vyplnte nekolik jmen a cisel
    - vytvorte metodu, ktera do slovniku ulozi noveho cloveka a jeho telefonni cislo
    - vytvorte metodu, ktera vrati telefonni cislo cloveka
    - vytvorte metodu, ktera vypise cely telefonni seznam
    - vytvorte metodu, ktera smaze daneho cloveka
    - vytvorte metodu, ktera smaze cely telefonni seznam .Clear()
    - myslete na mozne chybove stavy (co kdyz tam dany clovek neni, co kdyz pridavam cloveka, ktery uz tam je)
    - napiste kratky program, ktery overi funkcnost teto tridy */



    public string Name { get; set; }
    public int Phone { get; set; }
    public Dictionary<string, int> telSeznam = new Dictionary<string, int>
    {
        {"Matej", 605123456},
        {"Ondra", 731567890},
        {"Hana", 737987654}
    };

    public void pridejCloveka(string jmeno, int telefon)
    {
        try
        {
            telSeznam.Add(jmeno, telefon);
        }
        catch
        {
            Console.WriteLine("Nelze přidat.");
        }

    }

    public void vypisTelefon(string jmeno)
    {
        if (telSeznam.TryGetValue(jmeno, out int telefon))
        {
            System.Console.WriteLine($"Telefonni cislo pro {jmeno} je {telefon}");
        }
    }
    public void vypisTelefonniSeznam()
    {
        foreach (string key in telSeznam.Keys)
        {
            System.Console.WriteLine($"Telefonni cislo pro {key} je {telSeznam[key]}");
        }
    }
    public void smazCloveka(string jmeno)
    {
        telSeznam.Remove(jmeno);
    }

    public void smazVsechno()
    {
        telSeznam.Clear();
    }


}
