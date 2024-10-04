using System;
using System.Collections.Generic;
using StoreApp.DisplayTools;
using StoreApp.Stores;

namespace StoreApp
{

    class Program
    {
        static void Main(string[] args)
        {
            // Eftersom Main() är statisk, begränsar det din flexibilitet
            // när du arbetar med objekt och tillstånd.
            // Därför är det en bra idé att hålla Main() enkel och
            // snabbt överlåta programflödet till instansbaserade
            // klasser och metoder för bättre design, testbarhet och
            // underhållbarhet.

            var app = new App();
            app.Run();
        }
    }
}
