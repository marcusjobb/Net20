namespace HFAB_v2_EF.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DoorEventsLog
    {
        public static int MaxEntries { get; set; } = 20;

        /// <summary>
        /// Get logg from a given door
        /// </summary>
        /// <param name="doorName">Name of the Door</param>
        /// <returns>Logg List</returns>
        public static List<Models.Logg> FindEntriesByDoor(string doorName)
        {
            using (var dataList = new Database.HFABDataList())
            {
                var door = dataList.DoorNames.FirstOrDefault(d => d.Name == doorName);
                return dataList.Loggs.Include("Door").Include("Person").Include("Event").Where(l => l.Door == door).OrderByDescending(l => l.Date).Take(MaxEntries).ToList();
            }
        }

        /// <summary>
        /// Get logg from a given tag
        /// </summary>
        /// <param name="tag">tag</param>
        /// <returns>Logg List</returns>
        public static List<Models.Logg> FindEntriesByTag(string tag)
        {
            using (var dataList = new Database.HFABDataList())
            {
                var person = dataList.Persons.FirstOrDefault(p => p.Tag == tag);
                return dataList.Loggs.Include("Door").Include("Person").Include("Event").Where(l => l.Person == person).OrderByDescending(l => l.Date).Take(MaxEntries).ToList();
            }
        }

        /// <summary>
        /// Writes out all the enteries by a spesific Event
        /// </summary>
        /// <param name="eventCode">Name of event</param>
        /// <returns>Logg List</returns>
        public static List<Models.Logg> FindEntriesByEvent(string eventCode)
        {
            using (var dataList = new Database.HFABDataList())
            {
                var @event = dataList.Events.FirstOrDefault(e => e.Code == eventCode);
                return dataList.Loggs.Include("Door").Include("Person").Include("Event").Where(l => l.Event == @event).Take(MaxEntries).OrderByDescending(l => l.Date).ToList();
            }
        }

        /// <summary>
        /// Get logg from a given location
        /// </summary>
        /// <param name="locationName">Name of the location</param>
        /// <returns>Logg List</returns>
        public static List<Models.Logg> FindEntriesByLocation(string locationName)
        {
            using (var dataList = new Database.HFABDataList())
            {
                var doorLGH = dataList.DoorNames.FirstOrDefault(l => l.Name == "LGH" + locationName);
                var doorBLK = dataList.DoorNames.FirstOrDefault(l => l.Name == "BLK" + locationName);
                var door = dataList.DoorNames.FirstOrDefault(l => l.Name == locationName);
                return dataList.Loggs.Include("Door").Include("Person").Include("Event").Where(l => (l.Door == doorLGH) || (l.Door == doorBLK) || (l.Door == door)).Take(MaxEntries).OrderByDescending(l => l.Date).ToList();
            }
        }

        /// <summary>
        /// Get logg from a given tenent
        /// </summary>
        /// <param name="name">name of tenent</param>
        /// <param name="lastname">Optinal Lastname if lastname is listed in <paramref name="name"/></param>
        /// <returns>Logg List</returns>
        public static List<Models.Logg> FindEntriesByTenant(string name, string lastname = null)
        {
            using (var dataList = new Database.HFABDataList())
            {
                var person = dataList.Persons.FirstOrDefault(t => t.FirstName + " " + t.LastName == name || t.FirstName + " " + t.LastName == name + " " + lastname);
                return dataList.Loggs.Include("Door").Include("Person").Include("Event").Where(l => l.Person == person).Take(MaxEntries).OrderByDescending(l => l.Date).ToList();
            }
        }

        /// <summary>
        /// Get tentens of an apartment
        /// </summary>
        /// <param name="apartment">Name of apartment</param>
        /// <returns>List of tenten</returns>
        public static List<string> ListTenantsAt(string apartment)
        {
            using (var dataList = new Database.HFABDataList())
            {
                var location = dataList.Locations.FirstOrDefault(l => l.Name == apartment);
                return dataList.Persons.Where(t => t.Location == location).Select(t => t.FirstName + " " + t.LastName).ToList();
            }
        }

        /// <summary>
        /// Enter Log to db
        /// </summary>
        /// <param name="date"></param>
        /// <param name="doorName"></param>
        /// <param name="codeName"></param>
        /// <param name="tagName"></param>
        /// <returns>true if succsefull. false if unseccesfull</returns>
        public static bool LogEntry(string date, string doorName, string codeName, string tagName)
        {
            try
            {
                using (var dataList = new Database.HFABDataList())
                {
                    var door = dataList.DoorNames.FirstOrDefault(d => d.Name == doorName.ToUpper());
                    var @event = dataList.Events.FirstOrDefault(d => d.Code == codeName.ToUpper());
                    var person = dataList.Persons.FirstOrDefault(d => d.Tag == tagName.ToUpper());
                    dataList.Loggs.Add(new Models.Logg { Date = date, Door = door, Event = @event, Person = person });
                    dataList.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Remove and tenet or Update
        /// </summary>
        /// <param name="tenant">Tag or Firstname Lastname</param>
        /// <param name="locationName">Optional Apartment to move to</param>
        /// <returns>true if succsefull. false if unseccesfull</returns>
        public static bool MoveTenant(string tenant, string locationName = null)
        {
            try
            {
                using (var dataList = new Database.HFABDataList())
                {
                    var person = dataList.Persons.Include("Location").FirstOrDefault(t => t.Tag == tenant || t.FirstName + " " + t.LastName == tenant);
                    if (String.IsNullOrEmpty(locationName))
                    {
                        person.Location = null;
                        person.Tag = null;
                        dataList.SaveChanges();
                    }
                    else
                    {
                        const string tagList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                        var tagListArray = tagList.ToCharArray();
                        var i = 0;
                        var emptyTagLetter = false;
                        while ((i < tagListArray.Length) && (!emptyTagLetter))
                        {
                            var tagToCheck = locationName + tagListArray[i];
                            var reslult = dataList.Persons.Any(p => p.Tag == tagToCheck);
                            if (!reslult)
                            {
                                var location = dataList.Locations.FirstOrDefault(l => l.Name == locationName);
                                emptyTagLetter = true;
                                person.Tag = tagToCheck;
                                person.Location = location;
                                dataList.SaveChanges();
                            }
                            i++;
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Add Tenets to an appartment
        /// </summary>
        /// <param name="name">name of the tennet Firstname Lastname</param>
        /// <param name="locationName">Apparent to add the tenent to</param>
        /// <returns>true if succsefull. false if unseccesfull</returns>
        public static bool AddTenant(string name, string locationName)
        {
            try
            {
                using (var dataList = new Database.HFABDataList())
                {
                    var nameSplit = name.Split(" ");

                    const string tagList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    var tagListArray = tagList.ToCharArray();
                    var i = 0;
                    var emptyTagLetter = false;
                    while ((i < tagListArray.Length) && (!emptyTagLetter))
                    {
                        var tagToCheck = locationName + tagListArray[i];
                        var reslult = dataList.Persons.Any(t => t.Tag == tagToCheck);
                        if (!reslult)
                        {
                            var location = dataList.Locations.FirstOrDefault(l => l.Name == locationName);
                            emptyTagLetter = true;
                            dataList.Persons.Add(new Models.Person { FirstName = nameSplit[0], LastName = nameSplit[1], Tag = tagToCheck, Location = location });
                            dataList.SaveChanges();
                        }
                        i++;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}