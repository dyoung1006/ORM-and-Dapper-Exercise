
namespace ORM_and_Dapper_Exercise
{
    public interface IProductsRepository
    {
        IEnumerable<Products> GetAllProducts();

        void CreateProduct(string name, double price, int catetoryId);
    }
}
