using System;

namespace L4.Kolekce;

public class Knight
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Knight(string name, int health)
    {
        this.Name = name;
        this.Health = health;
    }
    public void WriteNameAndHealth()
    {
        Console.WriteLine($"I am {Name} and I have {Health} lives.");
    }
}

