namespace DoorEventsLogger.Helpers
{
    using DoorEventsLogger.Handler;

    using System;

    internal static class LogHelper
    {
        /// <summary>
        /// CreateLog.
        /// </summary>
        /// <param name="tenantId">Long<see cref="long"/> med hyresgästens ID.</param>
        /// <param name="doorId">Long<see cref="long"/> med dörrens ID.</param>
        /// <param name="eventCode">Long<see cref="long"/> med kodens ID. .</param>
        /// <param name="eventDate">Sträng<see cref="string"/> med händelsens datum.</param>
        internal static void CreateLog(long tenantId, long doorId, long eventCode, string eventDate, bool debug = true)
        {
            if (debug) MakeLogHumanReaable(tenantId, doorId, eventCode, eventDate);

            DBHandler.ExecuteSQL("INSERT INTO Events (TenantId, DoorId, EventCodeId, EventDate) VALUES(@tenantId, @doorId, @eventCodeId, @eventDate)",
                "@tenantId", tenantId.ToString(),
                "@doorId", doorId.ToString(),
                "@eventCodeId", eventCode.ToString(),
                "@eventDate", eventDate
                );
        }

        internal static void CreateLog(string eventDate, string location, string eventCode, string tag)
        {
            var tenantId = TenantHelper.GetTenantByTagId(tag);
            var doorId = LocationHelper.FindLocationByDoor(location);
            var eventCodeId = EventHelper.GetEventCodeId(eventCode);

            CreateLog(tenantId, doorId, eventCodeId, eventDate, false);
        }

        /// <summary>
        /// MakeLogHumanReaable.
        /// </summary>
        /// <param name="tenantId">Long<see cref="long"/> med hyresgästens ID.</param>
        /// <param name="doorId">Long<see cref="long"/> med dörrens ID.</param>
        /// <param name="eventCode">Long<see cref="long"/> med kodens ID. .</param>
        /// <param name="eventDate">Sträng<see cref="string"/> med händelsens datum.</param>
        private static void MakeLogHumanReaable(long tenantId, long doorId, long eventCode, string eventDate)
        {
            string name = TenantHelper.GetTenantName(tenantId);
            string tag = TagHelper.GetTenantTag(tenantId);
            object door = DoorHelper.GetDoorName(doorId);
            string code = EventHelper.GetEventCode(eventCode);
            Console.WriteLine(
                name +
                "used tag " + tag +
                "to open " + door +
                " at " + eventDate +
                " from the " + (code.EndsWith("IN") ? "inside" : "outside") + " " +
                (code.EndsWith("FD") ? "but had not access to open it" : "sucessfully")
                );
        }
    }
}