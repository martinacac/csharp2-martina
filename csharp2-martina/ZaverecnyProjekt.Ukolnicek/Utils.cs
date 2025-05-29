using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class Utils
{
    public static void MenuUzivatele()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("1) Přidat úkol");
            Console.WriteLine("2) Vypsat úkoly");
            Console.WriteLine("3) Smazat úkol");
            Console.WriteLine("4) Odhlásit se");
            Console.WriteLine("5) Označit úkol jako splněný");
            Console.WriteLine("6) Hledat úkol");
            Console.WriteLine("7) Uložit úkoly");
            Console.WriteLine("8) Načíst úkoly");
            Console.Write("Zadejte volbu: ");
            string volba = Console.ReadLine();

            //switch (volba)
        }
    }
    public static void Registrace()
    {

    }
    public static void Prihlaseni()
    {

    }

    public static void PridatUkol()
    {

    }
    public static void VypsatUkoly()
    {

    }
    public static void SmazatUkol()
    {

    }
    public static void OznacitUkolJakoSplneny()
    {

    }
    public static void HledatUkol()
    {

    }
    public static void UlozitUkolyUzivatele(string jmeno, List<Ukol> ukoly)
    {

    }
    public static List<Ukol> NacistUkolyUzivatele(string jmeno)
    {

    }
}
