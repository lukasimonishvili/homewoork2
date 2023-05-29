using System;

namespace task2
{
    internal class Teacher
    {
        public string Name { get; set; }
        public bool certified { get; set; }

        public void getStudentSubject(string subject) {
            string message;
            var random = new Random();
            var random1 = random.Next();
            var random2 = random.Next();
            switch (subject)
            {
                case "Math":
                    message = (random1 + random2).ToString();
                    break;
                case "English":
                    message = "Hello random subject is English";
                    break;
                case "Chemistry":
                    message = "H2O";
                    break;
                default:
                    message = "I dont know that subject";
                    break;
            }

            Console.WriteLine(message);
        }

    }
}
