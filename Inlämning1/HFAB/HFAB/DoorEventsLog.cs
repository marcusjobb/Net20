using System.Data;
using System.Data.SQLite;

namespace HFAB
{
    internal class DoorEventsLog
    {
        public DataTable FindEntriesByDoor(string door) // Sök de sensaste loggar från en viss dörr, returnerera en DataTable.
        {
            // Definiera sökningen
            const string sql = "SELECT * FROM Logs INNER JOIN Tenants ON Logs.Tag = Tenants.Tag WHERE Door = @door ORDER BY Date DESC LIMIT 20";

            // Gör sökningen
            var dt = DBHandler.GetDataTable(sql, "@door", door);

            // Kolla om DataTablen innehåller något
            if (dt?.Rows.Count > 0)
            {
                return DBHandler.GetDataTable(sql, "@door", door);
            }
            else
            {
                return dt;
            }
        }

        public DataTable FindEntriesByLocation(string location) // Sök de senaste loggar från en viss lägenhet/rum, returnera en DataTable
        {
            // Definiera sökningen
            const string sql = "SELECT * FROM Logs, Tenants WHERE Tenants.Tag = Logs.Tag AND Tenants.Location = @location ORDER BY Date DESC LIMIT 20";

            // Gör sökningen
            var dt = DBHandler.GetDataTable(sql, "@location", location);

            if (dt?.Rows.Count > 0)
            {
                return DBHandler.GetDataTable(sql, "@location", location);
            }
            else
            {
                return dt;
            }
        }

        public DataTable FindEntriesByEvent(string evnt)
        {
            // Definiera sökningen
            const string sql = "SELECT * FROM Logs, Tenants WHERE Logs.Tag = Tenants.Tag AND Event = @evnt ORDER BY Date DESC LIMIT 20";

            // Gör sökningen
            var dt = DBHandler.GetDataTable(sql, "@evnt", evnt);

            if (dt?.Rows.Count > 0)
            {
                return DBHandler.GetDataTable(sql, "@evnt", evnt);
            }
            else
            {
                return dt;
            }
        }

        public DataTable FindEntriesByTenant(string tenant) // Sök de senaste loggar från en viss hyresgäst, returnera en DataTable
        {
            // Definiera sökningen
            const string sql = "SELECT * FROM Logs, Tenants WHERE Logs.Tag = Tenants.Tag AND Tenant = @tenant ORDER BY Date DESC LIMIT 20";

            // Gör sökningen
            var dt = DBHandler.GetDataTable(sql, "@tenant", tenant);

            if (dt?.Rows.Count > 0)
            {
                return DBHandler.GetDataTable(sql, "@tenant", tenant);
            }
            else
            {
                return dt;
            }
        }

        public DataTable FindEntriesByTag(string tag) // Sök de senaste loggar fårn en viss tagg, returnera en DataTable
        {
            // Definiera sökningen
            const string sql = "SELECT * FROM Logs, Tenants WHERE Logs.Tag = @tag  AND Tenants.Tag = @tag ORDER BY Date DESC LIMIT 20";

            // Gör sökningen
            var dt = DBHandler.GetDataTable(sql, "@tag", tag);

            if (dt?.Rows.Count > 0)
            {
                return DBHandler.GetDataTable(sql, "@tag", tag);
            }
            else
            {
                return dt;
            }
        }

        public DataTable ListTenantsAt(string apartment) // Söker hyresgäster från specifik lägenhet, listar upp deras namn och tagg-kod. returenera en DataTable
        {
            // Definiera sökningen
            const string sql = "SELECT Tenant, Tag, Location FROM Tenants WHERE Apartment = @apartment LIMIT 20";

            // Gör sökningen
            var dt = DBHandler.GetDataTable(sql, "@apartment", apartment);

            if (dt?.Rows.Count > 0)
            {
                return DBHandler.GetDataTable(sql, "@apartment", apartment);
            }
            else
            {
                return dt;
            }
        }

        public static void LogEntry(string date, string door, string evnt, string tag) // Informationen skickas in i textform och sparas i lämplig form och i lämpliga tabeller i databasen.
        {
            const string sql = "INSERT INTO Logs (Date, Door, Event, Tag) VALUES (@date, @door, @evnt, @tag)";

            // Skapa en koppling till databasen
            using var conn = new SQLiteConnection("data source=" + Settings.Database);
            // Öppna kommunikationen
            conn.Open();

            // Skapa ett SQL-kommando
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@door", door);
            cmd.Parameters.AddWithValue("@evnt", evnt);
            cmd.Parameters.AddWithValue("@tag", tag);
            cmd.ExecuteNonQuery();
        }
    }
}