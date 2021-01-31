using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace EntityFramework_HFAB.Helpers
{
    class OutputHelper
    {
        public interface IOutput
        {
            //Properties for the interface
            string Date { get; set; }
            string Door { get; set; }
            string Event { get; set; }
            string Tag { get; set; }
            string Tenant { get; set; }

            /// <summary>
            /// Prints log entry to console from a sorted and filtered list 
            /// </summary>
            /// <param name="list">List of objects from IOutput interface</param>
            void Output(List<IOutput> list);

        }

        public class ConsoleOutput : IOutput
        {
            //Properties for the class
            public string Date { get; set; }
            public string Door { get; set; }
            public string Event { get; set; }
            public string Tag { get; set; }
            public string Tenant { get; set; }

            /// <summary>
            /// Prints log entry to console from a sorted and filtered list 
            /// </summary>
            /// <param name="list">List of objects</param>
            public void Output(List<IOutput> list)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Date} | {item.Door,8} | {item.Event,4} | {item.Tag,6} | {item.Tenant,-18} | {EventOutput(item.Event, item.Door, item.Tenant)}");
                }
            }

            /// <summary>
            /// Prints a list of all tenants living in a specific location
            /// </summary>
            /// <param name="list">List of objects from Tenant table in DB</param>
            public void OutputTenants(List<Models.Tenant> list)
            {
                Console.WriteLine("Tenants: ");
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Location} {item.Name} {item.Tag}");
                }
            }

            /// <summary>
            /// Prints an explaination of who opened what door and how (from in- or outside)
            /// </summary>
            /// <param name="Event">If user opened a door ("DÖIN"/"DÖUT"), or tried to open one without access("FDIN"/"FDUT")</param>
            /// <param name="Door">Door name</param>
            /// <param name="Tenant">Tenant name</param>
            /// <returns>A string explaining what happened during this event/log</returns>
            private static string EventOutput(string Event, string Door, string Tenant)
            {
                //Based on event name, these vars will explain if user really opened a door,
                //or tried to open one he/she didn't have access to
                var what = Event.StartsWith("FD") ? "försökte öppna" : "öppnade";
                //If door was opereted from inside or outside
                var where = Event.EndsWith("IN") ? "inifrån" : "utifrån";

                //If a Door starts with LGH the output will say "lägenhet xxxx"
                //if BLK it will say "balkong xxxx"
                string kindOfDoor;
                if (Door.StartsWith("LGH"))
                    kindOfDoor = "lägenhet " + Door[3] + Door[4] + Door[5] + Door[6];
                else if (Door.StartsWith("BLK"))
                    kindOfDoor = "balkong " + Door[3] + Door[4] + Door[5] + Door[6];
                //If door name doesn't begin with LGH or BLK, it's the same as location
                else
                    kindOfDoor = Door;
                //returns a string of events
                return Tenant + " " + $"{what} dörr till {kindOfDoor} {where}";
            }
        }
    }
}
