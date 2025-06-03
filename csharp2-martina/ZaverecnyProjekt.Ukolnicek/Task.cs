using System;

namespace ZaverecnyProjekt.Ukolnicek;

public class Task
{
    public string Description { get; set; }
    public bool HighPriority { get; set; }
    public DateTime DueDate { get; set; }
    public bool Completed { get; set; }
    //public string UserName { get;  set; }

}
