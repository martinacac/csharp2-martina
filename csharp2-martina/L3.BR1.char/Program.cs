namespace L3.BR1.CHAR;

class Program
{
    static void Main(string[] args)
    {



        //Ukol 1 - Napiste funkci, ktera umi detekovat, ze se jedna o palindrom (zatim jen u slov) a pak z pole vypiste jen palindromy
        string[] slova = new string[] { "kajak", "program", "rotor", "Czechitas", "madam", "Jarda", "radar", "nepotopen" };
        for (int i = 0; i < slova.Length; i++)
        {
            // if (JePalindrom(slova[i]))
            {
                Console.WriteLine(slova[i]);
            }
        }

        
    }
}
