namespace L6.Ukol.Knihovna;

class Program
{
    static void Main(string[] args)
    {
        //ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran]

        List<Book> knihovna = new List<Book>();
        knihovna.Add(new Book("Slabikář", "Petr Spisovný", new DateTime(2025, 5, 8), 55));
        knihovna.Add(new Book("Animal Farm", "George Orwell", new DateTime(1945, 08, 17), 112));

        bool chciUkoncitProgram = false;
        do
        {
            Console.WriteLine("Zadej text ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran], např. ADD;Animal Farm;George Orwell;1945-08-17;112");
            Console.WriteLine("Nebo zadej text LIST pro výpis knih dle data vydání");
            Console.WriteLine("Nebo zadej text STATS pro výpis statistik");
            Console.WriteLine("Nebo zadej text FIND;[klíčové slovo] pro hledání v názvu knih");
            Console.WriteLine("Nebo zadej text END pro ukončení programu: ");
            string vstupUzivatele = Console.ReadLine();

            if (vstupUzivatele.Trim().StartsWith("list", StringComparison.OrdinalIgnoreCase))
            {
                Book.ListBooks(knihovna);
            }
            else if (vstupUzivatele.Trim().StartsWith("stats", StringComparison.OrdinalIgnoreCase))
            {
                Book.WriteStats(knihovna);
            }
            else if (vstupUzivatele.Trim().StartsWith("find", StringComparison.OrdinalIgnoreCase))
            {
                Book.FindInTitle(knihovna);
            }
            else if (vstupUzivatele.Trim().StartsWith("end", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Ukončuji program.");
                chciUkoncitProgram = true;
                //return;
            }
            else if (vstupUzivatele.Trim().StartsWith("add", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    string title = Book.GetTitleFromString(vstupUzivatele);
                    string author = Book.GetAuthorFromString(vstupUzivatele);
                    DateTime date = Book.GetDateFromString(vstupUzivatele);
                    int pages = Book.GetPagesCountFromString(vstupUzivatele);

                    knihovna.Add(new Book(title, author, date, pages));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Kniha nebyla přidána. Zadej znovu.");
                }
            }
            else
            {
                Console.WriteLine("Neplatný vstup.");
            }
        } while (!chciUkoncitProgram);
    }
}
