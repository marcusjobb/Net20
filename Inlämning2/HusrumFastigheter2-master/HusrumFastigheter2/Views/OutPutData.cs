using System;
using System.Collections.Generic;
using System.Text;

namespace HusrumFastigheter2.Views
{
    class OutPutData
    {
        public static void OutPutLog(string searchBy, List<Models.Log> logs)
        {
            Console.WriteLine();
            Console.WriteLine(logs);
            if(logs != null)
            {
                foreach(var log in logs)
                {
                    var eventDescription = "";
                    if(log.Event.Code == "DÖIN")
                    {
                        eventDescription = "Öppnade dörren " + log.Door.DoorName + " " + "inifrån.";
                    }
                    else if(log.Event.Code == "DÖUT")
                    {
                        eventDescription = "Öppnade dörren " + log.Door.DoorName + " " + "utifrån.";
                    }
                    else if(log.Event.Code == "FDIN")
                    {
                        eventDescription = "Försökte öppna " + log.Door.DoorName + " " + "inifrån.";
                    }
                    else if(log.Event.Code == "FDUT")
                    {
                        eventDescription = "Försökte öppna " + log.Door.DoorName + " " +  "utifrån.";
                    }
                    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", log.Date, log.Door.DoorName, log.Event.Code, log.Tenant.Tag, log.Tenant.FirstName, log.Tenant.LastName, eventDescription);
                }
            }
            else
            {
                Console.WriteLine("Kunde inte hitta några resultat.");
            }
        }
        public static void OutPutList(List<string> tenants)
        {
            Console.WriteLine();
            Console.WriteLine("Lista med hyresgäster i lägenheten.");
            if(tenants != null)
            {
                foreach(var tenant in tenants)
                {
                    Console.WriteLine(tenant);
                }
            }
            else
            {
                Console.WriteLine("Hittade inga hyregäster i den sökta lägenheten.");
            }
        }
        public static void OutPutBool(bool trueOrFalse)
        {
            Console.WriteLine();
            if (!trueOrFalse)
            {
                Console.WriteLine("Något gick fel.");
            }
            else
            {
                Console.Write("Lyckad genomföring.");
            }
        }
    }
}
