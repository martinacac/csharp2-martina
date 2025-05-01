namespace L4.Slovniky;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>
        {
            {"car", "auto"},
            {"dog", "pes"},
            {"phone", "telefon"}
        };
        System.Console.WriteLine($"English word dog is in Czech {dict["dog"]}");
        dict.Add("watch", "hodinky");
        dict["cup"] = "pohar"; //jiná možnost přidávání

        if (dict.TryGetValue("dog", out string dogInCzech))
        {
            System.Console.WriteLine($"English word dog is in Czech {dogInCzech}");
        }
        foreach (string key in dict.Keys)
        {
            System.Console.WriteLine($"English word {key} is in Czech {dict[key]}");
        }

        foreach (KeyValuePair<string, string> keyValuePair in dict)
        {
            System.Console.WriteLine($"English word {keyValuePair.Key} is in Czech {keyValuePair.Value}");
        }

    }
}
