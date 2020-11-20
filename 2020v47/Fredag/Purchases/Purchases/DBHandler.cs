namespace Purchases
{
    using System.Data;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Databashanterare, i den här classen finns alla metoder som tar hand om
    /// kommunikation med databasen
    /// </summary>
    public static class DBHandler
    {
        /// <summary>
        /// Skapar en tabell
        /// Den här metoden använder inte parameters för att man får hoppas att programmet aldrig
        /// låter användaren bestämma själv vad tabellerna ska heta!
        /// (Man kan inte använda parameters för tabellnamn och fältnamn)
        /// </summary>
        /// <param name="name">Tabellnamn</param>
        /// <param name="fields">Fält och Index definieringar</param>
        public static void CreateTable(string name, params string[] fields)
        {
            var sql = @"CREATE TABLE IF NOT EXISTS """ + name + @""" (";
            foreach (var field in fields)
            {
                sql += field + ",";
            }
            sql = sql.TrimEnd(',') + ");";
            Debug.WriteLine(sql);
            ExecuteSQL(sql);
        }

        /// <summary>
        /// Exekverar SQL Sträng i databasen
        /// </summary>
        /// <param name="sql">SQL sträng</param>
        /// <param name="values">Parameter kommaseparerade ["@name", "My name"] </param>
        public static long ExecuteSQL(string sql, params string[] values)
        {
            // Identifiera databasfilen
            using (var conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                // Öppna filen och låt databasmotorn hantera det
                conn.Open();

                // Hämta SQL-kommando objekt för att exekvera SQL-strängen och skicka in parametrar
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                // Sätt parametrar
                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }

                // Kör SQL-koden
                cmd.ExecuteNonQuery();

                // returnera ID till senaste posten som skapades
                return conn.LastInsertRowId;
            }
        }

        /// <summary>
        /// Hämta en Datatable från databasen
        /// </summary>
        /// <param name="sql">SQL sträng</param>
        /// <param name="values">Parameter kommaseparerade ["@name", "My name"] </param>
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
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                // Stoppa in parametrarna
                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }

                // Öppna en Adapter för att omvandla informationen från Databasen till en DataTable
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

                // Fyll Datatablen
                da.Fill(dt);
            }

            // Returnera DataTable
            return dt;
        }

        /// <summary>
        /// Skapa datasen om den saknas
        /// </summary>
        /// <returns>true om databasen skapades</returns>
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
    }
}