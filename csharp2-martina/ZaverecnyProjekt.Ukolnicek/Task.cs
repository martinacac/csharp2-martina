using System;
using System.Security.Cryptography.X509Certificates;

namespace ZaverecnyProjekt.Ukolnicek;

public class Task
{
    public string Description { get; set; }
    public bool HighPriority { get; set; }
    public DateTime DueDate { get; set; }
    public bool Completed { get; set; }

    public Task(string description, DateTime dueDate, bool highPriority = false, bool completed = false)
    {
        Description = description;
        HighPriority = highPriority;
        DueDate = dueDate;
        Completed = completed;
    }
    public Task() { } //parameterless constructor for XmlSerializer

    public override string ToString()
    {
        string openOrCompleted = Completed ? "[COMPLETED]" : "[OPEN]     ";
        string priority = HighPriority ? "High  " : "Normal";
        string overdue = (DueDate < DateTime.Today && !Completed) ? "OVERDUE" : "";
        return $"{openOrCompleted} {Description.PadRight(20, ' ')} | Priority: {priority} | Deadline: {DueDate:dd.MM.yyyy} {overdue}";
    }

    public virtual void WriteTaskInConsole()
    {
        var originalColor = Console.ForegroundColor;

        // Set color based on task status
        if (Completed)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (DueDate < DateTime.Now)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (HighPriority)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        // Use the overridden ToString() method
        Console.Write($"{this}");

        Console.ForegroundColor = originalColor;
    }
}


