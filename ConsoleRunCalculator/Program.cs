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
                    //Because of Rule # 3 to allow \n and , as delimeters
                    //Calculator requires delemeters be seperated by a @ symbol
                    //and we need to escape \ with \\ so that it does not thing \n is new line.
                    delimeterInputData = ",@\\n"; 

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
