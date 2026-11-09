using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Data.Models
{
    internal class PartTimeEmployee : Employee // Child Class
    {
        public int HourRate { get; set; }
        public int CountOfHours { get; set; }

    }
}
