namespace L5.dotazy;

class Program
{
    static void Main(string[] args)
    {
        Knight borivoj = new Knight() { Name = "Borivoj", Health = 100, CountryCode = "CZ" };
        Knight vojtech = new Knight() { Name = "Vojtech", Health = 100, CountryCode = "CZ" };
        Knight miroslav = new Knight() { Name = "Miroslav", Health = 80, CountryCode = "HU" };
        Knight bronislav = new Knight() { Name = "Bronislav", Health = 50, CountryCode = "CZ" };
        Knight vaclav = new Knight() { Name = "Vaclav", Health = 80, CountryCode = "CZ" };
        Knight radovan = new Knight() { Name = "Radovan", Health = 10, CountryCode = "HU" };

        List<Knight> knights = new List<Knight>() { borivoj, vojtech, miroslav, bronislav, vaclav, radovan };

        List<Country> countries = new List<Country>() { new Country { Code = "CZ", Name = "Cesko" }, new Country { Code = "HU", Name = "Madarsko" } }

        var strongKnights = knights.Where(k => k.Health > 90);
        var strongKnights2 = knights.Where(isStrong);
        var weakKnights = knights.Where(isWeak);
        var strongKnightsNames = knights.Where(k => k.Health > 90).Select(k => k.Name); //zde vybírám jenom jména z těch co mají nad 90
        foreach (var k in strongKnights)
        {
            System.Console.WriteLine($"{k.Name}");
        }
        foreach (var name in strongKnightsNames)
        {
            System.Console.WriteLine($"{name}");
        }

        //count 
        System.Console.WriteLine($"number of strong knights: {strongKnightsNames.Count()}");
        System.Console.WriteLine($"number of strong knights: {knights.Count(k => k.Health > 90)}");

        //first last firstordefault
        System.Console.WriteLine($"first knight is {knights.First().Name}");
        System.Console.WriteLine($"last knight is {knights.Last().Name}");
        var emptyList = knights.Where(k => k.Health > 150);
        //System.Console.WriteLine($"first knight is {emptyList.First().Name}"); //invalid operation exception protože list je prázdný
        Knight knight1 = emptyList.FirstOrDefault();
        Knight? knight2 = emptyList.FirstOrDefault(); //použiji ? aby došlo ke kontrole zda je prázdné
        if (knight1 is not null)
        {
            System.Console.WriteLine($"first knight is {knight1.Name}");
        }
        else
        {
            System.Console.WriteLine("Knight is not present.");
        }

        //řetězení podmínek ve where
        var filteredKnights = knights.Where(k => k.Health > 60);
        var filteredKnightsStartsByM = filteredKnights.Where(k => k.Name.StartsWith("M"));
        foreach (var k in filteredKnightsStartsByM)
        {
            System.Console.WriteLine($"{k.Name}");
        }
        System.Console.WriteLine($"is there stronger knight than 200? {knights.Any(k => k.Health > 200)}"); //vrací true false if aspoň 1
        System.Console.WriteLine($"is there stronger knight than 20? {knights.Any(k => k.Health > 20)}"); //vrací true false
        System.Console.WriteLine($"are all knights stronger than 20? {knights.All(k => k.Health > 20)}"); //vrací true false if všechny splňují
        System.Console.WriteLine($" what is the min health? {knights.Min(k => k.Health)}"); //v predikátu musím uvést dle čeho posuzovat
        System.Console.WriteLine($"what is the average health? {knights.Average(k => k.Health)}");
        System.Console.WriteLine("knights ordered by name:");
        var orderedKnightsByName = knights.OrderBy(k => k.Name);
        var orderedKnightsByNameDesc = knights.OrderByDescending(k => k.Name);
        foreach (var k in orderedKnightsByName)
        {
            System.Console.WriteLine($"{k.Name}");
        }
        var knightsByHealth = knights.GroupBy(k => k.Health);
        foreach (var knightGroup in knightsByHealth)
        {
            System.Console.WriteLine($"Knights with Health {knightGroup.Key}: ");
            var orderedByName = knightGroup.OrderBy(k => k.Name);
            foreach (var k in knightGroup) //foreach (var k in orderedByName)
            {
                System.Console.WriteLine($"{k.Name}");
            }
        }
        System.Console.WriteLine("knights filtered by sql:");
        var knightsWithCountry = from knight in knights
                                 join country in countries on knight.CountryCode equals country.Code
                                 select new
                                 {
                                     Name = knight.Name,
                                     Country = country.Name
                                 }; //vytvořila jsem si nový list 
        var knightsWithCountryArray = knightsWithCountry.ToArray();

        foreach (var k in knightsWithCountry)
        {
            System.Console.WriteLine($"My name is {k.Name} and I am from {k.Country}");
        }
        var knightsWithCountryStartingWithM = knightsWithCountry.Where(k => k.Name.StartsWith("M"));

        foreach (var k in knightsWithCountryStartingWithM)
        {
            System.Console.WriteLine($"My name is {k.Name} and I am from {k.Country}");
        }

        var randomNumbers = new RandomEnumerable();
        var firstTenNumbers = randomNumbers.Take(10);
        foreach (var number in firstTenNumbers)
        {
            System.Console.WriteLine(number + ", ");
        }
        var numbersList = firstTenNumbers.ToList();
        foreach (var number in numbersList)
        {
            System.Console.WriteLine(number + ", ");
        }
        var knightsName = knightsByHealth.SelectMany(k => k.Select(n => n.Name)); //ZKONTROLOVAT byCode
        foreach (var name in knightsName)
        {
            System.Console.WriteLine(name);
        }

    }

    private static bool isStrong(Knight knight) //Main je static tak tato také musí být static
    {
        return knight.Health > 90;
    }
    private static bool isWeak(Knight knight)
    {
        return knight.Health < 30;
    }
}

class Knight
{
    public string Name { get; set; }
    public int Health { get; set; }
    public string CountryCode { get; set; }
}
class Country
{
    public string Code { get; set; }
    public string Name { get; set; }
}

public class RandomEnumerable : IEnumerable<int>
{

}
