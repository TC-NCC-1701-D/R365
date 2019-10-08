using Calculator;
using System;

namespace ConsoleRunCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCalculator();
        }

        public static void RunCalculator()
        {
            Calculator.Calculator calc = new Calculator.Calculator();

            bool isExit = false;
            string delimeterInputData = "";
            string numberInputData = "";

            while (!isExit)
            {
                try
                {
                    Console.WriteLine("Enter numbers:");
                    numberInputData = Console.ReadLine();
                    delimeterInputData = ","; // Based on Req rule 1
                    string[] delimeters = calc.GetDeleimeters(delimeterInputData);
                    long total = calc.SumNumbers(numberInputData, delimeters);

                    
                    Console.WriteLine(string.Format("Addition Result: {0}", total));
                }
                catch (Calculator.MoreThanTwoNumberException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
