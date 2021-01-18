namespace DoorEventsLogger.Helpers
{
    using DoorEventsLogger.Handler;

    using System;
    using System.Data;

    internal static class LocationHelper
    {
        /// <summary>
        /// FindEntriesByLocation.
        /// </summary>
        /// <param name="location">En sträng<see cref="string"/> med namnet på rummet eller lägenheten som söks.</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        internal static DataTable FindEntriesByLocation(string location, int maxEntries)
        {
            return DBHandler.GetDataTable(Settings.GenericSQLSearch + $"WHERE Locations.Location=@location ORDER BY Date DESC LIMIT {maxEntries}", "@location", location);
        }

        internal static long FindLocationByDoor(string location)
        {
            DataTable locationId = DBHandler.GetDataTable("SELECT Locations.Id, locations.Location, Doors.Door FROM Locations JOIN Doors on Doors.LocationId=Locations.Id Where Locations.Location = @location", "@location", location);
            return locationId.Rows.Count > 0 ? (long)locationId.Rows[0]["Id"] : -1;
        }
    }
}