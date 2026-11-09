using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Data.Models
{
    internal class Employee // Parent Class
    {
        // Make it Abstract Class if you don't want to create an instance of it
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }

    }
}
