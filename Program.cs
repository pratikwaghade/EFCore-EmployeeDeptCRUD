// See https://aka.ms/new-console-template for more information

using EFCoreRelationshipsDemo;

while (true)
{
    Console.WriteLine("-------------------------EFCore-EmployeeDeptCRUD-------------------------------");
    Console.WriteLine("\t 1. Add Department\n" + "\t 2. Add Employees To Department\n" + "\t 3. View All Department\n" +
                      "\t 4. View All Employees\n" + "\t 5. Update Department\n" + "\t 6. Delete Department\n" +
                      "\t 7. Update Employee\n" + "\t 8. Delete Employee\n" + "\t 9. Exit");

    Console.WriteLine("-------------------------------------------------------------------------------");
    string choice = Console.ReadLine();

    switch (choice)
    {
       case "1":
              EmployeeDepartmentService.AddDepartment();
              break;

       case "2":
              EmployeeDepartmentService.AddEmployeeToDepartment();
              break;

       case"3":
              EmployeeDepartmentService.ViewDepartments();
              break;

       case "4":
              EmployeeDepartmentService.ViewEmployees();
              break;

       case "5":
              EmployeeDepartmentService.UpdateDepartment();
              break;

       case "6":
              EmployeeDepartmentService.DeleteDepartment();
              break;

       case "7":
              EmployeeDepartmentService.UpdateEmployee();
              break;

       case "8":
              EmployeeDepartmentService.DeleteEmployee();
              break;
       
       case "9":
            Console.WriteLine("Exited");
            return;

        default:
            Console.WriteLine("Invalid input!");
            break;
      
    }
}