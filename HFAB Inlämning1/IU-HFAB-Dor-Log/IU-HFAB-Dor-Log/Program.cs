using System;
using System.Data;

namespace IU_HFAB_Dor_Log
{
    internal static class Program
    {
        private static void Main()
        {
            Sql.Create();
            Sql.CreateTestData();
            while (true)
            {
                var byDoor = DoorEventsLog.FindEntriesByDoor("SOPRUM");
                var byEvent = DoorEventsLog.FindEntriesByEvent("DÖUT");
                var byLocation = DoorEventsLog.FindEntriesByLocation("TVÄTT");
                var byTag = DoorEventsLog.FindEntriesByTag("0102A");
                var byTenant = DoorEventsLog.FindEntriesByTenant("Alexander Erlander");
                var ListTenat = DoorEventsLog.ListTenantsAt("0201");
                var enterData = DoorEventsLog.LogEntry("2020-10-23 10:23", "LGH0301", "DÖIN", "0301A");

                Print.PrintData("Find by door",byDoor);
                Print.PrintData("Find by event",byEvent);
                Print.PrintData("find by location",byLocation);
                Print.PrintData("find by tag",byTag);
                Print.PrintData("find by tanant",byTenant);
                Print.PrintList(ListTenat);
                Print.PrintLoggEntry(enterData);
                Console.ReadKey();
            }
        }
    }
}