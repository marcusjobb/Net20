using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;


namespace DoorWay
{
    class Program
    {
        static void Main(string[] args)
        {
          



            DatabaseCommunication.CreateDatabase();                                                                                                                                    
            var byDoor = DoorEventsLog.FindEntriesByDoor("LGH");
            var byCode = DoorEventsLog.FindEntriesByEvent("DÖIN");
            var byLocation = DoorEventsLog.FindEntriesByLocation("TVÄTT");
            var byTagg = DoorEventsLog.FindEntriesByTag("0101A");            
            var byTenant = DoorEventsLog.FindEntriesByTenant("Liam Jönsson");
            var tenants = DoorEventsLog.ListTenantsAt("0101");
            
            OutputData("Serch by door: ",byDoor);
            OutputData("Serch by events id: ", byCode);
            OutputData("Serch by location: ", byLocation);
            OutputData("Serch by tag id: ", byTagg);
            OutputData("Serch by tenant: ", byTenant); 
            OutputTenant(tenants);
            
            DoorEventsLog.LogEntry("Serch by door: ",byDoor);
            Console.ReadKey();
        }



        /// <summary>
        /// Outputs the data.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="byCode">The by code.</param>
        private static void OutputData(string title,DataTable byCode)
        {
            Console.WriteLine("\n"+title+"\n");
            foreach (DataRow dataRow in byCode.Rows)
            {
                Console.WriteLine($"{dataRow["date_of_events"]} {dataRow["door_id"]} {dataRow["apartment_id"]} {dataRow["event_cod"]} {dataRow["tagg_id"]}  {dataRow["tenant_first_name"]} {dataRow["tenant_last_name"]} {DoText(dataRow)} ");
            }
            
        }
        /// <summary>
        /// Outputs the tenant.
        /// </summary>
        /// <param name="tenants">The tenants.</param>
        private static void OutputTenant(DataTable tenants)
        {
            Console.WriteLine("\nTenants list:");
            foreach (DataRow dataRow in tenants.Rows)
            {
                Console.WriteLine($" -{dataRow["tenant_first_name"]} {dataRow["tenant_last_name"]} {dataRow["tagg_id"]} "+"\n");
            }
        }
        /// <summary>
        /// Does the text.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        private static string DoText(DataRow dataRow)
        {
            var @event = dataRow["event_cod"].ToString();
            var what = @event.StartsWith("FD") ? "försökte öppna" : "öppnade";
            var where = @event.EndsWith("IN") ? "inifrån." : "utifrån.";
            return dataRow["tenant_first_name"]+ " "  +" "+ $"{ what} dörren till {dataRow["door_id"]}{dataRow["apartment_id"]} {where}";
        }
    }
}
