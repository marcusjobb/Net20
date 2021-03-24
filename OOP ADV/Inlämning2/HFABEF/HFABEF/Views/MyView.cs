using HFABEF.Interfaces;
using System;

namespace HFABEF.Views
{
    public class MyView : IViews
    {
        /// <summary>
        ///  Metod som skriver ut information till användaren (output) och tar emot data från användaren (input) och tillkallar metoderna med som ansvarar för det användaren bad om.
        /// </summary>
        public static void View()
        {
            using var db = new Database.MyDatabase();

            int input = 11;
            while (input < 0 || input > 10)
            {
                Console.WriteLine("Ange vad du vill söka logsen efter. \n1. Door \n2. Location \n3. Event \n4. Tenant \n5. Tag \n6. Date \n7. Tenants in apartment \n8. Move tenant \n9. Add Tenant \n10. TextLog Input");
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Ange vilken dörr du vill söka efter (ex LGH0101, BLK0101)");
                        string door = Console.ReadLine();

                        foreach (var log in Models.DoorEventsLog.FindEntriesByDoor(door))
                        {
                            Console.WriteLine(log.Date + "\t" + log.Door.Door + "\t" + log.Tenant.Tag +"\t" +log.Event.Code + "\t" + log.Door.Location + "\t" + log.Tenant.Tenant);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Ange vilken plats du vill söka efter (ex 0101, TVÄTT)");
                        string location = Console.ReadLine();

                        foreach (var log in Models.DoorEventsLog.FindEntriesByLocation(location))
                        {
                            Console.WriteLine(log.Date + "\t" + log.Door.Door + "\t" + log.Tenant.Tag + "\t" + log.Event.Code + "\t" + log.Door.Location + "\t" + log.Tenant.Tenant);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Ange vilken händelse du vill söka efter (FDIN, FDUT, DÖIN, DÖUT)");
                        string evnt = Console.ReadLine();

                        foreach (var log in Models.DoorEventsLog.FindEntriesByEvent(evnt))
                        {
                            Console.WriteLine(log.Date + "\t" + log.Door.Door + "\t" + log.Tenant.Tag + "\t" + log.Event.Code + "\t" + log.Door.Location + "\t" + log.Tenant.Tenant);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Ange vilken inneboende du vill söka efter (ex Liam Jönsson)");
                        string tenant = Console.ReadLine();

                        foreach (var log in Models.DoorEventsLog.FindEntriesByTenant(tenant))
                        {
                            Console.WriteLine(log.Date + "\t" + log.Door.Door + "\t" + log.Tenant.Tag + "\t" + log.Event.Code + "\t" + log.Door.Location + "\t" + log.Tenant.Tenant);
                        }
                        break;

                    case 5:
                        Console.WriteLine("Ange vilken tag du vill söka efter (ex 0101A)");
                        string tag = Console.ReadLine();

                        foreach (var log in Models.DoorEventsLog.FindEntriesByTag(tag))
                        {
                            Console.WriteLine(log.Date + "\t" + log.Door.Door + "\t" + log.Tenant.Tag + "\t" + log.Event.Code + "\t" + log.Door.Location + "\t" + log.Tenant.Tenant);
                        }
                        break;

                    case 6:
                        Console.WriteLine("Ange vilket datum du vill söka logsen efter (YYYY-MM-DD hh:mm:ss)");
                        string date = Console.ReadLine();

                        foreach (var log in Models.DoorEventsLog.FindEntriesByDate(date))
                        {
                            Console.WriteLine(log.Date + "\t" + log.Door.Door + "\t" + log.Tenant.Tag + "\t" + log.Event.Code + "\t" + log.Door.Location + "\t" + log.Tenant.Tenant);
                        }
                        break;

                    case 7:
                        Console.WriteLine("Ange vilken lägenhets för att se dess inneboende");
                        string apartment1 = Console.ReadLine();

                        foreach (var log in Models.DoorEventsLog.ListTenantsAt(apartment1))
                        {
                            Console.WriteLine(log.Tenant);
                        }
                        break;

                    case 8:
                        Console.WriteLine("Ange den flyttandes namn eller tag: ");
                        string oldTenant = Console.ReadLine();
                        Console.WriteLine("Ange lägenheten i fråga (ex. 0101) OBS. Lämnas blankt om personen i fråga flyttar ut)");
                        string apartment2 = Console.ReadLine();
                        Console.WriteLine(Models.DoorEventsLog.MoveTenant(oldTenant, apartment2)); // skriver ut true false ifall resulatatet lyckades eller inte
                        break;

                    case 9:
                        Console.WriteLine("Ange den nya inneboendes namn");
                        string newTenant1 = Console.ReadLine();
                        Console.WriteLine(Models.DoorEventsLog.AddTenant(newTenant1)); // Skriver ut True om insättningen lyckades och false om den misslyckades
                        break;

                    case 10:
                        Console.WriteLine("Ange datum: (yyyy-mm-dd hh:mm:ss");
                        string date1 = Console.ReadLine();
                        Console.WriteLine("Ange dörr:(ex LGH0101, BLK0101)");
                        string door1 = Console.ReadLine();
                        Console.WriteLine("Ange händelse: (FDIN, FDUT, DÖIN, DÖUT)");
                        string evnt1 = Console.ReadLine();
                        Console.WriteLine("Ange Inneboende (Ella Ahlström)");
                        string tenant1 = Console.ReadLine();

                        Models.DoorEventsLog.LogEntry(date1, door1, evnt1, tenant1);
                        break;
                }
            }
        }
    }
}