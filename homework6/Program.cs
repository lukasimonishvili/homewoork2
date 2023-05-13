using System;
using System.Collections.Generic;
using System.Linq;

namespace homework6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TASK #1
            
            Console.WriteLine("please enter number");
            var arrayLength = Convert.ToInt32(Console.ReadLine());
            List<int> evenInts = new List<int>();
            List<int> oddInts = new List<int>();

            for (var i = 1; i <= arrayLength; i++)
            {
                if (i % 2 == 0)
                {
                    evenInts.Add(i);
                }
                else
                {
                    oddInts.Add(i);
                }
            }

            Console.WriteLine(String.Join(", ", evenInts));
            Console.WriteLine(String.Join(", ", oddInts));

            // TASK #2
            int[] secondTaskInts = { 1, 1, 2, 3, 3, 4, 4, 4 };
            var q = from x in secondTaskInts
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };
            foreach (var x in q)
            {
                Console.WriteLine(x.Value + " appears " + x.Count + " Times sum " + x.Value * x.Count);
            }

            // TASK #3
            List<int> randomList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> resultList = new List<int>();
            Console.WriteLine("please enter number");
            var topNnumberCount = Convert.ToInt32(Console.ReadLine());
            for(var i = 0; i < topNnumberCount; i++)
            {
                var res = randomList.Max();
                resultList.Add(res);
                var elementIndexToRemove = randomList.IndexOf(res);
                randomList.RemoveAt(elementIndexToRemove);
            }

            Console.WriteLine(String.Join(", ", resultList.ToArray()));
        }
    }
}
