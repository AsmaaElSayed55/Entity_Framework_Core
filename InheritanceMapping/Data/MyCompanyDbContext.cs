using InheritanceMapping.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; } // Child ==> Mapping
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }

    }
}
