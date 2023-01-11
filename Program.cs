using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_and_Dapper_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

        var connString = config.GetConnectionString("DefaultConnection");
        
        IDbConnection conn = new MySqlConnection(connString);

        var repo = new DapperDepartmentRepository(conn);
        var repoProducts = new DapperProductRepository(conn);

        Console.WriteLine("Type a new Department name");
        var newDepartment = Console.ReadLine();

        repo.InsertDepartment(newDepartment);

        var departments = repo.GetAllDepartments();
        var products = repoProducts.GetAllProducts();

        foreach (var department in departments) 
        {
            Console.WriteLine(department.Name);
        }

        var newProductName = "DELL XPS 9510";
        var newProductPrice = 1499.99d;
        var newProductCategoryId = 2;
        repoProducts.CreateProduct(newProductName, newProductPrice, newProductCategoryId);

    }

}