namespace DoorEventsLogger.Helpers
{
    using DoorEventsLogger.Handler;

    using System.Data;

    public static class DoorHelper
    {
        /// <summary>
        /// FindEntriesByDoor.
        /// </summary>
        /// <param name="door">Namnet på en dörr<see cref="string"/>.</param>
        /// <param name="maxEntries">todo: describe maxEntries parameter on FindEntriesByDoor</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        internal static DataTable FindEntriesByDoor(string door, int maxEntries)
        {
            return DBHandler.GetDataTable(Settings.GenericSQLSearch + $"WHERE Doors.Door = @door ORDER BY Date DESC LIMIT {maxEntries}", "@door", door);
        }

        /// <summary>
        /// GetDoorId.
        /// </summary>
        /// <param name="door">En sträng<see cref="string"/> med dörrbeteckning.</param>
        /// <returns>Ett ID av typen long<see cref="long"/>.</returns>
        internal static long GetDoorId(string door)
        {
            DataTable doorId = DBHandler.GetDataTable("SELECT Id From Doors Where Door = @door", "@door", door);
            return doorId.Rows.Count > 0 ? (long)doorId.Rows[0]["Id"] : -1;
        }

        /// <summary>
        /// GetDoorName.
        /// </summary>
        /// <param name="doorId">Long<see cref="long"/> med dörrens ID.</param>
        /// <returns>En sträng<see cref="string"/> med resultatet.</returns>
        internal static string GetDoorName(long doorId)
        {
            DataTable door = DBHandler.GetDataTable("SELECT Door From Doors Where Id = @doorId", "@doorId", doorId.ToString());
            return door.Rows.Count > 0 ? (string)door.Rows[0]["Door"] : "(Door not identified)";
        }
    }
}