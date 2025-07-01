using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; } //primary key

        [Required]
        public string EmpName { get; set; }

        public int Age  { get; set; }

        [ForeignKey("Department")]
        public int DeptId   { get; set; } //foreign key
        public Department Department { get; set; } //navigation property

    }
}
