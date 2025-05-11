using System;

namespace L4.Ukol.PlanovacUdalosti;

public class Event
{

    //Vytvořte třídu Event, která bude uchovávat informace o události (jméno a datum).
    public string JmenoUdalosti;
    public DateTime DatumUdalosti;
    public Event(string jmenoUdalosti, DateTime datumUdalosti)
    {
        JmenoUdalosti = jmenoUdalosti;
        DatumUdalosti = datumUdalosti;
    }

    public static string[] NactiEvent(string eventNameDate)
    {
        string[] eventCasti = eventNameDate.Split(';');
        if (eventCasti.Count() != 3)
        {
            throw new Exception("Nelze načíst událost. Slovo EVENT, název a datum události musí být odděleny středníkem.");
        }
        return eventCasti;
    }
    public static string NactiEventName(string eventNameDate)
    {
        string eventName = NactiEvent(eventNameDate)[1].Trim();

        if (string.IsNullOrWhiteSpace(eventName))
        {
            throw new Exception("Nelze zjistit název události.");
        }
        return eventName;

    }
    public static DateTime NactiEventDate(string eventNameDate)
    {
        DateTime eventDate = new DateTime(0001, 01, 01);

        string[] eventDateStrings = NactiEvent(eventNameDate)[2].Trim().Split('-');

        bool mamRok = int.TryParse(eventDateStrings[0], out int eventDateYear);
        bool mamMesic = int.TryParse(eventDateStrings[1], out int eventDateMonth);
        bool mamDen = int.TryParse(eventDateStrings[2], out int eventDateDay);

        if (!mamRok || !mamMesic || !mamDen || eventDateYear == 0 || eventDateMonth == 0 || eventDateDay == 0)
        {
            throw new Exception("Nelze zjistit datum události.");
        }

        eventDate = new DateTime(eventDateYear, eventDateMonth, eventDateDay);
        //DateTime.TryParseExact(eventDateString, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime eventDate);

        return eventDate;
    }
    public static void VypisEvents(List<Event> events)
    {
        //Vypište všechny uložené akce. Pro každou akci vypište její jméno, datum a počet dní do konání akce (pozor na akce, které již proběhly). 
        int i = 0;
        int j = 0;
        foreach (Event ev in events)
        {
            if ((ev.DatumUdalosti - DateTime.Now).Days < 0)
            {

                if (i == 0)
                {
                    Console.WriteLine("Již proběhlé akce: ");
                    i++;
                }
                Console.WriteLine($"Event {ev.JmenoUdalosti} with date {ev.DatumUdalosti} happened before {(ev.DatumUdalosti - DateTime.Now).Days} days");
            }
        }
        foreach (Event ev in events)
        {
            if ((ev.DatumUdalosti - DateTime.Now).Days >= 0)
            {
                if (j == 0)
                {
                    Console.WriteLine("Nastávající akce: ");
                    j++;
                }
                Console.WriteLine($"Event {ev.JmenoUdalosti} with date {ev.DatumUdalosti} will happen in {(ev.DatumUdalosti - DateTime.Now).Days} days");
            }
        }
    }
    public static void VypisStats(Dictionary<DateTime, int> eventsDictionary, List<Event> events)
    {
        //Ke každému datu vypište počet událostí, které se konají v daný den. 
        int pocetUdalosti;

        foreach (Event ev in events)
        {
            if (eventsDictionary.TryGetValue(ev.DatumUdalosti, out pocetUdalosti))
            {
                eventsDictionary.Remove(ev.DatumUdalosti);
                eventsDictionary.Add(ev.DatumUdalosti, pocetUdalosti + 1);
                pocetUdalosti = 0;
            }
            else
            {
                eventsDictionary.Add(ev.DatumUdalosti, 1);
            }
        }
        foreach (var keyValuePair in eventsDictionary)
        {
            Console.WriteLine($"Date: {keyValuePair.Key}...events: {keyValuePair.Value}");
        }
    }

}
