namespace PurchasesAltVer.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StoreHandler
    {

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
                return InsertStore(name);
            }
        }

        /// <summary>
        /// Mata in flera Butiker (för användning vid initiering av databasen)
        /// </summary>
        /// <param name="storeNames">En array av butiksnamn</param>
        /// <returns>ID till sista butiken som sparades</returns>
        public static long InsertStore(params string[] storeNames)
        {
            // Sätt standarvärde
            long retVal = 0;
            // Loopa igenom alla objekt i arrayen
            foreach (var store in storeNames)
            {
                // Skapa butik och kom ihåg Id till den
                retVal = InsertStore(store);
            }

            // Returnera Id till sista butiken som skapades
            return retVal;
        }

        /// <summary>
        /// Skapa en butik
        /// </summary>
        /// <param name="storeName">Butikens namn</param>
        /// <returns>Id till butiken som skapades</returns>
        public static long InsertStore(string storeName)
        {
            // Definiera sökningen
            const string sql = "INSERT INTO Stores (Name) VALUES(@name)";

            // Identifiera databasfilen
            using (var conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                // Öppna filen och låt databasmotorn hantera den
                conn.Open();

                // Hämta en SQL-commando från SQLite för att hantera SQL strängen och parameter
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                // Lägg in parametern
                cmd.Parameters.AddWithValue("@name", storeName);

                // Exekvera SQL strängen
                cmd.ExecuteNonQuery();

                // Returnera ID till senaste butik som sparats
                return conn.LastInsertRowId;
            }
        }
    }
}
