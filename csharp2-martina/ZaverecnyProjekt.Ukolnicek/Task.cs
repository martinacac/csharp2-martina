using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class Task
{
    public string Description { get; private set; }
    public bool HighPriority { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool Completed { get; private set; }
    public string UserName { get; private set; }

}
