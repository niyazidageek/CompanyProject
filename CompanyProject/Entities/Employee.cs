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
        public string ID { get; set; }
        public string DepartmentName { get; set; }
        public Employee(string fullname, string position, int salary, string departmentname)
        {
            FullName = fullname;
            Position = position;
            Salary = salary;
            No = count;
            count++;
            ID = departmentname[0].ToString().ToUpper() + departmentname[1].ToString().ToUpper() + No.ToString();
        }
    }
}
