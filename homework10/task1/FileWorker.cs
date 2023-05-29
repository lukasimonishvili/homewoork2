using System;

namespace task1
{
    internal abstract class FileWorker
    {
        public int fileSize { get; set; }

        public abstract void Read();
        public abstract void Write();
        public abstract void Edit();
        public abstract void Delete();
    }

    internal class SubClass : FileWorker
    {
        public override void Delete()
        {
            Console.WriteLine($"I can Delete from txt file with max storage {fileSize}");
        }

        public override void Edit()
        {
            Console.WriteLine($"I can Edit txt file with max storage {fileSize}");
        }

        public override void Read()
        {
            Console.WriteLine($"I can Read from txt file with max storage {fileSize}");
        }

        public override void Write()
        {
            Console.WriteLine($"I can Write to txt file with max storage {fileSize}");
        }
    }
}
