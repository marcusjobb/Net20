using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Husrum_Fastigheter_AB
{
    internal class Interactive
    {
        private Database DataBase = new Database();
        private CreateDatabase Data = new CreateDatabase();
        private DoorEventsLog Communication = new DoorEventsLog();

        public string Input_Reader()
        {
            string input = "";
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
            }
            return input;
        }

        public void Log()
        {
            int Person_ID = 0;
            int Location_ID = 0;
            int Event_ID = 0;
            int Date = 0;
            int Time = 0;
            string input;
            Console.WriteLine("In order to log an entry start off with the date yyyymmdd");
            while (true)
            {
                try
                {
                    Date = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
                if (Date.ToString().Count() == 8)
                {
                    break;
                }
                else
                    Console.WriteLine("Wrong Format");
            }

            Console.WriteLine("Enter time hhmm, use military system");
            while (true)
            {
                try
                {
                    Time = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
                if (Time.ToString().Count() == 4)
                {
                    break;
                }
                else
                    Console.WriteLine("Wrong Format");
            }

            Console.WriteLine("Enter tag code");
            while (true)
            {
                input = Input_Reader();
                DataTable result = DataBase.Data_Fetcher(@"SELECT * FROM Tenants
                                                     WHERE Tenants.Tag = @Tag", new string[] { "@Tag", input });
                if (result.Rows.Count != 0)
                {
                    foreach (DataRow x in result.Rows)
                        Person_ID = Convert.ToInt32(x["ID"]);
                    break;
                }
                else
                    Console.WriteLine("Invalid tag code");
            }

            Console.WriteLine("Enter door code");
            while (true)
            {
                input = Input_Reader();
                DataTable result = DataBase.Data_Fetcher(@"SELECT * FROM Locations
                                                     WHERE Locations.Location = @Location", new string[] { "@Location", input });
                if (result.Rows.Count != 0)
                {
                    foreach (DataRow x in result.Rows)
                        Location_ID = Convert.ToInt32(x["ID"]);
                    break;
                }
                else
                    Console.WriteLine("Invalid door code");
            }

            Console.WriteLine("Enter event code");
            while (true)
            {
                input = Input_Reader();
                DataTable result = DataBase.Data_Fetcher(@"SELECT * FROM Events
                                                     WHERE Events.Event = @Event", new string[] { "@Event", input });
                if (result.Rows.Count != 0)
                {
                    foreach (DataRow x in result.Rows)
                        Event_ID = Convert.ToInt32(x["ID"]);
                    break;
                }
                else
                    Console.WriteLine("Invalid event code");
            }
            Communication.LogEntry(Person_ID, Location_ID, Event_ID, Date, Time);
        }

        public void Print_Result(DataTable result)
        {
            if (result.Columns.Count != 6)
            {
                foreach (DataRow x in result.Rows)
                {
                    Console.WriteLine(x["Name"] + "\t" + x["Apartment"] + "\t" + x["Tag"]);
                }
            }
            else
            {
                foreach (DataRow x in result.Rows)
                {
                    var time = x["Time"].ToString();
                    var date = x["Date"].ToString();
                    var location = x["Location"].ToString();
                    var tenant = x["Name"].ToString();
                    var @event = x["Event"].ToString();
                    var tag = x["Tag"].ToString();

                    switch (@event)
                    {
                        case "DÖIN":
                            Console.WriteLine(date + "\t" + time + "\t" + location + "\t" + @event + "\t" + tag + "\t" + tenant + " öppnade dörren till {0} inifrån", location);
                            break;

                        case "DÖUT":
                            Console.WriteLine(date + "\t" + time + "\t" + location + "\t" + @event + "\t" + tag + "\t" + tenant + " öppnade dörren till {0} utifrån", location);
                            break;

                        case "FDIN":
                            Console.WriteLine(date + "\t" + time + "\t" + location + "\t" + @event + "\t" + tag + "\t" + tenant + " försökte öppna dörren till {0} inifrån", location);
                            break;

                        default:
                            Console.WriteLine(date + "\t" + time + "\t" + location + "\t" + @event + "\t" + tag + "\t" + tenant + " försökte öppna dörren till {0} utifrån", location);
                            break;
                    }
                }
            }
        }

        public void Test_To_See()
        {
            Data.Create_Database();
            Communication.max_enteries = 20;

            DataTable result = new DataTable();
            result = Communication.FindEntriesByDoor("LGH0302");
            Console.WriteLine("\nSearch by door:"); Print_Result(result);

            result = Communication.FindEntriesByEvent("DÖIN");
            Console.WriteLine("\nSearch by event:"); Print_Result(result);

            result = Communication.FindEntriesByLocation("SOPRUM");
            Console.WriteLine("\nSearch by Location:"); Print_Result(result);

            result = Communication.FindEntriesByTag("0302A");
            Console.WriteLine("\nSearch by tag:"); Print_Result(result);

            result = Communication.FindEntriesByTenant("William Erlander");
            Console.WriteLine("\nSearch by tenant:"); Print_Result(result);

            result = Communication.ListTenantAt("0301");
            Console.WriteLine("\nList Tenants At 0301:"); Print_Result(result);

            Console.WriteLine("\nLog an event:");
            Log();
        }
    }
}