using System.Data.SQLite;

namespace Assignment_1_Architecture
{
    internal static class DBHelper
    {
        /// <summary>
        /// Mata in flera hyresgäster vid initiering av databasen
        /// </summary>
        /// <param name="tenantNames">En array av hyresgästernas namn</param>
        /// <returns>ID till den sista hyresgästen som sparats</returns>
        public static long InsertTenant(params string[] tenantNames)
        {
            //Standardvärdet
            long value = 0;
            //Loop för arrayen i metoden
            foreach (var tenant in tenantNames)
            {
                var data = tenant.Split(',');
                //Skapar hyresgäster med ID
                value = InsertTenant(
                    data[0],
                    data[1],
                    data[2]);
            }
            //Returnerar ID till hyresgästen, till ista som lagt in
            return value;
        }

        /// <summary>
        /// Skapa en hyresgäst
        /// </summary>
        /// <param name="tenantName">Hyresgästens namn</param>
        /// <returns>Id till hyresgästen som skapades</returns>
        public static long InsertTenant(string tenantName, string tenantLocations, string tenantTags)
        {
            //Definiering av sökningen
            const string sql = "INSERT INTO Tenants (Name, Location, Tag) VALUES(@name, @location, @tag)";

            // Identifiera databasfilen
            using (var conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                // Öppnar filen och låter databasmotorn hantera den
                conn.Open();

                // Hämtar ett SQL-commando från SQLite för att hantera SQL stringen och parametern
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                // Lägger in parametern
                cmd.Parameters.AddWithValue("@name", tenantName);

                cmd.Parameters.AddWithValue("@location", tenantLocations);

                cmd.Parameters.AddWithValue("@tag", tenantTags);

                // Exekverar SQL stringen
                cmd.ExecuteNonQuery();

                // Returnerar ID till den senaste hyresgäst som sparats
                return conn.LastInsertRowId;
            }
        }

        /// <summary>
        /// Mata in flera dörrar vid initiering av databasen
        /// </summary>
        /// <param name="doors">En array av dörrar</param>
        /// <returns>ID till sista dörren som sparades</returns>
        public static long InsertDoor(params string[] doors)
        {
            long value = 0;
            foreach (var door in doors)
            {
                value = InsertDoor(door);
            }
            return value;
        }

        /// <summary>
        /// Skapa en dörr
        /// </summary>
        /// <param name="door">Dörrens benämning</param>
        /// <returns>Id till dörren som skapades</returns>
        public static long InsertDoor(string door)
        {
            using (var conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                conn.Open();

                const string sql = "INSERT INTO Doors (Door) VALUES(@door)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                cmd.Parameters.AddWithValue("@door", door);

                cmd.ExecuteNonQuery();

                return conn.LastInsertRowId;
            }
        }

        /// <summary>
        /// Mata in flera dörrkoder vid initiering av databasen
        /// </summary>
        /// <param name="doorCodes">En array av dörrkoder</param>
        /// <returns>ID till sista dörrkoden som sparades</returns>
        public static long InsertDoorCode(params string[] doorCodes)
        {
            long value = 0;
            foreach (var doorCode in doorCodes)
            {
                value = InsertDoorCode(doorCode);
            }
            return value;
        }

        /// <summary>
        /// Skapa en dörrkod
        /// </summary>
        /// <param name="doorCode">Dörrkodens benämning</param>
        /// <returns>Id till dörrkoden som skapades</returns>
        public static long InsertDoorCode(string doorCode)
        {
            using (var conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                conn.Open();

                const string sql = "INSERT INTO DoorCodes (DoorCode) VALUES(@doorcode)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                cmd.Parameters.AddWithValue("@doorcode", doorCode);

                cmd.ExecuteNonQuery();

                return conn.LastInsertRowId;
            }
        }

        /// <summary>
        /// Mata in flera datum vid initiering av databasen
        /// </summary>
        /// <param name="dates">En array av datum</param>
        /// <returns>ID till sista datum som sparades</returns>
        public static long InsertDate(params string[] dates)
        {
            long value = 0;
            foreach (var date in dates)
            {
                value = InsertDate(date);
            }
            return value;
        }

        /// <summary>
        /// Skapa en datum
        /// </summary>
        /// <param name="date">Datumet</param>
        /// <returns>Id till datumet som skapades</returns>
        public static long InsertDate(string date)
        {
            // Cpt Kirk: Hail ship
            using (var conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                // Uhura: Opening connection to ship
                conn.Open();

                // Klingons vill anfalla
                // Kirk: Prepare torpedos
                const string sql = "INSERT INTO Dates (Date) VALUES(@date)";

                // Scotty: Powering up engines
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                // Kirk: Use Proton torpedos
                cmd.Parameters.AddWithValue("@date", date);

                // Kirk: Fire!!!
                cmd.ExecuteNonQuery();

                // Spock: Ship was destroyed
                return conn.LastInsertRowId;
            }
        }

        /// <summary>
        /// Spara ett event, en dörröppning
        /// </summary>
        /// <param name="time">Tidpunkt</param>
        /// <param name="door">Dörrens benämning</param>
        /// <param name="doorCode">Dörrkodens benämning</param>
        /// <param name="tag">Taggens namn</param>
        /// <param name="tenantName">Hyresgästens namn</param>
        /// <returns>ID till senaste inmatning</returns>
        public static long InsertDoorEvent(string date, string door, string doorCode, string tag, string tenantName)
        {
            // Hämta ID för tidpunk
            var dateID = GettingID.GettingDateID(date.Trim());
            // Hämta ID från dörren
            var doorID = GettingID.GettingDoorID(door.Trim());
            // Hämta ID från dörrkoden
            var doorCodeID = GettingID.GettingEventID(doorCode.Trim());
            // Hämta ID från taggen
            var tagID = GettingID.GettingTagID(tag.Trim());
            // Hämta ID från hyresgästen
            var tenantID = GettingID.GettingTenantID(tenantName.Trim());

            return InsertDoorEvent(dateID, doorID, doorCodeID, tagID, tenantID);
        }

        /// <summary>
        /// Sparar ett event, en dörröppning
        /// </summary>
        /// <param name="date">Datum</param>
        /// <param name="door">Dörrens benämning</param>
        /// <param name="doorCode">Dörrkodens benämning</param>
        /// <param name="tag">Taggens namn</param>
        /// <param name="tenantName">Hyresgästens namn</param>
        /// <returns>ID till senaste inmatning</returns>
        public static long InsertDoorEvent(long date, long door, long doorCode, long tag, long tenantName)
        {
            // Definierar SQL-stringen
            const string sql = "INSERT INTO Events (DateID, DoorID, DoorCodeID, TagID, TenantID) VALUES(@dateID,@doorID,@doorCodeID,@tagID,@tenantID)";

            // Identifierar databasfilen
            using (var conn = new SQLiteConnection("data source=" + Settings.Database))
            {
                // Öppnar filen och låter databasmotorn hantera det
                conn.Open();

                // Hämtar SQL commando för att hantera SQL-string och parameter
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                // Anger parametrar
                cmd.Parameters.AddWithValue("@dateID", date);
                cmd.Parameters.AddWithValue("@doorID", door);
                cmd.Parameters.AddWithValue("@doorCodeID", doorCode);
                cmd.Parameters.AddWithValue("@tagID", tag);
                cmd.Parameters.AddWithValue("@tenantID", tenantName);

                // Exekverar SQL koden
                cmd.ExecuteNonQuery();

                // Returnerar ID till den senast sparade
                return conn.LastInsertRowId;
            }
        }
    }
}