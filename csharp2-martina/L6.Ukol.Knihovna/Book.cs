using System;

namespace L6.Ukol.Book;

public class Book
{
    /*Vytvořte třídu Book, která bude mít následující vlastnosti:

    Title (string) – název knihy
    Author (string) – autor knihy
    PublishedDate (DateTime) – datum vydání
    Pages (int) – počet stran
    Použijte veřejné vlastnosti, implementuje vlastní gettery/settery tam, kde se to hodí (např. validace, že počet stran je kladné číslo).*/

    public string Title { get; }
    public string Author { get; }
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
        }

    }


}
