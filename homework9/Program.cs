using System;
using System.Collections.Generic;

namespace task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var company = new Company(CompanyStatus.imported);
            company.setTaxRate();
            Console.WriteLine(company.taxRate);

            var employee = new Employee(EmployeePosition.Develoepr)
            {
                Name = "Luka",
                LastName = "Simonishvili",
                Age = 25,
                workedHours = new List<int>{8, 8, 8, 8, 8, 8, 8 }
            };

            employee.calculateSalary();
        }
    }
}
