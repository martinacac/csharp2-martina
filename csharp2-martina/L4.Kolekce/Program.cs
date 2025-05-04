namespace L4.Kolekce;

class Program
{
    static void Main(string[] args)
    {
        Knight martin = new Knight("Martin", 100);
        Knight zuzka = new Knight("Zuzka", 120);
        Knight artus = new Knight("Artus", 120);

        Knight[] knights = new Knight[] { martin, zuzka, artus };

        List<Knight> knighstsList = new List<Knight> { martin, zuzka, artus };

        for (int i = 0; i < knighstsList.Count; int++)
        {
            knighstsList[i].WriteNameAndHealth();
        }
        //nebo
        foreach (Knight knight in knighstsList)
        {
            knight.WriteNameAndHealth();
        }
        Knight jan = new Knight("Jan", 80);
        knighstsList.Add(jan);

        int indexOfArtus = knighstsList.IndexOf(artus);
        knighstsList.RemoveAt(indexOfArtus);
        knighstsList.Remove(artus);
        knighstsList.Insert(1, artus); //vloží za prvního- v List to jde, v Array nejde


        if (knighstsList.Contains(artus))
        {
            System.Console.WriteLine("Yes, he is here.");
        }
        else
        {
            System.Console.WriteLine("No, he is not here.");
        }

        Knight knightNamedMartin = knighstsList.Find(k => k.Name == "Martin"); //vrátí první prvek vyhovující podmínce nebo null if neex.
        if (knightNamedMartin == null)
        {
            throw new Exception("Not found");
        }
        knightNamedMartin.WriteNameAndHealth();

        List<Knight> foundKnights = knighstsList.FindAll(k => k.Health == 100);

        //sortovani - musím si vytvořit svoji metodu
        //pro stringy:
        string.Compare("string1", "string2");

        knighstsList.Sort(CompareKnights); //nedávám argumenty, bude porovnávat postupně všechny dvojice v List pomocí mojí metody

        foreach (Knight knight in knighstsList)
        {
            knight.WriteNameAndHealth();
        }

    }

    private static int CompareKnights(Knight knight1, Knight knight2) //moje metoda pro sortování
    {
        return string.Compare(knight1.Name, knight2.Name);
    }
}
