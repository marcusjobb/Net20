using System.Data.SQLite;

namespace Inlämningsuppgift_DB1
{
    class Database
    {
        public const string database = @".\DoorLog.db";

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
    }
}
