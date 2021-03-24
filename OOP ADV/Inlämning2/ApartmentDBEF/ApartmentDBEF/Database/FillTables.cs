using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentDBEF.Database
{
    public class FillTables
    {

        // En metod som kollar ifall det existerar något "Event" i databasen med ID 1, om den existerar är databasens data redan skapad och resten utav koden ignoreras. Ifall ingen träff sker kommer datan skapas i databasen.
        public static void checkTables()
        {
            using (ApartmentDB db = new ApartmentDB())
                if (db.Events.Any(o => o.ID == 1))
            {Console.WriteLine("Match in DB, exiting"); return;}
                else
                {
                    fillEvents();
                    fillActions();
                    fillApartments();
                    fillCodes();
                    fillDoors();                    
                    fillTags();
                    fillTenants();
                }                

        }


        // Seeder för databasen som kommer lägga in alla hyresgäster,lägenheter m.m. som skall finnas.
        public static void fillActions()
        {
            using (var addData = new ApartmentDB())
            {
                //Add Actions to table
                var action = new Models.Action
                {
                    ID = 1,
                    Actions = "Opened"
                };
                addData.Actions.Add(action);

                action = new Models.Action
                {
                    ID = 2,
                    Actions = "FailedToOpen"
                };
                addData.Actions.Add(action);

                addData.SaveChanges();

                // Actions added to table
            }
        }
        public static void fillApartments()
        {
            using (var addData = new ApartmentDB())
            {
                //Add apartments to table
                var apartment = new Models.Apartment
                {
                    ID = 1,
                    Apartmentnumber = "0101",
                    IDDoor = 1
                };
                addData.Apartments.Add(apartment);


                apartment = new Models.Apartment
                {
                    ID = 2,
                    Apartmentnumber = "0102",
                    IDDoor = 3
                };
                addData.Apartments.Add(apartment);

                apartment = new Models.Apartment
                {
                    ID = 3,
                    Apartmentnumber = "0103",
                    IDDoor = 5
                };
                addData.Apartments.Add(apartment);

                apartment = new Models.Apartment
                {
                    ID = 4,
                    Apartmentnumber = "0201",
                    IDDoor = 7
                };
                addData.Apartments.Add(apartment);

                apartment = new Models.Apartment
                {
                    ID = 5,
                    Apartmentnumber = "0202",
                    IDDoor = 9
                };
                addData.Apartments.Add(apartment);

                apartment = new Models.Apartment
                {
                    ID = 6,
                    Apartmentnumber = "0301",
                    IDDoor = 11
                };
                addData.Apartments.Add(apartment);

                apartment = new Models.Apartment
                {
                    ID = 7,
                    Apartmentnumber = "0302",
                    IDDoor = 13
                };
                addData.Apartments.Add(apartment);


                apartment = new Models.Apartment
                {
                    ID = 8,
                    Apartmentnumber = "Entrance",
                    IDDoor = 15
                };
                addData.Apartments.Add(apartment);


                apartment = new Models.Apartment
                {
                    ID = 9,
                    Apartmentnumber = "Garbageroom",
                    IDDoor = 16
                };
                addData.Apartments.Add(apartment);


                apartment = new Models.Apartment
                {
                    ID = 10,
                    Apartmentnumber = "Laundryroom",
                    IDDoor = 17
                };
                addData.Apartments.Add(apartment);


                apartment = new Models.Apartment
                {
                    ID = 11,
                    Apartmentnumber = "Janitor",
                    IDDoor = 18
                };
                addData.Apartments.Add(apartment);

                addData.SaveChanges();

                //Apartments added to table
            }
        }
        public static void fillCodes()
        {
            using (var addData = new ApartmentDB())
            {
                //Add codes to table
                var code = new Models.Code
                {
                    ID = 1,
                    Codes = "DI",
                    Explanation = "from the outside"
                };
                addData.Codes.Add(code);

                code = new Models.Code
                {
                    ID = 2,
                    Codes = "DO",
                    Explanation = "from the inside"
                };
                addData.Codes.Add(code);

                code = new Models.Code
                {
                    ID = 3,
                    Codes = "WDI",
                    Explanation = "wrong door in"
                };
                addData.Codes.Add(code);

                code = new Models.Code
                {
                    ID = 4,
                    Codes = "WDO",
                    Explanation = "wrong door out"
                };
                addData.Codes.Add(code);

                addData.SaveChanges();
                //Codes added to table
            }
        }
        public static void fillDoors()
        {
            using (var addData = new ApartmentDB())
            {
                //Add Doors to table

                var door = new Models.Door
                {
                    ID = 1,
                    Doorname = "01011LGH",
                    Explanation = "Door to apartment",
                    ApartmentID = 1
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 2,
                    Doorname = "0101BLK",
                    Explanation = "Door to balcony",
                    ApartmentID = 1
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 3,
                    Doorname = "0102LGH",
                    Explanation = "Door to apartment",
                    ApartmentID = 2
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 4,
                    Doorname = "0102BLK",
                    Explanation = "Door to balcony",
                    ApartmentID = 2
                };
                addData.Doors.Add(door);

                door = new Models.Door
                {
                    ID = 5,
                    Doorname = "0103LGH",
                    Explanation = "Door to apartment",
                    ApartmentID = 3
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 6,
                    Doorname = "01013BLK",
                    Explanation = "Door to balcony",
                    ApartmentID = 3
                };
                addData.Doors.Add(door);

                door = new Models.Door
                {
                    ID = 7,
                    Doorname = "0201LGH",
                    Explanation = "Door to apartment",
                    ApartmentID = 4
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 8,
                    Doorname = "0201BLK",
                    Explanation = "Door to balcony",
                    ApartmentID = 4
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 9,
                    Doorname = "0202LGH",
                    Explanation = "Door to apartment",
                    ApartmentID = 5
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 10,
                    Doorname = "0202BLK",
                    Explanation = "Door to balcony",
                    ApartmentID = 5
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 11,
                    Doorname = "0301LGH",
                    Explanation = "Door to apartment",
                    ApartmentID = 6
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 12,
                    Doorname = "0301BLK",
                    Explanation = "Door to balcony",
                    ApartmentID = 6
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 13,
                    Doorname = "0302LGH",
                    Explanation = "Door to apartment",
                    ApartmentID = 7
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 14,
                    Doorname = "0302BLK",
                    Explanation = "Door to balcony",
                    ApartmentID = 7
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 15,
                    Doorname = "Entrance",
                    Explanation = "Door to street",
                    ApartmentID = 11
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 16,
                    Doorname = "Garbage",
                    Explanation = "Door to garbage room",
                    ApartmentID = 10
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 17,
                    Doorname = "Laundry",
                    Explanation = "Door to laundry room",
                    ApartmentID = 9
                };
                addData.Doors.Add(door);


                door = new Models.Door
                {
                    ID = 18,
                    Doorname = "Janitor",
                    Explanation = "Door to janitor",
                    ApartmentID = 8
                };
                addData.Doors.Add(door);

                addData.SaveChanges();

                //Doors added to table
            }
        }
        public static void fillEvents()
        {
            using (var addData = new ApartmentDB())
            {
                //Add events to table

                var Event = new Models.Event
                {
                    ID = 1,
                    IDTag = 3,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 2,
                    IDTag = 2,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 3,
                    IDTag = 2,
                    IDAction = 1,
                    IDDoor = 3,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 4,
                    IDTag = 5,
                    IDAction = 1,
                    IDDoor = 5,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 5,
                    IDTag = 5,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 6,
                    IDTag = 4,
                    IDAction = 1,
                    IDDoor = 5,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 7,
                    IDTag = 4,
                    IDAction = 1,
                    IDDoor = 16,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 8,
                    IDTag = 4,
                    IDAction = 1,
                    IDDoor = 16,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 9,
                    IDTag = 4,
                    IDAction = 1,
                    IDDoor = 5,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 10,
                    IDTag = 3,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 11,
                    IDTag = 3,
                    IDAction = 1,
                    IDDoor = 3,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 12,
                    IDTag = 14,
                    IDAction = 1,
                    IDDoor = 11,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 13,
                    IDTag = 14,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 14,
                    IDTag = 14,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 15,
                    IDTag = 14,
                    IDAction = 2,
                    IDDoor = 1,
                    IDCode = 3,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 16,
                    IDTag = 14,
                    IDAction = 1,
                    IDDoor = 11,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 17,
                    IDTag = 21,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 18,
                    IDTag = 21,
                    IDAction = 1,
                    IDDoor = 18,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 19,
                    IDTag = 21,
                    IDAction = 1,
                    IDDoor = 18,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 20,
                    IDTag = 21,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 21,
                    IDTag = 6,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 22,
                    IDTag = 6,
                    IDAction = 1,
                    IDDoor = 8,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 23,
                    IDTag = 18,
                    IDAction = 1,
                    IDDoor = 13,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 24,
                    IDTag = 18,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 22,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 25,
                    IDTag = 12,
                    IDAction = 1,
                    IDDoor = 9,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 26,
                    IDTag = 12,
                    IDAction = 1,
                    IDDoor = 17,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 27,
                    IDTag = 19,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 28,
                    IDTag = 19,
                    IDAction = 1,
                    IDDoor = 13,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 29,
                    IDTag = 12,
                    IDAction = 1,
                    IDDoor = 17,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 30,
                    IDTag = 12,
                    IDAction = 1,
                    IDDoor = 9,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 31,
                    IDTag = 19,
                    IDAction = 1,
                    IDDoor = 13,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 32,
                    IDTag = 19,
                    IDAction = 1,
                    IDDoor = 16,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 33,
                    IDTag = 19,
                    IDAction = 1,
                    IDDoor = 16,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 34,
                    IDTag = 19,
                    IDAction = 1,
                    IDDoor = 13,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 35,
                    IDTag = 1,
                    IDAction = 1,
                    IDDoor = 1,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 36,
                    IDTag = 1,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 37,
                    IDTag = 7,
                    IDAction = 1,
                    IDDoor = 7,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 38,
                    IDTag = 7,
                    IDAction = 1,
                    IDDoor = 16,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 39,
                    IDTag = 7,
                    IDAction = 1,
                    IDDoor = 16,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 40,
                    IDTag = 7,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 41,
                    IDTag = 7,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 42,
                    IDTag = 7,
                    IDAction = 1,
                    IDDoor = 7,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 43,
                    IDTag = 17,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 44,
                    IDTag = 17,
                    IDAction = 1,
                    IDDoor = 13,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 45,
                    IDTag = 13,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 46,
                    IDTag = 13,
                    IDAction = 1,
                    IDDoor = 11,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 47,
                    IDTag = 5,
                    IDAction = 1,
                    IDDoor = 5,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 48,
                    IDTag = 5,
                    IDAction = 1,
                    IDDoor = 16,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 49,
                    IDTag = 5,
                    IDAction = 1,
                    IDDoor = 16,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 50,
                    IDTag = 5,
                    IDAction = 1,
                    IDDoor = 5,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 51,
                    IDTag = 2,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 52,
                    IDTag = 2,
                    IDAction = 1,
                    IDDoor = 3,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 53,
                    IDTag = 8,
                    IDAction = 1,
                    IDDoor = 7,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 54,
                    IDTag = 8,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 55,
                    IDTag = 8,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 56,
                    IDTag = 8,
                    IDAction = 1,
                    IDDoor = 7,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 57,
                    IDTag = 19,
                    IDAction = 1,
                    IDDoor = 13,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 58,
                    IDTag = 19,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 2,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);


                Event = new Models.Event
                {
                    ID = 59,
                    IDTag = 19,
                    IDAction = 1,
                    IDDoor = 15,
                    IDCode = 1,
                    CreatedAt = DateTime.Now
                };
                addData.Events.Add(Event);

                addData.SaveChanges();

                //Events added to table
            }
        }
        public static void fillTags()
        {
            using (var addData = new ApartmentDB())
            {
                //Add tags to table

                var tag = new Models.Tag
                {
                    ID = 1,
                    Tagnumber = "0101A",
                    IDTenant = 1,
                    IDApartment = 1
                };
                addData.Tags.Add(tag);

                tag = new Models.Tag
                {
                    ID = 2,
                    Tagnumber = "0102A",
                    IDTenant = 2,
                    IDApartment = 2
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 3,
                    Tagnumber = "0102B",
                    IDTenant = 3,
                    IDApartment = 2
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 4,
                    Tagnumber = "0103A",
                    IDTenant = 4,
                    IDApartment = 3
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 5,
                    Tagnumber = "0103B",
                    IDTenant = 5,
                    IDApartment = 3
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 6,
                    Tagnumber = "0201A",
                    IDTenant = 6,
                    IDApartment = 4
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 7,
                    Tagnumber = "0201B",
                    IDTenant = 7,
                    IDApartment = 4
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 8,
                    Tagnumber = "0201C",
                    IDTenant = 8,
                    IDApartment = 4
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 9,
                    Tagnumber = "0201D",
                    IDTenant = 9,
                    IDApartment = 4
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 10,
                    Tagnumber = "0202A",
                    IDTenant = 10,
                    IDApartment = 5
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 11,
                    Tagnumber = "0202B",
                    IDTenant = 11,
                    IDApartment = 5
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 12,
                    Tagnumber = "0202C",
                    IDTenant = 12,
                    IDApartment = 5
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 13,
                    Tagnumber = "0301A",
                    IDTenant = 13,
                    IDApartment = 6
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 14,
                    Tagnumber = "0301B",
                    IDTenant = 14,
                    IDApartment = 6
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 15,
                    Tagnumber = "0301C",
                    IDTenant = 15,
                    IDApartment = 6
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 16,
                    Tagnumber = "0301D",
                    IDTenant = 16,
                    IDApartment = 6
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 17,
                    Tagnumber = "0302A",
                    IDTenant = 17,
                    IDApartment = 7
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 18,
                    Tagnumber = "0302B",
                    IDTenant = 18,
                    IDApartment = 7
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 19,
                    Tagnumber = "0302C",
                    IDTenant = 19,
                    IDApartment = 7
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 20,
                    Tagnumber = "0302D",
                    IDTenant = 20,
                    IDApartment = 7
                };
                addData.Tags.Add(tag);


                tag = new Models.Tag
                {
                    ID = 21,
                    Tagnumber = "VAKT01",
                    IDTenant = 21,
                    IDApartment = 8
                };
                addData.Tags.Add(tag);

                addData.SaveChanges();

                //Tags added to table
            }
        }
        public static void fillTenants()
        {
            using (var addData = new ApartmentDB())
            {
                //Add tenants to table
                var tenant = new Models.Tenant
                {
                    ID = 1,
                    Name = "Liam Jönsson",
                    IDTag = 1,
                    IDApartment = 1
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 2,
                    Name = "Elias Petterson",
                    IDTag = 2,
                    IDApartment = 2
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 3,
                    Name = "Wilma Johansson",
                    IDTag = 3,
                    IDApartment = 2
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 4,
                    Name = "Alicia Sanchez",
                    IDTag = 4,
                    IDApartment = 3
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 5,
                    Name = "Aaron Sanchez",
                    IDTag = 5,
                    IDApartment = 3
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 6,
                    Name = "Olivia Erlander",
                    IDTag = 6,
                    IDApartment = 4
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 7,
                    Name = "William Erlander",
                    IDTag = 7,
                    IDApartment = 4
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 8,
                    Name = "Alexander Erlander",
                    IDTag = 8,
                    IDApartment = 4
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 9,
                    Name = "Astrid Erlander",
                    IDTag = 9,
                    IDApartment = 4
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 10,
                    Name = "Lucas Adolfsson",
                    IDTag = 10,
                    IDApartment = 5
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 11,
                    Name = "Ebba Adolfsson",
                    IDTag = 11,
                    IDApartment = 5
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 12,
                    Name = "Lilly Adolfsson",
                    IDTag = 12,
                    IDApartment = 5
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 13,
                    Name = "Ella Ahlström",
                    IDTag = 13,
                    IDApartment = 6
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 14,
                    Name = "Alma Alfredsson",
                    IDTag = 14,
                    IDApartment = 6
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 15,
                    Name = "Elsa Ahlström",
                    IDTag = 15,
                    IDApartment = 6
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 16,
                    Name = "Maja Ahlström",
                    IDTag = 16,
                    IDApartment = 6
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 17,
                    Name = "Noah Almgren",
                    IDTag = 17,
                    IDApartment = 7
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 18,
                    Name = "Adam Andersen",
                    IDTag = 18,
                    IDApartment = 7
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 19,
                    Name = "Kattis Backman",
                    IDTag = 19,
                    IDApartment = 7
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 20,
                    Name = "Oscar Chen",
                    IDTag = 20,
                    IDApartment = 7
                };
                addData.Tenants.Add(tenant);


                tenant = new Models.Tenant
                {
                    ID = 21,
                    Name = "Janitor",
                    IDTag = 21,
                    IDApartment = 8
                };
                addData.Tenants.Add(tenant);

                addData.SaveChanges();

                //Tenants added to table
            }
        }

























    }
}
