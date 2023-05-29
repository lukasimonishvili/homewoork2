using System;

namespace task2
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int freshemnYear { get; set; }

        private string[] subjects = { "Math", "Chemistry", "English", "Geography" };

        public string getRandomSubject()
        {
            var random = new Random();
            var randomIndex = random.Next(0, subjects.Length - 1);
            return subjects[randomIndex];
        }

        public void yearsLeftIn()
        {
            var yearsLeftIn = DateTime.Now.Year - freshemnYear;
            if ( yearsLeftIn > 4 )
            {
                Console.WriteLine($"you finished Univercity {yearsLeftIn - 4} years ago");
            }else
            {
                Console.WriteLine($"you have {4 - yearsLeftIn} years ahead in Univercity");
            }
        }
    }
}
