using System;
using System.Collections.Generic;
using L8.Interfacy.BR2;

internal class Program
{
    private static void Main(string[] args)
    {
        //napiste dva ruzne interfacy: IUmiPocitatObsah, IUmiPocitatObvod
        //implementujte tridy obdelnik a kruh, ktere oba interfacy pouzivaji
        //vlozte jejich instance do seznamu a zavolejte na nich prislusne metody na vypocet obsahu a obvodu
        Kruh kruh = new Kruh(5);
        Obdelnik obdelnik = new Obdelnik(4, 6);

        System.Console.WriteLine("---List<object>---");
        List<object> tvary = new List<object> { kruh, obdelnik };

        foreach (var tvar in tvary)
        {
            if (tvar is IUmiPocitatObsah obsah)
            {
                Console.WriteLine($"Obsah: {obsah.VypocitejObsah()}"); //bez IF s přetypováním objektu: Console.WriteLine($"Obsah: {((IUmiPocitatObsah)tvar).VypocitejObsah()}");
            }

            if (tvar is IUmiPocitatObvod obvod)
            {
                Console.WriteLine($"Obvod: {obvod.VypocitejObvod()}"); //bez IF: Console.WriteLine($"Obvod: {((IUmiPocitatObvod)tvar).VypocitejObvod()}");
            }
        }
        System.Console.WriteLine("---List<IUmiPocitatObsah>---");
        List<IUmiPocitatObsah> tvary2 = new List<IUmiPocitatObsah>
            {
                new Kruh(5),
                new Obdelnik(4, 6)
            };
        foreach (var tvar in tvary2)
        {
            // Výpočet obsahu (každý prvek v seznamu je IUmiPocitatObsah)
            Console.WriteLine($"Obsah: {tvar.VypocitejObsah()}");

            // Pokud objekt implementuje IUmiPocitatObvod, vypočítej obvod
            if (tvar is IUmiPocitatObvod obvod)
            {
                Console.WriteLine($"Obvod: {obvod.VypocitejObvod()}");
            }
        }
        System.Console.WriteLine("---List<ITvary>---"); //nejlepší řešení je vytvořit si rodičovský interface
        List<ITvary> tvary3 = new List<ITvary> { kruh, obdelnik };
        foreach (ITvary tvar in tvary3)
        {
            System.Console.WriteLine($"{tvar.GetType()} obsah: {tvar.VypocitejObsah()}");
            System.Console.WriteLine($"{tvar.GetType().Name} obvod: {tvar.VypocitejObvod():F2}");  //Name if chci jen název třídy bez názvu projetku
        }
    }
}


