namespace PurchasesAltVer.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SQLite;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class PurchaseHandler
    {
        /// <summary>
        /// Hämta antal inköp som gjorts
        /// </summary>
        /// <returns>Antalet</returns>
        internal static long GetAmountOfPurchases()
        {
            // Definiera SQL string
            const string sql = "SELECT Count(StoreId) from Purchases";

            // Hämta en DataTable
            var dt = DBHandler.GetDataTable(sql);

            // Kolla om DataTablen innehåller något
            if (dt.Rows.Count > 0)
            {
                // Returnera antal inköp
                return (long)dt.Rows[0][0];
            }

            // Returnera noll, då inget fanns i databasen
            return 0;
        }

        /// <summary>
        /// Hämta varor filtrerade på butiksnamn
        /// </summary>
        /// <param name="store">Butiksnamn</param>
        /// <returns>DataRow med varor från butiken</returns>
        internal static DataRowCollection GetItemsByStore(string store)
        {
            // Hämta ID till butiken
            var storeId = GetStoreId(store);

            // Definiera en sökning
            var sql = $@"
                SELECT Items.Name, Purchases.Price, Purchases.Date
                FROM Purchases
                JOIN Stores ON Purchases.StoreId=Stores.ID
                JOIN Items ON Purchases.ItemId=Items.ID
                WHERE Purchases.StoreId = {storeId}
                ORDER BY date
                ";

            // Returnera Rows från Datatablen som kommer från Sökningen
            return DBHandler.GetDataTable(sql)?.Rows;
        }

        /// <summary>
        /// Hämta summan av inköp per butik
        /// </summary>
        /// <returns>Tabell med Butiksnamn och Summan av inköpen per butik</returns>
        internal static DataRowCollection GetPurchasesValueByStore()
        {
            const string sql = @"Select Name, SUM(Price) AS Summa From Stores
                        JOIN Purchases On Purchases.StoreId = Stores.ID
                        GROUP BY Name
                        ORDER BY Summa DESC";

            // Returnera rader från DataTablen
            return DBHandler.GetDataTable(sql).Rows;
        }

        /// <summary>
        /// Hämta summan av alla inköp
        /// </summary>
        /// <returns>En Double med summan</returns>
        internal static double GetSumOfAllPurchases()
        {
            // Definiera SQL Sträng
            const string sql = "Select SUM(price) From Purchases";

            // Gör sökning
            var dt = DBHandler.GetDataTable(sql);

            // Kontrollera att vi fått svat
            if (dt.Rows.Count > 0)
            {
                // Returnera värdet på totalsumman
                return (double)dt.Rows[0][0];
            }

            // Om vi inte fick något i svaret (för att det inte finns information i databasen), returnera noll
            return 0;
        }

        /// <summary>
        /// Spara ett inköp
        /// </summary>
        /// <param name="store">Butiksnamn</param>
        /// <param name="item">Varans namn</param>
        /// <param name="price">Varans pris</param>
        /// <param name="date">Datum för inköp</param>
        /// <returns>Id till senast inmatad post</returns>
        internal static long InsertPurchase(string store, string item, double price, string date)
        {
            // Hämta butiksId från namnet
            var storeId = GetStoreId(store);
            // Hämta Varans Id från namnet
            var itemId = ItemHandler.GetItemId(item);
            // Returnera Id från senast sparade post
            return InsertPurchase(storeId, itemId, price, date);
        }

        /// <summary>
        /// Hämtar en Butiks ID, om butiken inte finns så skapas den
        /// </summary>
        /// <param name="name">Namn på butiken</param>
        /// <returns>Returnerar ID till butiken</returns>
        public static long GetStoreId(string name)
        {
            // Definiera sökningen
            const string sql = "Select Id FROM Stores where Name LIKE @name";

            // Gör sökningen
            var dt = DBHandler.GetDataTable(sql, "@name", name);

            // Kontrollera om butiken hittades
            if (dt?.Rows.Count > 0)
            {
                // Ja, den fanns, Returnera Id
                return (long)dt.Rows[0]["Id"];
            }
            else
            {
                // Nej den fanns inte, skapa den och returnera Id
                return StoreHandler.InsertStore(name);
            }
        }

        /// <summary>
        /// Spara ett inköp
        /// </summary>
        /// <param name="store">Butiks Id</param>
        /// <param name="item">Varans Id</param>
        /// <param name="price">Varans pris</param>
        /// <param name="date">Datum för inköp</param>
        /// <returns>Id till senast inmatad post</returns>
        internal static long InsertPurchase(long store, long item, double price, string date)
        {
            // Definiera SQL-strängen
            const string sql = "INSERT INTO Purchases (StoreId, ItemId, Price, Date) VALUES(@storeId,@itemId,@price,@date)";

            // Identifiera databasfilen
            using (var conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                // Öppna filen och låt databasmotorn hantera det
                conn.Open();

                // Hämta SQL commando för att hantera SQL-sträng och parameter
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                // Ange parametrar
                cmd.Parameters.AddWithValue("@storeId", store);
                cmd.Parameters.AddWithValue("@itemId", item);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@date", date);

                // Exekvera SQL koden
                cmd.ExecuteNonQuery();

                // Returnera Id till senast sparade post
                return conn.LastInsertRowId;
            }
        }
    }
}
