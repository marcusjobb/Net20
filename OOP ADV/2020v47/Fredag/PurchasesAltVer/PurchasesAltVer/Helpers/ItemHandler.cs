namespace PurchasesAltVer.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SQLite;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ItemHandler
    {
        /// <summary>
        /// Hämtar en varas ID, om varan inte finns så skapas den
        /// </summary>
        /// <param name="name">Namne på varan</param>
        /// <returns>Returnerar ID till varan</returns>
        public static long GetItemId(string name)
        {
            // Definiera SQL sökningen
            const string sql = "Select Id FROM Items where Name LIKE @name";

            // Sök efter varan
            var dt = DBHandler.GetDataTable(sql, "@name", name);

            // Kolla svaret för att veta om varan finns
            if (dt?.Rows.Count > 0)
            {
                // Returnera ID på varan
                return (long)dt.Rows[0]["Id"];
            }
            else
            {
                // Varan fanns inte, skapar en ny och returnera ny Id
                return InsertItem(name);
            }
        }

        /// <summary>
        /// Mata in flera varor (för användning vid initiering av databasen)
        /// </summary>
        /// <param name="items">En array av varor</param>
        /// <returns>ID till sista varan som sparades</returns>
        public static long InsertItem(params string[] items)
        {
            long retVal = 0;
            foreach (var store in items)
            {
                retVal = InsertItem(store);
            }
            return retVal;
        }

        /// <summary>
        /// Skapa en vara
        /// </summary>
        /// <param name="item">Varans namn</param>
        /// <returns>Id till varan som skapades</returns>
        public static long InsertItem(string item)
        {
            // Definiera SQL sträng
            const string sql = "INSERT INTO Items (Name) VALUES(@name)";

            // Identifiera databasfilen
            using (var conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                // Öppna filen och låt databasmotorn använda den
                conn.Open();

                //Hämta SQL kommando för att hantera SQL sträng och parametrar
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                //Sätt parameter för sökningen
                cmd.Parameters.AddWithValue("@name", item);

                // Exekvera SQL koden
                cmd.ExecuteNonQuery();

                // Returnera ID till sista posten som sparades
                return conn.LastInsertRowId;
            }
        }

        /// <summary>
        /// Hämta varor filtrerade på butiksnamn
        /// </summary>
        /// <param name="store">Butiksnamn</param>
        /// <returns>DataRow med varor från butiken</returns>
        internal static DataRowCollection GetItemsByStore(string store)
        {
            // Hämta ID till butiken
            var storeId = StoreHandler.GetStoreId(store);

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
    }
}
