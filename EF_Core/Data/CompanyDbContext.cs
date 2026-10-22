using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Project> Projects { get; set; }


        //  Add-Migration -Name "Intial Create" -Context "CompanyDbContext" -OutputDir  "Data/Migrations"

        // Update-Database

        // Update-Database 0

        // Drop-Database

        // Remove-Migration -Force

    }
}
