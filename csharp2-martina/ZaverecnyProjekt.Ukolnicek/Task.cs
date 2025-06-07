using System;
using System.Security.Cryptography.X509Certificates;

namespace ZaverecnyProjekt.Ukolnicek;

public class Task
{
    public string Description { get; set; }
    public bool HighPriority { get; set; }
    public DateTime DueDate { get; set; }
    public bool Completed { get; set; }
    //public string UserName { get;  set; }
    public Task(string description, DateTime dueDate, bool highPriority = false, bool completed = false)
    {
        Description = description;
        HighPriority = highPriority;
        DueDate = dueDate;
        Completed = completed;
    }

}
