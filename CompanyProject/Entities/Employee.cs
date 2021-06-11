using CompanyProject.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Entities
{
    public class Employee:Number
    {
        private static int count = 1000;
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public Employee(string fullname, string position, int salary)
        {
            FullName = fullname;
            Position = position;
            Salary = salary;
            No = count;
            count++;
        }
    }
}
