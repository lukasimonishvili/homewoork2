using System;
using System.Collections.Generic;

namespace task1
{
    public class Employee
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public EmployeePosition Position { get; set; }
        public List<int> workedHours { get; set; }

        private int hourPayRate;
        private int weekendPayRate;

        public Employee(EmployeePosition position)
        {
            this.Position = position;
            switch (position)
            {
                case EmployeePosition.Maneger:
                    hourPayRate = 40;
                    break;
                case EmployeePosition.Develoepr:
                    hourPayRate = 30;
                    break;
                case EmployeePosition.Tester:
                    hourPayRate = 20;
                    break;
                default:
                    hourPayRate = 10;
                    break;
            }
            weekendPayRate = hourPayRate * 2;
        }

        public void calculateSalary()
        {
            var moneyGained = 0;
            var houresWorked = 0;

            for (var i = 0; i < workedHours.Count; i++)
            {
                houresWorked += workedHours[i];
                moneyGained += workedHours[i] * (i > 4 ? weekendPayRate : hourPayRate);
            }

            if (houresWorked > 50)
            {
                moneyGained += moneyGained / 5;
            }

            Console.WriteLine(moneyGained);
        }
    }

}
