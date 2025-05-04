using System.Globalization;

namespace L4.Ukol.PlanovacUdalosti;

class Program
{
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
    }
    public static string[] NactiEvent(string eventNameDate)
    {
        string[] eventCasti = eventNameDate.Split(';');
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

    static void Main(string[] args)
    {
        List<Event> eventList = new List<Event>();
        bool chciUkoncitProgram = false;
        do
        {
            Console.WriteLine("Zadej text ve formátu EVENT;[event name];[event date], kde [event name] je jméno události a [event date] je datum ve formátu YYYY-MM-DD, např. EVENT;Lekce Czechitas;2025-05-15");
            Console.WriteLine("Nebo zadej text LIST pro výpis událostí");
            Console.WriteLine("Nebo zadej text STATS pro výpis statistik");
            Console.WriteLine("Nebo zadej text END pro ukončení programu: ");
            string vstupUzivatele = Console.ReadLine();

            switch (vstupUzivatele.ToLower().Trim())
            {
                case "list":
                    {

                        break;
                    }
                case "stats":
                    {

                        break;
                    }
                case "end":
                    {
                        Console.WriteLine("Ukončuji program.");
                        chciUkoncitProgram = true;
                        break;
                    }
                default:
                    {
                        if (vstupUzivatele.Trim().StartsWith("event", StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                eventList.Add(new Event(NactiEventName(vstupUzivatele), NactiEventDate(vstupUzivatele)));
                                Console.WriteLine(eventList[0].DatumUdalosti);
                            }
                            catch (Exception exception)
                            {
                                System.Console.WriteLine(exception.Message);
                                System.Console.WriteLine("Event nebyl přidán. Zadej znovu.");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Neplatný vstup.");
                        }
                        break;
                    }
            }
        } while (!chciUkoncitProgram);
    }
}
