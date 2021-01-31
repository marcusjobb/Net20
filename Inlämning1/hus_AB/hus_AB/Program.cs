using System;
using System.Data;
using System.Data.SQLite;


namespace hus_AB
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.creatdatabes();

            var events = new DoorEventsLog();
            var byDoor = events.FindEntriesByDoor("BLK0101")?.Rows;
            var byCode = events.FindEntriesByEvent("FDUT") ?.Rows;
            var byLocation = events.FindEntriesByLocation("102")?.Rows;
            var byTag = events.FindEntriesByTag("0102A")?.Rows;
            var byTenant = events.FindEntriesByTenant("Elias Petterson ")?.Rows;
            var tenants = events.ListTenantsAt("0201")?.Rows;
            OutputData("Search by code", byCode);
            OutputData("Search by location", byLocation);
            OutputData("Search by door", byDoor);
            OutputData("Search by Tenant", byTenant);
            OutputData("Search by tag", byTag);
            OutputTenants(tenants);
            Console.ReadLine();

        }

        private static void OutputData(string title, DataRowCollection byCode)
        {
            Console.WriteLine(title);
            foreach (DataRow r in byCode)
            {
                Console.WriteLine($"{r["Date_Tiden"]} {r["Doors"]} {r["Tag"]} {r["Koder"]} {r["Person"]} {DoText(r)}");
            }

        }

        private static void OutputTenants(DataRowCollection tenants)
        {
            Console.WriteLine("Tenants");
            foreach(DataRow r in tenants)
            {
                Console.WriteLine($"{r["Lghnum"]} {r["Tag"]} {r["Person"]}");
            }
        }

        private static string DoText(DataRow r)
        {
            var ev = r["Koder"].ToString();
            var what = ev.StartsWith("FD") ? "försökte öppna" : "öppnade";
            var where = ev.EndsWith("IN") ? "inifrån" : "utefrån";
            return r["Person"] + $"{what} dörr till {r["Lghnum"]} {where}";
        }

        public static void ExecuteSQL(string sql, params string[] values)
        {
            // Skapa en koppling till databasen
            using (var sqlite2 = new SQLiteConnection("data source=" + "Husrum_Fastigheter_AB_db.db"))
            {
                // Öppnat kommunikationen
                sqlite2.Open();
                // Skapat ett SQL-kommando
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

        public static DataTable GetDataTable(string sql, params string[] values)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + "Husrum_Fastigheter_AB_db.db"))
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
    }
}
