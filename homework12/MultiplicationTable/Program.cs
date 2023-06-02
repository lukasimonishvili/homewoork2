using System;
using System.IO;
using System.Reflection;

namespace MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateMultiplicationTable();
        }

        static void CreateMultiplicationTable()
        {
            Console.WriteLine("Please enter max number of multiplication table");
            var maxNumberOfMultTable = Convert.ToInt32(Console.ReadLine());
            var filesDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Split("bin")[0] + "/files"; // folder directory
            var textFileDirectory = filesDirectory + "/multiplication-table.txt"; // actual file directory

            if (!Directory.Exists(filesDirectory))
            {
                Directory.CreateDirectory(filesDirectory);
            }

            if (!File.Exists(textFileDirectory))
            {
                File.Create(textFileDirectory);
            }

            for (var i = 1; i <= maxNumberOfMultTable; i++)
            {
                var result = "";
                for (var j = 1; j <= 10; j++)
                {
                    result += $"{i} * {j} = {i * j} \n";
                }

                result += "\n \n \n";
                File.AppendAllText(textFileDirectory, result);
            }
        }
    }
}
