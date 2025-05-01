namespace L4.List;

class Program
{
    static void Main(string[] args)
    {
        List<double> cisla = new List<double>
        {
            0.046939913,
            0.295866297,
            0.852489925,
            0.84994766,
            0.96925183,
            0.946275497,
            0.688903175,
            0.553463564,
            0.59628254,
            0.645816929
        };

        // Vypis vsechna cisla na konzoli (nachystej si pro to funkci)
        Vypis(cisla);

        System.Console.WriteLine("výpis bez metody:");
        foreach (double cislo in cisla)
        {
            System.Console.WriteLine(cislo);
        }

        // Vypis na konzoli pocet cisel v seznamu
        VypisPocet(cisla);

        System.Console.WriteLine("výpis bez metody:");
        System.Console.WriteLine($"Pocet cisel: {cisla.Count}");

        // Pridej cislo 0.5 do seznamu
        cisla.Add(0.5);

        // vypis prvni cislo ze seznamu, ktere je vetsi nez 0.8
        double pozadovaneCislo = cisla.Find(c => c > 0.8);
        System.Console.WriteLine(pozadovaneCislo);

        // najdi nejvetsi cislo v seznamu, vypis, ktere to je, a odstran ho ze seznamu
        double maxCislo = cisla.Max();
        cisla.Remove(maxCislo);

        // vypis opet vsechna cisla a jejich pocet
        Vypis(cisla);
        VypisPocet(cisla);

        //součet všech čísel
        Console.WriteLine($"soucet: {cisla.Sum()}");

    }

    public static void Vypis(List<double> doublesList)
    {
        foreach (var cislo in doublesList)
        {
            System.Console.WriteLine(cislo);
        }
    }

    public static void VypisPocet(List<double> doublesList)
    {

        System.Console.WriteLine($"Pocet cisel: {doublesList.Count}");

    }
}
