using System.Net.Http.Headers;

namespace L2.vyjimky2;

class Program
{
    static void Main(string[] args)
    {
        int number1 = 10;
        int number2 = 0;
        Calculator calculator = new Calculator();
        calculator.DivideTwoNumbers(number1, number2);

        try
        {
            Console.WriteLine($"result is: {calculator.DivideTwoNumbers(number1, number2)}");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        finally
        {
            Console.WriteLine("Calculator has been called.");
        }
    }
}
