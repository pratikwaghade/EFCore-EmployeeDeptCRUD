using EFCoreRelationshipsDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsDemo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           string connectionString = @"Data Source = .\SQLEXPRESS; Initial Catalog = EFCoreRelationshipDemo; TrustServerCertificate = True; Integrated Security = True";

           optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
