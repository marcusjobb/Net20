using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace HFAB_v2
{
    public class DoorEventsLog
    {
        //Sets the LIMIT in SQL-output to a maximum number
        public const int maxEntries = 20;

        //Methods adds logs (from test data) to database
        public void LogEntry(string date, string door, string eventCode, string tag)
        {
            DatabaseCommunication.ExecuteSQL("INSERT INTO LogEntry (Date, Door, Event, Tag) VALUES (@date, @door, @eventCode, @tag) ", "@date", date, "@door", door, "@eventCode", eventCode, "@tag", tag);
        }

        //Returns DataTable showing all tenants in a location
        public DataTable ListTenantsAt(string location)
        {
            //string sql = "SELECT Tenants.tenant, Tenants.Location, Tenants.Tag FROM Tenants WHERE Tenants.Location = '@Loction'", "@Location", location;
            string sql = @"SELECT Tenants.tenant, Tenants.Location, Tenants.Tag FROM Tenants WHERE Tenants.Location = @Location";
            DataTable data = DatabaseCommunication.GetDataTable(sql, "@Location", location);
            return data;
        }

        //Returns DataTable showing all entries by tenant in LogEntry
        public DataTable FindEntriesByTenant(string tenant)
        {
            string sql = @"SELECT LogEntry.Date, LogEntry.Door, LogEntry.Tag, LogEntry.Event,
                            Tenants.Location, Tenants.Tenant
                            FROM LogEntry
                            JOIN Tenants ON LogEntry.Tag=Tenants.Tag
                            WHERE Tenants.Tenant LIKE @Tenant
                            ORDER BY LogEntry.Date DESC
                            LIMIT " + maxEntries + "";

            DataTable data = DatabaseCommunication.GetDataTable(sql, "@Tenant", "%" + tenant + "%");
            return data;
        }

        //Returns DataTable showing all entries by tag in LogEntry
        public DataTable FindEntriesByTag(string tag)
        {
            string sql = @"SELECT LogEntry.Date, LogEntry.Door, LogEntry.Tag, LogEntry.Event,
                            Tenants.Location, Tenants.Tenant
                            FROM LogEntry
                            JOIN Tenants ON LogEntry.Tag=Tenants.Tag
                            WHERE Tenants.Tag LIKE @Tag
                            ORDER BY LogEntry.Date DESC
                            LIMIT " + maxEntries + "";
            DataTable data = DatabaseCommunication.GetDataTable(sql, "@Tag", "%" + tag + "%");
            return data;
        }

        //Returns DataTable showing all entries by location in LogEntry
        public DataTable FindEntriesByLocation(string location)
        {
            string sql = @"SELECT LogEntry.Date, LogEntry.Door, LogEntry.Tag, LogEntry.Event,
                            Tenants.Location, Tenants.Tenant
                            FROM LogEntry
                            JOIN Tenants ON LogEntry.Tag=Tenants.Tag
                            WHERE LogEntry.Door LIKE @Location
                ORDER BY LogEntry.Date DESC
                LIMIT " + maxEntries + "";
            DataTable data = DatabaseCommunication.GetDataTable(sql, "@Location", "%" + "%" + location + "%");
            return data;
        }

        //Returns DataTable showing all entries by door in LogEntry
        public DataTable FindEntriesByDoor(string door)
        {
            string sql = @"SELECT LogEntry.Date, LogEntry.Door, LogEntry.Tag, LogEntry.Event,
                            Tenants.Location, Tenants.Tenant
                            FROM LogEntry
                            JOIN Tenants ON LogEntry.Tag=Tenants.Tag
                            WHERE LogEntry.Door LIKE @Door
                            ORDER BY LogEntry.Date DESC
                            LIMIT " + maxEntries + "";
            DataTable data = DatabaseCommunication.GetDataTable(sql, "@Door", "%" + door + "%");
            return data;
        }

        //Returns DataTable showing all entries by event in LogEntry
        public DataTable FindEntriesByEvent(string eventInput)
        {
            string sql = @"SELECT LogEntry.Date, LogEntry.Door, LogEntry.Tag, LogEntry.Event,
                            Tenants.Location, Tenants.Tenant
                            FROM LogEntry
                            JOIN Tenants ON LogEntry.Tag=Tenants.Tag
                            WHERE LogEntry.Event LIKE @EventInput
                            ORDER BY LogEntry.Date DESC
                            LIMIT " + maxEntries + "";
            DataTable data = DatabaseCommunication.GetDataTable(sql, "@EventInput", "%" + eventInput + "%");
            return data;
        }
    }
}