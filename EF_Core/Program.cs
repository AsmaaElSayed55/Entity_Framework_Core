using EF_Core.Data;
using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;

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


            #region Select Only Part of Data By Using Select Method


            //var departments = dbContext.Set<Department>().Include(D => D.Employees).Where(D => D.Name == "HR")
            //    .Select(x => new {DeptName=x.Name,x.Employees}); // Select only the name of the department and the employees of the department
            //if (departments != null)
            //{
            //    foreach (var item in departments)
            //    {
            //        Console.WriteLine($"Department Name : {item.DeptName}");
            //        foreach (var employee in item.Employees)
            //        {
            //            Console.WriteLine($"Employee Name : {employee.Name}");
            //            Console.WriteLine("--------------------------------------------------");
            //        }
            //    } 


            //}

            #endregion


            #endregion

            #region Loading - Explicit Loading

            // Get Employee with id 5, then get employee department

            #region Load Navigational Property One
            //var employee = dbContext.Employees.FirstOrDefault(E => E.Id == 15);

            //if (employee is not null)
            //{
            //    Console.WriteLine($"Employee Name ==> {employee.Name}");
            //    Console.WriteLine($"Department Id ==> {employee.DepartmentId}"); // FK 

            //    // Explicit Loading
            //    dbContext.Entry(employee).Reference(E => E.EmployeeDepartment).Load(); // Reference for one to one or one to many relationship

            //    Console.WriteLine($"Department Name ==> {employee.EmployeeDepartment?.Name}"); // Navigation Property

            //} 
            #endregion



            #region  Load Navigational Property Many 

            //var department = dbContext.Set<Department>().FirstOrDefault(D => D.Id == 1);

            //if (department is not null)
            //{
            //    Console.WriteLine($"Department Name ==> {department.Name}");
            //    Console.WriteLine($"Department Id ==> {department.Id}"); 

            //    // Explicit Loading
            //    dbContext.Entry(department).Collection(D => D.Employees).Load(); // Collection for one to many relationship
            //    // use 2 requests, one to load the department and one to load the employees

            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine($"Employee Name ==> {employee.Name}");
            //    }

            //}


            #endregion


            #region Put Condition On Navigational Property

            //var department = dbContext.Set<Department>().FirstOrDefault(D => D.Id == 1);

            //if (department is not null)
            //{
            //    Console.WriteLine($"Department Name ==> {department.Name}");
            //    Console.WriteLine($"Department Id ==> {department.Id}");

            //    // Explicit Loading
            //    dbContext.Entry(department).Collection(D => D.Employees).Query().Where(E => E.Age > 29).Load(); // use Query to turn into IQueryable to Can Use conditions

            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine($"Employee Name ==> {employee.Name}");
            //    }

            //}

            #endregion

            #endregion

            #region Loading - Lazy Loading (Most Common Used)

            // it like Explicit Loading that it load the related data with 2 requests

            // easy to use, but it will send a request to the database every time you access a navigation property, so it will be a lot of requests to the database, so it is not recommended to use it in production, but it is good for learning and testing


            // Loading Steps
            // 1] Install Microsoft.EntityFrameworkCore.Proxies package
            // 2] Enable Lazy Loading in OnConfiguring Method in DbContext Class
            // 3] Make Navigation Properties Virtual & Classes public or internal to be able to override them and create proxy classes



            // How Lazy Loading Works 
            // 1. for each model class, EF Core creates a proxy class that inherits from the model class and overrides the navigation properties to load the related data when accessed.


            //var employee = dbContext.Employees.FirstOrDefault(E => E.Id == 15);

            //if (employee is not null)
            //{
            //    Console.WriteLine($"Employee Name ==> {employee.Name}");
            //    Console.WriteLine($"Department Name ==> {employee.EmployeeDepartment?.Name}");
            //    Console.WriteLine($"Department Id ==> {employee.EmployeeDepartment?.Id}");
            //    // once we enabled Lazy Loading,I can access the navigation property, EF Core will send a request to the database to load the related data and cache it in the navigation property, so the next time we access the navigation property, it will return the cached data without sending a request to the database.

            //}

            //// Get the department of the employee with id 1, then get the employees of the department

            //var department = dbContext.Set<Department>().FirstOrDefault(D => D.Id == 1);
            //if(department is not null)
            //{
            //    Console.WriteLine($"Department Name ==> {department.Name}");
            //    Console.WriteLine($"Department Creation Date ==> {department.DateOfCreation}");
            //    foreach (var emp in department.Employees)
            //    {
            //        Console.WriteLine($"Employee Name ==> {emp.Name}");
            //    }
            //}

            #endregion


            #region Join Operators

            // join operators are used to combine data from two or more tables based on a related column between them.
            // work with Enumerable and IQueryable, but it is better to use IQueryable because it will be translated to SQL query and executed on the database server, so it will be more efficient than Enumerable that will be executed on the client side after getting all data from the database.

            #region Join (Inner Join)

            // ******* Inner Join Department & Employee Tables

            // Fluent Syntax 

            var result = dbContext.Set<Department>() // Department Table call Outer
                .Join(dbContext.Employees,
                D => D.Id,
                E => E.DepartmentId, (D, E) // D is the outer table and E is the inner table
                => new 
                {
                    DeptId=D.Id,
                    DeptName=D.Name,
                    EmpId=E.Id,
                    EmployeeName =E.Name

                }); // Employee Table call Inner
                    // Join is not Linq Method, it is a extension method that there is in a class, it used as helper method 

            // Query Syntax
            result=from D in dbContext.Set<Department>()
                     join E in dbContext.Employees
                     on D.Id equals E.DepartmentId
                     select new
                     {
                         DeptId = D.Id,
                         DeptName = D.Name,
                         EmpId = E.Id,
                         EmployeeName = E.Name
                     };


            foreach (var item in result)
            {
                Console.Write($"Department Id : {item.DeptId} ");
                Console.Write($"Department Name : {item.DeptName} ");
                Console.Write($"Employee Id : {item.EmpId} ");
                Console.Write($"Employee Name : {item.EmployeeName}");
                Console.WriteLine("--------------------------------------------------");
            }

            // Fluent Syntax
            var Result =dbContext.Employees
                .Join(dbContext.Set<Department>(),
                E=>E.Id,D=>D.ManagerId,(E,D)=>new
                {
                    EmployeeName=E.Name,
                    DepartmentId=D.Id,
                    DepartmentName=D.Name
                });


            // Query Syntax
            Result=from e in dbContext.Employees
                   join d in dbContext.Set<Department>()
                   on e.Id equals d.ManagerId
                     select new
                     {
                          EmployeeName = e.Name,
                          DepartmentId = d.Id,
                          DepartmentName = d.Name
                     };

            foreach (var item in Result)
            {
                Console.Write($"Employee Name : {item.EmployeeName} ");
                Console.Write($"Department Id : {item.DepartmentId} ");
                Console.Write($"Department Name : {item.DepartmentName}");
                Console.WriteLine("--------------------------------------------------");
            }

            #endregion



            #region GroupJoin (Left Outer Join , Grouping)


            #region Left Outer Join 



            #endregion





            #region Grouping



            #endregion




            #endregion


            #endregion



















        }
    }
}
