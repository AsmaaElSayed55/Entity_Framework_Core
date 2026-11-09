
using DatabaseFirst.Data;
using Microsoft.EntityFrameworkCore;

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

            #region Get Data (Restored by EFCore power tools)

            //var result = dbContext.Employees.ToList();
            //foreach (var employee in result)
            //{
            //    Console.WriteLine($"{employee.FirstName}  {employee.LastName}");
            //}


            //var Result= dbContext.Suppliers.ToList();
            //foreach (var supplier in Result)
            //{
            //    Console.WriteLine($"{supplier.ContactName} == {supplier.CompanyName}");
            //}

            #endregion

            #region Row SQL

            #region DQL (Select)

            // 2 methods 
            // 1. FromSqlRaw()
            // 2. FromSQLInterpolated()

            // Get All Products
            //var products= dbContext.Products.FromSqlRaw("Select * from Products where CategoryID = 1");
            // foreach (var product in products)
            // {
            //     Console.WriteLine($"{product.ProductName}  {product.UnitPrice}");
            // }

            // var categoryId = 4;
            // products = dbContext.Products.FromSqlRaw("Select * from Products where CategoryID = {0}", categoryId); // if the condition changes 

            //var region = "WA";
            //var employees= dbContext.Employees.FromSqlInterpolated($"select * from Employees where Region = {region}"); // you must put $

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($"{employee.LastName} {employee.LastName}");
            //}

            //var productName = "Pens";
            //var products= dbContext.Products.FromSqlInterpolated($"Select * from Products where ProductName = {productName}");

            //foreach (var product in products)
            //{
            //    Console.WriteLine($"{product.ProductName} {product.UnitPrice}");
            //}

            #endregion

            #region DML (Insert, Update, Delete)

            // 2 methods
            // 1. ExecuteSqlRaw()
            // 2. ExecuteSqlInterpolated()

            var numOfRaws=dbContext.Database.ExecuteSqlRaw("Update Products Set ProductName = 'Icelatte' where ProductID = 1");

            Console.WriteLine(numOfRaws);


            var productId = 89;
            numOfRaws = dbContext.Database.ExecuteSqlRaw("Update Products Set ProductName = 'Icelatte' where ProductID = {0}", productId); // if condition changes , will be executed using stored procedure

            var numOfRawsDeleted = dbContext.Database.ExecuteSqlInterpolated($"Delete from Products where ProductID = {productId}");

            Console.WriteLine(numOfRawsDeleted);

            #endregion



            #endregion

        }
    }
}
