namespace L2.BR.DATETIME;

class Program
{
    static void Main(string[] args)
    {

        // Zbyvajici dny do dovolene
        // Postupne se uzivatele zeptej na den, mesic a rok odjezdu na dovolenou. Pomoci DateTime a TimeSpan vypocitej pocet
        // zbyvajicich dni do odjezdu na dovolenou a vypis je na konzoli.
        // Pozn.: pro zjednoduseni staci pouzit int.Parse

        Console.WriteLine("Zadej den odjezdu na dovolenou:");
        string vstup = Console.ReadLine();
        int den = int.Parse(vstup);

        Console.WriteLine("Zadej mesic odjezdu na dovolenou:");
        vstup = Console.ReadLine();
        int mesic = int.Parse(vstup);
        //int mesic;
        //int.TryParse(vstup, out mesic);

        Console.WriteLine("Zadej rok odjezdu na dovolenou:");
        vstup = Console.ReadLine();
        int rok = int.Parse(vstup);

        DateTime odjezd = new DateTime(rok, mesic, den);

        TimeSpan pocetDniDoOdjezdu = odjezd - DateTime.Now;

        Console.WriteLine($"Do odjezdu  zbyva {pocetDniDoOdjezdu.Days} dni.");
        






    }
}
