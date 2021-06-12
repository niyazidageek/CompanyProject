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
            if (string.IsNullOrEmpty(departmentname))
                throw new ArgumentNullException("Department name can not be empty or null");
            Department department = new(departmentname);
            Departments.Add(department);
        }
        public void AddEmployee(string fullname, string position, int salary, string departmentname)
        {
            if (string.IsNullOrEmpty(fullname))
                throw new ArgumentNullException("Full name can not be empty or null");
            if (string.IsNullOrEmpty(position))
                throw new ArgumentNullException("Position can not be empty or null");
            if (salary < 250)
                throw new ArgumentOutOfRangeException("Salary can not be less than 250 AZN");
            if (string.IsNullOrEmpty(departmentname))
                throw new ArgumentNullException("Department name can not be empty or null");
            var department = Departments.Find(s => s.Name == departmentname);
            if (department == null)
                throw new ArgumentNullException("There is no such department");
            Employee employee = new(fullname, position, salary, departmentname);        
            department.Employees.Add(employee);            
        }
        public void EditDepartment(string currentname, string newname)
        {
            if (string.IsNullOrEmpty(currentname) || string.IsNullOrEmpty(newname))
                throw new ArgumentNullException("Department name can not be empty or null");
            var department = Departments.Find(s => s.Name == currentname);
            if (department == null)
                throw new ArgumentNullException("There is no such department");
            department.Name = newname;
        }
        public List<Department> GetDepartments()
        {
            if (Departments.Count == 0)
                throw new KeyNotFoundException("List is empty");
            return Departments.ToList();
        }
        public void RemoveEmployee(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("ID can not be empty or null");
            foreach (var item in Departments)
            {
                int index = item.Employees.FindIndex(s => s.ID == id);      
                if (index > -1)
                {
                    item.Employees.RemoveAt(index);                    
                    break;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("There is no such employee with a given ID");
                }
            }
            ResetNumber();
        }
        public void EditEmployee(string id, string newfullname, string newposition, int newsalary)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("There is no such employee with a given ID");
            if (string.IsNullOrEmpty(newfullname))
                throw new ArgumentNullException("Name can not be empty or null");
            if (string.IsNullOrEmpty(newposition))
                throw new ArgumentNullException("Position can not be empty or null");
            if (newsalary < 250)
                throw new ArgumentOutOfRangeException("Salary can not be less than 250 AZN");
            object employeetemp = null;
            foreach (var department in Departments)
            {  
                var employee = department.Employees.Find(s => s.ID == id);
                employeetemp = employee;
                if (employee!=null)
                {
                    employee.FullName = newfullname;
                    employee.Position = newposition;
                    employee.Salary = newsalary;
                }               
            }
            if (employeetemp == null)
                throw new KeyNotFoundException("There is no such employee with a given ID");
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
            if (Temp.Count == 0)
                throw new KeyNotFoundException("List is empty");
            return Temp.ToList();
        }
        public void ResetNumber()
        {
            int count = 1000;
            foreach (var item in Departments)
            {  
                foreach (var item1 in item.Employees)
                {                   
                    count++;
                    item1.No = count;
                    item1.ID = item1.DepartmentName[0].ToString().ToUpper() + item1.DepartmentName[1].ToString().ToUpper() + item1.No.ToString();
                }
            }
        }
    }
}
