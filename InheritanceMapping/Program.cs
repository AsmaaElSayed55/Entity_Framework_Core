using InheritanceMapping.Data;
using InheritanceMapping.Data.Models;

namespace InheritanceMapping
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            {
                Name = "Asmaa",
                Age = 20,
                Address = "Cairo",
                Salary = 10000,
                StartDate = DateTime.Now,
            };

            PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            {
                Name = "Ahmed",
                Age = 25,
                Address = "Giza",
                HourRate = 100,
                CountOfHours = 30
            };


            using MyCompanyDbContext dbContext = new();

            //Console.WriteLine($"{dbContext.Entry(fullTimeEmployee).State}");
            //Console.WriteLine($"{dbContext.Entry(partTimeEmployee).State}");

            //dbContext.PartTimeEmployees.Add(partTimeEmployee);

            //dbContext.Set<FullTimeEmployee>().Add(fullTimeEmployee);

            //Console.WriteLine($"{dbContext.Entry(fullTimeEmployee).State}");
            //Console.WriteLine($"{dbContext.Entry(partTimeEmployee).State}");

            //dbContext.SaveChanges();

            //Console.WriteLine($"{dbContext.Entry(fullTimeEmployee).State}");
            //Console.WriteLine($"{dbContext.Entry(partTimeEmployee).State}");

            //var partTimeEmployees = from p in dbContext.PartTimeEmployees 
            //                        select p;
            //foreach (var item in partTimeEmployees)
            //{
            //    Console.WriteLine($"Name: {item.Name}, Age: {item.Age}, Address: {item.Address}, HourRate: {item.HourRate}, CountOfHours: {item.CountOfHours}");
            //}


            //var fullTimeEmployees = from p in dbContext.FullTimeEmployees
            //                        select p;
            //foreach (var item in fullTimeEmployees)
            //{
            //    Console.WriteLine($"Name: {item.Name}, Age: {item.Age}, Address: {item.Address}, Salary: {item.Salary}, StartDate: {item.StartDate}");
            //}


            //  dbContext.Employees.Add(fullTimeEmployee);
            //   dbContext.Add(partTimeEmployee);

            //  dbContext.SaveChanges();

            var employees = dbContext.Employees.ToList();
            if (employees.Count > 0)
            {

                foreach (var employee in employees.OfType<FullTimeEmployee>())
                {

                    Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Address: {employee.Address}, Salary: {employee.Salary}, StartDate: {employee.StartDate}");
                }

                foreach (var employee in employees.OfType<PartTimeEmployee>())
                {
                    Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Address: {employee.Address}, HourRate: {employee.HourRate}, CountOfHours: {employee.CountOfHours}");
                }


            }

            var Emps = dbContext.Employees.Where(E=>E.Age > 20); // Condition to filter employees with Age greater than 20
            if (Emps.Count() > 0)
            {

                foreach (var employee in Emps.OfType<FullTimeEmployee>())
                {

                    Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Address: {employee.Address}, Salary: {employee.Salary}, StartDate: {employee.StartDate}");
                }
            }

            
        }

        
    }
}
