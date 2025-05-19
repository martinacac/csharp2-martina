namespace L6.opakovani;

class Knight
{
    private int _health; //tuto private hodnotu potřebuji pro custom ověření - viz public int Health

    public static int KnightCount { get; private set; } //příklad fungování static
    public string Name { get; } //if nenastavím public bude defaultně private, dám pouze {get;} abych nemohla změnit
    public int Strength { get; } //nemám zde {set;} tzn. že mohu nastavit jen v konstruktoru => zabráním nežádoucí změně
    // public int Health;  
    public int Health
    {
        get
        {
            return _health;
        }
        private set //(int value)
        {
            if (value < 0)
            {
                _health = 0;
            }
            else
            {
                _health = value;
            }
        }
    }
    // //analogie s metodou (if bych místo (int health) si to pojmenovala (int value)):
    // public void AddHealth(int value) //můj setter - nutný když změním Health na private (a nevyužiji {set;})
    // {
    //     if (_health < 10)
    //     {
    //         this._health += value;
    //     }
    // }

    public string Nickname
    {
        get
        {
            return "Some guy"; //toto už nezměním - nemůžu si uložit jinou hodnotu
        }
    }

    public bool IsAlive //property, volám pomocí Console.WriteLine(geralt.IsAlive);
    {
        get
        {
            return this._health > 0;
        }
    }
    public bool IsAliveMethod() //metoda - udělá to stejné, volám pomocí Console.WriteLine(geralt.IsAlive());
    {
        return this._health > 0;
    }

    // //konstruktor s defaultním nastavením
    // public Knight(string name)
    // {
    //     this.Name = name;
    //     this.Strength = 20;
    //     this.Health = 100;
    // }
    // //*konstruktor bez defaultního nastavení
    // public Knight(string name, int strength, int health)
    // {
    //     this.Name = name;
    //     this.Strength = strength;
    //     this.Health = health;
    //     System.Console.WriteLine("Inside of the big constructor.");
    // }
    // //**výše uvedené 2 konstruktory mohu nahradit (zjednodušit) tímto jedním s povinným jménem (konstruktor souhrnný včetně defaultního nastavení)
    // public Knight(string name, int strength = 20, int health = 100)
    // //public Knight(string name = "Null", int strength=20, int health=100) by vzal i zadání bez jména
    // {
    //     this.Name = name;
    //     this.Strength = strength;
    //     this.Health = health;
    // }
    //nebo můžeme volat konstruktory mezi sebou
    // public Knight(string name) :this(name, 20,100) //tento konstruktor volá konstruktor bez defaultního nastavení*
    // {System.Console.WriteLine("Inside of the small constructor.");}
    // public Knight(string nam = "Null") :this(name, 20,100); // umožní zadání Knighta i bez jména
    // //nemohu mít následující dva konstruktory současně, protože neumí rozlišit 2 int když zadám např. Knight jan = new Knight(10);
    // public Knight(int strength) : this("Null", strength, 100)
    // { }
    // public Knight(int health) : this("Null", 20, health)
    // { }

    //konstruktor souhrnný včetně defaultního nastavení**
    public Knight(string name, int strength = 20, int health = 100)
    //public Knight(string name = "Null", int strength=20, int health=100) by vzal i zadání bez jména
    {
        this.Name = name;
        this.Strength = strength;
        this.Health = health;
        Knight.KnightCount += 1;
    }
    //public Knight(int strength) : this("Null", strength, 100) //nastaví jen sílu a volá velký konstruktor který nastaví ostatní hodnoty
    //{ }

    public void DefendYourself(Knight attacker) ////můj setter - nutný když změním field Health na private (a nevyužiji {set;}), metoda totiž může měnit i private fieldy
    {
        this.Health -= attacker.Strength;
    }
    public int GetHealth() //můj getter pro private field NEBO to lze umožnit pomocí {get;} 
    {
        return this.Health;
    }


}
class Program
{
    static void Main(string[] args)
    {
        var knights = new List<string> { "Martin", "Matej", "Kamil", "Juraj", "Petr", "Josef" };
        var grouping = knights.GroupBy(knight => knight[0]); //podle počátečního písmena
        //nebo grouping.Select(group => group.Count()).Max();

        Console.WriteLine($"{grouping.Count()}, {grouping.Max(group => group.Count())}");

        var geralt = new Knight("Geralt", 20, 100);
        //geralt.Name = "Geralt";
        //geralt.Strength = 100; //if nenastavim Health zde ani defaultně v konstruktoru, bude obecně defaultně 0 (pro integer)
        var artus = new Knight("Artus", 200);
        var jan = new Knight("Jan");
        System.Console.WriteLine(geralt.Health);
        geralt.DefendYourself(artus);
        System.Console.WriteLine(geralt.Health);
        System.Console.WriteLine(geralt.IsAlive);
        System.Console.WriteLine(geralt.IsAliveMethod());
        System.Console.WriteLine(Knight.KnightCount);
        //geralt.Health += 5; //if mám private field nebo {private set;}, nemohu to takto měnit
        //geralt.AddHealth(9); //díky mému setteru můžu měnit i u private fieldu
        //System.Console.WriteLine(geralt.GetHealth); 
    }
}
