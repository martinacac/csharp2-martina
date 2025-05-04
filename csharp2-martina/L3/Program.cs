using System.Text;

namespace L3;

class Program
{
    static void Main(string[] args)
    {

        //metody na string

        //string.
        //char.
        //"abacd".Aggregate

        string str = "Hello!";

        foreach (char c in str)
        {
            System.Console.WriteLine(c);
        }

        System.Console.WriteLine("a" + "b");
        System.Console.WriteLine('a' + 'b');
        System.Console.WriteLine("char a: " + 'a');
        System.Console.WriteLine("int a: " + (int)'a'); //97
        System.Console.WriteLine("int A: " + (int)'A'); // 65
        System.Console.WriteLine("int b: " + (int)'b');
        System.Console.WriteLine('a' - 32); //65
        System.Console.WriteLine($"{'a' - 32}"); //65
        System.Console.WriteLine((char)('a' - 32)); //A
        System.Console.WriteLine((char)('a' + 'b')); //Ã

        System.Console.WriteLine(new string('=', 30)); //=========================(30x =)

        string input = Console.ReadLine();
        if (input == null || input.Length == 0)
        {
            System.Console.WriteLine("not good");
        }
        if (string.IsNullOrEmpty(input))
        {
            System.Console.WriteLine("not good");
        }
        if (string.IsNullOrWhiteSpace(input))
        {
            System.Console.WriteLine("not good");
        }

        //Ukol 1 - Obratte poradi stringu
        string palindrom = "Kuna nese nanuk";
        string obracene = ObratText(palindrom);
        System.Console.WriteLine(obracene);

        //char [] charArray = vstup.ToCharArray();
        //return new string(charArray.Reverse().ToArray());


        //Ukol 2 - Napiste funkci, ktera umi detekovat, ze se jedna o palindrom (zatim jen u slov) a pak z pole vypiste jen palindromy
        string[] slova = new string[] { "kajak", "program", "rotor", "Czechitas", "madam", "Jarda", "radar", "nepotopen" };
        for (int i = 0; i < slova.Length; i++)
        {
            if (JePalindrom(slova[i]))
            {
                Console.WriteLine(slova[i]);
            }
        }

        //Ukol 3 - opravte v tomto textu omylem zapnuty Caps Lock - např. pomoci char hodnot a int nebo char.IsUpper a char.IsLower('a')
        string capsLock = "jAK mICROSOFT wORD POZNA ZAPNUTY cAPSLOCK";
        string opraveny = ""; //string.Empty
        foreach (char ch in capsLock)
        {
            if (char.IsUpper(ch))
            {
                opraveny = opraveny + char.ToLower(ch);
            }
            else if (char.IsLower(ch))
            {
                opraveny = opraveny + char.ToUpper(ch);
            }
            else
            {
                opraveny = opraveny + ch;
            }
        }
        System.Console.WriteLine(opraveny);

        //jiná možnost
        string opraveny2 = string.Empty;
        for (int i = 0; i < capsLock.Length; i++)
        {
            opraveny2 += char.IsUpper(capsLock[i]) ? char.ToLower(capsLock[i]) : char.ToUpper(capsLock[i]);
        }
        System.Console.WriteLine(opraveny2);

        //Ukol 4 - rozsifrujte tuto zpravu - text byl zasifrovan tak, ze jsme kazde pismeno posunuli o jedno doprava: 'a' -> 'b'. 
        string sifra = "Wzcpsob!qsbdf!.!hsbuvmvkj!b!ktfn!ob!Ufcf!qztoz";

        foreach (char ch in sifra)
        {
            System.Console.Write((char)(ch - 1));
        }

        //nebo
        //nebo
        string odsifrovane = string.Empty;
        for (int i = 0; i < sifra.Length; i++)
        {
            odsifrovane += (char)(sifra[i] - 1);
        }
        System.Console.WriteLine(odsifrovane);


        string text = "Hello, my name is Martin and I am happy.";
        System.Console.WriteLine(text.Contains("Martin"));
        System.Console.WriteLine(text.Contains("martin", StringComparison.OrdinalIgnoreCase));
        System.Console.WriteLine(text.IndexOf("Martin"));
        System.Console.WriteLine(text.IndexOf("Martin", 19)); //od stringu 19 tj. hledám další výskyt
        System.Console.WriteLine(text.Replace("Martin", "Josef"), StringComparison.OrdinalIgnoreCase);

        string[] words = new string[] { "kajak", "program", "rotor", "Czechitas", "madam", "Jarda", "radar", "nepotopen" };

        foreach (string word in words)
        {
            System.Console.WriteLine($"{word}{new string('.', 20 - word.Length)} {word.Length}");
            System.Console.WriteLine($"{word.PadRight(20, '.')}{word.Length}");
        }

        System.Console.WriteLine("Give me 4 names (deliminated by space): ");
        string names = Console.ReadLine();
        string[] namesAsArray = names.Split(" ");

        if (namesAsArray.Length < 4)
        {
            throw new Exception("I wanted 4.");
        }
        foreach (var name in namesAsArray)
        {
            System.Console.WriteLine($"{name.PadRight(20, '.')}{name.Length}");
        }
        //ošetření více mezer zadaných omylem
        string[] namesAsArray2 = names.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string joinedWords = string.Join("\n", words); //vypíše každé na nový řádek
        System.Console.WriteLine(joinedWords);

        int x = 10;
        int y = -5;
        System.Console.WriteLine(x.ToString() + y); //if první je string, druhé se převede na string automaticky

        //string palindrom = "Kuna nese nanuk";
        obracene = string.Empty;
        for (int i = palindrom.Length - 1; i >= 0; i--)
        {
            obracene += palindrom[i];
        }
        System.Console.WriteLine(obracene);
        //to stejné se StringBuilder (efektivnější pro větší objem dat)
        StringBuilder reversedBuilder = new StringBuilder();
        for (int i = palindrom.Length - 1; i >= 0; i--)
        {
            reversedBuilder.Append(palindrom[i]);
        }
        System.Console.WriteLine(reversedBuilder.ToString());


    }

    static string ObratText(string vstupniString)
    {
        string vysledek = string.Empty;
        for (int i = vstupniString.Length - 1; i >= 0; i--)
        {
            vysledek += vstupniString[i];
        }
        return vysledek;
    }

    static bool JePalindrom(string slovo)
    {
        var obracene = ObratText(slovo);
        if (string.Compare(obracene, slovo, StringComparison.OrdinalIgnoreCase) == 0)
        {
            return true;
        }
        return false;
    }

}
