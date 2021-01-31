using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace HFABEF.Models
{
    public static class DoorEventsLog
    {
        public static int MaxEntries { get; set; } = 20;

        public static List<Logs> FindEntriesByDoor(string door) // Sök de sensaste loggar från en viss dörr, returnerera en List
        {
            using var db = new Database.MyDatabase();
            var doorQuery = from l in db.Logs.Include("Door").Include("Tenant").Include("Event")
                            where l.Door.Door == door
                            orderby l.Date descending
                            select l;
            List<Logs> logList = new List<Logs>();
            foreach (var log in doorQuery.Take(MaxEntries))
            {
                logList.Add(log);
            }
            return logList;
        }

        public static List<Logs> FindEntriesByLocation(string location) // Sök de senaste loggar från en viss lägenhet/rum, returnera en List
        {
            using var db = new Database.MyDatabase();
            var locationQuery = from l in db.Logs.Include("Door").Include("Tenant").Include("Event")
                                where l.Door.Location == location
                                orderby l.Date descending
                                select l;
            List<Logs> logList = new List<Logs>();
            foreach (var log in locationQuery.Take(MaxEntries))
            {
                logList.Add(log);
            }
            return logList;
        }

        public static List<Logs> FindEntriesByEvent(string evnt) // Sök de senaste loggar från en viss händelse, returnera en List
        {
            using var db = new Database.MyDatabase();
            var eventQuery = from l in db.Logs.Include("Door").Include("Tenant").Include("Event")
                             where l.Event.Code == evnt
                             orderby l.Date descending
                             select l;
            List<Logs> logList = new List<Logs>();
            foreach (var log in eventQuery.Take(MaxEntries))
            {
                logList.Add(log);
            }
            return logList;
        }

        public static List<Logs> FindEntriesByTenant(string tenant) // Sök de senaste loggar från en viss hyresgäst, returnera en List
        {
            using var db = new Database.MyDatabase();
            var tenantQuery = from l in db.Logs.Include("Door").Include("Tenant").Include("Event")
                              where l.Tenant.Tenant == tenant
                              orderby l.Date descending
                              select l;
            List<Logs> logList = new List<Logs>();
            foreach (var log in tenantQuery.Take(MaxEntries))
            {
                logList.Add(log);
            }
            return logList;
        }

        public static List<Logs> FindEntriesByTag(string tag) // Sök de senaste loggar fårn en viss tagg, returnera en List
        {
            using var db = new Database.MyDatabase();
            var tagQuery = from l in db.Logs.Include("Door").Include("Tenant").Include("Event")
                           where l.Tenant.Tag == tag
                           orderby l.Date descending
                           select l;
            List<Logs> logList = new List<Logs>();
            foreach (var log in tagQuery.Take(MaxEntries))
            {
                logList.Add(log);
            }
            return logList;
        }

        public static List<Logs> FindEntriesByDate(string date)
        {
            using var db = new Database.MyDatabase();
            var dateQuery = from l in db.Logs.Include("Door").Include("Tenant").Include("Event")
                            where l.Date == date // Hitta något sätt att endast söka efter en dag. Inte exakta tidpunkten
                            orderby l.Date descending
                            select l;
            List<Logs> logList = new List<Logs>();
            foreach (var log in dateQuery.Take(MaxEntries))
            {
                logList.Add(log);
            }
            return logList;
        }

        public static List<Tenants> ListTenantsAt(string apartment) // Söker hyresgäster från specifik lägenhet, listar upp deras namn och tagg-kod. returenera en List
        {
            using var db = new Database.MyDatabase();
            var apartmentQuery2 = from t in db.Tenants
                                  where t.Location == apartment
                                  select t;
            List<Tenants> logList = new List<Tenants>();
            foreach (var tenant in apartmentQuery2.Take(MaxEntries))
            {
                logList.Add(tenant);
            }
            return logList;
        }

        public static bool MoveTenant(string tenant, string apartment)
        {
            using var db = new Database.MyDatabase();
            int count = 0;
            List<char> tagHelper = new List<char>()
            {
                'A',
                'B',
                'C',
                'D',
                'E',
                'F',
                'G'
            };

            if (apartment == string.Empty)
            {
                try
                {
                    var moveQuery = from t in db.Tenants
                                    where t.Tenant == tenant
                                    select t;
                    var moveQueryList = moveQuery.ToList()[0];

                    if (moveQuery != null)
                    {
                        moveQueryList.Tag = null;
                        moveQueryList.Location = null;
                        db.Tenants.Update(moveQueryList);
                        db.SaveChanges();
                    }
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    bool tagChecker = false;
                    var moveQuery = from t in db.Tenants
                                    where t.Tenant == tenant
                                    select t;
                    var moveQueryList = moveQuery.ToList()[0];

                    if (moveQuery != null)
                    {
                        do
                        {
                            string tag = apartment + tagHelper[count];
                            var tagQuery = from t in db.Tenants
                                           where t.Tag == tag
                                           select t;
                            var tagQueryList = tagQuery.ToList();

                            if (!tagQueryList.Any())
                            {
                                moveQueryList.Tag = tag;
                                tagChecker = true;
                            }
                            else
                            {
                                count++;
                                tagChecker = false;
                            }
                        } while (!tagChecker);

                        moveQueryList.Location = apartment;
                        db.Tenants.Update(moveQueryList);
                        db.SaveChanges();
                    }
                }
                catch (System.Exception)
                {
                    return false;
                }
                return false;
            }
        }

        public static bool AddTenant(string newTenant)
        {
            try
            {
                using var db = new Database.MyDatabase();
                db.Tenants.Add(new Tenants { Tenant = newTenant });
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public static void LogEntry(string date, string door, string evnt, string tenant) // Informationen skickas in i textform och sparas i lämplig form och i lämpliga tabeller i databasen.
        {
            using var db = new Database.MyDatabase();

            db.Add(new Logs
            {
                Date = date,
                Door = new Doors { Door = door },
                Event = new Event { Code = evnt },
                Tenant = new Tenants { Tenant = tenant }
            });
        }
    }
}