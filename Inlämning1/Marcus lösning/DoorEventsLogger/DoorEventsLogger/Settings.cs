namespace DoorEventsLogger
{
    using System;

    /// <summary>
    /// Program settings shared by all classes.
    /// </summary>
    internal static class Settings
    {
        /// <summary>
        /// Definition av GenericSQLSearch..
        /// </summary>
        internal const string GenericSQLSearch = @"
            SELECT EventDate as Date, Tenants.Name as Tenant, Tenants.tag, Doors.Door, Locations.Location, EventCodes.code as Event, Events.Id as EventId, TenantId, DoorId, Doors.LocationId, EventCodeId
                FROM Events
                JOIN Tenants ON Tenants.ID=TenantId
                JOIN Doors ON Doors.Id=DoorId
                JOIN Locations ON Doors.LocationId=Locations.Id
                JOIN EventCodes ON EventCodes.Id=EventCodeId ";

        /// <summary>
        /// Definition av slumpgenerator..
        /// </summary>
        internal static readonly Random Rnd = new Random();

        internal static string DateTimeFormat { get; set; } = Settings.DateTimeFormat;

        /// <summary>
        /// Gets or sets the Database
        /// Sökväg till databasfilen..
        /// </summary>
        internal static string Database { get; set; } = @".\DoorEventsLog.db";
    }
}