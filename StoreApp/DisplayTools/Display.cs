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
                WriteCentered("Välj en butik (använd upp/ned piltangenter och tryck Enter):\n");

                // Visa butiker och markera vald butik
                for (int i = 0; i < stores.Count; i++)
                {
                    string prefix = "  "; // Two mellanslag unselected items

                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        prefix = "> "; // ">" symbol för vald item
                    }

                    WriteCentered(prefix + stores[i].Name);

                    // Återställ färger efter att ha markerat vald butik
                    Console.ResetColor();
                }

                // Lägg till en rad för att avsluta programmet
                string exitPrefix = "  ";
                if (selectedIndex == stores.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    exitPrefix = "> ";
                }
                Console.ForegroundColor = ConsoleColor.Red;
                WriteCentered(exitPrefix + "Exit");
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
                        WriteCentered("Tryck på valfri tangent för att återgå till menyn...");
                        Console.ReadKey(true);
                    }
                }
            }
            WriteCentered("Programmet avslutas. Tack för att du använde StoreApp!");
        }

        public static void DisplayStoreProducts(Store store)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteCentered($"Store: {store.Name}");
            Console.ResetColor();
            WriteCentered($"Opening Hours: {store.OpeningTime:HH:mm} - {store.ClosingTime:HH:mm}");
            WriteCentered("Products:");
            foreach (var product in store.GetProducts())
            {
                WriteCentered($"- {product.Name}: {product.Price} SEK");
            }
            Console.WriteLine();
        }

        public static void WriteCentered(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;
            int leftPadding = (windowWidth - textLength) / 2;

            // Ensure leftPadding is not negative
            if (leftPadding < 0) leftPadding = 0;

            string padding = new string(' ', leftPadding);
            Console.WriteLine(padding + text);
        }
    }
}
