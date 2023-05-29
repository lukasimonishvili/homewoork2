using System;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student = new Student()
            {
                Name = "John",
                Age = 25,
                freshemnYear = 2020,
            };
            student.yearsLeftIn();

            var teacher = new Teacher()
            {
                Name = "Nona",
                certified = true,
            };
            teacher.getStudentSubject(student.getRandomSubject());
        }
    }
}
