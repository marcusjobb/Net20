namespace HusrumProject.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class DoorEventLog
    {
        /// <summary>
        ///  Max entries to print to console
        /// </summary>
        public static int MaxEntries { get; set; } = 20;

        /// <summary>
        /// Add a new tenant to building
        /// </summary>
        /// <param name="name">Tenant name</param>
        /// <param name="location">Apartment tenant is added to</param>
        /// <returns></returns>
        public static bool AddTenant(string name, string location)
        {
            try
            {
                using var db = new Database.DatabaseFilePath();
                var split = name
                    .Split(" ");
                const string letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";
                var letterArray = letter
                    .ToCharArray();
                var i = 0;
                var thisBool = false;

                while ((i < letterArray.Length) && (!thisBool))
                {
                    var checkInfo = location + letterArray[i];
                    var checkAnswer = db.Tenants
                        .Any(e => e.FirstName == checkInfo);
                    if (!checkAnswer)
                    {
                        var aptNr = db.DoorLocations
                            .SingleOrDefault(e => e.Name == location);
                        var exist = db.Tenants
                            .Count(e => e.TenantTag == checkInfo);
                            db.Tenants
                            .Add(new Models.Tenant
                            { FirstName = split[0], LastName = split[1], TenantTag = checkInfo, Location = aptNr }
                        );
                            db.SaveChanges();
                            thisBool = true;
                        
                    }
                    i++;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Create log info and send to database
        /// </summary>
        /// <param name="dateTime">Date and time of log entry</param>
        /// <param name="code">Door event code</param>
        /// <param name="doorName">Where door is located</param>
        /// <param name="tenantTag">Tag number of tenant performing action</param>
        /// <returns></returns>
        public static bool Log(string dateTime, string code, string doorName, string tenantTag)
        {
            try
            {
                using var db = new Database.DatabaseFilePath();
                var eventID = db.DoorEvents
                    .FirstOrDefault(e => e.Code == code.ToUpper());
                var door = db.DoorNames
                    .FirstOrDefault(e => e.Name == doorName.ToUpper());
                var tenant = db.Tenants
                    .FirstOrDefault(e => e.TenantTag == tenantTag.ToUpper());

                db.EventLogs
                    .Add(
                    new Models.EventLog
                    {
                        DateTime = dateTime,
                        DoorEvent = eventID,
                        DoorName = door,
                        Tenant = tenant
                    }
                );
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Displays actions from a door
        /// </summary>
        /// <param name="name">Name of door / where it´s located</param>
        /// <returns></returns>
        public static List<Models.EventLog> FindEntriesByDoor(string name)
        {
            using var db = new Database.DatabaseFilePath();
            var door = db.DoorNames
                .FirstOrDefault(e => e.Name == name);
            return db.EventLogs
                .Include("DoorName")
                .Include("Tenant")
                .Include("DoorEvent")
                .Where(e => e.DoorName == door)
                .OrderByDescending(e => e.DateTime)
                .Take(MaxEntries)
                .ToList();
        }

        /// <summary>
        /// Find entries by event code
        /// </summary>
        /// <param name="eventCode">Code of the event</param>
        /// <returns></returns>
        public static List<Models.EventLog> FindEntriesByEvent(string eventCode)
        {
            using var db = new Database.DatabaseFilePath();
            var newEvent = db.DoorEvents
                .FirstOrDefault(e => e.Code == eventCode);
            return db.EventLogs
                .Include("DoorName")
                .Include("Tenant")
                .Include("DoorEvent")
                .Where(e => e.DoorEvent == newEvent)
                .Take(MaxEntries)
                .OrderByDescending(e => e.DateTime)
                .ToList();
        }

        /// <summary>
        /// Find entries from a location
        /// </summary>
        /// <param name="location">Where the door is located</param>
        /// <returns></returns>
        public static List<Models.EventLog> FindEntriesByLocation(string location)
        {
            using var db = new Database.DatabaseFilePath();
            var door = db.DoorNames
                .FirstOrDefault(e => e.Name == location);
            return db.EventLogs
                .Include("DoorName")
                .Include("Tenant")
                .Include("DoorEvent")
                .Where(e => e.DoorName == door)
                .Take(MaxEntries)
                .OrderByDescending(e => e.DateTime)
                .ToList();
        }

        /// <summary>
        /// Find entries made by a tag
        /// </summary>
        /// <param name="tag">Tenants personal tag</param>
        /// <returns></returns>
        public static List<Models.EventLog> FindEntriesByTag(string tag)
        {
            using var db = new Database.DatabaseFilePath();
            var tenantTag = db.Tenants
                .FirstOrDefault(e => e.TenantTag == tag);
            return db.EventLogs
                .Include("DoorName")
                .Include("Tenant")
                .Include("DoorEvent")
                .Where(e => e.Tenant == tenantTag)
                .OrderByDescending(e => e.DateTime)
                .ToList();
        }

        /// <summary>
        /// Find entries made by a tenant
        /// </summary>
        /// <param name="name">Name of tenant</param>
        /// <returns></returns>
        public static List<Models.EventLog> FindEntriesByTenant(string name)
        {
            using var db = new Database.DatabaseFilePath();
            var tenant = db.Tenants
                .FirstOrDefault(e => e.FirstName == name);
            return db.EventLogs
                .Include("DoorName")
                .Include("Tenant")
                .Include("DoorEvent")
                .Where(e => e.Tenant == tenant)
                .OrderByDescending(e => e.DateTime)
                .ToList();
        }

        /// <summary>
        /// List tenants at requested apartment
        /// </summary>
        /// <param name="aptNr">Apartment number</param>
        /// <returns></returns>
        public static List<string> ListTenantsAt(string aptNr)
        {
            using var db = new Database.DatabaseFilePath();
            var tName = db.DoorLocations
                .FirstOrDefault(e => e.Name == aptNr);
            return db.Tenants
                .Where(e => e.Location == tName)
                .Select(e => e.FirstName)
                .ToList();
        }

        /// <summary>
        /// Move tenant from apartment
        /// </summary>
        /// <param name="tenant">Tenant name</param>
        /// <param name="location">Where tenant are listed</param>
        /// <returns></returns>
        public static bool MoveTenant(string tenant, string location = null)
        {
            try
            {
                using var db = new Database.DatabaseFilePath();
                var tenantInfo = db.Tenants.Include("DoorLocation")
                    .FirstOrDefault(e => e.TenantTag == tenant || e.FirstName + " " + e.LastName == tenant);
                if (String.IsNullOrEmpty(location))
                {
                    tenantInfo.Location = null;
                    tenantInfo.TenantTag = null;
                    db.SaveChanges();
                }
                else
                {
                    const string letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";
                    var letterArray = letter
                        .ToCharArray();
                    var i = 0;
                    var thisBool = false;

                    while ((i < letterArray.Length) && (!thisBool))
                    {
                        var checkInfo = location + letterArray[i];
                        var checkAnswer = db.Tenants
                            .Any(e => e.TenantTag == checkInfo);
                        if (!checkAnswer)
                        {
                            var aptNr = db.DoorLocations
                                .FirstOrDefault(e => e.Name == location);
                            tenantInfo.TenantTag = checkInfo;
                            tenantInfo.Location = aptNr;
                            thisBool = true;
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
        
        /// <summary>
        /// WORK IN PROGRESS
        /// UNUSED FOR NOW
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static bool UpdateTenant(string tenantTag, string location)
        {
            try
            {
                using var db = new Database.DatabaseFilePath();
                var thisBool = false;

                while (!thisBool)
                {
                    var checkInfo = location;
                    var checkAnswer = db.Tenants
                        .Any(e => e.TenantTag == checkInfo);
                    if (!checkAnswer)
                    {
                        var aptNr = db.DoorLocations
                            .SingleOrDefault(e => e.Name == location);
                        var exist = db.Tenants
                            .Count(e => e.TenantTag == checkInfo);
                        db.Tenants
                            .Update(new Models.Tenant
                        { TenantTag = checkInfo, Location = aptNr }
                    );
                        db.SaveChanges();
                        thisBool = true;

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