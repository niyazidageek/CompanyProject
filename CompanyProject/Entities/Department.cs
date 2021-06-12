using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Entities
{
    public class Department
    {
        private int sum = 0;
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public Department(string name)
        {
            Name = name;
            Employees = new();
        }
        public double CalcAverageSalary()
        {
            double result = 0;
            if (Employees.Count == 0)
            {
                Console.WriteLine("The are no employees in this department");
            }
            else
            {
                foreach (var item in Employees)
                {
                    sum += item.Salary;
                }
                result = sum / Employees.Count;   
            }
            return result;
        }     
    }
}
