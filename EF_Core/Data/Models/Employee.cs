using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [MaxLength(50, ErrorMessage = "Max Length Must Be 50")]
        [AllowNull]

        // Required attribute -> Run-time required
        [MinLength(3,ErrorMessage ="Min Length Must Be 3")]
        public string? Name { get; set; }

        [Range(15000.0,70000.0)]
        // Required Keyword -> Compile-time required
      //  [Column("EmpSalary",TypeName="decimal(10,2")]
        public required decimal Salary { get; set; }
        [Range(25, 50)]
        [Required]
        public int Age { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [NotMapped]
        public string Test {  get; set; }

        // is nullable to be optional (May)
        // Relationship [One] ==> Employee ==> Navigational Property
        [InverseProperty(nameof(Department.Manager))] // To make it be understood for EF Core
        public Department? ManagedDepartment { get; set; }
       

        // One - One Mandatory - Mandatory

        public Address EmpAddress { get; set; }
        // Employee ==> Owner Of Address
        // Cols [Country, City, Street] ==> Map in Employees Table

        // One - many Mandatory - Mandatory
      //  [InverseProperty(nameof(Department.Employees))]
        public Department EmployeeDepartment { get; set; }

        public int DepartmentId { get; set; }

    }
}
 