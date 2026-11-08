using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.Data.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //  builder.HasMany(s => s.Courses).WithMany(C => C.Students);



        }
    }
}
