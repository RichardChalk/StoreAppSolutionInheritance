using StoreApp.Products;

namespace StoreApp.Stores
{
    // Base class Store
    public abstract class Store
    {
        public string Name { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }

        public Store(string name, TimeOnly openingTime, TimeOnly closingTime)
        {
            Name = name;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }

        public virtual List<Product> GetProducts()
        {
            // Optionally throw an exception to enforce overriding
            throw new NotImplementedException("This method should be overridden in a subclass.");
        }
    }
}
