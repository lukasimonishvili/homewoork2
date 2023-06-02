using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace XMLMagic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XMLMagic();
        }

        static void XMLMagic()
        {
            Console.WriteLine("Please enter as large word as you can");
            var userInputString = Console.ReadLine();

            Console.WriteLine("into how many peaces we must slice your word?");
            var countOfSlices = Convert.ToInt32(Console.ReadLine());
            var onePieceLength = userInputString.Length / countOfSlices;

            List<string> slices = new List<string>();
            for (int i = 0; i < userInputString.Length; i += onePieceLength)
            {
                if (i + onePieceLength > userInputString.Length)
                {
                    slices[slices.Count - 1] += userInputString.Substring(i, userInputString.Length - i);
                }
                else
                {
                    slices.Add(userInputString.Substring(i, onePieceLength));
                }
            }

            var filesDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Split("bin")[0] + "/files"; // folder directory
            var xmlFileDirectory = filesDirectory + "/strings.xml"; // actual file directory

            XmlDocument xmlDocument = new();
            xmlDocument.Load(xmlFileDirectory);
            XmlNode root = xmlDocument.DocumentElement;
            for (var i = 0; i < slices.Count; i++)
            {
                var newXmlElement = xmlDocument.CreateElement(slices[i]);
                newXmlElement.InnerText = $"string {i + 1}";
                root.AppendChild(newXmlElement);
            }
            xmlDocument.Save(xmlFileDirectory);
        }
    }
}
