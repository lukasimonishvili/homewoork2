using System;
using System.Linq;

namespace homework5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 2, 4, 5, 6, 7, 8, 9, 10 };
            test.Where(x => x == 1).ToArray();
            Console.WriteLine(String.Join(" - ", test));

            // TASK #1 
            Console.WriteLine("Pick a number. Any number");
            var doesItDevidesOnFiveInput = Convert.ToInt32(Console.ReadLine());
            string doesItDevidesOnFiveResult = doesItDevidesOnFiveInput % 5 == 0 && doesItDevidesOnFiveInput > 0 ? "Yes" : "No";
            Console.WriteLine(doesItDevidesOnFiveResult);

            // Task #2
            Console.WriteLine("Enter first number");
            var firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter action");
            Console.WriteLine("Only + - * and / are allowed");
            var action = Console.ReadLine();
            Console.WriteLine("enter second numbver");
            var secondNumber = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case "+":
                    Console.WriteLine(firstNumber + secondNumber);
                    break;
                case "*":
                    Console.WriteLine(firstNumber * secondNumber);
                    break;
                case "-":
                    Console.WriteLine(Math.Max(firstNumber, secondNumber) - Math.Min(firstNumber, secondNumber));
                    break;
                case "/":
                    double minimalNumber = Math.Min(firstNumber, secondNumber);
                    double maximumNumber = Math.Max(firstNumber, secondNumber);
                    if (minimalNumber == 0)
                    {
                        Console.WriteLine("Not Allowed To Divide By Zero");
                    }
                    else
                    {
                        Console.WriteLine(maximumNumber / minimalNumber);
                    }
                    break;
                default:
                    Console.WriteLine("Unkown action detected");
                    break;
            }


            // TASK #3
            var numberValueToSwitch1 = 12;
            var numberValueToSwitch2 = 5;

            Console.WriteLine("numberValueToSwitch1 = " + numberValueToSwitch1);
            Console.WriteLine("numberValueToSwitch2 = " + numberValueToSwitch2);
            numberValueToSwitch1 *= numberValueToSwitch2;
            numberValueToSwitch2 = numberValueToSwitch1 / numberValueToSwitch2;
            numberValueToSwitch1 /= numberValueToSwitch2;
            Console.WriteLine("numberValueToSwitch1 = " + numberValueToSwitch1);
            Console.WriteLine("numberValueToSwitch2 = " + numberValueToSwitch2);


            // TASK #4
            Console.WriteLine("Please enter number");
            var MultiplyTableInput = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(MultiplyTableInput * i);
            }


            // TASK 5
            Console.WriteLine("Please enter number");
            var findEvenNumbersInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= findEvenNumbersInput; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i * i);
                }
            }
        }
    }
}
