using System;

namespace DoorEventLogProject
{
    class Program
    {
        static void Main()
        {
            //Initiate database and add all test data
            Create.DatabaseFile();

            while (true)
            {
                var byDoor = DoorEventLog.FindEntriesByDoor("LGH0302");
                var byEvent = DoorEventLog.FindEntriesByEvent("DÖIN");
                var byLocation = DoorEventLog.FindEntriesByLocation("TVÄTT");
                var byTag = DoorEventLog.FindEntriesByTag("0102A");
                var byTenant = DoorEventLog.FindEntriesByTenant("Alexander Erlander");
                var tenants = DoorEventLog.ListTenantsAt("0201");
                var logEntry = DoorEventLog.LogEntry("2020-10-23 10:23", "DÖIN", "LGH0301", "0301A");

                PrintToConsole.PrintData("Search by door", byDoor);
                PrintToConsole.PrintData("Search by event", byEvent);
                PrintToConsole.PrintData("Search by location", byLocation);
                PrintToConsole.PrintData("Search by tag", byTag);
                PrintToConsole.PrintData("Search by tenants", byTenant);
                PrintToConsole.PrintList(tenants);
                PrintToConsole.PrintLogEntry(logEntry);
                Console.ReadLine();
            }
            
        }
    }
}
