namespace IU2_Test.Controllers
{
    using IU2_Test.Database;
    using IU2_Test.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class DoorEventsLog
    {
        /// <summary>
        /// Anger hur mycket av vad som skall printas ut i console.
        /// </summary>
        public static int MaxEntries { get; set; } = 20;

        /// <summary>
        /// Gör en sökväg till dörr typ -> LGH, BLK osv i DB.
        /// </summary>
        /// <param name="doorName">Parameter för dörr namn, ex "LGH".</param>
        /// <returns>Returnerar sökning från DB.</returns>
        public static List<Relation> FindEntriesByDoor(string doorName)
        {
            using (var db = new MyDatabase())
            {
                return db.Relations
                    .Include(t => t.doorType)
                    .Include(e => e.eventType)
                    .Include(d => d.tenant)
                    .Where(f => f.doorType.Name == doorName)
                    .OrderByDescending(f => f.Date)
                    .Take(MaxEntries).ToList();
            }
        }

        /// <summary>
        /// Gör en sökväg till event namn -> DÖIN, DÖUT osv i DB.
        /// </summary>
        /// <param name="eventName">Parameter för event namn, ex "DÖUT".</param>
        /// <returns>Returnerar sökning från DB.</returns>
        public static List<Relation> FindEntriesByEvent(string eventName)
        {
            using (var db = new MyDatabase())
            {
                return db.Relations
                    .Include(e => e.doorType)
                    .Include(e => e.eventType)
                    .Include(e => e.tenant)
                    .Where(e => e.eventType.Name == eventName)
                    .OrderByDescending(e => e.Date)
                    .Take(MaxEntries).ToList();
            }
        }

        /// <summary>
        /// Sökväg för de senaste loggar från en viss LGH.
        /// </summary>
        /// <param name="locationName">Parameter för en plats, ex "TVÄTT".</param>
        /// <returns>Returnerar sökning från DB.</returns>
        public static List<Relation> FindEntriesByLocation(string locationName)
        {
            using (var db = new MyDatabase())
            {
                return db.Relations
                    .Include(d => d.doorType)
                    .Include(d => d.eventType)
                    .Include(d => d.tenant)
                    .Where(d => d.doorType.Name == locationName)
                    .OrderByDescending(l => l.Date)
                    .Take(MaxEntries).ToList();
            }
        }

        /// <summary>
        /// Sökväg för de senaste loggar från en viss tagg.
        /// </summary>
        /// <param name="tagName">Parameter för en viss tagg, ex "0103A".</param>
        /// <returns>Returnerar sökning från DB.</returns>
        public static List<Relation> FindEntriesByTag(string tagName)
        {
            using (var db = new MyDatabase())
            {
                return db.Relations
                    .Include(t => t.doorType)
                    .Include(t => t.eventType)
                    .Include(t => t.tenant)
                    .Where(t => t.tenant.Tag == tagName)
                    .OrderByDescending(t => t.Date)
                    .Take(MaxEntries).ToList();
            }
        }

        /// <summary>
        /// Sökväg för de senaste loggar från en viss hyresgäst.
        /// </summary>
        /// <param name="tenantName">Parameter för en hyresgäst, ex "Alexander Erlander".</param>
        /// <returns>Returnerar sökning från DB.</returns>
        public static List<Relation> FindEntriesByTenant(string tenantName)
        {
            using (var db = new MyDatabase())
            {
                return db.Relations
                    .Include(t => t.doorType)
                    .Include(t => t.eventType)
                    .Include(t => t.tenant)
                    .Where(t => t.tenant.Name == tenantName)
                    .OrderByDescending(t => t.Date)
                    .Take(MaxEntries).ToList();
            }
        }

        /// <summary>
        /// Sökväg för hyresgäst från en spicifik LGH.
        /// </summary>
        /// <param name="listTenant">Parameter för en hyresgäst LGH, ex "0201"</param>
        /// <returns>Returnerar sökning från DB.</returns>
        public static List<Relation> ListTenantsAt(string listTenant)
        {
            using (var db = new MyDatabase())
            {
                return db.Relations
                    .Include(t => t.doorType)
                    .Include(t => t.eventType)
                    .Include(t => t.tenant)
                    .Where(t => t.tenant.ApartmentNum == listTenant)
                    .OrderByDescending(t => t.Date)
                    .Take(MaxEntries).ToList();
            }
        }

        /// <summary>
        /// Information sparas i DB, tagg identifierar hyresgäst.
        /// </summary>
        /// <param name="door">Vilken dörr.</param>
        /// <param name="tenantTag">Vilken tagg.</param>
        /// <param name="events">Vilket event som utlöste, "DÖIN", "DÖUT".</param>
        /// <param name="date">Datum för händelse.</param>
        public static void LogEntry(string door, string tenantTag, string events, string date)
        {
            using (var debbi = new MyDatabase())
            {
                try
                {
                    var doorType = debbi.DoorTypes.FirstOrDefault(d => d.Name == door);
                    var eventId = debbi.Events.FirstOrDefault(e => e.Name == events);
                    var tag = debbi.Tenants.FirstOrDefault(t => t.Tag == tenantTag);

                    var entryLog = new Relation() { Date = date, doorType = doorType, eventType = eventId, tenant = tag };
                    debbi.Relations.Add(entryLog);
                    debbi.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Metoden används när en hyresgäst flyttar ut.
        /// </summary>
        /// <param name="tenantTagOne">Parameter för vilken tagg och personens namn.</param>
        public static void MoveTenant(string tenantTagOne)
        {
            var list = new List<Tenant>();
            using (var db = new MyDatabase())
            {
                try
                {
                    var taggar = db.Tenants.FirstOrDefault(t => t.Tag == tenantTagOne || t.Name == tenantTagOne);

                    if (taggar != null)
                    {
                        taggar.Tag = string.Empty;
                        taggar.ApartmentNum = string.Empty;
                        db.Tenants.Update(taggar);

                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong...", ex);
                }
            }
        }

        /// <summary>
        /// Metoden används när en hyresgäst flyttar in.
        /// </summary>
        /// <param name="newTenantName">för- & efternamn på hyresgästen.</param>
        /// <param name="newTenantTag">Vilken tagg som tilldelas.</param>
        public static void AddTenant(string newTenantName, string newTenantTag)
        {
            using (var db = new MyDatabase())
            {
                try
                {
                    var newTenants = db.Tenants.FirstOrDefault(t => t.Name == newTenantName || t.Tag == newTenantTag);

                    if (newTenants == null)
                    {
                        var list = new List<Tenant>
                        {
                            new Tenant{Name = "Alice Olsson", Tag = "0102C", ApartmentNum = "0102"},
                            new Tenant{Name = "Lucas Olsson", Tag = "0102D", ApartmentNum = "0102"}
                        };
                        db.Tenants.AddRange(list.OrderByDescending(t => t.Tag));
                        db.SaveChanges();
                        Console.WriteLine("Lucas and Alice Olsson has been added to the database!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
    }
}
