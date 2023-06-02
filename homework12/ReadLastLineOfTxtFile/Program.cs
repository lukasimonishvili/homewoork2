using System;
using System.IO;
using System.Reflection;

namespace ReadLastLineOfTxtFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadLastLineOfTxtFile();
        }

        static void ReadLastLineOfTxtFile()
        {
            Console.WriteLine("Please enter length of text.txt File");
            Console.WriteLine("Enabled range 1 - 10");
            var FileLineLength = Convert.ToInt32(Console.ReadLine());
            var filesDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Split("bin")[0] + "/files"; // folder directory
            var textFileDirectory = filesDirectory + "/text.txt"; // actual file directory
            string[] wordList = { "Hello", "My", "Name Is", "Jovani", "Giovanni", "Giorgio", "But", "Everybody", "Calls Me", "Giorgio" };


            if (FileLineLength > 10 || FileLineLength < 1)
            {
                Console.WriteLine("Unable to create text.txt file out of legal range");
                return;
            }

            if (!Directory.Exists(filesDirectory))
            {
                Directory.CreateDirectory(filesDirectory);
            }

            if (!File.Exists(textFileDirectory))
            {
                File.Create(textFileDirectory);
            }


            for (var i = 0; i < FileLineLength; i++)
            {
                File.AppendAllText(textFileDirectory, wordList[i] + (i < FileLineLength - 1 ? Environment.NewLine : ""));
            }

            var fileLines = File.ReadAllLines(textFileDirectory)[FileLineLength - 1];
            Console.WriteLine(fileLines);
        }
    }
}