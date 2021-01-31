using ApartmentDBEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentDBEF.Controllers
{
    public static class DoorEventsLog
    {

        // Int för att välja antal rader att skriva ut vid FindEntriesBy...
        private static int maxEntries = 20;

        public static int MaxEntries
        {
            get { return maxEntries; }
            set { maxEntries = value; }
        }

        //Hämtar data ifrån databasen och sorterar ut dem efter dörr
        public static IQueryable<Models.Result> FindEntriesByDoor(string input)
        {
            Database.ApartmentDB searchDB = new Database.ApartmentDB();

            var showEvents =
            (from Events in searchDB.Events
            join Tags in searchDB.Tags on Events.IDTag equals Tags.ID
            join Actions in searchDB.Actions on Events.IDAction equals Actions.ID
            join Doors in searchDB.Doors on Events.IDDoor equals Doors.ID
            join Codes in searchDB.Codes on Events.IDCode equals Codes.ID
            join Tenants in searchDB.Tenants on Events.IDTag equals Tenants.IDTag
            join Apartments in searchDB.Apartments on Events.IDDoor equals Apartments.IDDoor
            where Doors.Doorname == input
            orderby Events.ID descending


            select new Models.Result
            {
                ID = Events.ID.ToString(),
                Time = Events.CreatedAt.ToString(),
                Tag = Tags.Tagnumber,
                Action = Actions.Actions,
                Door = Doors.Doorname,
                Code = Codes.Codes,
                Tenant = Tenants.Name,
                Apartment = Apartments.Apartmentnumber,
                Doorexp = Doors.Explanation,
                InorOut = Codes.Explanation

            }).Take(MaxEntries);

            return showEvents;

        }

        //Hämtar data ifrån databasen och sorterar ut dem efter händelse
        public static IQueryable<Models.Result> FindEntriesByEvent(string input)
        {
            Database.ApartmentDB searchDB = new Database.ApartmentDB();

            var showEvents =
            (from Events in searchDB.Events
            join Tags in searchDB.Tags on Events.IDTag equals Tags.ID
            join Actions in searchDB.Actions on Events.IDAction equals Actions.ID
            join Doors in searchDB.Doors on Events.IDDoor equals Doors.ID
            join Codes in searchDB.Codes on Events.IDCode equals Codes.ID
            join Tenants in searchDB.Tenants on Events.IDTag equals Tenants.IDTag
            join Apartments in searchDB.Apartments on Events.IDDoor equals Apartments.IDDoor
            where Codes.Codes == input
            orderby Events.ID descending


            select new Models.Result
            {
                ID = Events.ID.ToString(),
                Time = Events.CreatedAt.ToString(),
                Tag = Tags.Tagnumber,
                Action = Actions.Actions,
                Door = Doors.Doorname,
                Code = Codes.Codes,
                Tenant = Tenants.Name,
                Apartment = Apartments.Apartmentnumber,
                Doorexp = Doors.Explanation,
                InorOut = Codes.Explanation

            }).Take(MaxEntries);

            return showEvents;

        }

        //Hämtar data ifrån databasen och sorterar ut dem efter plats
        public static IQueryable<Models.Result> FindEntriesByLocation(string input)
        {
            Database.ApartmentDB searchDB = new Database.ApartmentDB();

            var showEvents =
            (from Events in searchDB.Events
            join Tags in searchDB.Tags on Events.IDTag equals Tags.ID
            join Actions in searchDB.Actions on Events.IDAction equals Actions.ID
            join Doors in searchDB.Doors on Events.IDDoor equals Doors.ID
            join Codes in searchDB.Codes on Events.IDCode equals Codes.ID
            join Tenants in searchDB.Tenants on Events.IDTag equals Tenants.IDTag
            join Apartments in searchDB.Apartments on Events.IDDoor equals Apartments.IDDoor
            where Apartments.Apartmentnumber == input
            orderby Events.ID descending


            select new Models.Result
            {
                ID = Events.ID.ToString(),
                Time = Events.CreatedAt.ToString(),
                Tag = Tags.Tagnumber,
                Action = Actions.Actions,
                Door = Doors.Doorname,
                Code = Codes.Codes,
                Tenant = Tenants.Name,
                Apartment = Apartments.Apartmentnumber,
                Doorexp = Doors.Explanation,
                InorOut = Codes.Explanation

            }).Take(MaxEntries);

            return showEvents;

        }
        //Hämtar data ifrån databasen och sorterar ut dem efter tagg
        public static IQueryable<Models.Result> FindEntriesByTag(string input)
        {
            Database.ApartmentDB searchDB = new Database.ApartmentDB();

            var showEvents =
            (from Events in searchDB.Events
            join Tags in searchDB.Tags on Events.IDTag equals Tags.ID
            join Actions in searchDB.Actions on Events.IDAction equals Actions.ID
            join Doors in searchDB.Doors on Events.IDDoor equals Doors.ID
            join Codes in searchDB.Codes on Events.IDCode equals Codes.ID
            join Tenants in searchDB.Tenants on Events.IDTag equals Tenants.IDTag
            join Apartments in searchDB.Apartments on Events.IDDoor equals Apartments.IDDoor
            where Tags.Tagnumber == input
            orderby Events.ID descending

            select new Models.Result
            {
                ID = Events.ID.ToString(),
                Time = Events.CreatedAt.ToString(),
                Tag = Tags.Tagnumber,
                Action = Actions.Actions,
                Door = Doors.Doorname,
                Code = Codes.Codes,
                Tenant = Tenants.Name,
                Apartment = Apartments.Apartmentnumber,
                Doorexp = Doors.Explanation,
                InorOut = Codes.Explanation

            }).Take(MaxEntries);

            return showEvents;

        }

        //Hämtar data ifrån databasen och sorterar ut dem efter hyresgäst
        public static IQueryable<Models.Result> FindEntriesByTenant(string input)
        {
            Database.ApartmentDB searchDB = new Database.ApartmentDB();

            var showEvents =
            (from Events in searchDB.Events
            join Tags in searchDB.Tags on Events.IDTag equals Tags.ID
            join Actions in searchDB.Actions on Events.IDAction equals Actions.ID
            join Doors in searchDB.Doors on Events.IDDoor equals Doors.ID
            join Codes in searchDB.Codes on Events.IDCode equals Codes.ID
            join Tenants in searchDB.Tenants on Events.IDTag equals Tenants.IDTag
            join Apartments in searchDB.Apartments on Events.IDDoor equals Apartments.IDDoor           
            where Tenants.Name == input
            orderby Events.ID descending
            


            select new Models.Result
            {
                ID = Events.ID.ToString(),
                Time = Events.CreatedAt.ToString(),
                Tag = Tags.Tagnumber,
                Action = Actions.Actions,
                Door = Doors.Doorname,
                Code = Codes.Codes,
                Tenant = Tenants.Name,
                Apartment = Apartments.Apartmentnumber,
                Doorexp = Doors.Explanation,
                InorOut = Codes.Explanation

            }).Take(MaxEntries);

            return showEvents;

        }

        //Listar hyresgäster på en specifik plats
        public static IQueryable<Models.TenantsAt> ListTenantsAt(string input)
        {
            Database.ApartmentDB searchDB = new Database.ApartmentDB();

            var showTenants =
            from Tenants in searchDB.Tenants
            join Tags in searchDB.Tags on Tenants.IDTag equals Tags.ID
            join Apartments in searchDB.Apartments on Tenants.IDApartment equals Apartments.ID
            where Apartments.Apartmentnumber == input


            select new Models.TenantsAt
            {
                Tag = Tags.Tagnumber,
                Tenant = Tenants.Name,
                Apartment = Apartments.Apartmentnumber,

            };

            return showTenants;

        }

        //Skapar en ny händelse i Event-loggen
        public static void InsertEvent(string Tagz, string Actionz, string Doorz, string Codez)
        {
            using (var db = new Database.ApartmentDB())
            {
                db.Events.Add(new Models.Event
                {
                    IDAction = db.Actions.FirstOrDefault(a => a.Actions == Actionz).ID,
                    IDTag = db.Tags.FirstOrDefault(a => a.Tagnumber == Tagz).ID,
                    IDDoor = db.Doors.FirstOrDefault(a => a.Doorname == Doorz).ID,
                    IDCode = db.Codes.FirstOrDefault(a => a.Codes == Codez).ID,
                    CreatedAt = DateTime.Now

                });              


                db.SaveChanges();

            }


        }

        //Skapar en ny hyresgäst med Namn och tomma IDn
        public static bool addTenant(string tenantName)
        {
            bool success = false;
            if (!success)
            {

                using (var db = new Database.ApartmentDB())
                {
                    db.Tenants.Add(new Models.Tenant

                    {
                        Name = tenantName

                    });
                    db.SaveChanges();
                }
                success = true;
            }

            else success = false;

            return success;
        }

        //Flyttar en befintlig hyresgäst och ger denne ny lägenhet samt tagg eller flyttar in en ny hyresgäst och ger denne tagg och lägenhet
        public static bool MoveTenant(string tagOrName, string toApartment)
        {
            bool success = false;




            using (var db = new Database.ApartmentDB())
            {
                
                var nameNull = db.Tenants.FirstOrDefault(tenant => tenant.Name == tagOrName);
                

                if (nameNull != null)
                {
                    var tenant = db.Tenants.FirstOrDefault(a => a.Name == tagOrName);
                    tenant.IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == toApartment).ID;
                    CreateTag(toApartment, tagOrName);
                    tenant.IDTag = db.Tags.OrderBy(a => a.ID).LastOrDefault(a => a.IDTenant == tenant.ID).ID;

                    db.SaveChanges();
                    success = true;
                    
                }
                else if (nameNull == null)
                {
                    var tag = db.Tags.FirstOrDefault(tag => tag.Tagnumber == tagOrName).ID;

                    var tenant = db.Tenants.FirstOrDefault(t => t.IDTag == tag);
                    tenant.IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == toApartment).ID;
                    var tenantName = db.Tenants.FirstOrDefault(tn => tn.IDTag == tag).Name;
                    CreateTag(toApartment, tenantName);
                    tenant.IDTag = db.Tags.OrderBy(a => a.ID).LastOrDefault(a => a.IDTenant == tenant.ID).ID;

                    db.SaveChanges();
                    success = true;
                    
                }
            }
            return success;
        } 

        //Flyttar ut en befintlig hyresgäst. Den befintliga taggen raderas och andra IDn sätts till 0.
        public static bool MoveOutTenant(string tagOrName)
        {
            bool success = false;
            using (var db = new Database.ApartmentDB())
            {

                var nameNull = db.Tenants.FirstOrDefault(tenant => tenant.Name == tagOrName);

                if (nameNull != null)
                {
                    var tenant = db.Tenants.FirstOrDefault(t => t.Name == tagOrName);                    
                    var tagid = db.Tenants.FirstOrDefault(t => t.Name == tagOrName).IDTag;                                        
                    var tagToRemove = db.Tags.FirstOrDefault(t => t.ID == tagid);
                    db.Tags.Remove(tagToRemove);
                    tenant.IDApartment = 0;
                    tenant.IDTag = 0;

                    db.SaveChanges();
                    success = true;

                }
                else if (nameNull == null)
                {
                    var tag = db.Tags.FirstOrDefault(tag => tag.Tagnumber == tagOrName).ID;                    
                    var tenant = db.Tenants.FirstOrDefault(t => t.IDTag == tag);                                    
                    var tagid = db.Tags.FirstOrDefault(t => t.Tagnumber == tagOrName).ID;
                    var tagToRemove = db.Tags.FirstOrDefault(t => t.ID == tagid);
                    db.Tags.Remove(tagToRemove);
                    tenant.IDApartment = 0;
                    tenant.IDTag = 0;

                    db.SaveChanges();
                    success = true;

                }








            }
            return success;



        }

        // Skapar en ny tagg vid flytt utav befintlig hyresgäst eller inflyttning utav en ny hyresgäst.
        public static void CreateTag(string apartment, string tenant)
        {
            using (var db = new Database.ApartmentDB())
            {
                var SearchTag1 = apartment + "A";
                var SearchTag2 = apartment + "B";
                var SearchTag3 = apartment + "C";
                var SearchTag4 = apartment + "D";
                var SearchTag5 = apartment + "E";
                var SearchTag6 = apartment + "F";
                var SearchTag7 = apartment + "G";


                var tagid = db.Tenants.FirstOrDefault(t => t.Name == tenant).IDTag;

                if (tagid != 0)
                {
                    var tagToRemove = db.Tags.FirstOrDefault(t => t.ID == tagid);
                    db.Tags.Remove(tagToRemove);
                }


                if (db.Tags.Any(a => a.Tagnumber == SearchTag7))
                { 
                    db.Tags.Add(new Models.Tag
                    {
                        Tagnumber = apartment + "H",
                        IDTenant = db.Tenants.FirstOrDefault(a => a.Name == tenant).ID,
                        IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == apartment).ID,

                    });


                    db.SaveChanges();

                }
                else if (db.Tags.Any(a => a.Tagnumber == SearchTag6))
                {
                    db.Tags.Add(new Models.Tag
                    {
                        Tagnumber = apartment + "G",
                        IDTenant = db.Tenants.FirstOrDefault(a => a.Name == tenant).ID,
                        IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == apartment).ID,

                    });


                    db.SaveChanges();


                }
                else if (db.Tags.Any(a => a.Tagnumber == SearchTag5))
                {
                    db.Tags.Add(new Models.Tag
                    {
                        Tagnumber = apartment + "F",
                        IDTenant = db.Tenants.FirstOrDefault(a => a.Name == tenant).ID,
                        IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == apartment).ID,

                    });


                    db.SaveChanges();


                }
                else if (db.Tags.Any(a => a.Tagnumber == SearchTag4))
                {
                    db.Tags.Add(new Models.Tag
                    {
                        Tagnumber = apartment + "E",
                        IDTenant = db.Tenants.FirstOrDefault(a => a.Name == tenant).ID,
                        IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == apartment).ID,

                    });


                    db.SaveChanges();


                }
                else if (db.Tags.Any(a => a.Tagnumber == SearchTag3))
                {
                    db.Tags.Add(new Models.Tag
                    {
                        Tagnumber = apartment + "D",
                        IDTenant = db.Tenants.FirstOrDefault(a => a.Name == tenant).ID,
                        IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == apartment).ID,

                    });


                    db.SaveChanges();

                }
                else if (db.Tags.Any(a => a.Tagnumber == SearchTag2))
                {
                    db.Tags.Add(new Models.Tag
                    {
                        Tagnumber = apartment + "C",
                        IDTenant = db.Tenants.FirstOrDefault(a => a.Name == tenant).ID,
                        IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == apartment).ID,

                    });


                    db.SaveChanges();

                }
                else if (db.Tags.Any(a => a.Tagnumber == SearchTag1))
                {
                    db.Tags.Add(new Models.Tag
                    {
                        Tagnumber = apartment + "B",
                        IDTenant = db.Tenants.FirstOrDefault(a => a.Name == tenant).ID,
                        IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == apartment).ID,

                    });


                    db.SaveChanges();

                }
                else if (!db.Tags.Any(a => a.Tagnumber == SearchTag1))
                {
                    db.Tags.Add(new Models.Tag
                    {
                        Tagnumber = apartment + "A",
                        IDTenant = db.Tenants.FirstOrDefault(a => a.Name == tenant).ID,
                        IDApartment = db.Apartments.FirstOrDefault(a => a.Apartmentnumber == apartment).ID,

                    });

                }




            }


        }


    }
    
}