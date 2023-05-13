using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace homework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TASK #1
            Console.WriteLine("please enter circle radius...");
            var radius = Convert.ToInt32(Console.ReadLine());
            var bigSquare = (radius * 2) * (radius * 2);
            var smallSquare = (radius * radius) * 2;
            Console.WriteLine("Diference between 2 squares is: " + (bigSquare - smallSquare));

            // TASK #2
            string[] jackpotArr = { "@", "@", "@", "!" };
            var jackpotSymbol = jackpotArr[0];
            var jackpotResult = true;
            for(var i = 1; i < jackpotArr.Length; i++)
            {
                if (jackpotArr[i] != jackpotSymbol)
                {
                    jackpotResult = false;
                }
            }

            Console.WriteLine(jackpotResult ? "You won jackpot" : "good luck for next time");

            // TASK #3
            Dictionary<string, int> footballTeam = new Dictionary<string, int>();
            const int victoryPoints = 3;
            const int drawPoints = 1;
            const int defeatPoints = 0;
            footballTeam.Add("victory", 2);
            footballTeam.Add("draw", 0);
            footballTeam.Add("defeat", 1);
            var totalScore = (footballTeam["victory"] * victoryPoints) + (footballTeam["draw"] * drawPoints) + (footballTeam["defeat"] * defeatPoints);
            Console.WriteLine("Football team total score is - " + totalScore);

            // TASK #4
            int[] workedHours = {8, 8, 8, 8, 8, 3, 5};
            var paymentPerHour = 10;
            var overTimePayment = 5;
            var weekendPaymentPerHour = paymentPerHour * 2;
            var overTimeStartsFrom = 40;

            var totalIncome = 0;
            var totalHoursWorked = 0;

            for(var i = 0; i <  workedHours.Length; i++) {
                if(i > 4)
                {
                    totalIncome += workedHours[i] * weekendPaymentPerHour;
                }else
                {
                    totalIncome += workedHours[i] * paymentPerHour;

                }
                totalHoursWorked += workedHours[i];
            }

            if(totalHoursWorked > overTimeStartsFrom) {
                var overTimeHoursCount = totalHoursWorked - overTimeStartsFrom;
                totalIncome += overTimeHoursCount * overTimePayment;
            }

            Console.WriteLine("Total income is - " + totalIncome);

            // TASK #5

            int[] workoutHours = { 5, 8, 8, 9, 10 };
            var improvedDaysCount = 0;
            for(int i = 1; i < workoutHours.Length; i++)
            {
                if (workoutHours[i - 1] < workoutHours[i])
                {
                    improvedDaysCount++;
                }
            }
            Console.WriteLine("George improved results " + improvedDaysCount + " Times in this week");

            // TASK #6
            Console.WriteLine("Enter word length");
            var wordLength = Convert.ToInt32(Console.ReadLine());
            string[] listOfStrings = {"Hello", "World", "Programming", "Communication", "karatee", "chuuu"};
            string[] filteredSrings = listOfStrings
                .Where(s => s.Length == wordLength)
                .ToArray();

            if(filteredSrings.Length > 0)
            {
                Console.WriteLine(String.Join(", " , filteredSrings));
            }else
            {
                Console.WriteLine("No elements found");
            }
        }
    }
}
