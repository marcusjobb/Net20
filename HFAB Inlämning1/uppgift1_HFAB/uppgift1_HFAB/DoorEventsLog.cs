using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace uppgift1_HFAB
{
    public class DoorEventsLog
    {

        /// <summary>
        /// Skriver ut all entries från en specifik dörr.
        /// </summary>
        /// <param name="Door">Vilken dörr</param>
        /// <returns></returns>
        public DataTable FindEntriesByDoor(string Door)
        {
            var sql = @"SELECT Date, Door.Name, Event.Name, Personer.Tagg, (Personer.firstname || ' ' || personer.lastname) AS Name 
                        FROM Koppling 
                        JOIN Door ON Koppling.DoorID = Door.ID
                        JOIN Event ON Koppling.EventID = Event.ID
                        JOIN Personer ON Koppling.PersonID = Personer.ID 
                        WHERE Door.Name = @WHERE
                        ORDER BY Date DESC LIMIT " + MaxEntries;

            var data = SQL.GetDataTable(sql, Door);
            return data;
        }

        /// <summary>
        /// Skriver ut all entries från ett specifikt event.
        /// </summary>
        /// <param name="Event">Event(DÖUT,DÖIN)</param>
        /// <returns></returns>
        public DataTable FindEntriesByEvent(string Event)
        {
            var sql = @"SELECT Date, Event.Name, Personer.Tagg, door.Name, (Personer.firstname || ' ' || personer.lastname) AS Name 
                        FROM Koppling 
                        JOIN Personer ON Koppling.PersonID = Personer.ID 
                        JOIN Door ON Koppling.DoorID = Door.ID
                        JOIN Event ON Koppling.EventID = Event.ID
                        WHERE Event.Name = @WHERE
                        ORDER BY Date DESC LIMIT " + MaxEntries;

            var data = SQL.GetDataTable(sql, Event);
            return data;
        }

        /// <summary>
        /// Skriver ut all entries från ett specifikt ställe.
        /// </summary>
        /// <param name="Location">Område</param>
        /// <returns></returns>
        public DataTable FindEntriesByLocation(string Location)
        {
            var sql = @"SELECT Date, Event.Name, Personer.Tagg, door.Name, (Personer.firstname || ' ' || personer.lastname) AS Name 
                        FROM Koppling 
                        JOIN Personer ON Koppling.PersonID = Personer.ID 
                        JOIN Door ON Koppling.DoorID = Door.ID
                        JOIN Event ON Koppling.EventID = Event.ID
                        WHERE Door.Name = 'LGH' || @WHERE OR Door.Name = 'BLK' || @WHERE OR Door.Name = @WHERE
                        ORDER BY Date DESC LIMIT " + MaxEntries;

            var data = SQL.GetDataTable(sql, Location);
            return data;
        }

        /// <summary>
        /// Skriver ut all entries från en specifik tagg.
        /// </summary>
        /// <param name="Tag">Vilken tagg som används</param>
        /// <returns></returns>
        public DataTable FindEntriesByTag(string Tag)
        {
            var sql = @"SELECT Date, Event.Name, Personer.Tagg, door.Name, (Personer.firstname || ' ' || personer.lastname) AS Name 
                        FROM Koppling 
                        JOIN Personer ON Koppling.PersonID = Personer.ID 
                        JOIN Door ON Koppling.DoorID = Door.ID
                        JOIN Event ON Koppling.EventID = Event.ID
                        WHERE Personer.Tagg = @WHERE
                        ORDER BY Date DESC LIMIT " + MaxEntries;

            var data = SQL.GetDataTable(sql, Tag);
            return data;
        }


        /// <summary>
        /// Skriver ut all entries från en specifik hyresgäst.
        /// </summary>
        /// <param name="Tenant">Namnet på personen som skrivs ut</param>
        /// <returns></returns>
        public DataTable FindEntriesByTenant(string Tenant)
        {
            var sql = @"SELECT Date, Event.Name, Personer.Tagg, door.Name, (Personer.firstname || ' ' || personer.lastname) AS Name 
                        FROM Koppling 
                        JOIN Personer ON Koppling.PersonID = Personer.ID 
                        JOIN Door ON Koppling.DoorID = Door.ID
                        JOIN Event ON Koppling.EventID = Event.ID
                        WHERE personer.firstname = @Where OR (Personer.firstname || ' ' || personer.lastname) = @Where
                        ORDER BY date DESC LIMIT " + MaxEntries;

            var data = SQL.GetDataTable(sql, Tenant);
            return data;
        }

        /// <summary>
        /// Listar alla hyresgästerna från lägenhet i databasen.
        /// </summary>
        /// <param name="tenantsAt"></param>
        /// <returns></returns>
        public DataTable ListTenantsAt(string tenantsAt)
        {
            var sql = @"SELECT Personer.firstname, Personer.lastname AS Name
                        FROM Personer
                        WHERE Personer.Lägenhetsnummer = @where ";

            var data = SQL.GetDataTable(sql, tenantsAt);
            return data;
        }

        /// <summary>
        /// Läggs in i loggen som skapats i output klassen.
        /// </summary>
        /// <param name="date">Datum</param>
        /// <param name="door">Vilken dörr</param>
        /// <param name="events">Event på dörren</param>
        /// <param name="tag">Vilken tagg</param>
        /// <returns></returns>
        public static bool LogEntry(string date, string door, string events, string tag)
        {
            try
            {
                SQL.Input(date, door, events, tag);
                return true;
            }
            catch (Exception exceptionOps)
            {
                Console.WriteLine(exceptionOps);
                return false;
            }

        }
        public static int MaxEntries { get; set; } = 20;

    }
}


