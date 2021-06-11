using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Entities.Common
{
    interface IHumanResourceManager
    {
        public List<Department> GetDepartments();
        public List<Employee> GetEmployees();
        public void AddDepartment(string departmentname);
        public void EditDepartment(string currentname, string newname);
        public void AddEmployee(string fullname, string position, int salary, string departmentname);
        public void RemoveEmployee(int no);
        public void EditEmployee(int no, string newfullname, string newposition, int newsalary);

    }
}
