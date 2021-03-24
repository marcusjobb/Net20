using System;
using System.Data;

namespace Assignment_1_Architecture
{
    public static class Outputs
    {
        public static void Data(string title, DataRowCollection byCode)
        {
            Console.WriteLine(title);
            foreach (DataRow r in byCode)
            {
                Console.WriteLine($"{r["Date"]} {r["Door"]} {r["DoorCode"]} {r["Tag"]} {DoorEventsLog.LogEntry(r)}");
            }
        }

        public static void Tenants(DataRowCollection tenants)
        {
            Console.WriteLine("Tenants");
            foreach (DataRow r in tenants)
            {
                Console.WriteLine($"{r["Location"]} {r["Name"]} {r["Tag"]}");
            }
        }
    }
}