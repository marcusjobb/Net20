namespace PurchasesAltVer
{
    using PurchasesAltVer.Helpers;

    using System;
    using System.Data;

    /// <summary>
    /// Main class
    /// </summary>
    internal static class Program
    {
        // Slumptalsgenerator
        internal static Random Random = new Random();

        /// <summary>
        /// Main metoden
        /// </summary>
        /// <param name="args"></param>
        internal static void Main()
        {
            // Definiera databasfilen
            Settings.Database = @".\Purchases.db";

            // Kolla om databasen finns, om ny databas skapats fyll på med demoinformation
            InitieraDatabas();

            // Flagga för att veta om den ska fortsätta att fråga
            bool KeepAsking;
            do
            {
                Console.WriteLine("Mata in Butik, Vara, Pris, Datum (åååå-mm-dd) (ej nödvändig fält)");
                Console.WriteLine("Tom rad avslutar inmatningarna");

                // Fråga användaren om data
                var input = Console.ReadLine();
                // Kolla om inputvärdet innehåller text
                KeepAsking = input.Length>0;
                if (KeepAsking)
                {
                    // Dela upp användarens kommaseparerade input
                    var split = InputHandler.HandleInput(input);

                    // Om längden är mindre än 2 då har användaren inte angett rätt mängd data
                    if (split.Length > 2)
                    {
                        // Hämta butikens namn från input
                        var store = split[0].Trim();

                        // Hämta varans namn från input
                        var item = split[1].Trim();

                        // Hämta varans pris från input och omvandla till double
                        double.TryParse(split[2].Trim(), out double price);

                        // Sätt standarddatum (idag)
                        var date = DateTime.Now.ToString("yyyy-MM-dd");

                        // Kolla om datum har angetts
                        if (split.Length == 4)
                        {
                            // försök att omvandla datumet i textform till datum
                            if (DateTime.TryParse(split[3], out DateTime newDate))
                            {
                                // omvandla datumet till föredragen format
                                date = newDate.ToString("yyyy-MM-dd");
                            }
                        }

                        // Spara inköpet
                        PurchaseHandler.InsertPurchase(store, item, price, date);
                    }
                    else
                    {
                        // Informera användaren att datan är felaktig
                        Console.WriteLine("Du angav felaktig data");
                        Console.WriteLine(" --> "+split[0]);
                        Console.WriteLine();
                    }
                }
                // Forsätt så länge som användaren vill
            } while (KeepAsking);

            // Rensa skärmen
            Console.Clear();
            // Visa statistik
            Console.WriteLine("Statistik");
            Console.WriteLine($"Antal köpta varor {PurchaseHandler.GetAmountOfPurchases()}");
            Console.WriteLine($"Totalt kostade det {PurchaseHandler.GetSumOfAllPurchases()} kr");
            Console.WriteLine("Totalt för butiker");

            // Hämta lista på butiker och hur mycket pengar som spenderats där
            var purchases = PurchaseHandler.GetPurchasesValueByStore();
            foreach (DataRow row in purchases)
            {
                Console.WriteLine($"{row["Name"]} - {row["Summa"]}:-");

                // Bonuskod! Ej nödvändigt men kul att göra
                // Hämta lista på alla varor från en butik
                var items = ItemHandler.GetItemsByStore(row["Name"].ToString());
                foreach (DataRow item in items)
                {
                    // Hämta namn på varan och se till att en är minst 15 tecken långt
                    var name = item["Name"].ToString().PadLeft(15);

                    // Hämta priset på varan och se till att den är minst 5 tecken långt
                    var price = (item["Price"].ToString() + ":-").PadRight(5);

                    // Skriv ut information och datum
                    Console.WriteLine($"  {name} - {price} {item["Date"]}");
                }
                // Lägg till en tomrad mellan varje butik
                Console.WriteLine();
            }
            // Lägg till tomrad för att debuggerns meddelande inte ska förstöra den snygga outputen
            Console.WriteLine();
        }

        /// <summary>
        /// Generera slumpvald datum
        /// </summary>
        /// <returns>Sträng med datum</returns>
        private static string GetRandomDate()
        {
            var year = 2016 + Random.Next(4);
            var month = Random.Next(1, 13);
            var day = Random.Next(1, 28);
            return new DateTime(year, month, day).ToString("yyyy-MM-dd");
        }

        private static void InitieraDatabas()
        {
            if (DBHandler.InitDatabase())
            {
                // Skapa tabeller
                DBHandler.CreateTable("Purchases", "ID INTEGER NOT NULL UNIQUE ", "ItemId INTEGER NOT NULL", "StoreId INTEGER NOT NULL", "Price REAL NOT NULL", "Date TEXT NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("Stores", "ID INTEGER NOT NULL UNIQUE", "Name TEXT NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("Items", "ID INTEGER NOT NULL UNIQUE", "Name TEXT NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");

                // Skapa butiker
                StoreHandler.InsertStore("Coop", "Ica", "Netto", "Lidl", "Bokus", "Adlibris", "SF Bokhandeln", "Kjell och Co", "Knas Ohlson", "Elgiganten", "H&M");

                // Skapa varor
                ItemHandler.InsertItem("Mjölk", "Kattmat", "ASUS Laptop", "Bröd", "Knäckebröd", "USB hub", "Bok");

                // Skapa demoinköp med slumpvalda datum
                PurchaseHandler.InsertPurchase("Coop", "Mjölk", 17.0, GetRandomDate());
                PurchaseHandler.InsertPurchase("Coop", "Smör", 26.0, GetRandomDate());
                PurchaseHandler.InsertPurchase("Coop", "Ost", 99.0, GetRandomDate());
                PurchaseHandler.InsertPurchase("Ica", "Bröd", 16.0, GetRandomDate());
                PurchaseHandler.InsertPurchase("Ica", "Mjölk", 17.0, GetRandomDate());
                PurchaseHandler.InsertPurchase("Ica", "Pålägg", 22.0, GetRandomDate());
                PurchaseHandler.InsertPurchase("Netto", "Mjölk", 17.0, GetRandomDate());
                PurchaseHandler.InsertPurchase("Netto", "Bröd", 16.0, GetRandomDate());
                PurchaseHandler.InsertPurchase("Adlibris", "Bok", 175, GetRandomDate());
                PurchaseHandler.InsertPurchase("Adlibris", "Bok", 234, GetRandomDate());
                PurchaseHandler.InsertPurchase("Bokus", "Bok", 127, GetRandomDate());
                PurchaseHandler.InsertPurchase("Bokus", "Bok", 36, GetRandomDate());
                PurchaseHandler.InsertPurchase("Netto", "Knäckabröd", 19, GetRandomDate());
                PurchaseHandler.InsertPurchase("Netto", "Mjölk", 19, GetRandomDate());
                PurchaseHandler.InsertPurchase("Kjell och Co", "USB Hub", 256, GetRandomDate());
                PurchaseHandler.InsertPurchase("Knas Ohlson", "Glödlampa", 79, GetRandomDate());
            }
        }
    }
}
