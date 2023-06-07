using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            cipher();
        }

        static void cipher()
        {
            var filesDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Split("bin")[0] + "/files"; // folder directory
            var JSONFileDirectory = filesDirectory + "/data.json"; // actual file directory
            var JSON = File.ReadAllText(JSONFileDirectory);
            JsonDataObject jsonDataObject = JsonConvert.DeserializeObject<JsonDataObject>(JSON);
            string[] abc = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string output = "";
            for (var i = 0; i < jsonDataObject.word.Length; i++)
            {
                var charIndex = Array.IndexOf(abc, jsonDataObject.word.Substring(i, 1));
                var index = charIndex + jsonDataObject.key > abc.Length - 1
                ? (charIndex + jsonDataObject.key) - abc.Length
                : charIndex + jsonDataObject.key;
                output += abc[index];
            }

            jsonDataObject.output = output;
            File.WriteAllText(JSONFileDirectory, JsonConvert.SerializeObject(jsonDataObject, Formatting.Indented));
        }
    }

    internal class JsonDataObject
    {
        public string word { get; set; }
        public int key { get; set; }
        public string output { get; set; }
    }
}
