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

        var departments = repo.GetAllDepartments();
        var products = repoProducts.GetAllProducts();


        Console.WriteLine("Here is a list of departments");
        foreach (var department in departments)
        {
            Console.WriteLine(department.Name);
        }

        Console.WriteLine("Would you like to create a new department? [yes/no] ");
        switch (Console.ReadLine().ToLower())
        {
            case "yes":
                Console.WriteLine("Type a new Department name");
                var newDepartment = Console.ReadLine();

                if (newDepartment != null)
                {
                    repo.InsertDepartment(newDepartment);
                }
                else
                {
                    Console.WriteLine("No Department name was supplied, we will proceed."); 
                }
            break;
        }
            
                              
        var newProductName = "DELL XPS 9510";
        var newProductPrice = 1499.99d;
        var newProductCategoryId = 2;
        repoProducts.CreateProduct(newProductName, newProductPrice, newProductCategoryId);
        
        var productToUpdate = products.Where(x => x.productId == 1).ToList();

        repoProducts.UpdateInventory(productToUpdate[0].productId, (productToUpdate[0].stockLevel-1));
        Console.ReadLine();
    }

}