using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework_HFAB.Views
{
    class ConsoleViews

    {
        /// <summary>
        /// Controlls what content is displayed in the console
        /// </summary>
        public static void ConsoleView()
        {
            //Sets window size for console
            Console.SetWindowSize(140, 30);

            //Creates new instance for ConsoleOutput
            var OutputData = new Helpers.OutputHelper.ConsoleOutput();
            //Creates new instance fot DoorLogsEvent
            var c = new Helpers.DoorLogsEvent(20);

            //Calls for method to print a list of logs by a specific door
            Console.WriteLine("Search by door\n");
            OutputData.Output(c.FindEntriesByDoor("LGH0202"));
            Console.WriteLine("\n-----------------------------------\n");

            //Calls for method to print a list of logs by a specific event
            Console.WriteLine("Search by event\n");
            OutputData.Output(c.FindEntriesByEvent("DÖIN"));
            Console.WriteLine("\n-----------------------------------\n");

            //Calls for method to print a list of logs by a specific location
            Console.WriteLine("Search by location\n");
            OutputData.Output(c.FindEntriesByLocation("0301"));
            Console.WriteLine("\n-----------------------------------\n");

            //Calls for method to print a list of logs by a specific tag
            Console.WriteLine("Search by tag\n");
            OutputData.Output(c.FindEntriesByTag("0202A"));
            Console.WriteLine("\n-----------------------------------\n");

            //Calls for method to print a list of logs by a specific tenant
            Console.WriteLine("Search by tenant\n");
            OutputData.Output(c.FindEntriesByTenant("Erlander", "William"));
            Console.WriteLine("\n-----------------------------------\n");
            
            //Show a list of all tenants living in a specific location
            OutputData.OutputTenants(c.ListTenantsAt("0102"));
        }
    }
}
