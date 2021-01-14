using System;

namespace uppgift1_HFAB
{
    class Program : Database
    {
        static void Main(string[] args)
        {
            // TestDatan laddas.
            SQL.TestData();

            //Instans från DoorEventsLog.cs
            var events = new DoorEventsLog();

            var byDoor = events.FindEntriesByDoor("LGH");
            var byEvent = events.FindEntriesByEvent("DÖUT");
            var byLocation = events.FindEntriesByLocation("TVÄTT");
            var byTag = events.FindEntriesByTag("0102A");
            var byTenant = events.FindEntriesByTenant("Alexander Erlander");
            var tenants = events.ListTenantsAt("0201");
            var enterData = DoorEventsLog.LogEntry("2020-12-04 - 16:15", "LGH0101", "DÖIN", "0301A");

            Output.outputData("Find by location", byLocation);
            Output.outputData("Find by event", byEvent);
            Output.outputData("Find by door", byDoor);
            Output.outputData("Find by tag", byTag);
            Output.outputData("Find by Tenant", byTenant);
            Output.ThePrinterOfList(tenants);
            Output.PrintLoggEntry(enterData);
            Console.ReadKey();
        }
    }
}
