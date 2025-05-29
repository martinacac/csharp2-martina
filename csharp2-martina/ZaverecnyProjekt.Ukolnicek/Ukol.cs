using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class Ukol
{
    public string Nazev { get; private set; }
    public int Priorita { get; private set; }
    public DateTime DatumSplneni { get; private set; }
    public bool Splneno { get; private set; }

}
