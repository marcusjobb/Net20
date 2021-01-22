namespace DoorEventsLogger
{
    using DoorEventsLogger.Handler;
    using DoorEventsLogger.Helpers;

    using System.Data;

    /// <summary>
    /// Definition av <see cref="DoorEventsLog" />.
    /// </summary>
    public static class DoorEventsLog
    {
        /// <summary>
        /// Gets or sets the MaxEntries.
        /// </summary>
        public static int MaxEntries { get; set; } = 20;

        /// <summary>
        /// FindEntriesByDoor.
        /// </summary>
        /// <param name="door">Namnet på en dörr<see cref="string"/>.</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        public static DataTable FindEntriesByDoor(string door)
        {
            return DoorHelper.FindEntriesByDoor(door, MaxEntries);
        }

        /// <summary>
        /// FindEntriesByEvent.
        /// </summary>
        /// <param name="doorEvent">En sträng<see cref="string"/> med händelse ID (DÖIN = Dörren öppnades inifrån).</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        public static DataTable FindEntriesByEvent(string doorEvent)
        {
            return EventHelper.FindEntriesByEvent(doorEvent, MaxEntries);
        }

        /// <summary>
        /// FindEntriesByLocation.
        /// </summary>
        /// <param name="location">En sträng<see cref="string"/> med namnet på rummet eller lägenheten som söks.</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        public static DataTable FindEntriesByLocation(string location)
        {
            return LocationHelper.FindEntriesByLocation(location, MaxEntries);
        }

        /// <summary>
        /// FindEntriesByTag.
        /// </summary>
        /// <param name="TenantTag">En sträng<see cref="string"/> med koden till hyresgästens tagg.</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        public static DataTable FindEntriesByTag(string TenantTag)
        {
            return TagHelper.FindEntriesByTag(TenantTag, MaxEntries);
        }

        /// <summary>
        /// FindEntriesByTenant.
        /// </summary>
        /// <param name="Tenant">En sträng<see cref="string"/> med namnet på en hyresgäst.</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        public static DataTable FindEntriesByTenant(string Tenant)
        {
            return TenantHelper.FindEntriesByTenant(Tenant, MaxEntries);
        }

        /// <summary>
        /// ListTenantsAt.
        /// </summary>
        /// <param name="location">En sträng<see cref="string"/> med lägenhetsnummer.</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        public static DataTable ListTenantsAt(string location)
        {
            return TenantHelper.ListTenantsAt(location, MaxEntries);
        }

        public static void LogEntry(string date, string location, string eventCode, string tag)
        {
            LogHelper.CreateLog(date, location, eventCode, tag);
        }
    }
}