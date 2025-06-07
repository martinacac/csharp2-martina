namespace L9.XMLSoubory.BR2.Serializace;

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

public class Clovek
{
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    public int TelCislo { get; set; }

    public Clovek() { } // Povinný pro deserializaci

    public Clovek(string jmeno, string prijmeni, int telCislo)
    {
        Jmeno = jmeno;
        Prijmeni = prijmeni;
        TelCislo = telCislo;
    }
}

public class TelefonniSeznam
{
    public List<Clovek> Lide { get; set; } = new List<Clovek>();
}

public class Program
{
    public static void Main()
    {
        var seznam = new TelefonniSeznam
        {
            Lide = new List<Clovek>
            {
                new Clovek("Jarda", "Kadlec", 777123456),
                new Clovek("Honza", "Kratochvila", 777987654),
                new Clovek("Petr", "Novak", 778111222)
            }
        };

        string path = "seznam.xml";

        // 2. Serializace
        XmlSerializer serializer = new XmlSerializer(typeof(TelefonniSeznam));
        using (StreamWriter writer = new StreamWriter(path))
        {
            serializer.Serialize(writer, seznam);
        }

        Console.WriteLine("Seznam byl uložen do XML.");

        // 3. Deserializace
        TelefonniSeznam nactenySeznam;
        using (StreamReader reader = new StreamReader(path))
        {
            nactenySeznam = (TelefonniSeznam)serializer.Deserialize(reader)!;
        }

        Console.WriteLine("Načtený seznam:");
        foreach (var clovek in nactenySeznam.Lide)
        {
            Console.WriteLine($"{clovek.Jmeno} {clovek.Prijmeni} - {clovek.TelCislo}");
        }
    }
}

