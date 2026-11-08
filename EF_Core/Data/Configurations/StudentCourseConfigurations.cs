using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.Data.Configurations
{
    public class StudentCourseConfigurations : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(SC => new { SC.CourseId, SC.StudentId }); // Composite PK
        }
    }
}
