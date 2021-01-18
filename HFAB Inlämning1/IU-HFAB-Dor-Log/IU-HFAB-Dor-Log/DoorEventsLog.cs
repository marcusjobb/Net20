using System;
using System.Data;

namespace IU_HFAB_Dor_Log
{
    internal static class DoorEventsLog
    {
        /// <summary>
        /// Writes out all the enteries by a spesic door
        /// </summary>
        /// <param name="door">Door name</param>
        public static DataTable FindEntriesByDoor(string door)
        {
            var queary = @"SELECT Date, DoorName.name,Event.Code,Person.Tag,(Person.FirstName || ' ' || Person.LastName) AS Name
                                    FROM Logg
                                    JOIN DoorName on Logg.DoorID = DoorName.ID
                                    JOIN Event on Logg.EventCodeID = Event.ID
                                    JOIN Person on Logg.PersonID = Person.ID
                                    WHERE DoorName.Name = @where
									ORDER BY Date DESC
									Limit "+ MaxEntries;
            var dataTable = Sql.Select(queary, door.ToUpper());
            return dataTable;
        }

        /// <summary>
        /// Writes out all the enteries by a spesific Event
        /// </summary>
        /// <param name="eventCode">Name of event</param>
        public static DataTable FindEntriesByEvent(string eventCode)
        {
            var queary = @"SELECT Date, DoorName.name,Event.Code,Person.Tag,(Person.FirstName || ' ' || Person.LastName) AS Name
                                    FROM Logg
                                    JOIN DoorName on Logg.DoorID = DoorName.ID
                                    JOIN Event on Logg.EventCodeID = Event.ID
                                    JOIN Person on Logg.PersonID = Person.ID
                                    WHERE Event.Code = @where
									ORDER BY Date DESC
									Limit "+ MaxEntries;
            var dataTable = Sql.Select(queary, eventCode.ToUpper());
            return dataTable;
        }

        /// <summary>
        /// Writes out all the enteries by a spesific Location
        /// </summary>
        /// <param name="location">Location</param>
        public static DataTable FindEntriesByLocation(string location)
        {
            var queary = @"SELECT Date, DoorName.name,Event.Code,Person.Tag,(Person.FirstName || ' ' || Person.LastName) AS Name
                                    FROM Logg
                                    JOIN DoorName on Logg.DoorID = DoorName.ID
                                    JOIN Event on Logg.EventCodeID = Event.ID
                                    JOIN Person on Logg.PersonID = Person.ID
                                    WHERE DoorName.Name = 'LGH' || @where OR DoorName.Name = 'BLK' || @where OR DoorName.Name = @where
                                    ORDER BY Date DESC
                                    Limit "+ MaxEntries;
            var dataTable = Sql.Select(queary, location.ToUpper());
            return dataTable;
        }

        /// <summary>
        /// Writes out all the enteries by a spesific Tag
        /// </summary>
        /// <param name="tag">Tag</param>
        public static DataTable FindEntriesByTag(string tag)
        {
            var queary = @"SELECT Date, DoorName.name,Event.Code,Person.Tag,(Person.FirstName || ' ' || Person.LastName) AS Name
                                    FROM Logg
                                    JOIN DoorName on Logg.DoorID = DoorName.ID
                                    JOIN Event on Logg.EventCodeID = Event.ID
                                    JOIN Person on Logg.PersonID = Person.ID
                                    WHERE Person.Tag = @where
									ORDER BY Date DESC
									Limit "+ MaxEntries;
            var dataTable = Sql.Select(queary, tag.ToUpper());
            return dataTable;
        }

        /// <summary>
        /// Writes out all the enteries by a spesific Person
        /// </summary>
        /// <param name="name">Name of the person</param>
        public static DataTable FindEntriesByTenant(string name)
        {
            var queary = @"SELECT Date, DoorName.name,Event.Code,Person.Tag,(Person.FirstName || ' ' || Person.LastName) AS Name
                                    FROM Logg
                                    JOIN DoorName on Logg.DoorID = DoorName.ID
                                    JOIN Event on Logg.EventCodeID = Event.ID
                                    JOIN Person on Logg.PersonID = Person.ID
                                    WHERE Person.FirstName = @where OR (Person.FirstName || ' ' || Person.LastName) = @where
									ORDER BY Date DESC
									Limit "+ MaxEntries;
            var dataTable = Sql.Select(queary, name);
            return dataTable;
        }
        /// <summary>
        /// Lists all the Tenats at a appartment
        /// </summary>
        /// <param name="appartment"></param>
        public static DataTable ListTenantsAt(string appartment)
        {
            var queary = @"SELECT(Person.FirstName || ' ' || Person.LastName) as Name
                                FROM Person
                                WHERE Person.appartment = (SELECT ID FROM Location WHERE Location.Name = @where)
                                Limit "+ MaxEntries;
            var dataTable = Sql.Select(queary, appartment.ToUpper());
            return dataTable;
        }

        /// <summary>
        /// add to Logg
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="door">Name of door</param>
        /// <param name="code">Event code (DÖIN/DÖUT...)</param>
        /// <param name="tag">tag name</param>
        public static bool LogEntry(string date, string door, string code, string tag)
        {
            try
            {
                Sql.InsertData(date, door, code, tag);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public static int MaxEntries { get; set; } = 5;
    }
}