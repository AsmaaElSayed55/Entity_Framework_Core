
using DatabaseFirst.Data;

namespace DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MyNorthwindDbContext dbContext = new MyNorthwindDbContext();

            #region Database First (Reverse Engineering)
            // Database First Steps
            // 1. Install EF Core Packages
            // 2. Scaffold the Entities and DbContext

            // Scaffold-DbContext
            // -Connection "Server=.;Database=Northwind;Trusted_Connection=true;TrustServerCertificate=true"
            // -Provider Microsoft.EntityFrameWorkCore.SqlServer
            // -Schemas "Choose Specific Schema"
            // -Tables "TableName" , "Another TableName"
            // -Context "Name of Class DbContext"
            // -ContextDir "Folder of Contexts"
            // -OutputDir "Folder of Entities-Models"
            // -DataAnnotations

            /*
             Scaffold-DbContext -Connection "Server=.;Database=Northwind;Trusted_Connection=true;TrustServerCertificate=true" -Provider "Microsoft.EntityFrameWorkCore.SqlServer" -Context "MyNorthwindDbContext" -ContextDir "Data" -OutputDir "Data/Models" -Tables "Customers","Employees","Products","Orders","Categories","Products by Category"
             */
            #endregion

            #region Get Employees Data


            //var result = dbContext.Employees.ToList();
            //foreach (var employee in result)
            //{
            //    Console.WriteLine($"{employee.FirstName}  {employee.LastName}");
            //}



            #endregion

            #region MyRegion

            var result = dbContext.Employees.ToList();
            foreach (var employee in result)
            {
                Console.WriteLine($"{employee.FirstName}  {employee.LastName}");
            }


            var Result= dbContext.Suppliers.ToList();
            foreach (var supplier in Result)
            {
                Console.WriteLine($"{supplier.ContactName} == {supplier.CompanyName}");
            }

            #endregion

        }
    }
}
