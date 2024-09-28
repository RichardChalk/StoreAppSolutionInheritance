using StoreApp.Products;

namespace StoreApp.Stores
{
    // Subclass Ica
    public class Ica : Store
    {
        public Ica(string name, TimeOnly openingTime, TimeOnly closingTime)
            : base(name, openingTime, closingTime)
        {
        }

        public override List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Name = "Milk", Price = 10m },
                new Product { Name = "Bread", Price = 15m },
                new Product { Name = "Eggs", Price = 20m }
            };
        }
    }
}
