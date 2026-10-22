using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [AllowNull]
        public string? Name { get; set; }
        [Range(15000.0,70000.0)]
        public decimal Salary { get; set; }
        [Range(25, 50)]
        [Required]
        public int Age { get; set; }

    }
}
