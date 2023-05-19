using System;
using System.Collections.Generic;

namespace homework8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            getRootsInIntRange(1, 100, 2);
            fintPairOfSocks("AABBCC");
            endsWithMatch("Some Random Text", "It is Some Random Text");
            List<string> stringList = new List<string>() { "hi", "Hello", "gamarjoba", "zd" };
            List<int> intList = new List<int>() { 1, 2, 4, 5, 6, 7 };
            List<bool> boolList = new List<bool>() { true, false, false, true, true, false, false, true, false, true, true };
            genericArray(stringList);
            genericArray(intList);
            genericArray(boolList);

            Console.WriteLine(printEacMemberOfStringNumber("123456778"));
        }

        static void getRootsInIntRange(int start, int end, int root)
        {
            int result = 0;
            for(int i = start; i < end; i++)
            {
               double roots = Math.Pow(i, 1.0 / root);
                if(roots == Math.Round(roots))
                {
                    result++;
                }
            }
            Console.WriteLine(result);
        }

        static void fintPairOfSocks(string socksText)
        {
            int result = 0;
            while (socksText.Length > 0)
            {
                var charToFind = socksText[0];
                socksText = socksText.Remove(0, 1);
                int indexToRemove = socksText.IndexOf(charToFind);

                if(indexToRemove > -1)
                {
                    result++;
                    socksText = socksText.Remove(indexToRemove, 1);
                }
            }
            Console.WriteLine(result);
        }

        static void endsWithMatch(string firstText, string secondText)
        {
            var result = "";
            if(firstText == secondText)
            {
                result = firstText;
            }else
            {
                for(var i = 0; i < firstText.Length; i++)
                {
                    if (firstText[firstText.Length - (i + 1)] == secondText[secondText.Length - (i + 1)])
                    {
                        result = firstText[firstText.Length - (i + 1)] + result;
                    }else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(result.Length > 0 ? result : "No Match found");
        }

        static void genericArray<T>(List<T> genericArr)
        {
            string typeToString = genericArr[0].GetType().ToString();
            switch (typeToString)
            {
                case "System.Int32":
                    var sum = 0;
                    foreach (var item in genericArr)
                    {
                        sum += Convert.ToInt32(item);
                    }
                    Console.WriteLine(sum);
                break;
                case "System.String":
                    foreach(var item in genericArr)
                    {
                        Console.WriteLine(item.ToString().ToUpper());
                    }
                break;
                case "System.Boolean":
                    Console.WriteLine("First element is " + genericArr[0].ToString());
                    Console.WriteLine("Middle element is " + genericArr[genericArr.Count / 2].ToString());
                    Console.WriteLine("Last element is " + genericArr[genericArr.Count - 1].ToString());
                break;

            }
        }

        static string printEacMemberOfStringNumber(string stringNumber)
        {
            var result = stringNumber[0].ToString();
            stringNumber = stringNumber.Remove(0, 1);

            if(stringNumber.Length > 0)
            {
                result = result + " - " + printEacMemberOfStringNumber(stringNumber);
            }

            return result;
        }
    }
}
