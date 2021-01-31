using EntityFramework_HFAB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework_HFAB.Helpers
{
    class DoorLogsEvent
    {
        //Property for setting a limit to how many rows of data will be returned to output
        private int MaxEntries { get; set; }
        public DoorLogsEvent(int maxEntries)
        {
            MaxEntries = maxEntries;
        }

        /// <summary>
        /// Finds all logs based on search by door
        /// </summary>
        /// <param name="byDoor">Door name</param>
        /// <returns>List of sorted and filtered log entries</returns>
        public List<Helpers.OutputHelper.IOutput> FindEntriesByDoor(string byDoor)
        {
            //Creates an unfiltered list from LogEntry 
            var unfilteredList = GetListOfJoinedTables();
            //Creates a filtered list from user search word
            var filteredList = unfilteredList.Where(_ => _.Door.Equals(byDoor)).Take(MaxEntries).ToList();
            //returns a sorted and filtered list of objects from LogEntry
            return CreateOutputList(filteredList);
        }

        /// <summary>
        /// Finds all logs based on search by event
        /// </summary>
        /// <param name="byEvent">Event code</param>
        /// <returns>List of sorted and filtered log entries</returns>
        public List<Helpers.OutputHelper.IOutput> FindEntriesByEvent(string byEvent)
        {
            //Creates an unfiltered list from LogEntry 
            var unfilteredList = GetListOfJoinedTables();
            //Creates a filtered list from user search word
            var filteredList = unfilteredList.Where(_ => _.Event.Equals(byEvent)).Take(MaxEntries).ToList();
            //returns a sorted and filtered list of objects from LogEntry
            return CreateOutputList(filteredList);
        }

        /// <summary>
        /// Finds all logs based on search by location
        /// </summary>
        /// <param name="byLocation">Location name</param>
        /// <returns>List of sorted and filtered log entries</returns>
        public List<Helpers.OutputHelper.IOutput> FindEntriesByLocation(string byLocation)
        {
            //Creates an unfiltered list from LogEntry 
            var unfilteredList = GetListOfJoinedTables();
            //Creates a filtered list from user search word
            var filteredList = unfilteredList.Where(_ => _.Door.EndsWith(byLocation)).Take(MaxEntries).ToList();
            //returns a sorted and filtered list of objects from LogEntry
            return CreateOutputList(filteredList);
        }

        /// <summary>
        /// Finds all logs based on search by tag
        /// </summary>
        /// <param name="byTag">Tag name</param>
        /// <returns>List of sorted and filtered log entries</returns>
        public List<Helpers.OutputHelper.IOutput> FindEntriesByTag(string byTag)
        {
            //Creates an unfiltered list from LogEntry 
            var unfilteredList = GetListOfJoinedTables();
            //Creates a filtered list from user search word
            var filteredList = unfilteredList.Where(_ => _.Tag.Equals(byTag)).Take(MaxEntries).ToList();
            //returns a sorted and filtered list of objects from LogEntry
            return CreateOutputList(filteredList);
        }

        /// <summary>
        /// Finds all logs based on search by tenant
        /// </summary>
        /// <param name="byTenant">Tenants full name in one string</param>
        /// <returns>List of sorted and filtered logentries</returns>
        public List<Helpers.OutputHelper.IOutput> FindEntriesByTenant(string byTenant)
        {
            //Creates an unfiltered list from LogEntry 
            var unfilteredList = GetListOfJoinedTables();
            //Creates a filtered list from user search word
            var filteredList = unfilteredList.Where(_ => _.Tenant.Equals(byTenant)).Take(MaxEntries).ToList();
            //returns a sorted and filtered list of objects from LogEntry
            return CreateOutputList(filteredList);
        }

        /// <summary>
        /// Finds all logs based on search by tenant
        /// </summary>
        /// <param name="lastName">Tenants last name</param>
        /// <param name="firstName">Tenants first name</param>
        /// <returns>List of sorted and filtered logentries</returns>
        public List<Helpers.OutputHelper.IOutput> FindEntriesByTenant(string lastName, string firstName)
        {
            //Creates an unfiltered list from LogEntry 
            var unfilteredList = GetListOfJoinedTables();
            //Creates a filtered list from user search words
            var filteredList = unfilteredList.Where(_ => _.Tenant.Equals(firstName + " " + lastName) || _.Tenant.Equals(lastName + " " + firstName)).Take(MaxEntries).ToList();
            //returns a sorted and filtered list of objects from LogEntry
            return CreateOutputList(filteredList);
        }

        /// <summary>
        /// Lists all tenants living in a specific location
        /// </summary>
        /// <param name="location">Name of location</param>
        /// <returns>List of all tenants living in searched location</returns>
        public List<Models.Tenant> ListTenantsAt(string location)
        {
            //Creates an empty list 
            var list = new List<Models.Tenant>();
            using var db = new Database.MyDatabase();
            //Adds objects to list based on location search word
            list = db.Tenants.Where(n => n.Location.Equals(location)).ToList();
            //returns filtered list
            return list;
        }

        /// <summary>
        /// Saves a log entry to DB
        /// </summary>
        /// <param name="logEntry">String array containing test data for logging</param>
        /// <returns>bool true if transaction succeeded</returns>
        public static bool LogEntry(string[] logEntry)
        {
            //Creates a bool with value false. Only changes to true if transaction is complete
            var logAccepted = false;
            //Creates an instance of MyDatabase
            using (var db = new Database.MyDatabase())
                //Try/catch-statement to stop transaction if any error occurs 
                try
                {
                    //Begins transaction
                    db.Database.BeginTransaction();
                    //Adds a new object from LogEntry-class to LogEntries-table in DB
                    db.LogEntries.Add(new Models.LogEntry
                    {
                        Date = logEntry[0],
                        Door = logEntry[1],
                        Tag = logEntry[2],
                        Event = logEntry[3]
                    });
                    //Saves changes to DB
                    db.SaveChanges();
                    //Committs transaction to DB
                    db.Database.CommitTransaction();
                    //Sets bool value to true
                    logAccepted = true;
                }
                catch
                {
                    //Rollbacks transaction
                    db.Database.RollbackTransaction();
                }
            return logAccepted;
        }

        /// <summary>
        /// Moves a tenant to a new location, or no location (tenants moves out)
        /// </summary>
        /// <param name="tenant">Name or tag of tenant</param>
        /// <param name="newLocation">New location, or empty (tenant moves out)</param>
        /// <returns>bool true if transaction succeded</returns>
        public static bool MoveTenant(string tenant, string newLocation)
        {
            //Creates a bool with false-value. Only changes to true if transaction is complete
            var moveAccepted = false;
            //Checks it new location is existing in DB, or set to blank (tenants is moving out)
            //If not, bool is still set to false and no transaction is committed
            if (CheckIfLocationExists(newLocation) || newLocation == "")
            {
                //Checks if tenant is already living in this location
                //If true, no transaction is committed
                if (!TenantAlreadyLivingInLocation(tenant, newLocation))
                {
                    //Creates an instance of MyDatabase
                    using var db = new Database.MyDatabase();
                    //Try/catch-statement to stop transaction if any errors occurs 
                    try
                    {
                        //Creates a new list for objects
                        var findTenantsId = new List<Models.Tenant>();
                        //Begins transaction
                        db.Database.BeginTransaction();
                        //Checks is user input is a name of a tenants stored in DB. If found, adds tenant to list
                        if (CheckIfTenantNameExists(tenant))
                            findTenantsId = db.Tenants.Where(_ => _.Name.Equals(tenant)).ToList();
                        //If user input is a correct tag, tenant is added to list. If not correct, nothing is added to list
                        else
                            findTenantsId = db.Tenants.Where(_ => _.Tag.Equals(tenant)).ToList();
                        //Creates var with tenants ID. If list is empty (neither name or tag is correct), transaction breaks
                        var tID = db.Tenants.Find(findTenantsId[0].ID);
                        //Sets value of new location to tenant via tenants ID
                        db.Entry(tID).Property(_ => _.Location).CurrentValue = newLocation;

                        //Checks id tenant is moving out (no new location)
                        if (newLocation == "")
                        {
                            //If new location is "", deletes value for tag as well (tenant has moved out)
                            db.Entry(tID).Property(_ => _.Tag).CurrentValue = "";
                        }
                        else
                        {
                            //Creates a new tag based on new location
                            db.Entry(tID).Property(_ => _.Tag).CurrentValue = newLocation + CreateNewTag(newLocation);
                        }
                        //Saves changes to DB
                        db.SaveChanges();
                        //Commits transaction
                        db.Database.CommitTransaction();
                        //Sets bool to true
                        moveAccepted = true;
                    }
                    catch
                    {
                        //Rollbacks transaction 
                        db.Database.RollbackTransaction();
                    }
                }
            }
            return moveAccepted;
        }

        /// <summary>
        /// Adds a tenant w/o tag or location to DB
        /// </summary>
        /// <param name="tenantName">Name of tenant</param>
        /// <returns>bool TRUE if transaction succeded</returns>
        public static bool AddTenant(string tenantName)
        {
            //Creates a bool with value false. Only changes to true if transaction is complete
            var addAccepted = false;
            using (var db = new Database.MyDatabase())
                try
                {
                    //Begins transaction to DB
                    db.Database.BeginTransaction();

                    //Checks if tenant name already exists in DB. To prevent same tenant to be added again by mistake,
                    //and to avoid mixup/confusion when searching for entries by tenant in logs
                    if (!CheckIfTenantNameExists(tenantName))
                    {
                        //Creates a new object from Tenant-class, with Name value from user input
                        var newTenant = new Models.Tenant { Name = tenantName };
                        //Adds new tenant to DB
                        db.Tenants.Add(newTenant);
                        //Saves changes to DB
                        db.SaveChanges();
                        //Committs transaction to DB
                        db.Database.CommitTransaction();
                        //Sets bool value to true
                        addAccepted = true;
                    }
                }
                catch
                {
                    //Rollbacks transaction
                    db.Database.RollbackTransaction();
                }
            //returns bool value
            return addAccepted;
        }

        /// <summary>
        /// Checks if tenant is already living in this location. If true, no transaction is committed
        /// </summary>
        /// <param name="tenant">Name of tenant</param>
        /// <param name="newLocation">Name of new location</param>
        /// <returns>bool true if tenant is already living in this location</returns>
        private static bool TenantAlreadyLivingInLocation(string tenant, string newLocation)
        {
            //Creates a bool and sets its value to false
            var tenantLivingInLocation = false;
            using (var db = new Database.MyDatabase())
            {
                //Creates a list of all objects with same name AND location as user input
                var list = db.Tenants.Where(_ => _.Name.Equals(tenant) && _.Location.Equals(newLocation)).ToList();
                //If list has any object, it means that tenant is already living here
                //and will reatur a true value
                if (list.Count > 0)
                    tenantLivingInLocation = true;
            }
            return tenantLivingInLocation;
        }

        /// <summary>
        /// Searches database to check if location exists
        /// </summary>Location name</param>
        /// <returns>bool true if location exists in DB</returns>
        private static bool CheckIfLocationExists(string location)
        {
            //Creates a bool with false-value. Only changes to true if user input location exists
            var locationExists = false;
            //Checks static data-class if location exists. Could be searching DB for same information insted,
            //but LocationArray has less elements to loop
            foreach (var item in Database.StaticData.LocationArray)
                if (item == location)
                    locationExists = true;
            //returns bool value if location exists in Static Data-class or not
            return locationExists;
        }

        /// <summary>
        /// Searches DB to check if tenants name exists.
        /// </summary>
        /// <param name="tenant">Tenants name or tag</param>
        /// <returns>bool true if tenant exists in DB</returns>
        private static bool CheckIfTenantNameExists(string tenant)
        {
            //Creates a bool with value false
            var nameExists = false;
            using (var db = new Database.MyDatabase())
                //Searches DB if tenant exists
                foreach (var item in db.Tenants)
                    //Sets bool value true if tenant exist in DB
                    if (item.Name == tenant)
                        nameExists = true;
            //returns bool value
            return nameExists;
        }

        /// <summary>
        /// Creates a uniqe tag for a specific location
        /// </summary>
        /// <param name="location">Location for the tag</param>
        /// <returns>First avaliable letter in alphabet</returns>
        /// 
        private static char CreateNewTag(string location)
        {
            //Creates a var for the letter at the end of the new tag
            char letter;
            using (var db = new Database.MyDatabase())
            {
                //Creates a new list with all tags from this location
                var locList = db.Tenants.Where(_ => _.Location.Equals(location)).ToList();
                //Sets var letter to A 
                letter = 'A';
                foreach (var item in locList)
                {
                    //If letter 'A' already exists, loops through all letters in alphabetical order
                    //to find first uniqe number
                    if (item.Tag[4] == letter)
                        letter = (char)(((int)letter) + 1);
                }
            }
            //returns a uniqe letter to create a new tag
            return letter;
        }

        /// <summary>
        /// Joins LogEntry-table with Tenant-table to create a list of new objects
        /// containing necessary info from both tables
        /// </summary>
        /// <returns>List of objects</returns>
        private static List<OutputHelper.IOutput> GetListOfJoinedTables()
        {
            //Creates a list for objects from ConsoleOutput-class
            var list = new List<Helpers.OutputHelper.IOutput>();
            //Creates a list for objects from LogEntry-class
            var logList = new List<Models.LogEntry>();
            //Creates a list for objects from Tenant-class
            var tenantsList = new List<Models.Tenant>();
            using (var db = new Database.MyDatabase())
            {
                //Creates a list with objects from two joined tables. The Tag-value from
                //LogEntries is used to locate name of tenant i Tenants.
                var query = (from log in db.LogEntries.ToList()
                             join ten in db.Tenants.ToList()
                             on log.Tag equals ten.Tag
                             orderby log.Date descending
                             select new
                             {
                                 log.Date,
                                 log.Door,
                                 log.Tag,
                                 log.Event,
                                 ten.Name
                             }).ToList();
                //Transfers all objects from query to a list of ConsoleOutput-objects
                foreach (var item in query)
                {
                    list.Add(new Helpers.OutputHelper.ConsoleOutput
                    {
                        Date = item.Date,
                        Door = item.Door,
                        Tag = item.Tag,
                        Event = item.Event,
                        Tenant = item.Name
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// Takes a list of filtered and sorted objects and creates a new list of objects
        /// </summary>
        /// <param name="list">List cointaining filtered and sorted objects from DB</param>
        /// <returns>List containing new objects</returns>
        private static List<Helpers.OutputHelper.IOutput> CreateOutputList(List<Helpers.OutputHelper.IOutput> list)
        {
            //Creates a new list to store objects from IOutput-class
            var outputList = new List<Helpers.OutputHelper.IOutput>();
            //Creates a new object from ConsoleOute-class and sets values from an object in a sorted and filtered list
            for (int i = 0; i < list.Count; i++)
            {
                var newObject = new Helpers.OutputHelper.ConsoleOutput
                {
                    Date = list[i].Date,
                    Door = list[i].Door,
                    Event = list[i].Event,
                    Tag = list[i].Tag,
                    Tenant = list[i].Tenant
                };
                //Adds created object to the list
                outputList.Add(newObject);
            }
            //returns list when for-loop is completed
            return outputList;
        }
    }
}


