using System;

namespace Homework_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please Enter your fullname...");
            var userName = Console.ReadLine();
            Console.WriteLine("Hello " + userName + " My name is Luka Simonishvili");
            Console.ReadLine();
        }
    }
}
