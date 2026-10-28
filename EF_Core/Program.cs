using EF_Core.Data;
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

            //   dbContext.Database.Migrate(); if the app is deploymented
          
            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll; // Defualt

            //dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // if you read only from Database

            #region Create
            Create(dbContext );
            #endregion

            #region Read
            Read(dbContext);
            #endregion

            #region Update
            Update(dbContext);
            #endregion

            #region Delete
            Delete(dbContext);
            #endregion




        }
    }
}
   