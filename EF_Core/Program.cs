using EF_Core.Data;
using EF_Core.Data.DataSeeding;
using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EF_Core
{
    internal class Program
    {
        public static void Create(CompanyDbContext dbContext)
        {
            Employee employee1 = new Employee()
            {
                Name = "Asmaa",
                Salary = 2000,
                Age = 22,
                EmailAddress = "asmaaelsayed2298@gmail.com",
                Password = "23ewqewewef",
                PhoneNumber = "01061921024"

            };

            // Return State of Entity
            Console.WriteLine(dbContext.Entry(employee1).State); // Most Common Used 

            // Add ==> 4 Ways
            dbContext.Employees.Add(employee1); // Most Common Used 

            // if I don't have DbSet
            dbContext.Set<Employee>().Add(employee1);
            // Not Good Way
            dbContext.Add(employee1);
            // Detached ==> Added
            dbContext.Entry(employee1).State = EntityState.Added;
            dbContext.SaveChanges();
        }
        public static void Read(CompanyDbContext dbContext)
        {
            var employee = dbContext.Employees.AsNoTracking().FirstOrDefault(E => E.Id == 1);
            // AsNoTracking because i don't need it

            var employeeTemp = dbContext.Employees.AsTracking().FirstOrDefault(E => E.Id == 1);
            // AsTracking because i need it in this part only

            if (employee is not null)
            {
                Console.WriteLine(dbContext.Entry(employee).State);

                Console.WriteLine($"{employee.Name}, {employee.Salary}, {employee.Age}");
            }

        }
        public static void Update(CompanyDbContext dbContext)
        {
            // Update on DB only , not local object
            var emp = (from e in dbContext.Employees
                       where e.Id == 1
                       select e).FirstOrDefault();

            if (emp is not null)
            {
                Console.WriteLine(dbContext.Entry(emp).State);
                Console.WriteLine($"Salary = {emp.Salary}");
                Console.WriteLine(dbContext.Entry(emp).State);

                Console.WriteLine($" Old Salary {dbContext.Entry(emp).OriginalValues["Salary"]}");
                Console.WriteLine($" New Salary {dbContext.Entry(emp).CurrentValues["Salary"]}");

                emp.Salary = 9000;

                Console.WriteLine($" Old Salary {dbContext.Entry(emp).OriginalValues["Salary"]}");
                Console.WriteLine($" New Salary {dbContext.Entry(emp).CurrentValues["Salary"]}");

                dbContext.SaveChanges(); // To SaveChanges in DB

                Console.WriteLine($" Old Salary {dbContext.Entry(emp).OriginalValues["Salary"]}");
                Console.WriteLine($" New Salary {dbContext.Entry(emp).CurrentValues["Salary"]}");

                Console.WriteLine(dbContext.Entry(emp).State);
                Console.WriteLine("After Update ");
                Console.WriteLine($"Salary is {emp.Salary}");
            }

        }
        public static void Delete(CompanyDbContext dbContext)
        {
            var DeletedEmployee = (from e in dbContext.Employees
                                   where e.Id == 1
                                   select e).FirstOrDefault();

            if (DeletedEmployee is not null)
            {
                Console.WriteLine(dbContext.Entry(DeletedEmployee).State);

                // Remove Locally
                dbContext.Employees.Remove(DeletedEmployee); // Most Common Used

                dbContext.Set<Employee>().Remove(DeletedEmployee); // Most Common Used

                dbContext.Remove(DeletedEmployee);

                dbContext.Entry(DeletedEmployee).State = EntityState.Deleted;

                dbContext.SaveChanges(); // Remove form DB
            }


        }
        static void Main(string[] args)
        {

            using CompanyDbContext dbContext = new CompanyDbContext();
            //  dbContext.Employees.Add();

               dbContext.Database.Migrate(); // if the app is deploymented

            //   dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll; // Defualt


            //dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // if you read only from Database

            #region Create
            //  Create(dbContext );
            #endregion

            #region Read
            //  Read(dbContext);
            #endregion

            #region Update
            //  Update(dbContext);
            #endregion

            #region Delete
            //    Delete(dbContext);
            #endregion


            #region Data Seeding 

            // Work With Department & Employee Tables

            // 1********* Manual Data Seeding

            // 1] Make ManagerId Nullable and Add Migration
            // 2] open Connection with database
            // 3] Create Instance from classes



            #region  Add One Record to Department Table
            //Department department1 = new Department()
            //{
            //    Name = "HR",
            //    DateOfCreation = new DateOnly(2026, 11, 5)

            //};
            //dbContext.Set<Department>().Add(department1); // Add Locally , Change State
            //dbContext.SaveChanges(); 
            #endregion


            #region Add Multiple Records to Department Table
            //List<Department> departments = new List<Department>()
            //{
            //    new Department()
            //    {
            //        Name = "Media",
            //        DateOfCreation = new DateOnly(2023, 4, 5)
            //    },
            //    new Department()
            //    {
            //        Name = "IT",
            //        DateOfCreation = new DateOnly(2025, 1,5)
            //    },
            //    new Department()
            //    {
            //        Name = "Finance",
            //        DateOfCreation = new DateOnly(2024, 11, 20)
            //    }
            //};
            //dbContext.Set<Department>().AddRange(departments); // Add Locally , Change State
            //dbContext.SaveChanges(); // Save Changes to DB

            #endregion


            // 2********* Data Seeding Using Migration 
            // should be done in OnModelCreating Method in DbContext Class

            // you should send all required data to the database in the migration file, and then run the migration to apply the changes to the database.


            // 3********* Dynamic Data Seeding

            //var flag = CompanyDbContextSeed.SeedData(dbContext);

            //if(flag)
            //{
            //    Console.WriteLine("Data Seeded Successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Not Completed");
            //}

            #endregion


            #region Loading - Eager Loading
            // it load all the data of the employee with id 20 and the data of the department that the employee manages, if any, in one request , so it good only for relationship one to one or one to many, but not for many to many because it will load all the data of the related entities and it will be a lot of data, so we need to use Eager Loading with ThenInclude method to load the related data with the main data in one request for many to many relationship


            // ************ Get First Employee with id 5

            #region Using SQL Query
            //var employee = dbContext.Employees.FirstOrDefault(E => E.Id == 15);
            //if (employee is not null)
            //{
            //    Console.WriteLine($"Employee Name : {employee.Name}");
            //    Console.WriteLine($"Employee Id : {employee.Id}");
            //    Console.WriteLine($"Department Name : {employee.EmployeeDepartment?.Name}"); // it will throw an exception because the EmployeeDepartment is not loaded yet, so we need to use Eager Loading to load the related data with the main data
            //    // by default it does not load the data of navigation properties

            //    var departmentOfEmployee =(from D in dbContext.Set<Department>()
            //                              where employee.DepartmentId == D.Id
            //                              select D).FirstOrDefault();
            //    Console.WriteLine($"Department Name : {departmentOfEmployee?.Name}"); // it will throw an exception because the EmployeeDepartment is not loaded yet, so we need to use Eager Loading to load the related data with the main data  
            // I Sent 2 requests to the database, one for the employee and one for the department, so we need to use Eager Loading to load the related data with the main data in one request

            //} 
            #endregion


            #region Using Eager Loading to load the related data with the main data in one request

            //var employee = dbContext.Employees.Include(E => E.EmployeeDepartment).FirstOrDefault(E => E.Id == 15); // use Include method with Navigation property to load the related data with the main data in one request
            //// it did 
            //if (employee is not null)
            //{
            //    Console.WriteLine($"Employee Name : {employee.Name}");
            //    Console.WriteLine($"Employee Id : {employee.Id}");
            //    Console.WriteLine($"Department Name : {employee.EmployeeDepartment?.Name}"); 

            //}

            //var employee1 = dbContext.Employees.Include(E => E.ManagedDepartment).Include(E=>E.EmployeeDepartment).FirstOrDefault(E => E.Id == 17); // use Include method with Navigation property to load the related data with the main data in one request

            //if (employee is not null)
            //{
            //    Console.WriteLine($"Employee Name : {employee1.Name}");
            //    Console.WriteLine($"Employee Id : {employee1.Id}");
            //    Console.WriteLine($"Managed Department Name : {employee1.ManagedDepartment?.Name}");
            //    Console.WriteLine($"Employee Department Name : {employee1.EmployeeDepartment?.Name}");
            //} 
            #endregion

            #region Using ThenInclude method to load the related data with the main data in one request for many to many relationship

            //var employee1 = dbContext.Employees.Include(E => E.EmployeeDepartment) // in this part we in Department class we have a navigation property to Employee class called Manager
            //    .ThenInclude(D=>D.Manager).FirstOrDefault(E => E.Id == 17);
            //if (employee1 is not null)
            //{
            //    Console.WriteLine($"Employee Name : {employee1.Name}");
            //    Console.WriteLine($"Employee Id : {employee1.Id}");
            //    Console.WriteLine($"Employee Department Name : {employee1.EmployeeDepartment?.Name}");
            //    Console.WriteLine($"Employee Department Manager Name : {employee1.EmployeeDepartment?.Manager?.Name}");

            //}

            #endregion


            #region Get All Employees that in HR Department

            //var department = dbContext.Set<Department>().Include(D=>D.Employees).FirstOrDefault(D => D.Name == "HR");
            //if (department != null)
            //{
            //    Console.WriteLine($"Department Name : {department.Name}");  
            //    Console.WriteLine($" Department Creation Date : {department.DateOfCreation}");
            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine($"Employee Name : {employee.Name}");
            //        Console.WriteLine("--------------------------------------------------");
            //    }
            //}

            #endregion

            #region MyRegion


            var departments = dbContext.Set<Department>().Include(D => D.Employees).Where(D => D.Name == "HR")
                .Select(x => new {DeptName=x.Name,x.Employees}); // Select only the name of the department and the employees of the department
            if (departments != null)
            {
                foreach (var item in departments)
                {
                    Console.WriteLine($"Department Name : {item.DeptName}");
                    foreach (var employee in item.Employees)
                    {
                        Console.WriteLine($"Employee Name : {employee.Name}");
                        Console.WriteLine("--------------------------------------------------");
                    }
                } 


            }

            #endregion


            #endregion


























        }
    }
}
   