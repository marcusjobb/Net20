namespace HusrumProject
{
    using Controllers;
    using System;
    using Utils;
    using Views;

    internal class Program
    {
        private static void Main()
        {
            Seed.CheckDbPopulation();

            var byDoor = DoorEventLog.FindEntriesByDoor("LGH0302");
            PrintToConsole.Log("Search by door ", byDoor);
            var byEvent = DoorEventLog.FindEntriesByEvent("DÖIN");
            PrintToConsole.Log("\nSearch by event ", byEvent);
            var byLocation = DoorEventLog.FindEntriesByLocation("TVÄTT");
            PrintToConsole.Log("\nSearch by location ", byLocation);
            var byTenant = DoorEventLog.FindEntriesByTenant("Alexander Erlander");
            PrintToConsole.Log("\nSearch by tenant ", byTenant);
            var byTag = DoorEventLog.FindEntriesByTag("0102A");
            PrintToConsole.Log("\nSearch by tag ", byTag);
            var listTenants = DoorEventLog.ListTenantsAt("0201");
            PrintToConsole.List(listTenants);
            var logEntry = DoorEventLog.Log("2021-01-17 16:47", "DÖIN", "LGH0101", "0101A");
            PrintToConsole.CheckPrint(logEntry);
            var moveTenant = DoorEventLog.MoveTenant("0102A");
            PrintToConsole.CheckPrint(moveTenant);
            moveTenant = DoorEventLog.MoveTenant("Wilma Johansson");
            PrintToConsole.CheckPrint(moveTenant);
            var newTenant = DoorEventLog.AddTenant("Alice Olsson", "0102");
            PrintToConsole.CheckPrint(newTenant);
            newTenant = DoorEventLog.AddTenant("Lucas Olsson", "0102");
            PrintToConsole.CheckPrint(newTenant);
            listTenants = DoorEventLog.ListTenantsAt("0102");
            PrintToConsole.List(listTenants);

            Console.ReadLine();
        }
    }
}