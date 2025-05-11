using System.Globalization;

namespace L4.Ukol.PlanovacUdalosti;

class Program
{


    static void Main(string[] args)
    {
        List<Event> eventList = new List<Event>();
        eventList.Add(new Event("lekce1", new DateTime(2025, 5, 8, 18, 0, 0)));
        eventList.Add(new Event("lekce2", new DateTime(2025, 5, 15, 18, 0, 0)));
        eventList.Add(new Event("lekce3", new DateTime(2025, 5, 22, 18, 0, 0)));
        eventList.Add(new Event("hospoda", new DateTime(2025, 5, 22, 18, 0, 0)));
        eventList.Add(new Event("hospoda", new DateTime(2025, 4, 22)));
        eventList.Add(new Event("lekce4", new DateTime(2025, 5, 29, 18, 0, 0)));

        //Vytvořte slovník (Dictionary<DateTime, int>), do kterého si uložíte data všech uložených akcí a ke každému datu počet událostí, které se konají v daný den.
        Dictionary<DateTime, int> eventsDict = new Dictionary<DateTime, int>();

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
                        Event.VypisEvents(eventList);
                        break;
                    }
                case "stats":
                    {
                        Event.VypisStats(eventsDict, eventList);
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
                                eventList.Add(new Event(Event.GetEventName(vstupUzivatele), Event.SplitStringEventDate(vstupUzivatele)));
                                //Console.WriteLine(eventList[0].DatumUdalosti);
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                                Console.WriteLine("Event nebyl přidán. Zadej znovu.");
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
