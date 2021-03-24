using System.Data;

namespace Assignment_1_Architecture
{
    public static class DoorEventsLog
    {
        public static DataRowCollection FindEntriesByDate(string date)
        {
            // Hämtar ID till datumet
            var dateID = GettingID.GettingDateID(date);

            // Definierar en sökning
            string sqlDate = $@"
                SELECT Dates.Date, Doors.Door, DoorCodes.DoorCode, Tenants.Tag, Tenants.Name
                FROM Events
                JOIN Dates ON Events.DateID = Dates.ID
                JOIN Doors ON Events.DoorID=Doors.ID
                JOIN DoorCodes ON Events.DoorcodeID=DoorCodes.ID
                JOIN Tenants ON Events.TenantID=Tenants.ID
                WHERE Events.DateID = {dateID}
                ORDER BY date
                LIMIT {MaxEntries}
                ";

            // Returnerar Rows från datatabellen som kommer ifrån sökningen
            return DBHandler.GetDataTable(sqlDate)?.Rows;
        }

        public static DataRowCollection FindEntriesByDoor(string door)
        {
            // Hämtar ID till dörren
            var doorID = GettingID.GettingDoorID(door);

            // Definierar en sökning
            string sqlDoor = $@"
                SELECT Dates.Date, Doors.Door, DoorCodes.DoorCode, Tenants.Tag, Tenants.Name
                FROM Events
                JOIN Dates ON Events.DateID = Dates.ID
                JOIN Doors ON Events.DoorID=Doors.ID
                JOIN DoorCodes ON Events.DoorcodeID=DoorCodes.ID
                JOIN Tenants ON Events.TenantID=Tenants.ID
                WHERE Events.DoorID = {doorID}
                ORDER BY date
                LIMIT {MaxEntries}
                ";

            // Returnerar Rows från datatabellen som kommer ifrån sökningen
            return DBHandler.GetDataTable(sqlDoor)?.Rows;
        }

        public static DataRowCollection FindEntriesByEvent(string code)
        {
            // Hämtar ID till dörrkoden
            var codeID = GettingID.GettingEventID(code);

            // Definierar en sökning
            string sqlCode = $@"
                SELECT Dates.Date, Doors.Door, DoorCodes.DoorCode, Tenants.Tag, Tenants.Name
                FROM Events
                JOIN Dates ON Events.DateID = Dates.ID
                JOIN Doors ON Events.DoorID=Doors.ID
                JOIN DoorCodes ON Events.DoorcodeID=DoorCodes.ID
                JOIN Tenants ON Events.TenantID=Tenants.ID
                WHERE Events.DoorCodeID = {codeID}
                ORDER BY date
                LIMIT {MaxEntries}
                ";

            // Returnerar Rows från datatabellen som kommer ifrån sökningen
            return DBHandler.GetDataTable(sqlCode)?.Rows;
        }

        public static DataRowCollection FindEntriesByLocation(string location)
        {
            var locationID = GettingID.GettingLocationID(location);

            string sqlLocation = $@"
                SELECT Dates.Date, Doors.Door, DoorCodes.DoorCode, Tenants.Tag, Tenants.Name
                FROM Events
                JOIN Dates ON Events.DateID = Dates.ID
                JOIN Doors ON Events.DoorID=Doors.ID
                JOIN DoorCodes ON Events.DoorcodeID=DoorCodes.ID
                JOIN Tenants ON Events.TenantID=Tenants.ID
                WHERE Events.DoorID = {locationID}
                ORDER BY date
                LIMIT {MaxEntries}
                ";

            return DBHandler.GetDataTable(sqlLocation)?.Rows;
        }

        public static DataRowCollection FindEntriesByTag(string tag)
        {
            // Hämtar ID till taggen
            var tagID = GettingID.GettingTagID(tag);

            // Definierar en sökning
            string sqlTag = $@"
                SELECT Dates.Date, Doors.Door, DoorCodes.DoorCode, Tenants.Tag, Tenants.Name
                FROM Events
                JOIN Dates ON Events.DateID = Dates.ID
                JOIN Doors ON Events.DoorID=Doors.ID
                JOIN DoorCodes ON Events.DoorcodeID=DoorCodes.ID
                JOIN Tenants ON Events.TenantID=Tenants.ID
                WHERE Events.TagID = {tagID}
                ORDER BY date
                LIMIT {MaxEntries}
                ";

            // Returnerar Rows från datatabellen som kommer ifrån sökningen
            return DBHandler.GetDataTable(sqlTag)?.Rows;
        }

        public static DataRowCollection FindEntriesByTenant(string tenant)
        {
            // Hämtar ID till hyresgästen
            var tenantID = GettingID.GettingTenantID(tenant);

            // Definierar en sökning
            string sqlTenant = $@"
                SELECT Dates.Date, Doors.Door, DoorCodes.DoorCode, Tenants.Tag, Tenants.Name
                FROM Events
                JOIN Dates ON Events.DateID = Dates.ID
                JOIN Doors ON Events.DoorID=Doors.ID
                JOIN DoorCodes ON Events.DoorcodeID=DoorCodes.ID
                JOIN Tenants ON Events.TenantID=Tenants.ID
                WHERE Events.TenantID = {tenantID}
                ORDER BY date
                LIMIT {MaxEntries}
                ";

            // Returnerar Rows från datatabellen som kommer ifrån sökningen
            return DBHandler.GetDataTable(sqlTenant)?.Rows;
        }

        public static DataRowCollection ListTenantsAt(string tenantList)
        {
            // Hämtar ID till hyresgästen
            var tenantIDLocation = GettingID.GettingTenantID(tenantList);

            // Definierar en sökning
            string sqlListTenants = $@"
                Select * FROM Tenants
	            WHERE Location = @location
                ";

            // Returnerar Rows från datatabellen som kommer ifrån sökningen
            return DBHandler.GetDataTable(sqlListTenants, "@location", tenantList).Rows;
        }

        public static string LogEntry(DataRow r)
        {
            {
                var ev = r["Name"].ToString();
                // If/else för vad som sker
                var what = ev.StartsWith("FD") ? "försökte öppna" : "öppnade";
                // If/else för vad som sker
                var where = ev.EndsWith("IN") ? "inifrån" : "utifrån";
                return r["Name"] + " " + $"{what} dörr till {r["Door"]} {where}";
            }
        }

        public static int MaxEntries { get; set; } = 20;
    }
}