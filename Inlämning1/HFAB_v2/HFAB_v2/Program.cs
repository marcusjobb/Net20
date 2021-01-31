using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;

namespace HFAB_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var events = new DoorEventsLog();

            //Sets console window to a fixed width for better display
            Console.SetWindowSize(130, 30);

            //Creates a new Database if it doesn't exists
            //Else asks if user wants to update database
            CreateDatabaseOnStartup();

            var byDoor = events.FindEntriesByDoor("LGH0101")?.Rows;
            OutputData("Search by door", byDoor);
            var byEvent = events.FindEntriesByEvent("DÖIN")?.Rows;
            OutputData("Search by event", byEvent);
            var byLocation = events.FindEntriesByLocation("0202")?.Rows;
            OutputData("Search by location", byLocation);
            var byTag = events.FindEntriesByTag("0302A")?.Rows;
            OutputData("Search by tag", byTag);
            var byTenant = events.FindEntriesByTenant("William")?.Rows;
            OutputData("Search by tenant", byTenant);
            var tenants = events.ListTenantsAt("0201")?.Rows;
            OutputTenants(tenants);
        }

        private static void OutputData(string title, DataRowCollection byCode)
        {
            Console.WriteLine(title);
            foreach (DataRow r in byCode)
            {
                Console.WriteLine($"{r["Date"], -15} {r["Door"],-8} {r["Event"],-5} {r["Tag"],-7} {r["Tenant"],-18} | {DoText(r)}");
            }
        }
        private static void OutputTenants(DataRowCollection tenants)
        {
            Console.WriteLine("Tenants");
            foreach (DataRow r in tenants) { Console.WriteLine($"{r["Location"]} {r["Tag"]} {r["Tenant"]}"); }
        }
        private static string DoText(DataRow r)
        {
            var ev = r["Event"].ToString();
            var what = ev.StartsWith("FD") ? "försökte öppna" : "öppnade";
            var where = ev.EndsWith("IN") ? "inifrån" : "utifrån";

            //If a Door starts with LGH the output will say "lägenhet xxxx"
            //if BLK it will say "balkong xxxx"
            var dr = r["Door"].ToString();
            string kindOfDoor = "";
            if (dr.StartsWith("LGH"))
                kindOfDoor = "lägenhet " + dr[3] + dr[4] + dr[5] + dr[6];
            else if (dr.StartsWith("BLK"))
                kindOfDoor = "balkong " + dr[3] + dr[4] + dr[5] + dr[6];
            else
                kindOfDoor = dr.ToString();

            return r["Tenant"] + " " + $"{what} dörr till {kindOfDoor} {where}";
        }
        private static void CreateDatabaseOnStartup()
        {
            //Sets how many LogEntry rows will be created from TestData
            int numberOfLogEntries = 500;


            //Creates a database if it does not exists
            if (File.Exists(@".\HFAB.db"))
            {
                string createDatabase;
                bool inputCheck;
                do
                {
                    Console.WriteLine("Do you want to update database? (y/n)");

                    createDatabase = Console.ReadLine().ToLower();

                    if (createDatabase == "y" || createDatabase == "n")
                        inputCheck = true;
                    else
                    {
                        Console.WriteLine("Invalid input, please type 'y' for yes or 'n' for no. Try again, human.\n\n");
                        inputCheck = false;
                    }

                } while (inputCheck == false);

                if (createDatabase == "y")
                {
                    Console.WriteLine("Creating database...");
                    CreateDatabase.CreateMainDatabase();
                    InsertStaticDataToDB.InsertIntoTables();


                    for (int i = 0; i < numberOfLogEntries; i++)
                    {
                        TestData.GenerateTestData();
                    }
                }
            }
            else
            {
                Console.WriteLine("Creating database...");
                CreateDatabase.CreateMainDatabase();
                InsertStaticDataToDB.InsertIntoTables();
                
                for (int i = 0; i < numberOfLogEntries; i++)
                {
                    TestData.GenerateTestData();
                }
            }
        }
    }
}
