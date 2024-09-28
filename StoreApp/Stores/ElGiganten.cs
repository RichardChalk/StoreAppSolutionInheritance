using StoreApp.Products;

namespace StoreApp.Stores
{
    // Subclass ElGiganten
    public class ElGiganten : Store
    {
        public ElGiganten(string name, TimeOnly openingTime, TimeOnly closingTime)
            : base(name, openingTime, closingTime)
        {
        }

        public override List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Name = "TV", Price = 5000m },
                new Product { Name = "Laptop", Price = 8000m },
                new Product { Name = "Smartphone", Price = 6000m }
            };
        }
    }
}
