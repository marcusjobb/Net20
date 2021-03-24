namespace HFAB_v2_EF
{
    internal static class Program
    {
        private static void Main()
        {
            Database.DataBaseSeeder.CheackIfDataExist();

            while (true)
            {
                var byDoor = Controllers.DoorEventsLog.FindEntriesByDoor("SOPRUM");
                Views.Print.PrintLogg("Find by door", byDoor);

                var byEvent = Controllers.DoorEventsLog.FindEntriesByEvent("DÖUT");
                Views.Print.PrintLogg("Find by event", byEvent);

                var byLocation = Controllers.DoorEventsLog.FindEntriesByLocation("TVÄTT");
                Views.Print.PrintLogg("find by location", byLocation);

                var byTag = Controllers.DoorEventsLog.FindEntriesByTag("0102A");
                Views.Print.PrintLogg("find by tag", byTag);

                var byTenant = Controllers.DoorEventsLog.FindEntriesByTenant("Alexander Erlander");
                Views.Print.PrintLogg("find by tenant", byTenant);

                var ListTenat = Controllers.DoorEventsLog.ListTenantsAt("0201");
                Views.Print.PrintList(ListTenat);

                var enterData = Controllers.DoorEventsLog.LogEntry("2020-10-23 10:23", "LGH0301", "DÖIN", "0301A");
                Views.Print.PrintBool(enterData);

                var moveTanat = Controllers.DoorEventsLog.MoveTenant("0102A");
                Views.Print.PrintBool(moveTanat);

                moveTanat = Controllers.DoorEventsLog.MoveTenant("Wilma Johansson");
                Views.Print.PrintBool(moveTanat);

                var addTenent = Controllers.DoorEventsLog.AddTenant("Alice Olsson", "0102");
                Views.Print.PrintBool(addTenent);

                addTenent = Controllers.DoorEventsLog.AddTenant("Lucas Olsson", "0102");
                Views.Print.PrintBool(addTenent);

                ListTenat = Controllers.DoorEventsLog.ListTenantsAt("0102");
                Views.Print.PrintList(ListTenat);

                moveTanat = Controllers.DoorEventsLog.MoveTenant("0202C", "0302");
                Views.Print.PrintBool(moveTanat);
                moveTanat = Controllers.DoorEventsLog.MoveTenant("Lilly Adolfsson", "0202");
                Views.Print.PrintBool(moveTanat);

                System.Console.ReadKey();
            }
        }
    }
}