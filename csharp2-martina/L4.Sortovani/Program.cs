namespace L4.Slovniky;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>
        {
            {"car", "auto"},
            {"dog", "pes"},
            {"phone", "telefon"}
        };
        System.Console.WriteLine($"English word dog is in Czech {dict["dog"]}");
        dict.Add("watch", "hodinky");
        dict["cup"] = "pohar"; //jiná možnost přidávání

        if (dict.TryGetValue("dog", out string dogInCzech))
        {
            System.Console.WriteLine($"English word dog is in Czech {dogInCzech}");
        }
        foreach (string key in dict.Keys)
        {
            System.Console.WriteLine($"English word {key} is in Czech {dict[key]}");
        }

        foreach (KeyValuePair<string, string> keyValuePair in dict)
        {
            System.Console.WriteLine($"English word {keyValuePair.Key} is in Czech {keyValuePair.Value}");
        }


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
        TelefonniSeznam telSeznam2 = new TelefonniSeznam();



    }
}
