namespace HusrumProject.Views
{
    using System;
    using System.Collections.Generic;

    internal class PrintToConsole
    {
        /// <summary>
        /// Will print to console if requested event was successful
        /// </summary>
        /// <param name="boolTrue"></param>
        public static void CheckPrint(bool boolTrue)
        {
            if (!boolTrue)
                Console.WriteLine("Error");
            else
                Console.WriteLine("Sucess");
        }

        /// <summary>
        /// Lists tenants at requested apartment
        /// </summary>
        /// <param name="tenants">Tenants in requested apartment</param>
        public static void List(List<string> tenants)
        {
            Console.WriteLine("Personer i lägenheten: ");
            if (tenants != null)
                foreach (var tenant in tenants)
                    Console.WriteLine(tenant);
            else
                Console.WriteLine("Lägenheten är tom");
        }

        /// <summary>
        /// Prints log to console
        /// </summary>
        /// <param name="search">Search parameter</param>
        /// <param name="logs">Retrieve log from database</param>
        public static void Log(string search, List<Models.EventLog> logs)
        {
            Console.WriteLine(search);
            if (logs != null)
                foreach (var log in logs)
                {
                    var action = "";

                    if (log.DoorEvent.Code == "DÖIN")
                        action = "Öppnade dörr " + log.DoorName.Name + " inifrån";
                    if (log.DoorEvent.Code == "DÖUT")
                        action = "Öppnade dörr " + log.DoorName.Name + " utifrån";
                    if (log.DoorEvent.Code == "FDIN")
                        action = "Har inte tillåtelse att  öppna " + log.DoorName.Name + " inifrån";
                    if (log.DoorEvent.Code == "FDUT")
                        action = "Har inte tillåtelse att öppna " + log.DoorName.Name + " utifrån";

                    Console.WriteLine("{0}, {1}, {2}, {3}, {4} {5} {6}",
                                      log.DateTime,
                                      log.DoorName.Name,
                                      log.DoorEvent.Code,
                                      log.Tenant.TenantTag,
                                      log.Tenant.FirstName,
                                      log.Tenant.LastName,
                                      action);
                }
            else
                Console.WriteLine("No result");
        }
    }
}