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
            try
            {
                method.AddDepartment(departmentname);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
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
            try
            {
                method.AddEmployee(fullname, position, salary, departmentname);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }          
        }
        public static void EditDepartmentMenu()
        {
            Console.WriteLine("Enter the name of a department");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the new name of a department");
            string newname = Console.ReadLine();
            try
            {
                method.EditDepartment(name, newname);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }    
        public static void GetDepartmentsMenu()
        {
            var table = new ConsoleTable("Departments");
            try
            {
                foreach (var item in method.GetDepartments())
                {
                    table.AddRow(item.Name);
                }
                table.Write();
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static void RemoveEmployeeMenu()
        {
            Console.WriteLine("Enter the ID of an employee");
            string id = Console.ReadLine();
            try
            {
                method.RemoveEmployee(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
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
            try
            {
                method.EditEmployee(id, newfullname, newposition, salary);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static void GetEmployeesMenu()
        {
            var table = new ConsoleTable("ID", "Full name", "Position", "Salary");
            try
            {
                foreach (var item in method.GetEmployees())
                {
                    table.AddRow(item.ID, item.FullName, item.Position, item.Salary);
                }
                table.Write();
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
