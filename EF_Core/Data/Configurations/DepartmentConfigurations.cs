using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // turn into table in schema that named sales
            builder.ToTable("Departments", "Sales");
            builder.Property(d => d.Id).UseIdentityColumn();
            //  D.Property(D=>D.Id).ValueGeneratedNever(); // Disable Identity Constrain
            //   D.Property(D => D.Id). HasDefaultValueSql("NEWGUID()");

            builder.Property(D => D.Name).HasColumnType("varchar(20)").HasColumnName("DepartmentName").HasDefaultValue("HR");

            //    D.Property(D => D.DateOfCreation).HasAnnotation("DataType", "Date").HasDefaultValue(DateOnly.FromDateTime(DateTime.Now)); // Defualt Value Will be set with date of migration

            //   D.Property(D => D.DateOfCreation).HasAnnotation("DataType", "Date").HasDefaultValueSql("NEWGUID()"); // Insert Department => Insert date of creation , when you update [no change will happen], you can manually change it 

            builder.Property(D => D.DateOfCreation).HasAnnotation("DataType", "Date").HasComputedColumnSql("GETDATE()"); // Insert Department => Insert date of creation , when you update [change the date], you can't manually change it 

            builder.Ignore(D => D.Serial);

            // the Same Relationship Configur
            //  builder.HasOne(D=>D.Manager).WithOne(E=>E.ManagedDepartment).HasForeignKey<Department>(D=>D.ManagerId).OnDelete(DeleteBehavior.Restrict);

        //    builder.OwnsOne(E => E.DeptAddress, Address => Address.WithOwner()); // Most Common Used 

            // One to Many 
            builder.HasMany(D=>D.Employees).WithOne(E=>E.EmployeeDepartment).HasForeignKey(E=>E.DepartmentId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
