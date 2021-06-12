using CompanyProject.Entities;
using CompanyProject.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Services
{
    public class CompanyService : IHumanResourceManager
    {
        public List<Department> Departments { get; set; }
        public CompanyService()
        {
            Departments = new();
        }
        public void AddDepartment(string departmentname)
        {
            Department department = new(departmentname);
            Departments.Add(department);
        }

        public void AddEmployee(string fullname, string position, int salary, string departmentname)
        {
            Employee employee = new(fullname, position, salary, departmentname);
            var department = Departments.Find(s => s.Name == departmentname);
            department.Employees.Add(employee);            
        }

        public void EditDepartment(string currentname, string newname)
        {
            var department = Departments.Find(s => s.Name == currentname);
            department.Name = newname;
        }

        public List<Department> GetDepartments()
        {
            return Departments.ToList();
        }

        public void RemoveEmployee(string id)
        {
            int check = 0;
            foreach (var item in Departments)
            {
                check = item.Employees.RemoveAll(s => s.ID == id);
            }
            if (check != 1)
                throw new KeyNotFoundException("There is no such employee");
        }
        public void EditEmployee(string id, string newfullname, string newposition, int newsalary)
        {
            foreach (var item in Departments)
            {
                var employee = item.Employees.Find(s => s.ID == id);
                employee.FullName = newfullname;
                employee.Position = newposition;
                employee.Salary = newsalary;
            }
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> Temp = new();
            foreach (var item in Departments)
            {
                foreach (var item1 in item.Employees)
                {                   
                    Temp.Add(item1);
                }
            }
            return Temp.ToList();
        }
    }
}
