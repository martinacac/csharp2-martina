using L2.ukol;

internal class Program
{
    private static void Main(string[] args)
    {
        //V metodě Main vytvořte jednu instanci třídy Lucistnik pomocí jejího konstruktoru.

        Lucistnik artur = new Lucistnik("Artur", 8);

        // Implementujte hlavní smyčku programu (např. pomocí while(true)), která bude opakovaně:
        // Zobrazovat aktuální stav lučištníka (zavoláním metody ZobrazStav).
        // Prezentovat uživateli textové menu s následujícími volbami:
        // Vystřelit šíp
        // Přidat šípy
        // Konec
        while (true)
        {
            artur.ZobrazStav();

            System.Console.WriteLine("1 - vystřelit šíp");
            System.Console.WriteLine("2 - přidat šípy");
            System.Console.WriteLine("3 - konec");

            // Načíst volbu uživatele z konzole.
            int akce;
            akce = NactiCeleCisloZKonzole("Vyber akci: ");
            // Zpracovat volbu (pomocí switch nebo if/else if):
            switch (akce)
            {
                case 1: // Při volbě 1: Zavolat metodu Vystrel na instanci lučištníka.
                    {
                        artur.Vystrel();
                        break;
                    }
                case 2: // Při volbě 2: Získat od uživatele počet šípů k přidání (viz bod 3) a zavolat metodu PridejSipy na instanci lučištníka s tímto počtem.
                    {
                        int pocetPridavanychSipu = NactiCeleCisloZKonzole("Zadej počet přidávaných šípů: ");
                        artur.PridejSipy(pocetPridavanychSipu);
                        break;
                    }
                case 3: // Při volbě 3: Ukončit program.
                    {
                        System.Console.WriteLine("Končím program.");
                        return;
                    }
                default: //Pro neplatné volby: Zobrazit chybovou hlášku.
                    {
                        System.Console.WriteLine("Neznámá akce.");
                        break;
                    }
            }
        }
    }
    //NactiCeleCisloZKonzole(string vyzva)
    //Co má dělat: Tato metoda by měla bezpečně načíst celé číslo od uživatele. Měla by opakovaně vyzývat k zadání, dokud uživatel nezadá platné celé číslo (a ideálně by měla odmítnout záporné hodnoty, pokud to dává smysl pro kontext, kde se používá - např. přidávání šípů). Metoda vrátí validní načtené číslo.
    public static int NactiCeleCisloZKonzole(string vyzva)
    {
        bool byloZadanoCeleKladneCislo;
        int celeCislo;
        do
        {
            System.Console.WriteLine(vyzva);
            byloZadanoCeleKladneCislo = int.TryParse(Console.ReadLine(), out celeCislo);
        } while (!byloZadanoCeleKladneCislo || celeCislo < 1);
        return celeCislo;
    }
}