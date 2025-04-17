namespace L2.datetime;

class Program
{
    static void Main(string[] args)
    {
        Rytir albrecht = new Rytir("Albrecht", 10);
        albrecht.IntroduceYourself();
        Console.ReadLine(); //čekám na stisk klávesy

        Console.WriteLine($"I am born on: {albrecht.DateOfBirth}"); //ještě není nastaveno
        Console.ReadLine(); //čekám na stisk klávesy


        albrecht.DateOfBirth = DateTime.Now;
        albrecht.DateOfBirth = new DateTime(1970, 10, 30);
        albrecht.DateOfBirth = albrecht.DateOfBirth.AddHours(5).AddMinutes(25);

        Console.WriteLine($"I am born on: {albrecht.DateOfBirth}");
        Console.ReadLine(); //čekám na stisk klávesy

        TimeSpan vek = DateTime.Now - albrecht.DateOfBirth;
        TimeSpan cas = new TimeSpan(10, 10, 10, 5,); //h min sek

        Console.WriteLine(cas);

        Console.WriteLine($"I am {vek} years old.");
        Console.WriteLine($"I am {vek.Days / 365} years old."); //int
        Console.WriteLine($"I am {vek.TotalDays / 365} years old."); //double

        Console.ReadLine(); //čekám na stisk klávesy
    }
}
