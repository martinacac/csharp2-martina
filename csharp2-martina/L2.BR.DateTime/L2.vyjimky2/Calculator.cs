using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L2.vyjimky2
{
    public class Calculator
    {
        //divide 2 numbers
        //if second number is zero, throw exception

        public double DivideTwoNumbers(int a, int b)
        {
            //if b is zero throw exception
            if (b == 0)
            {
                throw new ArgumentException("Nelze delit nulou");
            }
            return a / b;
        }
    }
}