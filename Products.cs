namespace ORM_and_Dapper_Exercise
{
    public class Products
    {
        public Products()
        {
            name = string.Empty;
        }

        public int productId { get; set; }

        public string name { get; set; }

        public double price { get; set;}

        public int categoryId { get; set; }

        public bool onSale { get; set; }

        public int stockLevel { get; set; }

    }
}
