using System;
using System.Data;

namespace HFAB
{
    internal static class InputOutput
    {
        public static int UserInput(DoorEventsLog events)
        {
            int input = 9;
            while (input < 0 || input > 8)
            {
                Console.WriteLine("Ange vad du vill söka logsen efter. \n1. Door \n2. Location \n3. Event \n4. Tenant \n5. Tag \n6. Apartment \n7. TextLog Input");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Ange vilken dörr du vill söka efter (ex LGH0101, BLK0101)");
                        string door = Console.ReadLine();
                        var byDoor = events.FindEntriesByDoor(door)?.Rows;
                        OutputData("Search by door", byDoor);
                        break;

                    case 2:
                        Console.WriteLine("Ange vilken plats du vill söka efter (ex 0101, TVÄTT)");
                        string location = Console.ReadLine();
                        var byLocation = events.FindEntriesByLocation(location)?.Rows;
                        OutputData("Search by location", byLocation);
                        break;

                    case 3:
                        Console.WriteLine("Ange vilken händelse du vill söka efter (FDIN, FDUT, DÖIN, DÖUT)");
                        string evnt = Console.ReadLine();
                        var byEvent = events.FindEntriesByEvent(evnt)?.Rows;
                        OutputData("Search by event", byEvent);
                        break;

                    case 4:
                        Console.WriteLine("Ange vilken inneboende du vill söka efter (ex Liam Jönsson)");
                        string tenant = Console.ReadLine();
                        var byTenant = events.FindEntriesByTenant(tenant)?.Rows;
                        OutputData("Search by Tenant", byTenant);
                        break;

                    case 5:
                        Console.WriteLine("Ange vilken tag du vill söka efter (ex 0101A)");
                        string tag = Console.ReadLine();
                        var byTag = events.FindEntriesByTag(tag)?.Rows;
                        OutputData("Search by tag", byTag);
                        break;

                    case 6:
                        Console.WriteLine("Ange vilken lägenhet du vill söka efter (ex LGH0101)");
                        string apartment = Console.ReadLine();
                        var tenants = events.ListTenantsAt(apartment)?.Rows;
                        OutputTenants(tenants);
                        break;

                    case 7:
                        Console.WriteLine("Ange datum: (yyyy-mm-dd hh:mm:ss");
                        string date = Console.ReadLine();
                        Console.WriteLine("Ange dörr:(ex LGH0101, BLK0101)");
                        string door1 = Console.ReadLine();
                        Console.WriteLine("Ange händelse: (FDIN, FDUT, DÖIN, DÖUT)");
                        string evnt1 = Console.ReadLine();
                        Console.WriteLine("Ange dörrtag (0101A)");
                        string tag1 = Console.ReadLine();
                        DoorEventsLog.LogEntry(date, door1, evnt1, tag1);
                        break;
                }
            }
            return input;
        }

        private static void OutputData(string title, DataRowCollection byCode)
        {
            Console.WriteLine(title);
            foreach (DataRow r in byCode)
            {
                Console.WriteLine($"{r["Date"]} {r["Door"]} {r["Event"]} {r["Tag"]} {r["Tenant"]} {DoText(r)}");
            }
        }

        private static void OutputTenants(DataRowCollection tenants)
        {
            Console.WriteLine("Tenants");
            foreach (DataRow r in tenants) { Console.WriteLine($"{r["Location"]} {r["Tag"]} {r["Tenant"]}"); }
        }

        private static string DoText(DataRow r)
        {
            var ev = r["event"].ToString();
            var what = ev.StartsWith("FD") ? "Fösökte öppna" : "öppnade";
            var where = ev.EndsWith("IN") ? "inifrån" : "utifrån";
            return $"{what} dörr till {r["Location"]} {where}";
        }
    }
}