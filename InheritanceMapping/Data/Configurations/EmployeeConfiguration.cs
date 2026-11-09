using InheritanceMapping.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
        {
          //  builder.HasDiscriminator<string>("EmployeeType").HasValue<FullTimeEmployee>("FTE") .HasValue<PartTimeEmployee>("PTE");
        //  builder.ToTable("Employees"); // Not Necessary, it will be created automatically with the name of the class, but it is a good practice to specify it explicitly.

        }
    }
}
