using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework_HFAB.Database
{
    class Seeder
    {
        /// <summary>
        /// Adds tables and rows to database from StatcData-class IF tables are empty
        /// </summary>
        internal static void Seed()
        {
            using var db = new MyDatabase();
            {
                //Add tenants-info to db if table is empty
                if (db.Tenants.Count() == 0)
                {
                    try
                    {
                        //Begins a tranasction to DB
                        db.Database.BeginTransaction();
                        //Loops through all tags in TagArray
                        for (int i = 0; i < StaticData.TagArray.Length; i++)
                        {
                            //Creates a new StringBulder
                            var sb = new StringBuilder();
                            //Creates a new temporary location-variable and sets its value to current tag name
                            var locTemp = StaticData.TagArray[i];
                            //Adds the four numbers from the tag to the StringBulder var
                            sb.Append(new char[] { locTemp[0], locTemp[1], locTemp[2], locTemp[3] });
                            //Adds info about tenant from Static Data-class to DB
                            db.Tenants.Add(new Models.Tenant
                            {
                                Name = StaticData.TenantArray[i].ToString(),
                                Tag = StaticData.TagArray[i].ToString(),
                                Location = sb.ToString()
                            }
                            );
                            //Saves changes to DB
                            db.SaveChanges();
                        }
                        //Commits tranasction to DB
                        db.Database.CommitTransaction();
                    }
                    catch
                    {
                        //Rollbacks transaction if any error occurs
                        db.Database.RollbackTransaction();
                    }
                }

                //Add doors-info to db if table is empty
                if (db.Doors.Count() == 0)
                {
                    try
                    {
                        //Begins transaction to DB
                        db.Database.BeginTransaction();

                        //Loops through all doornames in DoorArrray to find the doors connected to "LGH" (appartment) or
                        //"BLK" (balcony). 
                        foreach (var item in StaticData.DoorArray)
                        {
                            if (item.StartsWith("LGH") || item.StartsWith("BLK"))
                            {
                                //If door name begins with LGH or BLK, its location value is set to
                                //doors last four digits
                                var locTemp = item;
                                var loc = locTemp[3].ToString() + locTemp[4].ToString() + locTemp[5].ToString() + locTemp[6].ToString();
                                db.Doors.Add(new Models.Door
                                {
                                    DoorName = item,
                                    Location = loc
                                });
                            }
                            else
                            {
                                //If door doesn't begin with LGH or BLK, location is the same as door name
                                db.Doors.Add(new Models.Door { DoorName = item, Location = item });
                            }
                            //Saves chenges to DB
                            db.SaveChanges();
                        }
                            //Commits tranasction to DB
                            db.Database.CommitTransaction();
                    }
                    catch
                    {
                        //Rollbacks transaction if any error occurs
                        db.Database.RollbackTransaction();
                    }
                }
                //Add event-info to db if table is empty
                if (db.Events.Count() == 0)
                {
                    try
                    {
                        //Begins transaction to DB
                        db.Database.BeginTransaction();
                        //Loops through all elements in EventArray in StaticData-class and 
                        //adds same value to Event table in DB
                        foreach (var item in StaticData.EventArray)
                        {
                            db.Events.Add(new Models.Event { EventName = item });
                            //Saves changes to DB
                            db.SaveChanges();
                        }
                            //Commits transaction to DB
                            db.Database.CommitTransaction();
                    }
                    catch
                    {
                        //Rollbacks transaction if any error occurs
                        db.Database.RollbackTransaction();
                    }
                }
            }
        }
        /// <summary>
        /// Generates random test data from StaticData-class
        /// </summary>
        /// <returns>Array with 4 elements, containing random values for LogEntry-table</returns>
        public static string[] GenerateTestData()
        {
            using var db = new MyDatabase();
            //creates a string array with 4 empty elements
            string[] logEntry = new string[4];

            //Creates new object of StaticData and Random
            Random rand = new Random();

            //Sets random number for Date
            var hour = rand.Next(10, 13);
            var min = rand.Next(0, 59);
            var sec = rand.Next(0, 59);

            //Randomizes a new time within 4 hours for test purposes
            //and adds it to first element of array
            logEntry[0] = $"2020-10-31 {hour}:{min:00}:{sec:00}";

            //Sets random numbers for array-index and adds to remaining elements in array
            logEntry[1] = StaticData.DoorArray[rand.Next(0, StaticData.DoorArray.Length)];
            logEntry[2] = StaticData.TagArray[rand.Next(0, StaticData.TagArray.Length)];
            logEntry[3] = StaticData.EventArray[rand.Next(0, StaticData.EventArray.Length)];

            //returns an array with a random Log Entry
            return logEntry;
        }

        /// <summary>
        /// Generates a new database if there is none
        /// </summary>
        /// <param name="logAmount">How many log entries should be generated</param>
        public static void GenerateDatabase(int logAmount)
        {
            //Message to user in conosole
            Console.WriteLine("Checking database...");
            using var db = new MyDatabase();
            //If Tenant table in DB is empty, calls Seed-method to add all table values to DB
            if (db.Tenants.Count() == 0)
                Seed();
            //Clears console
            Console.Clear();
            //Message to user in conosole
            Console.WriteLine("Creating test data...");
            //Creates new log entries if table is empty 
            if (db.LogEntries.Count() == 0)
                for (int i = 0; i < logAmount; i++)
                {
                    Helpers.DoorLogsEvent.LogEntry(GenerateTestData());
                }
            //Clears console
            Console.Clear();
        }
    }
}


