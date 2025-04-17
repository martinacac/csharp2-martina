using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        Car car = new Car(); //vytvářím objekt typu Car (konstruktor bez parametru)
        car.SetColor("blue"); //volání nestatické metody na objektu (instanci)
        Car car2 = new Car("yellow"); //vytvářím další objekt typu Car (konstruktor s parametrem)

        int rectangleArea = Rectangle.CalculateArea(8, 9); //volání statické metody (pracuje pouze se vstupními parametry, které uživatel zadává přímo)
    }

    class Car
    {
        private string color;
        public Car() { } //defaultní konstruktor není nutný, ale potřebuji ho přidat, pokud mám další konstruktory s paramentrem a chci povolit i bez parametru
        public Car(string color) //konstruktor s 1 parametrem
        {
            this.color = color;
        }
        public void SetColor(string color) //protože color je private, potřebuji metodu pro změnu, nemůže být statická (manipuluje s instancí)
        {
            this.color = color;
        }
    }

    class Rectangle
    {
        public static int CalculateArea(int a, int b) //static metoda - nevytvářím instanci třídy
        {
            return a * b;
        }
    }
}