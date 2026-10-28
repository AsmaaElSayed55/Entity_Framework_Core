using EF_Core.Data.Configurations;
using EF_Core.Data.Models;
using Final_Task.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Company;Trusted_Connection=true;TrustServerCertificate=true");
            // base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
         //   modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfigurations());
         //   modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());

            // Apply all Configuration classes 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



            // base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Project> Projects { get; set; }

       // public DbSet<Student> Students { get; set; }


        //  Add-Migration -Name "Initial Create" -Context "CompanyDbContext" -OutputDir  "Data/Migrations"

        // Update-Database

        // Update-Database 0

        // Drop-Database

        // Remove-Migration -Force

    }
}
