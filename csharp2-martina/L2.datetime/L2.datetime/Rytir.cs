using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace L2.datetime
{
    public class Rytir
    {
        //vytvorit promenne name and number of lifes
        //create a constructor
        //create a date of birth

        public string Name { get; set; }
        public int NumberOfLifes { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Rytir(string name, int numberOfLifes)
        {
            Name = name;
            NumberOfLifes = numberOfLifes;
        }

        public void IntroduceYourself()
        {
            Console.WriteLine($"my name is {Name} and I have {NumberOfLifes} number of lifes.");
        }
    }
}