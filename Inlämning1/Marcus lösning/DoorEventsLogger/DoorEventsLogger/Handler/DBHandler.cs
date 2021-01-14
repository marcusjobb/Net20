namespace DoorEventsLogger.Handler
{
    using DoorEventsLogger;

    using System;
    using System.Data;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Databashanterare, i den här classen finns alla metoder som tar hand om
    /// kommunikation med databasen.
    /// </summary>
    public static class DBHandler
    {
        /// <summary>
        /// Skapar en tabell
        /// Den här metoden använder inte parameters för att man får hoppas att programmet aldrig
        /// låter användaren bestämma själv vad tabellerna ska heta!
        /// (Man kan inte använda parameters för tabellnamn och fältnamn).
        /// </summary>
        /// <param name="name">Tabellnamn.</param>
        /// <param name="fields">Fält och Index definieringar.</param>
        public static void CreateTable(string name, params string[] fields)
        {
            string sql = $"CREATE TABLE IF NOT EXISTS \"{name}\" ({AddFields(fields)});";
            Debug.WriteLine(sql);
            Console.WriteLine($"Created table {name}");
            ExecuteSQL(sql);
        }

        /// <summary>
        /// Exekverar SQL Sträng i databasen.
        /// </summary>
        /// <param name="sql">SQL sträng.</param>
        /// <param name="values">Parameter kommaseparerade ["@name", "My name"] .</param>
        /// <returns>Returnerar Id av senaste skapad rad<see cref="long"/>.</returns>
        public static long ExecuteSQL(string sql, params string[] values)
        {
            // Identifiera databasfilen
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                // Öppna filen och låt databasmotorn hantera det
                conn.Open();

                // Hämta SQL-kommando objekt för att exekvera SQL-strängen och skicka in parametrar
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    // Sätt parametrar
                    SetParameters(values, cmd);
                    // Kör SQL-koden
                    cmd.ExecuteNonQuery();
                }

                // returnera ID till senaste posten som skapades
                return conn.LastInsertRowId;
            }
        }

        /// <summary>
        /// Hämta en Datatable från databasen.
        /// </summary>
        /// <param name="sql">SQL sträng.</param>
        /// <param name="values">Parameter kommaseparerade ["@name", "My name"] .</param>
        /// <returns>En <see cref="DataTable"/>.</returns>
        public static DataTable GetDataTable(string sql, params string[] values)
        {
            // Förbered ett DataTable objekt
            DataTable dt = new DataTable();

            // Identifiera databasfilen
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                // Öppna filen och låt databasmotorn hantera den
                conn.Open();

                // Hämta ett SQL-commandobjekt för att hantera SQL strängen och parametrar
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    // Sätt parametrar
                    SetParameters(values, cmd);

                    // Öppna en Adapter för att omvandla informationen från Databasen till en DataTable
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    // Fyll Datatablen
                    da.Fill(dt);
                }
            }

            // Returnera DataTable
            return dt;
        }

        /// <summary>
        /// Skapa datasen om den saknas.
        /// </summary>
        /// <returns>true om databasen skapades.</returns>
        public static bool InitDatabase()
        {
            // Hämta filinfo
            FileInfo fi = new FileInfo(Settings.Database);

            // Kontrollera att databasfilen finns eller om den är tom
            if (!fi.Exists || fi.Length == 0)
            {
                // Om databasfilen inte finns, skapa en
                SQLiteConnection.CreateFile(Settings.Database);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lägger till en lista av fält i SQL koden.
        /// </summary>
        /// <param name="fields">Fälten <see cref="string[]" som ska läggas in i strängen kommaseparerade />.</param>
        /// <returns>Sträng med fälten<see cref="string"/>.</returns>
        private static string AddFields(string[] fields)
        {
            string sql = "";
            foreach (string field in fields)
            {
                sql += field + ",";
            }

            return sql.TrimEnd(',');
        }

        /// <summary>
        /// SetParameters.
        /// </summary>
        /// <param name="values">Parameterlista som ska in i SQL commmando i form av "@namn","Bond","@id","007"<see cref="string[]"/>.</param>
        /// <param name="cmd">SQL-commandot<see cref="SQLiteCommand"/>.</param>
        private static void SetParameters(string[] values, SQLiteCommand cmd)
        {
            for (int i = 0; i < values.Length; i += 2)
            {
                cmd.Parameters.AddWithValue(values[i], values[i + 1]);
            }
        }
    }
}