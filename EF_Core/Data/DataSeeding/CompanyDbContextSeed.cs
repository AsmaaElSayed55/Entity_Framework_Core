using EF_Core.Data.Models;
using System.Text.Json;

namespace EF_Core.Data.DataSeeding
{
    internal static class CompanyDbContextSeed
    {
        public static bool SeedData(CompanyDbContext dbContext)
        {
            try
            {
                if (!dbContext.Employees.Any())
                {
                    //  var EmpsData = File.ReadAllText("C:\\D\\Projects\\Entity_Framework_Core\\EF_Core\\Data\\DataSeeding\\employees.json");

                    var EmpsData = File.ReadAllText("Files\\employees.json"); // as json file is in the same directory as the executable, we can use a relative path
                    // json => C# object --> Deserialize
                    // C #=> json object --> Serialize
                    var employees = JsonSerializer.Deserialize<List<Employee>>(EmpsData); // Deserialize the json data to a list of Employee objects
                    //foreach (var emp in employees)
                    //{
                    //    dbContext.Employees.Add(emp);
                    //} 

                    // if you want to add a list of objects to the database, you can use the AddRange method instead of a foreach loop

                    if (employees != null && employees.Count > 0)
                    {
                        dbContext.Employees.AddRange(employees); // Add the list of Employee objects to the database

                        dbContext.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
