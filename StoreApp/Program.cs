using System;
using System.Collections.Generic;
using StoreApp.Stores;

namespace StoreApp
{

    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of each store with TimeOnly for opening and closing times
            Store elGiganten = new ElGiganten("ElGiganten", new TimeOnly(9, 0), new TimeOnly(21, 0));
            Store ica = new Ica("Ica", new TimeOnly(8, 0), new TimeOnly(20, 0));
            Store xxl = new XXL("XXL", new TimeOnly(10, 0), new TimeOnly(22, 0));

            // Add my stores to a list
            var myStores = new List<Store>();   
            myStores.Add(elGiganten);
            myStores.Add(ica);
            myStores.Add(xxl);

            // Display products for each store
            foreach (var store in myStores) 
            {
                DisplayStoreProducts(store);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static void DisplayStoreProducts(Store store)
        {
            Console.WriteLine($"Store: {store.Name}");
            Console.WriteLine($"Opening Hours: {store.OpeningTime:HH:mm} - {store.ClosingTime:HH:mm}");
            Console.WriteLine("Products:");
            foreach (var product in store.GetProducts())
            {
                Console.WriteLine($"- {product.Name}: {product.Price} SEK");
            }
            Console.WriteLine();
        }
    }
}
