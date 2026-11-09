using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Data.Models
{
    internal class FullTimeEmployee : Employee // Child Class
    {
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
    
    }
}
