using System;
using ConsoleTables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Services
{
    public class MenuService
    {
        static CompanyService method = new();
        public static void AddDepartmentMenu()
        {
            Console.WriteLine("Enter the name of a department");
            string departmentname = Console.ReadLine();
            method.AddDepartment(departmentname);
        }
        public static void AddEmployeeMenu()
        {
            int salary = 0;
            Console.WriteLine("Enter the name of an employee");
            string fullname = Console.ReadLine();
            Console.WriteLine("Enter the name of the position");
            string position = Console.ReadLine();
            Console.WriteLine("Enter the salary");
            string salarystr = Console.ReadLine();
            while (!int.TryParse(salarystr, out salary))
            {
                Console.WriteLine("Enter a number, please");
                salarystr = Console.ReadLine();
            }
            Console.WriteLine("Enter the name of a department");
            string departmentname = Console.ReadLine();
            method.AddEmployee(fullname, position, salary, departmentname);
        }
        public static void EditDepartmentMenu()
        {
            Console.WriteLine("Enter the name of a department");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the new name of a department");
            string newname = Console.ReadLine();
            method.EditDepartment(name, newname);
        }    
        public static void GetDepartmentsMenu()
        {
            var table = new ConsoleTable("Departments");
            foreach (var item in method.GetDepartments())
            {
                table.AddRow(item.Name);
            }
            table.Write();
            Console.WriteLine();
        }
        public static void RemoveEmployeeMenu()
        {
            Console.WriteLine("Enter the ID of an employee");
            string id = Console.ReadLine();
            method.RemoveEmployee(id);
        }
        public static void EditEmployeeMenu()
        {
            int salary = 0;
            Console.WriteLine("Enter the ID of an employee");
            string id = Console.ReadLine();
            Console.WriteLine("Enter the new name of an employee");
            string newfullname = Console.ReadLine();
            Console.WriteLine("Enter the new position of an employee");
            string newposition = Console.ReadLine();
            Console.WriteLine("Enter the new salary");
            string salarystr = Console.ReadLine();
            while (!int.TryParse(salarystr, out salary))
            {
                Console.WriteLine("Enter a number, please");
                salarystr = Console.ReadLine();
            }
            method.EditEmployee(id, newfullname, newposition, salary);
        }
        public static void GetEmployeesMenu()
        {
            var table = new ConsoleTable("ID", "Full name", "Position", "Salary");
            foreach (var item in method.GetEmployees())
            {
                table.AddRow(item.ID, item.FullName, item.Position, item.Salary);
            }
            table.Write();
            Console.WriteLine();
        }
    }
}
