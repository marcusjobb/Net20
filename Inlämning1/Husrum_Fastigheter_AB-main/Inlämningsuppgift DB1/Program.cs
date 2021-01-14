using System;
using System.Data;
namespace Inlämningsuppgift_DB1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                DataFeed.SkapaDatabas();
                Console.WriteLine("Husrum Fastigheter AB Database");
                Console.WriteLine("What do you want to look up? (Door, Event, Location, Tag, Tenant, ListTenants, MakeLog, Quit)");
                string user = Console.ReadLine();
                if (user == "Door")
                {
                    Console.Clear();
                    Console.WriteLine("Which door would you like to see data on?");
                    string userDoor = Console.ReadLine();
                    var byDoorName = DoorEventLog.FindEntriesByDoor(userDoor)?.Rows;
                    DoorEventLog.UpdateDateTime();
                    OutputData("Search by Door", byDoorName);
                }
                else if (user == "Event")
                {
                    Console.Clear();
                    Console.WriteLine("Which event would you like to see data on?");
                    string userEvent = Console.ReadLine();
                    var byEvent = DoorEventLog.FindEntriesByEvent(userEvent)?.Rows;
                    DoorEventLog.UpdateDateTime();
                    OutputData("Search by CodeEvent", byEvent);
                }
                else if (user == "Location")
                {
                    Console.Clear();
                    Console.WriteLine("Which location would you like to see data on?");
                    string userLocation = Console.ReadLine();
                    var byLocation = DoorEventLog.FindEntriesByLocation(userLocation)?.Rows;
                    DoorEventLog.UpdateDateTime();
                    OutputData("Search by Location", byLocation);
                }
                else if (user == "Tag")
                {
                    Console.Clear();
                    Console.WriteLine("Which tag would you like to see data on?");
                    string userTag = Console.ReadLine();
                    var byTag = DoorEventLog.FindEntriesByTag(userTag)?.Rows;
                    DoorEventLog.UpdateDateTime();
                    OutputData("Search by Tag", byTag);
                }
                else if (user == "Tenant")
                {
                    Console.Clear();
                    Console.WriteLine("Which tenant would you like to see data on?");
                    string userTenant = Console.ReadLine();
                    var byTenant = DoorEventLog.FindEntriesByTenant(userTenant)?.Rows;
                    DoorEventLog.UpdateDateTime();
                    OutputData("Search by Tenant", byTenant);
                }
                else if (user == "ListTenants")
                {
                    Console.Clear();
                    Console.WriteLine("Which door would you like to know which tenants live?");
                    string userListTenantsAt = Console.ReadLine();
                    var tenants = DoorEventLog.ListTenantsAt(userListTenantsAt)?.Rows;
                    OutputTenants(tenants);
                }
                else if (user == "MakeLog")
                {
                    Console.Clear();
                    EnterLog();
                }
                else if(user == "Quit")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input");
                }
            }
        }

        //Skriver ut data tabellen via Console.WriteLine och tar emot tabellens data via strängar.
        private static void OutputData(string title, DataRowCollection byCode)
        {
            Console.WriteLine(title);
            foreach(DataRow r in byCode)
            {
                Console.WriteLine($"{r["Tid"]} {r["Kod"]} {r["Gäst"]} {r["Dörr"]} {r["Tagg"]} {DoText(r)}");
            }
        }
        //Skriver ut data tabellen via Console.WriteLine och tar emot tabellens data via strängar.
        private static void OutputTenants(DataRowCollection tenants)
        {
            Console.WriteLine("Tenants");
            foreach(DataRow r in tenants) { Console.WriteLine($"{r["Dörr"]} {r["Tagg"]} {r["Gäst"]}"); }
        }
        //Gör sträng tillägg utifrån vad för kod event som är loggat i tabellen.
        private static string DoText(DataRow r)
        {
            var ev = r["Kod"].ToString();
            var what = ev.StartsWith("FD") ? " försökte öppna" : " öppnade";
            var where = ev.EndsWith("IN") ? "inifrån" : "utifrån";

            return r["Gäst"] + $"{what} dörr till {r["Dörr"]} {where}";
        }
        //Ett simpelt UI som tar emot användarens parametrar för LogEntry metoden.
        private static void EnterLog()
        {
            DataFeed.SkapaDatabas();
            Console.WriteLine("To enter a log you have to type in four objects. Code, Tenant, Door and Tag.");
            Console.WriteLine("Please enter Code:");
            string kod = Console.ReadLine();
            Console.WriteLine("Please enter the Tenant name:");
            string gäst = Console.ReadLine();
            Console.WriteLine("Please enter the Door name:");
            string dörr = Console.ReadLine();
            Console.WriteLine("Please enter the Tag:");
            string tagg = Console.ReadLine();
            if(dörr != null && tagg != null && kod != null && gäst != null)
            {
                DoorEventLog.LogEntry(kod, gäst, dörr, tagg);
                Console.WriteLine("The log has been updated.");
            }
        }
    }
}
