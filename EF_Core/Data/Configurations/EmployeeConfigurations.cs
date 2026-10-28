using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EF_Core.Data.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // PK , Identity constrain [1,1]
            builder.HasKey(e => e.Id);

            //   modelBuilder.Entity<Employee>().Property("EmpName"); // throw Ex if not there is this property

            builder.Property<string>("EmpName"); // Create Shadow Property
                                                                         // Shadow Property => Exist Table [Database], But Not Exist In The Model 

            builder.Property(E => E.Name).HasColumnName("EmployeeName").HasColumnType("varchar(50)").IsRequired(true);
            // not exist minLength, But there is in data annotation


            /* Note:
             * Shadow Property => Exist Table [Database], But Not Exist In The Model 
             * Not Mapped Property => Exist Property In Model, But Not Exist In [Database] 
             */
              builder.HasOne(E => E.ManagedDepartment).WithOne(D => D.Manager).HasForeignKey<Department>(D=>D.ManagerId).OnDelete(DeleteBehavior.Restrict);
            // .OnDelete(DeleteBehavior.Restrict) ==> to change delete Behavior

            // If you don't want to put a Navigational Property in the models , can't arrive to model data form another that has relationship with it

         //   builder.HasOne<Department>().WithOne().HasForeignKey<Department>(D => D.ManagerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
