internal class Program
{
    private static void Main(string[] args)
    {
        // Creates a new file next to my exe
        //File.WriteAllText("myFirstFile.txt", "My first content");

        //string secondFile = @"C:\Git\csharp2\lekce9\live\Live9lekce\bin\Debug\SecondFile.txt";
        //File.WriteAllText(secondFile, "My second content");


        // Write into documents folder
        string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string thirdFile = Path.Combine(myDocumentsPath, "ThirdFile.txt");
        Console.WriteLine(thirdFile);

        File.AppendAllText(thirdFile, "My third content second try");
        File.AppendAllText(thirdFile, "My third content third try");


        string fourthFile = Path.Combine(myDocumentsPath, "FourthFile.txt");
        StreamWriter writer = new StreamWriter(fourthFile, append: false);
        writer.WriteLine("First Line");
        writer.WriteLine("Second Line");
        writer.WriteLine("Third Line");
        writer.Flush();
        writer.WriteLine("Fourth Line");
        writer.WriteLine("First Line");
        writer.Close();

        string[] lines = File.ReadAllLines(fourthFile);
        foreach (var item in lines)
        {
            Console.WriteLine(item);
        }


        string pathToDirectory = Path.Combine(myDocumentsPath, "MyCSHarpFolder");
        Directory.CreateDirectory(pathToDirectory);


        string pathToFileInDirectory = Path.Combine(pathToDirectory, "FifthFile.txt");

        if (Directory.Exists(pathToDirectory))
        {
            File.WriteAllText(pathToFileInDirectory, "My second content");
        }

        if (File.Exists(pathToFileInDirectory))
        {
            Console.WriteLine("File exist");
        }

        // Second part of Lecture

        // Streams in easy ways
        string sixthFile = Path.Combine(myDocumentsPath, "SixthFile.txt");
        using (StreamWriter writer1 = new StreamWriter(sixthFile))
        {
            writer1.WriteLine("Inside using 1");
            writer1.WriteLine("Inside using 2");
            writer1.WriteLine("Inside using 3");
            writer1.WriteLine("Inside using 4");
            writer1.WriteLine("Inside using 5");
        }

        List<Person> phoneBook = new List<Person>
        {
            new Person("Jarda", "Kadlec", 777123456),
            new Person("Honza", "Kratochvila", 777987654),
            new Person("Petr", "Novak", 778111222)
    };

        // XML serializer for one object
        XmlSerializer personSerializer = new XmlSerializer(typeof(Person));
        var xmlFilePath = Path.Combine(myDocumentsPath, "xmlFile.xml");
        using (StreamWriter writer1 = new StreamWriter(xmlFilePath))
        {
            personSerializer.Serialize(writer1, phoneBook[0]);
        }

        // XML serializer for one object list
        XmlSerializer personListSerializer = new XmlSerializer(typeof(List<Person>));
        var xmlListFilePath = Path.Combine(myDocumentsPath, "xmlListFile.xml");
        using (StreamWriter writer1 = new StreamWriter(xmlListFilePath))
        {
            personListSerializer.Serialize(writer1, phoneBook);
        }

        // XML Deserialization
        using (StreamReader reader = new StreamReader(xmlFilePath))
        {
            Person person = personSerializer.Deserialize(reader) as Person;
            Console.WriteLine($"{person.FirstName} {person.Surname} has been deserialized");
        }

        using (StreamReader reader = new StreamReader(xmlListFilePath))
        {
            List<Person> person = personListSerializer.Deserialize(reader) as List<Person>;
            Console.WriteLine("----------------------List has been serialized succesfully---------------------------");
            foreach (var item in person)
            {
                Console.WriteLine($"{item.FirstName} {item.Surname} has been deserialized");
            }
        }


        Console.WriteLine("----------------------EndOfStream---------------------------");
        using (StreamReader reader = new StreamReader(fourthFile))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
        }

    }
}
}