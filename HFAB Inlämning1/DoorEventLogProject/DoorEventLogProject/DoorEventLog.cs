using System;
using System.Data;

namespace DoorEventLogProject
{
    internal static class DoorEventLog
    {
        public static int MaxEntries { get; set; } = 20;
        //Find all events from a door
        public static DataTable FindEntriesByDoor(string doorName)
        {
            var find = @"SELECT OpeningDate,DoorName.DoorName,DoorEvent.EventCode,TenantTable.TenantTag,(TenantTable.FirstName || ' ' || TenantTable.LastName) AS Name
                        FROM DoorEventTable
                        JOIN DoorName ON DoorEventTable.DoorID = DoorName.ID
                        JOIN DoorEvent ON DoorEventTable.DoorEventType = DoorEvent.ID
                        JOIN TenantTable ON DoorEventTable.TenantID = TenantTable.ID
                        WHERE DoorName.DoorName = @values
                        ORDER BY OpeningDate DESC
                        LIMIT " + MaxEntries;
            var dt = Datatable.DataTable(find, doorName.ToUpper());
            return dt;
        }
        //Find all events based on event ID
        public static DataTable FindEntriesByEvent(string eventCode)
        {
            var find = @"SELECT OpeningDate,DoorName.DoorName,DoorEvent.EventCode,TenantTable.TenantTag,(TenantTable.FirstName || ' ' || TenantTable.LastName) AS Name
                        FROM DoorEventTable
                        JOIN DoorName ON DoorEventTable.DoorID = DoorName.ID
                        JOIN DoorEvent ON DoorEventTable.DoorEventType = DoorEvent.ID
                        JOIN TenantTable ON DoorEventTable.TenantID = TenantTable.ID
                        WHERE DoorEvent.EventCode = @values
                        ORDER BY OpeningDate DESC
                        LIMIT " + MaxEntries;
            var dt = Datatable.DataTable(find, eventCode.ToUpper());
            return dt;
        }
        //Find all events from a room/apartment
        public static DataTable FindEntriesByLocation(string doorLocation)
        {
            var find = @"SELECT OpeningDate,DoorName.DoorName,DoorEvent.EventCode,TenantTable.TenantTag,(TenantTable.FirstName || ' ' || TenantTable.LastName) AS Name
                        FROM DoorEventTable
                        JOIN DoorName ON DoorEventTable.DoorID = DoorName.ID
                        JOIN DoorEvent ON DoorEventTable.DoorEventType = DoorEvent.ID
                        JOIN TenantTable ON DoorEventTable.TenantID = TenantTable.ID
                        WHERE DoorName.DoorName = 'LGH' || @values OR DoorName.DoorName = 'BLK' || @values OR DoorName.DoorName = @values
                        ORDER BY OpeningDate DESC
                        LIMIT " + MaxEntries;
            var dt = Datatable.DataTable(find, doorLocation.ToUpper());
            return dt;
        }
        //Find all events from a tag
        public static DataTable FindEntriesByTag(string tenantTag)
        {
            var find = @"SELECT OpeningDate,DoorName.DoorName,DoorEvent.EventCode,TenantTable.TenantTag,(TenantTable.FirstName || ' ' || TenantTable.LastName) AS Name
                        FROM DoorEventTable
                        JOIN DoorName ON DoorEventTable.DoorID = DoorName.ID
                        JOIN DoorEvent ON DoorEventTable.DoorEventType = DoorEvent.ID
                        JOIN TenantTable ON DoorEventTable.TenantID = TenantTable.ID
                        WHERE TenantTable.TenantTag = @values
                        ORDER BY OpeningDate DESC
                        LIMIT " + MaxEntries;

            var dt = Datatable.DataTable(find, tenantTag.ToUpper());
            return dt;
        }
        //Find all events from a person
        public static DataTable FindEntriesByTenant(string tenantName)
        {
            var find = @"SELECT OpeningDate,DoorName.DoorName,DoorEvent.EventCode,TenantTable.TenantTag,(TenantTable.FirstName || ' ' || TenantTable.LastName) AS Name
                        FROM DoorEventTable
                        JOIN DoorName ON DoorEventTable.DoorID = DoorName.ID
                        JOIN DoorEvent ON DoorEventTable.DoorEventType = DoorEvent.ID
                        JOIN TenantTable ON DoorEventTable.TenantID = TenantTable.ID
                        WHERE TenantTable.FirstName LIKE @values OR (TenantTable.FirstName || ' ' || TenantTable.LastName) = @values
                        ORDER BY OpeningDate DESC
                        LIMIT " + MaxEntries;
            var dt = Datatable.DataTable(find, tenantName);
            return dt;
        }
        //List all tenants in a specific room/apartment
        public static DataTable ListTenantsAt(string apartmentNumber)
        {
            var find = @"SELECT(TenantTable.FirstName || ' ' || TenantTable.LastName) AS Name
                        FROM TenantTable
                        WHERE TenantTable.ApartmentNumber_ID = (SELECT ID FROM DoorLocationTable WHERE ApartmentNumber = @values)
                        LIMIT " + MaxEntries;
            var dt = Datatable.DataTable(find, apartmentNumber.ToUpper());
            return dt;
        }
        //insert information in log
        public static bool LogEntry(string date, string door, string code, string tag)
        {
            try
            {
                InsertData.DataToLog(date, door, code, tag);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
