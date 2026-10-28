using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateOnly? DateOfCreation {  get; set; }
        public int Serial { get; set; }
    }
}
