namespace ZaverecnyProjekt.Ukolnicek;

class Program
{
    static void Main(string[] args)
    {
        Uzivatel prihlasenyUzivatel = new Uzivatel();
        string cestaUzivatele = "uzivatele.txt";
        while (true)
        {
            if (prihlasenyUzivatel == null)
            {
                Console.Clear();
                Console.WriteLine("----------------------");
                Console.WriteLine("Správce úkolů - hlavní menu");
                Console.WriteLine("----------------------");
                Console.WriteLine("1) Registrace");
                Console.WriteLine("2) Přihlášení");
                Console.WriteLine("0) Konec");
                Console.Write("Zadejte volbu: ");
                string volba = Console.ReadLine();

                //switch (volba)
            }
            else
            {
                Utils.MenuUzivatele();
            }

        }
    }
}
