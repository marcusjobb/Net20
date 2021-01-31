namespace IU2_Test.Models
{
    using IU2_Test.Controllers;
    using IU2_Test.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Output : IOutput
    {
        /// <summary>
        /// Hanterar utskrift från "FindEntriesByDoor("LGH")".
        /// </summary>
        /// <param name="outDoor">sträng parameter "LGH"</param>
        /// <param name="data">Data från Listan Relation.cs.</param>
        public void OutputByDoor(string outDoor, List<Relation> data)
        {
            Console.WriteLine(outDoor);

            var byDoor = DoorEventsLog.FindEntriesByDoor("LGH");

            if (data.Count > 0)
            {
                foreach (var doors in byDoor)
                {
                    string doorEvent;
                    if (doors.eventType.Name == "DÖIN")
                    {
                        doorEvent = $"Öppnade dörr {doors.doorType.Name} inifrån";
                    }
                    else if (doors.eventType.Name == "DÖUT")
                    {
                        doorEvent = $"Öppnade dörr {doors.doorType.Name} utifrån";
                    }
                    else if (doors.eventType.Name == "FDIN")
                    {
                        doorEvent = $"Försökt öppna fel dörr {doors.doorType.Name} utifrån";
                    }
                    else if (doors.eventType.Name == "FDUT")
                    {
                        doorEvent = $"Försökt öppna fel dörr {doors.doorType.Name} inifrån";
                    }
                    else
                    {
                        doorEvent = " ";
                    }
                    Console.WriteLine($"{doors.Date}, {doors.eventType.Name}, {doors.tenant.Tag}, {doors.doorType.Name}, {doors.tenant.ApartmentNum}, {doors.tenant.Name}, {doorEvent}");
                }
            }
        }

        /// <summary>
        /// Hanterar utsktift från FindEntriesByEvent("DÖUT").
        /// </summary>
        /// <param name="outEvent">sträng parameter "DÖUT"</param>
        /// <param name="data">Data från Listan Relation.cs.</param>
        public void OutputByEvent(string outEvent, List<Relation> data)
        {
            Console.WriteLine(outEvent);

            var byEvent = DoorEventsLog.FindEntriesByEvent("DÖUT");

            if (data.Count > 0)
            {
                foreach (var events in byEvent)
                {
                    string doorEvent;
                    if (events.eventType.Name == "DÖIN")
                    {
                        doorEvent = $"Öppnade dörr {events.doorType.Name} inifrån";
                    }
                    else if (events.eventType.Name == "DÖUT")
                    {
                        doorEvent = $"Öppnade dörr {events.doorType.Name} utifrån";
                    }
                    else if (events.eventType.Name == "FDUT")
                    {
                        doorEvent = $"Försökt öppna fel dörr {events.doorType.Name} inifrån";
                    }
                    else
                    {
                        doorEvent = "";
                    }
                    Console.WriteLine($"{events.Date}, {events.eventType.Name}, {events.tenant.Tag}, {events.doorType.Name}, {events.tenant.ApartmentNum}, {events.tenant.Name}, {doorEvent}");

                }
            }
        }

        /// <summary>
        /// Hanterar utskrift från FindEntriesByLocation("TVÄTT").
        /// </summary>
        /// <param name="outLocation">Sträng parameter "TVÄTT"</param>
        /// <param name="data">Data från Listan Relation.cs.</param>
        public void OutputByLocation(string outLocation, List<Relation> data)
        {
            Console.WriteLine(outLocation);

            var byLocation = DoorEventsLog.FindEntriesByLocation("TVÄTT");

            if (data.Count > 0)
            {
                foreach (var locations in byLocation)
                {
                    string doorEvent;
                    if (locations.eventType.Name == "DÖIN")
                    {
                        doorEvent = $"Öppnade dörr {locations.doorType.Name} inifrån";
                    }
                    else if (locations.eventType.Name == "DÖUT")
                    {
                        doorEvent = $"Öppnade dörr {locations.doorType.Name} utifrån";
                    }
                    else if (locations.eventType.Name == "FDIN")
                    {
                        doorEvent = $"Försökt öppna fel dörr {locations.doorType.Name} utifrån";
                    }
                    else if (locations.eventType.Name == "FDUT")
                    {
                        doorEvent = $"Försökt öppna fel dörr {locations.doorType.Name} inifrån";
                    }
                    else
                    {
                        doorEvent = "";
                    }
                    Console.WriteLine($"{locations.Date}, {locations.eventType.Name}, {locations.tenant.Tag}, {locations.doorType.Name}, {locations.tenant.ApartmentNum}, {locations.tenant.Name}, {doorEvent}");
                }
            }
        }

        /// <summary>
        /// Hanterar utskrift från FindEntriesByTag("0103A").
        /// </summary>
        /// <param name="outTag">Sträng parameter för "0102A".</param>
        /// <param name="data">Data från Listan Relation.cs.</param>
        public void OutputByTag(string outTag, List<Relation> data)
        {
            Console.WriteLine(outTag);

            var byTag = DoorEventsLog.FindEntriesByTag("0103A");

            if (data.Count > 0)
            {
                foreach (var tag in byTag)
                {
                    string doorEvent;
                    if (tag.eventType.Name == "DÖIN")
                    {
                        doorEvent = $"Öppnade dörr {tag.doorType.Name} inifrån";
                    }
                    else if (tag.eventType.Name == "DÖUT")
                    {
                        doorEvent = $"Öppnade dörr {tag.doorType.Name} utifrån";
                    }
                    else if (tag.eventType.Name == "FDIN")
                    {
                        doorEvent = $"Försökt öppna fel dörr {tag.doorType.Name} utifrån";
                    }
                    else if (tag.eventType.Name == "FDUT")
                    {
                        doorEvent = $"Försökt öppna fel dörr {tag.doorType.Name} inifrån";
                    }
                    else
                    {
                        doorEvent = "";
                    }
                    Console.WriteLine($"{tag.Date}, {tag.eventType.Name}, {tag.tenant.Tag}, {tag.doorType.Name}, {tag.tenant.ApartmentNum}, {tag.tenant.Name}, {doorEvent}");
                }
            }
        }

        /// <summary>
        /// Hanterar utskrift från FindEntriesByTenant("Alexander Erlander").
        /// </summary>
        /// <param name="outTenant">Sträng parameter "Alexander Erlander".</param>
        /// <param name="data">Data från Listan Relation.cs.</param>
        public void OutputByTenant(string outTenant, List<Relation> data)
        {
            Console.WriteLine(outTenant);

            var byTenant = DoorEventsLog.FindEntriesByTenant("Alexander Erlander");

            if (data.Count > 0)
            {
                foreach (var tenant in byTenant)
                {
                    string doorEvent;
                    if (tenant.eventType.Name == "DÖIN")
                    {
                        doorEvent = $"Öppnade dörr {tenant.doorType.Name} inifrån";
                    }
                    else if (tenant.eventType.Name == "DÖUT")
                    {
                        doorEvent = $"Öppnade dörr {tenant.doorType.Name} utifrån";
                    }
                    else if (tenant.eventType.Name == "FDIN")
                    {
                        doorEvent = $"Försökt öppna fel dörr {tenant.doorType.Name} utifrån";
                    }
                    else if (tenant.eventType.Name == "FDUT")
                    {
                        doorEvent = $"Försökt öppna fel dörr {tenant.doorType.Name} inifrån";
                    }
                    else
                    {
                        doorEvent = "";
                    }
                    Console.WriteLine($"{tenant.Date}, {tenant.eventType.Name}, {tenant.tenant.Tag}, {tenant.doorType.Name}, {tenant.tenant.ApartmentNum}, {tenant.tenant.Name}, {doorEvent}");
                }
            }
        }

        /// <summary>
        /// Hanterar utskrift från ListTenantsAt("0201").
        /// </summary>
        /// <param name="data">Data från Listan Relation.cs.</param>
        public void OutputListTenant(List<Relation> data)
        {
            var listTenant = DoorEventsLog.ListTenantsAt("0201");

            if (data.Count > 0)
            {
                foreach (var tenants in listTenant)
                {
                    string doorEvent;
                    if (tenants.eventType.Name == "DÖIN")
                    {
                        doorEvent = $"Öppnade dörr {tenants.doorType.Name} inifrån";
                    }
                    else if (tenants.eventType.Name == "DÖUT")
                    {
                        doorEvent = $"Öppnade dörr {tenants.doorType.Name} utifrån";
                    }
                    else if (tenants.eventType.Name == "FDIN")
                    {
                        doorEvent = $"Försökt öppna fel dörr {tenants.doorType.Name} utifrån"; 
                    }
                    else if (tenants.eventType.Name == "FDUT")
                    {
                        doorEvent = $"Försökt öppna fel dörr {tenants.doorType.Name} inifrån";
                    }
                    else
                    {
                        doorEvent = "";
                    }
                    Console.WriteLine($"{tenants.Date}, {tenants.eventType.Name}, {tenants.tenant.Tag}, {tenants.doorType.Name}, {tenants.tenant.ApartmentNum}, {tenants.tenant.Name}, {doorEvent}");
                }
            }
        }
    }
}
