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
                Name="Asmaa",
                Age=20,
                Address="Cairo",
                Salary=10000,
                StartDate =DateTime.Now,
            };

            PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            {
                Name = "Ahmed",
                Age = 25,
                Address = "Giza",
                HourRate = 100,
                CountOfHours = 30
            };


            using MyCompanyDbContext dbContext = new ();

            //Console.WriteLine($"{dbContext.Entry(fullTimeEmployee).State}");
            //Console.WriteLine($"{dbContext.Entry(partTimeEmployee).State}");

            //dbContext.PartTimeEmployees.Add(partTimeEmployee);

            //dbContext.Set<FullTimeEmployee>().Add(fullTimeEmployee);

            //Console.WriteLine($"{dbContext.Entry(fullTimeEmployee).State}");
            //Console.WriteLine($"{dbContext.Entry(partTimeEmployee).State}");

            //dbContext.SaveChanges();

            //Console.WriteLine($"{dbContext.Entry(fullTimeEmployee).State}");
            //Console.WriteLine($"{dbContext.Entry(partTimeEmployee).State}");

            var partTimeEmployees = from p in dbContext.PartTimeEmployees 
                                    select p;
            foreach (var item in partTimeEmployees)
            {
                Console.WriteLine($"Name: {item.Name}, Age: {item.Age}, Address: {item.Address}, HourRate: {item.HourRate}, CountOfHours: {item.CountOfHours}");
            }


            var fullTimeEmployees = from p in dbContext.FullTimeEmployees
                                    select p;
            foreach (var item in fullTimeEmployees)
            {
                Console.WriteLine($"Name: {item.Name}, Age: {item.Age}, Address: {item.Address}, Salary: {item.Salary}, StartDate: {item.StartDate}");
            }




        }

    }
}
