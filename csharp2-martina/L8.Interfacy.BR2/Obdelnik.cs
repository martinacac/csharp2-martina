using System;
using System.Collections.Generic;

namespace L8.Interfacy.BR2;

public class Obdelnik : IUmiPocitatObsah, IUmiPocitatObvod
{
    public int StranaA { get; set; }
    public int StranaB { get; set; }
    public Obdelnik(int stranaA, int stranaB)
    {
        StranaA = stranaA;
        StranaB = stranaB;
    }
    public double VypocitejObsah()
    {
        return StranaA * StranaB;
    }
    public double VypocitejObvod()
    {
        return (StranaA + StranaB) * 2;
    }
}
