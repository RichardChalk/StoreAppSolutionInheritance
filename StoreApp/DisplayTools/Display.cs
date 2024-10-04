using StoreApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DisplayTools
{
    public static class Display
    {
        public static void ShowMenu(List<Store> stores)
        {
            int selectedIndex = 0;
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Välj en butik (använd upp/ned piltangenter och tryck Enter):\n");

                // Visa butiker och markera vald butik
                for (int i = 0; i < stores.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(stores[i].Name);

                    // Återställ färger efter att ha markerat vald butik
                    Console.ResetColor();
                }

                // Lägg till en rad för att avsluta programmet
                if (selectedIndex == stores.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exit");
                Console.ResetColor();

                
                // Läs tangenttryckning
                var keyInfo = Console.ReadKey(true);

                // Hantera piltangenterna med enklare uttryck
                // Vad är fördelen med detta sätt?
                // (vi slipper 'try catch'!)
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--; // Minska indexet
                    if (selectedIndex < 0)
                    {
                        selectedIndex = stores.Count; // Om vi går förbi början, hoppa till sista alternativet (Exit)
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++; // Öka indexet
                    if (selectedIndex > stores.Count)
                    {
                        selectedIndex = 0; // Om vi går förbi slutet, hoppa till första alternativet
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    // Detta motsvarar 'Exit' alternativet
                    if (selectedIndex == stores.Count)
                    {
                        running = false; // Exit-programmet
                    }
                    else
                    {
                        Console.Clear();
                        DisplayStoreProducts(stores[selectedIndex]);
                        Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
                        Console.ReadKey(true);
                    }
                }
            }
            Console.WriteLine("Programmet avslutas. Tack för att du använde StoreApp!");
        }

        public static void DisplayStoreProducts(Store store)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Store: {store.Name}");
            Console.ResetColor();
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
