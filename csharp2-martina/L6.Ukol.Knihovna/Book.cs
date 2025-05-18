using System;
using System.Globalization;

namespace L6.Ukol.Knihovna;

public class Book
{
    /*Vytvořte třídu Book, která bude mít následující vlastnosti:

    Title (string) – název knihy
    Author (string) – autor knihy
    PublishedDate (DateTime) – datum vydání
    Pages (int) – počet stran
    Použijte veřejné vlastnosti, implementuje vlastní gettery/settery tam, kde se to hodí (např. validace, že počet stran je kladné číslo).*/

    public string Title { get; private set; }
    public string Author { get; private set; }
    private DateTime _publishedDate;
    public DateTime PublishedDate
    {
        get { return _publishedDate; }
        set
        {
            if (value > DateTime.Today)
            {
                _publishedDate = DateTime.Today;
            }
            else
            {
                _publishedDate = value;
            }
            //_publishedDate = value > DateTime.Today ? DateTime.Today : value;
        }
    }
    private int _pages;
    public int Pages
    {
        get { return _pages; }
        set
        {
            if (value < 0)
            {
                _pages = 0;
            }
            else
            {
                _pages = value;
            }
            //_pages = value < 0 ? 0 : value;
        }
    }
    // Konstruktor, který inicializuje knihu
    public Book(string title, string author, DateTime publishedDate, int pages)
    {
        Title = title;
        Author = author;
        PublishedDate = publishedDate;
        Pages = pages;
    }

    // Metody pro zpracování vstupního řetězce (vstup uživatele) ve formátu:
    // ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran]
    public static string[] SplitStringAdd(string vstupUzivateleAdd)
    {
        string[] bookStringCasti = vstupUzivateleAdd.Split(';');
        if (bookStringCasti.Length != 5)
        {
            throw new Exception("Nelze načíst knihu. Slovo ADD, název, autor, datum vydání a počet stran musí být odděleny středníkem.");
        }
        return bookStringCasti;
    }
    public static string GetTitleFromString(string vstupUzivateleAdd)
    {
        string bookTitle = SplitStringAdd(vstupUzivateleAdd)[1].Trim();

        if (string.IsNullOrWhiteSpace(bookTitle))
        {
            throw new Exception("Nelze zjistit název knihy.");
        }
        return bookTitle;
    }
    public static string GetAuthorFromString(string vstupUzivateleAdd)
    {
        string bookAuthor = SplitStringAdd(vstupUzivateleAdd)[2].Trim();

        if (string.IsNullOrWhiteSpace(bookAuthor))
        {
            throw new Exception("Nelze zjistit autora knihy.");
        }
        return bookAuthor;
    }
    public static DateTime GetDateFromString(string vstupUzivateleAdd)
    {
        /*DateTime bookDate = new DateTime(0001, 01, 01);

        string[] bookDateStrings = SplitStringAdd(vstupUzivateleAdd)[3].Trim().Split('-');

        bool mamRok = int.TryParse(bookDateStrings[0], out int bookDateYear);
        bool mamMesic = int.TryParse(bookDateStrings[1], out int bookDateMonth);
        bool mamDen = int.TryParse(bookDateStrings[2], out int bookDateDay);

        if (!mamRok || !mamMesic || !mamDen || bookDateYear == 0 || bookDateMonth == 0 || bookDateDay == 0)
        {
            throw new Exception("Nelze zjistit datum vydání.");
        }

        bookDate = new DateTime(bookDateYear, bookDateMonth, bookDateDay);*/

        string datePart = SplitStringAdd(vstupUzivateleAdd)[3].Trim();
        if (!DateTime.TryParseExact(datePart, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime bookDate))
        {
            throw new Exception("Nelze zjistit datum vydání.");
        }
        return bookDate;
    }

    public static int GetPagesCountFromString(string vstupUzivateleAdd)
    {
        int bookPagesCount;

        if (!int.TryParse(SplitStringAdd(vstupUzivateleAdd)[4].Trim(), out bookPagesCount))
        {
            throw new Exception("Nelze zjistit počet stran knihy.");
        }
        return bookPagesCount;
    }
    public static void ListBooks(List<Book> nazevKnihovny)
    {
        //Vypíše všechny knihy, seřazené podle data vydání. Použijte OrderBy
        System.Console.WriteLine("Vypisuji knihy v knihovně (seřazené podle data vydání):");
        foreach (Book book in nazevKnihovny.OrderBy(book => book.PublishedDate))
        {
            Console.WriteLine($"{book.Title} - {book.Author}, datum vydání {book.PublishedDate:yyyy-MM-dd}, {book.Pages} stran");
        }
    }
    public static void WriteStats(List<Book> nazevKnihovny)
    {
        /*Přehled statistik vypíše:
            Průměrný počet stran (použijte Select a Average)
            Počet knih od každého autora (použijte GroupBy)
            Počet unikatních slov v názvech knih. Použijte SelectMany a rozdělení názvů podle mezer (interpunkci vynechte) pro vytvoření jednoho seznamu všech slov, pak použijte Distinct*/
        System.Console.WriteLine("Vypisuji statistiky:");
        if (!nazevKnihovny.Any())
        {
            Console.WriteLine("Knihovna je prázdná.");
            return;
        }
        // Průměrný počet stran
        double avgPages = nazevKnihovny.Select(book => book.Pages).Average();
        Console.WriteLine($"Průměrný počet stran: {avgPages:N2}"); //formátovací řetězec N2 „numeric format specifier“ - hodnota avgPages bude převedena na řetězec s dvěma desetinnými místy (jako F2) a navíc s oddělovači tisíců
                                                                   // Počet knih od každého autora
        var booksByAuthor = nazevKnihovny.GroupBy(book => book.Author)
                                .Select(group => new { Author = group.Key, Count = group.Count() });
        foreach (var group in booksByAuthor)
        {
            Console.WriteLine($"Autor {group.Author}: {group.Count} knih");
        }
        // Počet unikátních slov v názvech knih
        var uniqueWords = nazevKnihovny
            .SelectMany(book => book.Title.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries))
            .Select(word => word.ToLower())
            .Distinct();
        Console.WriteLine($"Počet unikátních slov v názvech: {uniqueWords.Count()}");
    }
    public static void FindInTitle(List<Book> nazevKnihovny)
    {
        //Vyhledá knihy, jejichž název obsahuje zadané slovo, bez ohledu na velikost písmen (použijte Where).
        Console.Write("Zadejte klíčové slovo pro hledání v názvu knihy: ");
        string keyword = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Klíčové slovo nesmí být prázdné.");
            return;
        }
        System.Console.WriteLine("Vypisuji knihy obsahující zadané slovo v jejich názvu:");
        var foundBooks = nazevKnihovny.Where(book => book.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        if (!foundBooks.Any())
        {
            Console.WriteLine("Nebyla nalezena žádná kniha s tímto klíčovým slovem.");
        }
        else
        {
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"{book.Title} - {book.Author}, datum vydání {book.PublishedDate:yyyy-MM-dd}, {book.Pages} stran");
            }
        }
    }
}
