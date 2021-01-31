using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Husrum_Fastigheter_AB
{
    public class DoorEventsLog
    {
        Database DataBase = new Database();
        int Max_Enteries;
        public int max_enteries
        {
            get { return Max_Enteries; }
            set { Max_Enteries = value;}
        }
       

        public DataTable FindEntriesByDoor (string input)
        {
            DataTable result = DataBase.Data_Fetcher(@"SELECT Logs.Date, Logs.Time, Locations.Location, Events.Event, Tag.Tag, Tenants.name
                                                       FROM Logs 
                                                       JOIN Locations on Logs.Location = Locations.ID
                                                       JOIN Events on Logs.Event = Events.ID
                                                       JOIN Tenants on Logs.Tenant = Tenants.ID
                                                       LEFT JOIN Tenants as Tag ON Logs.Tag = Tag.ID 
                                                       WHERE Locations.Location = @Location
                                                       ORDER BY Logs.time DESC
                                                       LIMIT " + Max_Enteries, new string[] { "@Location", input });
            return result;
        }

        public DataTable FindEntriesByEvent(string input)
        {
            DataTable result = DataBase.Data_Fetcher(@"SELECT Logs.Date, Logs.Time, Locations.Location, Events.Event, Tag.Tag, Tenants.name
                                                       FROM Logs 
                                                       JOIN Locations on Logs.Location = Locations.ID
                                                       JOIN Events on Logs.Event = Events.ID
                                                       JOIN Tenants on Logs.Tenant = Tenants.ID
                                                       LEFT JOIN Tenants as Tag ON Logs.Tag = Tag.ID 
                                                       WHERE Events.Event = @Event
                                                       ORDER BY Logs.time DESC
                                                       LIMIT " + Max_Enteries, new string[] { "@Event", input });
            return result;
        }

        public DataTable FindEntriesByLocation(string input)
        {
            input = "%" + input + "%";
            DataTable result = DataBase.Data_Fetcher(@"SELECT Logs.Date, Logs.Time, Locations.Location, Events.Event, Tag.Tag, Tenants.name
                                                       FROM Logs 
                                                       JOIN Locations on Logs.Location = Locations.ID
                                                       JOIN Events on Logs.Event = Events.ID
                                                       JOIN Tenants on Logs.Tenant = Tenants.ID
                                                       LEFT JOIN Tenants as Tag ON Logs.Tag = Tag.ID 
                                                       WHERE Locations.Location LIKE @Location
                                                       ORDER BY Logs.time DESC
                                                       LIMIT " + Max_Enteries, new string[] { "@Location", input });
            return result;
        }

        public DataTable FindEntriesByTag(string input)
        {
            DataTable result = DataBase.Data_Fetcher(@"SELECT Logs.Date, Logs.Time, Locations.Location, Events.Event, Tag.Tag, Tenants.name
                                                       FROM Logs 
                                                       JOIN Locations on Logs.Location = Locations.ID
                                                       JOIN Events on Logs.Event = Events.ID
                                                       JOIN Tenants on Logs.Tenant = Tenants.ID
                                                       LEFT JOIN Tenants as Tag ON Logs.Tag = Tag.ID 
                                                       WHERE Tenants.Tag = @Tag
                                                       ORDER BY Logs.time DESC
                                                       LIMIT " + Max_Enteries, new string[] { "@Tag", input });
            return result;
        }

        public DataTable FindEntriesByTenant(string input)
        {
            DataTable result = DataBase.Data_Fetcher(@"SELECT Logs.Date, Logs.Time, Locations.Location, Events.Event, Tag.Tag, Tenants.name
                                                       FROM Logs 
                                                       JOIN Locations on Logs.Location = Locations.ID
                                                       JOIN Events on Logs.Event = Events.ID
                                                       JOIN Tenants on Logs.Tenant = Tenants.ID
                                                       LEFT JOIN Tenants as Tag ON Logs.Tag = Tag.ID 
                                                       WHERE Tenants.Name = @Name
                                                       ORDER BY Logs.time DESC
                                                       LIMIT " + Max_Enteries, new string[] { "@Name", input });
            return result;
        }

        public DataTable ListTenantAt(string input)
        {
            DataTable result = DataBase.Data_Fetcher(@"SELECT * FROM Tenants 
                                                     WHERE Tenants.Apartment = @Apartment", new string[] {"@Apartment" , input});

            return result;
        }

        public void LogEntry(int Person_ID, int Location_ID, int Event_ID, int Date, int Time)
        {
            //Console.WriteLine( "{0}\t{1}\t{2}\t{3}\t{4}", Date, Time,  Person_ID, Location_ID, Event_ID );
            DataBase.SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", Date.ToString(), "@Time", Time.ToString(), "@Location", Location_ID.ToString(), "@Tenant", Person_ID.ToString(), "@Tag", Person_ID.ToString(), "@Event", Event_ID.ToString() });
        }


    }
}
