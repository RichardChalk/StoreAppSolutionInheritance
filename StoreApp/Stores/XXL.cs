using StoreApp.Products;

namespace StoreApp.Stores
{
    // Subclass XXL
    public class XXL : Store
    {
        public XXL(string name, TimeOnly openingTime, TimeOnly closingTime)
            : base(name, openingTime, closingTime)
        {
        }

        public override List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Name = "Running Shoes", Price = 1000m },
                new Product { Name = "Jacket", Price = 1500m },
                new Product { Name = "Backpack", Price = 800m }
            };
        }
    }
}
