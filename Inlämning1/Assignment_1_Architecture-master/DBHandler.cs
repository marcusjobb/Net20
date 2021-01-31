using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace Assignment_1_Architecture
{
    internal static class DBHandler
    {
        private const string database = @".\DB.db";

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
        /// Executes a SQL string to the database
        /// </summary>
        /// <param name="sql">SQL code string</param>
        /// <param name="values">Values separated by comma e.g  ["@name", "My name"] </param>
        public static void ExecuteSQL(string sql, params string[] values)
        {
            // Skapa en koppling till databasen
            using (var sqlite2 = new SQLiteConnection("data source=" + database))
            {
                // Öppna kommunikationen
                sqlite2.Open();
                // Skapa ett SQL-kommando
                SQLiteCommand cmd = new SQLiteCommand(sql, sqlite2);
                // Kör SQL-koden
                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }
                cmd.ExecuteNonQuery();
                // Lägg till standarddata i databasen
            }
        }

        /// <summary>
        /// Gets a Datatable from the database
        /// </summary>
        /// <param name="sql">SQL code</param>
        /// <param name="values">Values separated by comma e.g  ["@name", "My name"] </param>
        public static DataTable GetDataTable(string sql, params string[] values)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static bool CreateDatabase()
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