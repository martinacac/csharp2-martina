using System;
using System.Collections.Generic;

namespace L8.Interfacy.BR2;

public class Kruh : IUmiPocitatObsah, IUmiPocitatObvod
{
    public int Polomer { get; set; }
    public Kruh(int polomer)
    {
        Polomer = polomer;
    }
    public double VypocitejObsah()
    {
        return Math.PI * Polomer * Polomer;
    }
    public double VypocitejObvod()
    {
        return Math.PI * Polomer * 2;
    }
}
