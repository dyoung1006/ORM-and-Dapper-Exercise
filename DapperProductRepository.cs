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
        public void CreateProduct(string name, double price, int catetoryId)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                        new { name = name, price = price, catetoryId = catetoryId });
        }
        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM products;").ToList();
        }
    }
}
