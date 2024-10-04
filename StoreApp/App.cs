using StoreApp.DisplayTools;
using StoreApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class App
    {
        public void Run()
        {
            // Add my stores to a list
            var myStores = new List<Store>()
            {
                new ElGiganten("ElGiganten", new TimeOnly(9, 0), new TimeOnly(21, 0)),
                new Ica("Ica", new TimeOnly(8, 0), new TimeOnly(20, 0)),
                new XXL("XXL", new TimeOnly(10, 0), new TimeOnly(22, 0))
            };

            // Anropa menyn
            // ?? Varför behöver jag inte skapa en instans?
            Display.ShowMenu(myStores);
        }
    }
}
