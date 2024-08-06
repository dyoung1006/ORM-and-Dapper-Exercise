using Dapper;
using System.Data;

namespace ORM_and_Dapper_Exercise
{
    public class DapperProductRepository : IProductsRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryId)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                        new { name = name, price = price, categoryID = categoryId });
        }
        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM products;");
        }

        public void UpdateInventory(int productId, int newStockLevel)
        {
            _connection.Execute("UPDATE products SET stocklevel = @stockLevel WHERE ProductID = @ProductId;",
                        new { stockLevel = newStockLevel, productId = productId });   
        }
    }
}
