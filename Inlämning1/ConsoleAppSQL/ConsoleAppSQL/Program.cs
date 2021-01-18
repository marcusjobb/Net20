using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ConsoleAppSQL
{

    class Program

    {
        static void Main()
        {
            SQL.SkapaDatabas();

            var byDoor = DoorEventsLog.FindEntriesByDoor("LGH 0102")?.Rows;
            var byEvent = DoorEventsLog.FindEntriesByEvent("DÖIN")?.Rows;
            var byLocation = DoorEventsLog.FindEntriesByLocation("VAKT")?.Rows;
            var byTag = DoorEventsLog.FindEntriesByTag("0102A")?.Rows;
            var byTenant = DoorEventsLog.FindEntriesByTenant("Liam Jönsson")?.Rows;
            var tenants = DoorEventsLog.ListTenantsAt("LGH 0201")?.Rows;
            
            OutputData("search by door", byDoor);
            OutputData("search by event", byEvent);
            OutputData("search by location", byLocation);
            OutputData("search by tag", byTag);
            OutputData("search by tenant", byTenant);
            OutputTenants(tenants);

            EnterLogg();

        }

        private static void EnterLogg()
        {
            string DateTime = Console.ReadLine();
            string Location = Console.ReadLine();
            string Kod = Console.ReadLine();
            string Tagg = Console.ReadLine();
            string Tenant = Console.ReadLine();

            DoorEventsLog.LogEntry(DateTime, Location, Kod, Tagg, Tenant);
        }

        private static void OutputTenants(DataRowCollection Tenants)
        {
            Console.WriteLine("Tenants");
            foreach(DataRow r in Tenants)
            {
                Console.WriteLine($"{r["Location"]} {r["Tagg"]} {r["Tenant"]}");

            }

        }
        

        private static void OutputData(string title, DataRowCollection byCode)
        {
            Console.WriteLine(title);
            foreach (DataRow r in byCode)
            {
                Console.WriteLine($"{r["DatumTid"]} {r["Location"]} {r["Kod"]} {r["Tagg"]} {r["Tenant"]} {DoText(r)}");
            }
        }

        private static string DoText(DataRow r)
        {
            var ev = r["Kod"].ToString();
            var what = ev.StartsWith("FD") ? " försökte öppna" : " öppnade";
            var where = ev.EndsWith("IN") ? "inifrån" : "utifrån";

            return r["Tenant"] + $"{what} dörr till {r["Location"]} {where}";
        }
    }
}
