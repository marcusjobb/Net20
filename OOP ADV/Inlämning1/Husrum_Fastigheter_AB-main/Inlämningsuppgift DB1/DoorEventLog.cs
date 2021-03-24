using System;
using System.Data;
using System.Data.SQLite;

namespace Inlämningsuppgift_DB1
{
    
    class DoorEventLog : DataFeed
    {
        // Strängar som används för att skicka kommando till databasen
        public static int MaxEntries { get; set; } = 20;
        public const string DoorCommand = @"SELECT Logg.Tid, Logg.Kod, Logg.Gäst, Logg.Dörr, Logg.Tagg FROM Logg 
            JOIN LägenhetsInformation On (Logg.Dörr=LägenhetsInformation.Dörr AND Logg.Gäst=LägenhetsInformation.Person AND Logg.Tagg=LägenhetsInformation.Tagg)
            JOIN Dörrkoder On Logg.Kod=Dörrkoder.Kod
            WHERE LägenhetsInformation.Dörr=@door
            ORDER BY Logg.Tid DESC;
            LIMIT @entries";
        public const string EventCommand = @"SELECT Logg.Tid, Logg.Kod, Logg.Gäst, Logg.Dörr, Logg.Tagg FROM Logg
            JOIN Dörrkoder On Logg.Kod=Dörrkoder.Kod
            JOIN DörrID On Logg.Dörr=DörrID.Dörrbenämning 
            JOIN LägenhetsInformation On (Logg.Gäst=LägenhetsInformation.Person AND Logg.Tagg=LägenhetsInformation.Tagg)
            WHERE Dörrkoder.Kod=@code
            ORDER BY Logg.Tid DESC;
            LIMIT @entries";
        public const string LocationCommand = @"SELECT Logg.Tid, Logg.Kod, Logg.Gäst, Logg.Dörr, Logg.Tagg FROM Logg 
            JOIN DörrID On Logg.Dörr=DörrID.Dörrbenämning 
            JOIN LägenhetsInformation On (Logg.Gäst=LägenhetsInformation.Person AND Logg.Tagg=LägenhetsInformation.Tagg)
            WHERE DörrID.Dörrbenämning=@location
            ORDER BY Logg.Tid DESC;
            LIMIT @entries";
        public const string TagCommand = @"SELECT Logg.Tid, Logg.Kod, Logg.Gäst, Logg.Dörr, Logg.Tagg FROM Logg 
            JOIN LägenhetsInformation On (Logg.Tagg=LägenhetsInformation.Tagg AND Logg.Gäst=LägenhetsInformation.Person AND Logg.Tagg=LägenhetsInformation.Tagg)
            JOIN Dörrkoder On Logg.Kod=Dörrkoder.Kod
            WHERE LägenhetsInformation.Tagg=@tag
            ORDER BY Logg.Tid DESC;
            LIMIT @entries";
        public const string TenantCommand = @"SELECT Logg.Tid, Logg.Kod, Logg.Gäst, Logg.Dörr, Logg.Tagg FROM Logg 
            JOIN LägenhetsInformation On (Logg.Gäst=LägenhetsInformation.Person AND Logg.Tagg=LägenhetsInformation.Tagg AND Logg.Tagg=LägenhetsInformation.Tagg)
            JOIN Dörrkoder On Logg.Kod=Dörrkoder.Kod
            WHERE LägenhetsInformation.Person=@tenant
            ORDER BY Logg.Tid DESC;
            LIMIT @entries";
        public const string ListTenantCommand = @"SELECT Logg.Gäst, Logg.Tagg, Logg.Dörr FROM Logg
            JOIN LägenhetsInformation On (Logg.Gäst=LägenhetsInformation.Person AND Logg.Tagg=LägenhetsInformation.Tagg AND Logg.Dörr=LägenhetsInformation.Dörr)
            WHERE LägenhetsInformation.Dörr=@DoorList";
        public static string LoggEntry = @"INSERT INTO Logg (Tid, Kod, Gäst, Dörr, Tagg) VALUES (@tid, @kod, @gäst, @dörr, @tagg)";
        public const string UpdateTime = @"UPDATE Logg
                                            SET Tid=@time";

        // En metod som skriver ut data från Logg tabellen genom sökning av dörr.
        public static DataTable FindEntriesByDoor(string DoorName)
        {
            
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(DoorCommand, conn);
                cmd.Parameters.AddWithValue("@door", DoorName);
                cmd.Parameters.AddWithValue("@entries", MaxEntries);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        // En metod som skriver ut data från Logg tabellen genom sökning av kod event.
        public static DataTable FindEntriesByEvent(string CodeEvent)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(EventCommand, conn);
                cmd.Parameters.AddWithValue("@code", CodeEvent);
                cmd.Parameters.AddWithValue("@entries", MaxEntries);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        // En metod som skriver ut data från Logg tabellen genom sökning av plats.
        public static DataTable FindEntriesByLocation(string DoorLocation)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(LocationCommand, conn);
                cmd.Parameters.AddWithValue("@location", DoorLocation);
                cmd.Parameters.AddWithValue("@entries", MaxEntries);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        // En metod som skriver ut data från Logg tabellen genom sökning av tagg.
        public static DataTable FindEntriesByTag(string Tag)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(TagCommand, conn);
                cmd.Parameters.AddWithValue("@tag", Tag);
                cmd.Parameters.AddWithValue("@entries", MaxEntries);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        // En metod som skriver ut data från Logg tabellen genom sökning av gäst.
        public static DataTable FindEntriesByTenant(string Tenant)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(TenantCommand, conn);
                cmd.Parameters.AddWithValue("@tenant", Tenant);
                cmd.Parameters.AddWithValue("@entries", MaxEntries);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        // En metod som skriver ut data från Logg tabellen genom sökning av gäst och skriver bara ut vart gästen bor och vilken tagg som tillhör.
        public static DataTable ListTenantsAt(string ListTenant)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(ListTenantCommand, conn);
                cmd.Parameters.AddWithValue("@DoorList", ListTenant);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        // En metod som loggar data till Logg tabellen.
        public static void LogEntry(string Händelsekod, string Gästnamn, string Dörrkod, string Taggkod)
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(LoggEntry, conn);
                cmd.Parameters.AddWithValue("@tid", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                cmd.Parameters.AddWithValue("@kod", Händelsekod);
                cmd.Parameters.AddWithValue("@gäst", Gästnamn);
                cmd.Parameters.AddWithValue("@dörr", Dörrkod);
                cmd.Parameters.AddWithValue("@tagg", Taggkod);

                cmd.ExecuteNonQuery();
            }
        }
        public static DataTable UpdateDateTime()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(UpdateTime, conn);
                cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyy-MM-dd hh:mm:ss"));

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
