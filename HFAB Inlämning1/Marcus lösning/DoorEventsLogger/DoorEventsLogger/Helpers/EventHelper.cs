namespace DoorEventsLogger.Helpers
{
    using DoorEventsLogger.Handler;

    using System.Data;

    public static class EventHelper
    {
        /// <summary>
        /// FindEntriesByEvent.
        /// </summary>
        /// <param name="doorEvent">En sträng<see cref="string"/> med händelse ID (DÖIN = Dörren öppnades inifrån).</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        internal static DataTable FindEntriesByEvent(string doorEvent, int maxEntries)
        {
            return DBHandler.GetDataTable(Settings.GenericSQLSearch + $"WHERE EventCodes.Code=@doorEvent ORDER BY Date DESC LIMIT {maxEntries}", "@doorEvent", doorEvent);
        }

        /// <summary>
        /// GetEventCode.
        /// </summary>
        /// <param name="codeId">Long<see cref="long"/> med Händelsekodens ID från databasen.</param>
        /// <returns>En sträng<see cref="string"/> med resultatet.</returns>
        internal static string GetEventCode(long codeId)
        {
            DataTable door = DBHandler.GetDataTable("SELECT Code From EventCodes Where Id = @codeId", "@codeId", codeId.ToString());
            return door.Rows.Count > 0 ? (string)door.Rows[0]["Code"] : "(Code not identified)";
        }

        /// <summary>
        /// GetEventCodeId.
        /// </summary>
        /// <param name="code">Parameter av typen code<see cref="string"/>.</param>
        /// <returns>Ett ID av typen long<see cref="long"/>.</returns>
        internal static long GetEventCodeId(string code)
        {
            DataTable doorId = DBHandler.GetDataTable("SELECT Id From EventCodes Where Code = @code", "@code", code);
            return doorId.Rows.Count > 0 ? (long)doorId.Rows[0]["Id"] : -1;
        }
    }
}