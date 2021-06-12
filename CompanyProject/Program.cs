using CompanyProject.Services;
using System;

namespace CompanyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("1. Departments");
                Console.WriteLine("2. Employees");
                Console.WriteLine("0 .Exit");
                Console.WriteLine("Please, enter a selection");
                string optionstr = Console.ReadLine();
                while (!int.TryParse(optionstr, out option))
                {
                    Console.WriteLine("Enter a number, please");
                    optionstr = Console.ReadLine();
                }
                switch (option)
                {
                    case 1:
                        int option1 = 0;
                        do
                        {
                            Console.WriteLine("1. Add department");
                            Console.WriteLine("2. Edit Department");
                            Console.WriteLine("3. Show departments");
                            Console.WriteLine("0. Back");
                            Console.WriteLine("Please, enter a selection");
                            string optionstr1 = Console.ReadLine();
                            while (!int.TryParse(optionstr1, out option1))
                            {
                                Console.WriteLine("Enter a number, please");
                                optionstr = Console.ReadLine();
                            }
                            switch (option1)
                            {
                                case 1:
                                    MenuService.AddDepartmentMenu();
                                    break;
                                case 2:
                                    MenuService.EditDepartmentMenu();
                                    break;
                                case 3:
                                    MenuService.GetDepartmentsMenu();
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.WriteLine("There is no such option!");
                                    break;
                            }
                        } while (option1!=0);                       
                        break;
                    case 2:
                        int option2 = 0;
                        do
                        {
                            Console.WriteLine("1. Add employee");
                            Console.WriteLine("2. Edit employee");
                            Console.WriteLine("3. Remove employee");
                            Console.WriteLine("4. Show employees");
                            Console.WriteLine("0. Back");
                            Console.WriteLine("Please, enter a selection");
                            string optionstr2 = Console.ReadLine();
                            while (!int.TryParse(optionstr2, out option2))
                            {
                                Console.WriteLine("Enter a number, please");
                                optionstr = Console.ReadLine();
                            }
                            switch (option2)
                            {
                                case 1:
                                    MenuService.AddEmployeeMenu();
                                    break;
                                case 2:
                                    MenuService.EditEmployeeMenu();
                                    break;
                                case 3:
                                    MenuService.RemoveEmployeeMenu();
                                    break;
                                case 4:
                                    MenuService.GetEmployeesMenu();
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.WriteLine("There is no such option!");
                                    break;
                            }
                        } while (option2 != 0);
                        break;
                    case 0:
                        Console.WriteLine("Shutting down...");
                        break;
                    default:
                        Console.WriteLine("There is no such option!");
                        break;
                }
            } while (option!=0);
        }
    }
}
