using L8.AbstraktniTridy.BR1;

internal class Program
{
    private static void Main(string[] args)
    {
        // Vytvořte abstraktní třídu PohadkovaBytost a v ní abstraktní metodu NapisJakTravisVolnyCas
        // Vytvorte tridy Princezna, Rytir, Carodenice, ktere dedi PohadkovouBytost
        // Naimplementujte metodu NapisJakTravisVolnyCas - vypsanemu textu na konzoli se meze nekladou
        // Vytvorte instance od kazde tridy a vypiste informace o trávení volného času.

        PohadkovaBytost ruzenka = new Princezna("Ruzenka");
        //ruzenka.NapisJakTravisVolnyCas();
        PohadkovaBytost borivoj = new Rytir("Borivoj");
        PohadkovaBytost kouzelnice = new Carodejnice("Kouzelnice");
        Umelec umelec = new Umelec();
        List<PohadkovaBytost> pohadkoveBytosti = new List<PohadkovaBytost>() { ruzenka, borivoj, kouzelnice };
        //List<PohadkovaBytost> ruzneBytosti = new List<PohadkovaBytost>() { ruzenka, borivoj, kouzelnice, umelec }; toto nejde protože Umelec nededi z PohadkovaBytost

        foreach (PohadkovaBytost bytost in pohadkoveBytosti)
        {
            bytost.NapisJakTravisVolnyCas();
        }
    }
}