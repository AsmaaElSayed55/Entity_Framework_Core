using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core.Data.Models
{

    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public DateOnly? DateOfCreation { get; set; }
        public int Serial { get; set; }

        // Navigational Property ==> One ==> Mandatory
        public virtual Employee? Manager { get; set; }

        // It will understand it is Navigational prop when it named
        // 1. NavPropName+Id  ==> ManagerId
        // 2. NavPropName+AnotherIdName ==> ManagerEmpId
        // 3. TypeNavProp+Id ==> EmployeeId
        // 4. TypeNavProp+PK ==> EmployeeEmpId
        public int? ManagerId { get; set; }

        // Another Way if name is not be understood
        //  [ForeignKey(nameof(Manager))]
        //  public int ManagerDepartmentId { get; set; }

        //   public Address DeptAddress { get; set; }


        // One - Many  Mandatory - Mandatory
        [InverseProperty(nameof(Employee.EmployeeDepartment))]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        // HashSet  is Fastest


    }
}
