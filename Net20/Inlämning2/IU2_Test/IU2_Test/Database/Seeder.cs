namespace IU2_Test.Database
{
    using IU2_Test.Controllers;
    using IU2_Test.Interfaces;
    using IU2_Test.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Seeder
    {
        /// <summary>
        /// Nedan används using för att öppna kommunikation till DB.
        /// Vi lägger till alla hyresgäster, taggar, lägenheter.
        /// De sorteras i DB efter taggarna i fallande ordning.
        /// db.SaveChanges(); Sparar ändringar.
        /// </summary>
        public static void AddTenantsToDatabase()
        {
            using (var db = new MyDatabase())
            {
                try
                {
                    if (db.Tenants.Count() == 0)
                    {
                        var list = new List<Tenant>
                        {
                        new Tenant{Name = "Liam Jönsson", Tag = "0101A", ApartmentNum = "0101"},
                        new Tenant{Name = "Elias Petterson", Tag ="0102A", ApartmentNum = "0102"},
                        new Tenant{Name = "Wilma Johansson", Tag ="0102B", ApartmentNum = "0102"},
                        new Tenant{Name = "Alicia Sanchez", Tag ="0103A", ApartmentNum = "0103"},
                        new Tenant{Name = "Aaron Sanchez", Tag ="0103B", ApartmentNum = "0103"},
                        new Tenant{Name = "Olivia Erlander", Tag ="0201A", ApartmentNum = "0201"},
                        new Tenant{Name = "William Erlander", Tag ="0201B", ApartmentNum = "0201"},
                        new Tenant{Name = "Alexander Erlander", Tag ="0201C", ApartmentNum = "0201"},
                        new Tenant{Name = "Astrid Erlander", Tag ="0201D", ApartmentNum = "0201"},
                        new Tenant{Name = "Lucas Adolfsson", Tag ="0202A", ApartmentNum = "0202"},
                        new Tenant{Name = "Ebba Adolfsson", Tag ="0202B", ApartmentNum = "0202"},
                        new Tenant{Name = "Lilly Adolfsson", Tag ="0202C", ApartmentNum = "0202"},
                        new Tenant{Name = "Ella Ahlström", Tag ="0301A", ApartmentNum = "0301"},
                        new Tenant{Name = "Alma Alfredsson", Tag ="0301B", ApartmentNum = "0301"},
                        new Tenant{Name = "Elsa Ahlström", Tag ="0301C", ApartmentNum = "0301"},
                        new Tenant{Name = "Maja Ahlström", Tag ="0301D", ApartmentNum = "0301"},
                        new Tenant{Name = "Noah Almgren", Tag ="0302A", ApartmentNum = "0302"},
                        new Tenant{Name = "Adam Andersen", Tag ="0302B", ApartmentNum = "0302"},
                        new Tenant{Name = "Kattis Backman", Tag ="0302C", ApartmentNum = "0302"},
                        new Tenant{Name = "Oscar Chen", Tag ="0302D", ApartmentNum = "0302"},
                        new Tenant{Name = "Vaktmästare", Tag ="VAKT01", ApartmentNum = "VAKT"}
                        };
                        db.Tenants.AddRange(list.OrderByDescending(s => s.Tag));
                        db.SaveChanges();
                        Console.WriteLine("Everything added successfully - " + DateTime.Now + "!");
                    }
                    else
                    {
                        Console.WriteLine("Everything is up to date, no update needed. - " + DateTime.Now + "!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong...");
                }
            }
        }

        /// <summary>
        /// Nedan används using för att öppna kommunikation till DB.
        /// Vi lägger till Dörr namn.
        /// De sorteras i DB efter namn i fallande ordning.
        /// db.SaveChanges(); Sparar ändringar.
        /// </summary>
        public static void AddDoorType()
        {
            using (var db = new MyDatabase())
            {
                try
                {
                    if (db.DoorTypes.Count() == 0)
                    {
                        var list = new List<DoorType>
                    {
                        new DoorType{Name = "LGH"},
                        new DoorType{Name = "BLK"},
                        new DoorType{Name = "SOPRUM"},
                        new DoorType{Name = "UT"},
                        new DoorType{Name = "SOPRUM"},
                        new DoorType{Name = "TVÄTT"},
                        new DoorType{Name = "VAKT"}
                    };
                        db.DoorTypes.AddRange(list.OrderBy(s => s.Name));
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong...");
                }
            }
        }

        /// <summary>
        /// Nedan används using för att öppna kommunikation till DB.
        /// Vi lägger till eventen.
        /// De sorteras i DB efter namn i fallande ordning.
        /// db.SaveChanges(); Sparar ändringar.
        /// </summary>
        public static void AddEvents()
        {
            using (var db = new MyDatabase())
            {
                try
                {
                    if (db.Events.Count() == 0)
                    {
                        var list = new List<Event>
                    {
                        new Event{Name = "DÖUT"},
                        new Event{Name = "DÖIN"},
                        new Event{Name = "FDIN"},
                        new Event{Name = "FDUT"},
                    };
                        db.Events.AddRange(list.OrderBy(s => s.Name));
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong...");
                }
            }
        }

        /// <summary>
        /// Nedan används using för att öppna kommunikation till DB.
        /// Vi lägger till aktiviteter från hyresgästerna.
        /// De sorteras i DB efter ID i fallande ordning.
        /// db.SaveChanges(); Sparar ändringar.
        /// </summary>
        public static void AddRelations()
        {
            using (var db = new MyDatabase())
            {
                try
                {
                    if (db.Relations.Count() == 0)
                    {
                        var list = new List<Relation>
                    {
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 10), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 2), eventType = db.Events.FirstOrDefault(s => s.ID == 2), Date = "2020-12-30 - 11:14"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 3), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 3), eventType = db.Events.FirstOrDefault(s => s.ID == 1), Date = "2020-11-28 - 18:32"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 6), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 7), eventType = db.Events.FirstOrDefault(s => s.ID == 3), Date = "2020-11-28 - 18:35"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 8), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 3), eventType = db.Events.FirstOrDefault(s => s.ID == 2), Date = "2020-11-29 - 12:53"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 5), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 5), eventType = db.Events.FirstOrDefault(s => s.ID == 1), Date = "2020-11-30 - 15:00"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 4), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 2), eventType = db.Events.FirstOrDefault(s => s.ID == 1), Date = "2020-12-02 - 16:32"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 17), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 6), eventType = db.Events.FirstOrDefault(s => s.ID == 1), Date = "2020-12-02 - 16:33"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 18), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 1), eventType = db.Events.FirstOrDefault(s => s.ID == 2), Date = "2020-12-03 - 18:00"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 11), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 1), eventType = db.Events.FirstOrDefault(s => s.ID == 2), Date = "2020-12-03 - 18:00"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 1), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 7), eventType = db.Events.FirstOrDefault(s => s.ID == 1), Date = "2020-12-03 - 19:22"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 2), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 2), eventType = db.Events.FirstOrDefault(s => s.ID == 2), Date = "2020-12-29 - 11:30"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 7), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 7), eventType = db.Events.FirstOrDefault(s => s.ID == 3), Date = "2020-12-05 - 03:42"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 9), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 1), eventType = db.Events.FirstOrDefault(s => s.ID == 1), Date = "2020-12-04 - 16:15"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 12), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 3), eventType = db.Events.FirstOrDefault(s => s.ID == 1), Date = "2021-01-05 - 09:58"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 13), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 2), eventType = db.Events.FirstOrDefault(s => s.ID == 2), Date = "2021-01-04 - 05:02"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 14), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 5), eventType = db.Events.FirstOrDefault(s => s.ID == 2), Date = "2021-01-02 - 16:06"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 15), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 5), eventType = db.Events.FirstOrDefault(s => s.ID == 1), Date = "2021-01-03 - 16:01"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 16), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 1), eventType = db.Events.FirstOrDefault(s => s.ID == 1), Date = "2021-01-01 - 11:02"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 19), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 1), eventType = db.Events.FirstOrDefault(s => s.ID == 2), Date = "2021-01-06 - 08:31"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 20), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 2), eventType = db.Events.FirstOrDefault(s => s.ID == 3), Date = "2021-01-05 - 15:49"},
                        new Relation{tenant = db.Tenants.FirstOrDefault(s => s.ID == 21), doorType = db.DoorTypes.FirstOrDefault(s => s.ID == 7), eventType = db.Events.FirstOrDefault(s => s.ID == 3), Date = "2021-01-03 - 02:26"}
                    };
                        db.Relations.AddRange(list.OrderBy(s => s.ID));
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong...");
                }
            }
        }
    }
}
