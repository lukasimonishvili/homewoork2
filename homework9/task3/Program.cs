using System;
using System.Collections.Generic;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var goodStudent = new GoodStudent()
            {
                Name = "Gela",
            };
            var lazyStudent = new LazyStudent()
            {
                Name = "Nini",
            };

            var classRoom = new ClassRoom(new List<Student> { lazyStudent, goodStudent});
            classRoom.studentsInAction();
        }
    }
}
