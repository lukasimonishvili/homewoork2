using System;
using System.IO;
using System.IO.Compression;

namespace Strategy
{
    internal class ZipFiler : AbstractFiler
    {
        public override void workWithFile()
        {
            string zipFilePath = filesDirectory + "/files/archive.zip";
            string extractionPath = filesDirectory + "/backup";


            if (!Directory.Exists(extractionPath))
            {
                Directory.CreateDirectory(extractionPath);
            }
            ZipFile.ExtractToDirectory(zipFilePath, extractionPath);
        }
    }

    internal class TxtFiler : AbstractFiler
    {
        public override void workWithFile()
        {
            var txtFilePath = filesDirectory + "/backup/text.txt";
            File.Delete(txtFilePath);
        }
    }

    internal class JsonFiler : AbstractFiler
    {
        public override void workWithFile()
        {
            var JSONFileDirectory = filesDirectory + "/backup/data.json"; // actual file directory
            var JSON = File.ReadAllText(JSONFileDirectory);

            Console.WriteLine(JSON);
        }
    }
}
