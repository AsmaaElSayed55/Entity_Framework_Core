using InheritanceMapping.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Data
{
    internal class MyCompanyDbContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=InheritanceMapping;Trusted_Connection=true;TrustServerCertificate=true");


        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
        // Three Approaches to Map Inheritance in EF Core:
        // 1- Table Per Hierarchy (TPH) ==> Default Approach 
        // make DbSet for Parent Class and Child Classes.

        // 2- Table Per Type (TPT)
        // make DbSet for Each Class.

        // 3- Table Per Concrete Class (TPC) 
        // make DbSet for Child Classes only.

        public DbSet<Employee> Employees { get; set; } // Parent ==> Mapping
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; } // Child ==> Mapping
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }




    }
}
