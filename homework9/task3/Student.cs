using System;

namespace task3
{
    internal class Student
    {
        public string Name {get; set;}

        public virtual void Study()
        {
            Console.WriteLine($"{Name} is now studing");
        }

        public virtual void Read()
        {
            Console.WriteLine($"{Name} is now reading");
        }

        public virtual void Write()
        {
            Console.WriteLine($"{Name} is now writing");
        }

        public virtual void Relax()
        {
            Console.WriteLine($"{Name} is now relaxing");
        }
    }

    internal class GoodStudent : Student
    {
        public override void Study()
        {
            Console.WriteLine($"{Name} is now studing - good student");
        }

        public override void Read()
        {
            Console.WriteLine($"{Name} is now reading - good student");
        }

        public override void Write() { 
            Console.WriteLine($"{Name} is now writing - good student");
        }

        public override void Relax()
        {
            Console.WriteLine($"{Name} is now relaxing - good student");

        }
    }

    internal class LazyStudent : Student
    {
        public override void Study()
        {
            Console.WriteLine($"{Name} is now studing - Lazy student");
        }

        public override void Read()
        {
            Console.WriteLine($"{Name} is now reading - Lazy student");
        }

        public override void Write()
        {
            Console.WriteLine($"{Name} is now writing - Lazy student");
        }

        public override void Relax()
        {
            Console.WriteLine($"{Name} is now relaxing - Lazy student");

        }
    }
}
