using EFCoreRelationshipsDemo.Data;
using EFCoreRelationshipsDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsDemo
{
    public class EmployeeDepartmentService
    {
        static public void AddDepartment()
        {
            using(var context = new AppDbContext())
            {
                Console.Write("Enter Department Name: ");
                string dname = Console.ReadLine();

                var department = new Department
                {
                    DepartmentName = dname
                };

                context.Departments.Add(department);
                context.SaveChanges();

                Console.WriteLine("Department added successfully.");
                Console.WriteLine();
            }
        }

        static public void AddEmployeeToDepartment()
        {
            using (var context = new AppDbContext())
            {
                var departments = context.Departments.ToList();

                if (!departments.Any())
                {
                    Console.WriteLine("No departments found. Please add a department first.");
                    return;
                }

                Console.WriteLine("Available Departments: ");
                foreach (var dept in departments)
                {
                    Console.WriteLine($"{dept.DepartmentId}  {dept.DepartmentName}");
                }
                Console.WriteLine();

                Console.Write("Enter Department ID to assign employee:");
                int deptid = Convert.ToInt32(Console.ReadLine());

                var selectedDept = context.Departments.Find(deptid);

                if(selectedDept == null)
                {
                    Console.WriteLine("Department Id not found!");
                    return;
                }

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Employee Age: ");
                int age = int.Parse(Console.ReadLine());

                var employee = new Employee
                {
                    EmpName = name,
                    Age = age,
                    DeptId = deptid
                };

                context.Employees.Add(employee);
                context.SaveChanges();

                Console.WriteLine("Employee assigned succesfully.");
                Console.WriteLine();

            }
        }

        static public void ViewDepartments()
        {
            using (var context = new AppDbContext())
            {
                var depts = context.Departments.ToList();

                if (!depts.Any())
                {
                    Console.WriteLine("No departments found.");
                    return;
                }

                foreach (var d in depts)
                    Console.WriteLine($"ID: {d.DepartmentId} | Name: {d.DepartmentName}");
            }
            Console.WriteLine();
        }
        static public void ViewEmployees()
        {
            using(var context = new AppDbContext())
            {
               // var employees = context.Employees.ToList();
                var employees = context.Employees.Include(e => e.Department).ToList();
                if (!employees.Any())
                {
                    Console.WriteLine("No Employees found!");
                    return;
                }

                Console.WriteLine("Employees Details are: ");

                foreach (var emp in employees)
                {
                    Console.WriteLine($"Employee ID: {emp.EmployeeId}  Name: {emp.EmpName}  " +
                                      $"Age: {emp.Age}  Department ID: {emp.Department.DepartmentId}  Department Name: {emp.Department.DepartmentName}");
                }
                Console.WriteLine();
            }
        }

        static public void UpdateDepartment()
        {
            using (var context = new AppDbContext())
            {
                ViewDepartments();

                Console.Write("Enter Department ID to update: ");
                int id = int.Parse(Console.ReadLine());

                var dept = context.Departments.Find(id);
                if (dept == null)
                {
                    Console.WriteLine("Department not found.");
                    return;
                }

                Console.Write("New Name: ");
                dept.DepartmentName = Console.ReadLine();

                context.SaveChanges();
                Console.WriteLine("Department updated.");
                Console.WriteLine();
            }
        }

        static public void DeleteDepartment()
        {
            using (var context = new AppDbContext())
            {
                ViewDepartments();

                Console.Write("Enter Department ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                var dept = context.Departments
                    .Include(d => d.Employees)
                    .FirstOrDefault(d => d.DepartmentId == id);

                if (dept == null)
                {
                    Console.WriteLine("Department not found.");
                    return;
                }

                if (dept.Employees.Any())
                {
                    Console.WriteLine("Cannot delete. Department has assigned employees.");
                    return;
                }

                context.Departments.Remove(dept);
                context.SaveChanges();

                Console.WriteLine("Department deleted.");
                Console.WriteLine();
            }
        }

        static public void UpdateEmployee()
        {
            using (var context = new AppDbContext())
            {
                ViewEmployees();

                Console.Write("Enter Employee ID to update: ");
                int id = int.Parse(Console.ReadLine());

                var emp = context.Employees.Find(id);
                if (emp == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                Console.Write("New Name: ");
                emp.EmpName = Console.ReadLine();

                Console.Write("New Age: ");
                emp.Age = int.Parse(Console.ReadLine());

                ViewDepartments();
                Console.Write("New Department ID: ");
                emp.DeptId = int.Parse(Console.ReadLine());

                context.SaveChanges();
                Console.WriteLine("Employee updated.");
                Console.WriteLine();
            }
        }

        static public void DeleteEmployee()
        {
            using(var context = new AppDbContext())
            {
                ViewEmployees();

                Console.Write("Enter Employee ID to delete: ");
                int eid = int.Parse(Console.ReadLine());

                var emp = context.Employees.Find(eid);

                if(emp == null)
                {
                    Console.WriteLine($"No Employee found with id : {eid}");
                    return;
                }

                context.Employees.Remove(emp);
                context.SaveChanges();
                Console.WriteLine();
            }
        }
    }
}
