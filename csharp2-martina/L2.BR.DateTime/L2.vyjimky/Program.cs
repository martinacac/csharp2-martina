namespace L2.vyjimky;

class Program
{
    static void Main(string[] args)
    {
        //ziskej 2 cisla a podel je
        int cislo1; //proměnné je třeba definovat mimo try, abych s nimi mohla pracovat i mimo try
        int cislo2;
        try
        {
            Console.WriteLine("zadej prvni cislo: ");
            string input = Console.ReadLine();
            cislo1 = int.Parse(input);
            Console.WriteLine("zadej druhe cislo: ");
            input = Console.ReadLine();
            cislo2 = int.Parse(input);
        }
        catch (FormatException exception)
        {
            Console.WriteLine(exception.Message);
            Console.WriteLine("user input was not number, program will be terminated.");
            Console.ReadLine();
            return;
        }
        catch (Exception exception) //catch samotný stačí por obecnou výjimku, pokud nepotřebuji exception.Message
        {
            Console.WriteLine(exception.Message);
            Console.WriteLine("Wrong user input, program will be terminated.");
            Console.ReadLine();
            return;
        }
        Console.WriteLine($"result is: {cislo1 / cislo2}");

    }
}
