using System;

namespace HusrumFastigheter2
{
    class Program
    {
        static void Main()
        {
            Database.DatabaseSeeder.CheckData();

            while (true)
            {
                var byDoor = Controllers.DoorEventsLog.FindEntriesByDoor("LGH0101");
                Views.OutPutData.OutPutLog("Find entries by door", byDoor);

                var byEvent = Controllers.DoorEventsLog.FindEntriesByEvent("DÖIN");
                Views.OutPutData.OutPutLog("Find entries by event", byEvent);

                var byLocation = Controllers.DoorEventsLog.FindEntriesByLocation("SOPRUM");
                Views.OutPutData.OutPutLog("Find entries by location", byLocation);

                var byTag = Controllers.DoorEventsLog.FindEntriesByTag("0201B");
                Views.OutPutData.OutPutLog("Find entries by tag", byTag);

                var byTenant = Controllers.DoorEventsLog.FindEntriesByTenant("Liam Jönsson");
                Views.OutPutData.OutPutLog("Find entries by tenant", byTenant);

                var listTenant = Controllers.DoorEventsLog.ListTenantsAt("0102");
                Views.OutPutData.OutPutList(listTenant);

                var entryLog = Controllers.DoorEventsLog.LogEntry("2021-01-14 12:51", "LGH0302", "DÖIN", "0302D");
                Views.OutPutData.OutPutBool(entryLog);

                var moveTenant = Controllers.DoorEventsLog.MoveTenant("0201B");
                Views.OutPutData.OutPutBool(moveTenant);
                moveTenant = Controllers.DoorEventsLog.MoveTenant("Wilma Johansson");
                Views.OutPutData.OutPutBool(moveTenant);

                var addTenant = Controllers.DoorEventsLog.AddTenant("Torsten Eliasson", "0201");
                Views.OutPutData.OutPutBool(addTenant);

                addTenant = Controllers.DoorEventsLog.AddTenant("Gunn-Britt Eliasson", "0201");
                Views.OutPutData.OutPutBool(addTenant);

                moveTenant = Controllers.DoorEventsLog.MoveTenant("0202B", "0301");
                Views.OutPutData.OutPutBool(moveTenant);
                moveTenant = Controllers.DoorEventsLog.MoveTenant("Lilly Adolfsson", "0202");
                Views.OutPutData.OutPutBool(moveTenant);

                Console.ReadKey();
            }
        }
    }
}
