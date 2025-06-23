using System.Xml.Serialization;

namespace L11.InterfaceExamples;
// "aplikace" která bude pracovat s uzivateli pomocí interfacu
// implementujeme interface ruznymi zpusoby

class Program
{
    static void Main(string[] args)
    {
        var userRepository = new InMemoryUserReporitory(); //s vyžitím dat v paměti
        var userRepository2 = new XmlUserRepository(); //s využitím dat uložených v souboru
        App myApp = new App(userRepository);
        App myApp2 = new App(userRepository2);
        myApp.Run();
        myApp2.Run();
    }
}
