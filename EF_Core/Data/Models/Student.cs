using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

      //  public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
      public ICollection<StudentCourse> StudentCourses { get; set; }=new HashSet<StudentCourse>();
    }
}
