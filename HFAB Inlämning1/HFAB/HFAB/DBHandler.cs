using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace HFAB
{
    internal static class DBHandler
    {
        // Snodd från purchase exempel
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

        // Snodd från purchase exempel
        public static long ExecuteSQL(string sql, params string[] values)
        {
            // Identifiera databasfilen
            using var conn = new SQLiteConnection("data source=" + Settings.Database);

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

        public static DataTable GetDataTable(string sql, params string[] values)
        {
            // Skapa en koppling till databasen
            DataTable dt = new DataTable(); //<-- Här hamnar informationen

            using var conn = new SQLiteConnection("data source=" + Settings.Database);

            // Öppna kommunikationen
            conn.Open();

            // Skapa ett SQL-kommando
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            // Stoppa in parametrarna
            for (int i = 0; i < values.Length; i += 2)
            {
                cmd.Parameters.AddWithValue(values[i], values[i + 1]);
            }

            // Ingen ExecuteNonQuery
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd); //<-- Exekverar SQL och hämtar data

            da.Fill(dt); // <--- Lägger in datan i din DataTable
                         // hämta data från databasen

            // Returnera DataTable
            return dt;
        }

        // Snodd från purchase exempel
        public static void InitiateDatabase()
        {
            if (DatabaseCheck())
            {
                // Kollar ifall tables finns. Annars skapar nya.
                DBHandler.CreateTable("Door_Explanation", "Door_Name TEXT PRIMARY KEY", "Explanation TEXT");
                DBHandler.CreateTable("Event", "Code TEXT", "Explanation TEXT PRIMARY KEY", "Code");
                DBHandler.CreateTable("Location", "Door TEXT PRIMARY KEY", "Door");
                DBHandler.CreateTable("Logs", "Date TEXT NOT NULL", "Door TEXT NOT NULL", "Event TEXT NOT NULL", "Tag TEXT NOT NULL");
                DBHandler.CreateTable("Tenants", "Apartment TEXT", "Location TEXT NOT NULL", "Tenant  TEXT", "Tag TEXT UNIQUE");
                DBHandler.CreateTable("Tenants_Info", "Name TEXT PRIMARY KEY", "Info TEXT");

                // Fyller i med random rader i Logs
                for (int i = 0; i < 200; i++)
                {
                    LogSeeder.GetRandomLogInput();
                }

                //Kollar om data finns i tables. Annars lägg in datan.
            }
        }

        // Snodd från purchase exempel
        public static bool DatabaseCheck()
        {
            // Hämta filinfo, snott från purchase exempel.
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