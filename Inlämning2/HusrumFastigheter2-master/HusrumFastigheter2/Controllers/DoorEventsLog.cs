using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using HusrumFastigheter2.Interfaces;
using System.Linq;

namespace HusrumFastigheter2.Controllers
{
    public class DoorEventsLog : IControllers
    {
        public static int MaxEntries { get; set; } = 20;
        public static List<Models.Log> FindEntriesByDoor(string doorName)
        {
            using (var dataList = new Database.MyDatabase())
            {
                var door = dataList.Doors.FirstOrDefault(d => d.DoorName == doorName);
                return dataList.Logs.Include("Door").Include("Event").Include("Tenant").Where(d => d.Door == door).OrderByDescending(d => d.Date).Take(MaxEntries).ToList();
            }
        }

        public static List<Models.Log> FindEntriesByEvent(string codeName)
        {
            using (var dataList = new Database.MyDatabase())
            {
                var code = dataList.Events.FirstOrDefault(d => d.Code == codeName);
                return dataList.Logs.Include("Door").Include("Event").Include("Tenant").Where(d => d.Event == code).OrderByDescending(d => d.Date).Take(MaxEntries).ToList();
            }
        }

        public static List<Models.Log> FindEntriesByLocation(string locationName)
        {
            using (var dataList = new Database.MyDatabase())
            {
                var location = dataList.Doors.FirstOrDefault(d => d.DoorName == locationName);
                return dataList.Logs.Include("Door").Include("Event").Include("Tenant").Where(d => d.Door == location).OrderByDescending(d => d.Date).Take(MaxEntries).ToList();
            }
        }

        public static List<Models.Log> FindEntriesByTag (string tagName)
        {
            using (var dataList = new Database.MyDatabase())
            {
                var tag = dataList.Tenants.FirstOrDefault(d => d.Tag == tagName);
                return dataList.Logs.Include("Door").Include("Event").Include("Tenant").Where(d => d.Tenant == tag).OrderByDescending(d => d.Date).Take(MaxEntries).ToList();
            }
        }

        public static List<Models.Log> FindEntriesByTenant(string tenantFirstName, string tenantLastName = null)
        {
            using(var dataList = new Database.MyDatabase())
            {
                var tenant = dataList.Tenants.FirstOrDefault(d => d.FirstName + " " + d.LastName == tenantFirstName || d.FirstName + " " + d.LastName == tenantFirstName + " " + tenantLastName);
                return dataList.Logs.Include("Door").Include("Event").Include("Tenant").Where(d => d.Tenant == tenant).OrderByDescending(d => d.Date).Take(MaxEntries).ToList();
            }
        }

        public static List<string> ListTenantsAt(string doorName)
        {
            using(var dataList = new Database.MyDatabase())
            {
                var door = dataList.Locations.FirstOrDefault(d => d.LocationName == doorName);
                return dataList.Tenants.Where(d => d.Location == door).Select(d => d.FirstName + " " + d.LastName).ToList();
            }
        }

        public static bool LogEntry(string date, string doorName, string eventCode, string tag)
        {
            try
            {
                using (var dataList = new Database.MyDatabase())
                {
                    var door = dataList.Doors.FirstOrDefault(d => d.DoorName == doorName.ToUpper());
                    var @event = dataList.Events.FirstOrDefault(d => d.Code == eventCode.ToUpper());
                    var tenant = dataList.Tenants.FirstOrDefault(d => d.Tag == tag.ToUpper());
                    dataList.Logs.Add(new Models.Log { Date = date, Door = door, Event = @event, Tenant = tenant });
                    dataList.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool MoveTenant(string tenant, string doorName = null)
        {
            try
            {
                using (var dataList = new Database.MyDatabase())
                {
                    var identifyTenant = dataList.Tenants.Include("Location").FirstOrDefault(d => d.Tag == tenant || d.FirstName + " " + d.LastName == tenant);
                    if (String.IsNullOrEmpty(doorName))
                    {
                        identifyTenant.Location = null;
                        identifyTenant.Tag = null;
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
                            var tagToCheck = doorName + tagListArray[i];
                            var result = dataList.Tenants.Any(d => d.Tag == tagToCheck);
                            if (!result)
                            {
                                var location = dataList.Locations.FirstOrDefault(d => d.LocationName == doorName);
                                emptyTagLetter = true;
                                identifyTenant.Tag = tagToCheck;
                                identifyTenant.Location = location;
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
        public static bool AddTenant(string tenantName, string doorName)
        {
            try
            {
                using(var dataList = new Database.MyDatabase())
                {
                    var nameSplit = tenantName.Split(" ");
                    const string tagList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    var tagListArray = tagList.ToCharArray();
                    var i = 0;
                    var emptyTagLetter = false;
                    while((i < tagListArray.Length) && (!emptyTagLetter))
                    {
                        var tagToCheck = doorName + tagListArray[i];
                        var result = dataList.Tenants.Any(d => d.Tag == tagToCheck);
                        if (!result)
                        {
                            var location = dataList.Locations.FirstOrDefault(d => d.LocationName == doorName);
                            emptyTagLetter = true;
                            dataList.Tenants.Add(new Models.Tenant { FirstName = nameSplit[0], LastName = nameSplit[1], Tag = tagToCheck, Location = location });
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
