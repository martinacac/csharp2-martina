namespace L5.dotazy;

class Program
{
    static void Main(string[] args)
    {
        Knight borivoj = new Knight() { Name = "Borivoj", Health = 100, CountryCode = "CZ" };
        Knight vojtech = new Knight() { Name = "Vojtech", Health = 100, CountryCode = "CZ" };
        Knight miroslav = new Knight() { Name = "Miroslav", Health = 80, CountryCode = "SK" };
        Knight bronislav = new Knight() { Name = "Bronislav", Health = 50, CountryCode = "SK" };
        Knight vaclav = new Knight() { Name = "Vaclav", Health = 80, CountryCode = "CZ" };
        Knight radovan = new Knight() { Name = "Radovan", Health = 10, CountryCode = "HU" };

        List<Knight> knights = new List<Knight>() { borivoj, vojtech, miroslav, bronislav, vaclav, radovan };

        List<Country> countries = new List<Country>() {
            new Country() { Code = "CZ", Name = "Czech" },
            new Country() { Code = "SK", Name = "Slovakia" },
            new Country() { Code = "HU", Name = "Hungary" }
             };

        var strongKnights = knights.Where(k => k.Health > 90);
        var strongKnights2 = knights.Where(IsStrong);
        var weakKnights = knights.Where(IsWeak);
        var strongKnightsNames = knights.Where(k => k.Health > 90).Select(k => k.Name); //zde vybírám jenom jména z těch co mají nad 90
        foreach (var k in strongKnights)
        {
            System.Console.WriteLine($"{k.Name}");
        }
        foreach (var name in strongKnightsNames)
        {
            System.Console.WriteLine($"{name}");
        }

        //Count 
        System.Console.WriteLine($"number of strong knights: {strongKnightsNames.Count()}");

        System.Console.WriteLine($"number of strong knights: {knights.Count()}");
        System.Console.WriteLine($"number of strong knights: {knights.Count(k => k.Health > 90)}");

        //First Last FirstOrDefault
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
        System.Console.WriteLine($"what is the min health? {knights.Min(k => k.Health)}"); //v predikátu musím uvést dle čeho posuzovat
        System.Console.WriteLine($"what is the average health? {knights.Average(k => k.Health)}");
        System.Console.WriteLine("---knights ordered by name:---");
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
            foreach (var k in knightGroup) //foreach (var k in orderedByName) NEBO (var k in knightGroup.OrderBy(k => k.Name))
            {
                System.Console.WriteLine($"{k.Name}");
            }
        }
        System.Console.WriteLine("--SelectMany:--");
        var knightsName3 = knightsByHealth.SelectMany(klic => klic.Select(hodnota => hodnota.Name));
        foreach (var name in knightsName3)
        {
            System.Console.WriteLine(name);
        }
        System.Console.WriteLine("--GroupBy--");
        var knightsByCountry = knights.GroupBy(k => k.CountryCode);
        foreach (var knightGroup in knightsByCountry)
        {
            System.Console.WriteLine($"Country: {knightGroup.Key}");
            foreach (var k in knightGroup)
            {
                System.Console.WriteLine($"Knight: {k.Name}");
            }
        }

        //včetně seřazení vzestupně v rámci jednotlivých zemí
        foreach (var knightGroup in knightsByCountry)
        {
            System.Console.WriteLine($"Country: {knightGroup.Key}");
            foreach (var k in knightGroup.OrderBy(k => k.Name))
            {
                System.Console.WriteLine($"Knight: {k.Name}");
            }
        }
        //SelectMany pro získání hodnot zpět z GroupBy bez uvedení klíče
        System.Console.WriteLine("--SelectMany:--");
        var knightsName2 = knightsByCountry.SelectMany(klic => klic.Select(hodnota => hodnota.Name));
        foreach (var name in knightsName2)
        {
            System.Console.WriteLine(name);
        }

        System.Console.WriteLine("--knights filtered by sql:--");
        var knightsWithCountry = from knight in knights
                                 join country in countries on knight.CountryCode equals country.Code
                                 select new
                                 {
                                     Name = knight.Name,
                                     Country = country.Name
                                 }; //vytvořila jsem si nový list 
        var knightsWithCountryArray = knightsWithCountry.ToArray(); //nebo ToList() - if potřebuji zafixování hodnot

        foreach (var k in knightsWithCountry.OrderBy(k => k.Name).OrderBy(k => k.Country)) //seřadí dle zemí a v rámci nich dle jména
        {
            System.Console.WriteLine($"My name is {k.Name} and I am from {k.Country}");
        }
        var knightsWithCountryStartingWithM = knightsWithCountry.Where(k => k.Name.StartsWith("M"));

        foreach (var k in knightsWithCountryStartingWithM)
        {
            System.Console.WriteLine($"My name is {k.Name} and I am from {k.Country}");
        }
        var cisla = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 3 };
        System.Console.WriteLine("--distinct čísla--");
        foreach (var cislo in cisla.Distinct())
        {
            System.Console.Write(cislo + " ");
        }
        System.Console.WriteLine();
        System.Console.WriteLine("--přeskočená první 3 čísla--");
        foreach (var cislo in cisla.Skip(3))
        {
            System.Console.Write(cislo + " ");
        }
        System.Console.WriteLine();
        System.Console.WriteLine("--přeskočená první 3 čísla a chci jen 4--");
        foreach (var cislo in cisla.Skip(3).Take(4))
        {
            System.Console.Write(cislo + " ");
        }

        /*
        var randomNumbers = new RandomEnumerable();

        var firstTenNumbers = randomNumbers.Take(10);

        foreach (var number in firstTenNumbers)
        {
            System.Console.WriteLine(number + ", ");
        }
        var numbersList = firstTenNumbers.ToList(); //když převedu na list, zafixuji si hodnoty
        foreach (var number in numbersList)
        {
            System.Console.Write(number + ", ");
        }
        var knightsName = knightsByHealth.SelectMany(k => k.Select(n => n.Name)); //ZKONTROLOVAT byCode
        foreach (var name in knightsName)
        {
            System.Console.WriteLine(name);
        }
        */

    }

    private static bool IsStrong(Knight knight) //Main je static tak tato také musí být static
    {
        return knight.Health > 90;
    }
    private static bool IsWeak(Knight knight)
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
/*
public class RandomEnumerable : IEnumerable<int>
{
    private Random random;
    public RandomEnumerable()
    {
        random = new Random();
    }
    public IEnumerator<int> GetEnumerator()
    {
        while (true)
        {
            yield return random.Next(1, 20);
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
*/
