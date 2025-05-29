using System;

namespace L8.AbstraktniTridy.BR1;

public abstract class PohadkovaBytost
{
    public string Jmeno { get; }

    protected PohadkovaBytost(string jmeno)
    {
        Jmeno = jmeno;
    }
    public abstract void NapisJakTravisVolnyCas();
}
