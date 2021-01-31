using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HusrumFastigheter2.Database
{
    class DatabaseSeeder
    {
        public static void CheckData()
        {
                using (var dataList = new Database.MyDatabase())
                {
                    var standardData = dataList.Tenants.Take(1).ToList();
                    var staticData = dataList.Logs.Take(1).ToList();
                    if (standardData.Count == 0)
                    {
                        StandardData();
                    }
                    else if (staticData.Count == 0)
                    {
                        StaticData();
                    }
                }
        }

        private static void StandardData()
        {
            using(var dataList = new Database.MyDatabase())
            {
                var doorNames = new[] {"LGH0101", "LGH0102", "LGH0103", "LGH0201", "LGH0202", "LGH0301", "LGH0302", "BLK0101", "BLK0102", "BLK0103", "BLK0201", "BLK0202", "BLK0301", "BLK0302", "VAKT", "TVÄTT", "SOPRUM", "UT" };
                var events = new[] {"FDIN", "FDUT", "DÖIN", "DÖUT" };
                var locations = new[] {"0101", "0102", "0103", "0201", "0202", "0301", "0302", "VAKT", "TVÄTT", "SOPRUM"};

                foreach(var doorName in doorNames)
                {
                    dataList.Doors.Add(new Models.Door { DoorName = doorName });
                    dataList.SaveChanges();
                }
                foreach(var @event in events)
                {
                    dataList.Events.Add(new Models.Event { Code = @event });
                    dataList.SaveChanges();
                }
                foreach(var location in locations)
                {
                    dataList.Locations.Add(new Models.Location { LocationName = location });
                    dataList.SaveChanges();
                }
                var tenants = new[,] {
                    { "Liam","Jönsson", "0101A", "1" },
                    { "Elias", "Petterson", "0102A", "2" }, { "Wilma", "Johansson", "0102B", "2"},
                    { "Alicia", "Sanchez", "0103A", "3"}, { "Aaron", "Sanchez", "0103B", "3"},
                    { "Olivia", "Erlander", "0201A", "4"}, { "William", "Erlander", "0201B", "4"}, { "Alexander", "Erlander", "0201C", "4"}, { "Astrid", "Erlander", "0201D", "4"},
                    { "Lucas", "Adolfsson", "0202A", "5"}, { "Ebba", "Adolfsson", "0202B", "5"}, { "Lilly", "Adolfsson", "0202C", "5"},
                    { "Ella", "Ahlström", "0301A", "6"}, { "Alma", "Alfredsson", "0301B", "6"}, { "Elsa", "Ahlström", "0301C", "6"}, { "Maja", "Ahlström", "0301D", "6"},
                    { "Noah", "Almgren", "0302A", "7"}, { "Adam", "Andersen", "0302B", "7"}, { "Kattis", "Backman", "0302C", "7"}, { "Oscar", "Chen", "0302D", "7"},
                    { "Vaktmästare", "", "VAKT01", "8"}
                };
                for(int i = 0; i < tenants.GetLength(0); i++)
                {
                    dataList.Tenants.Add(new Models.Tenant
                    {
                        FirstName = tenants[i, 0],
                        LastName = tenants[i, 1],
                        Tag = tenants[i, 2],
                        Location = dataList.Locations.FirstOrDefault(l => l.ID == int.Parse(tenants[i, 3]))
                    });
                    dataList.SaveChanges();
                }
                Console.WriteLine("Standard Data created.");
            }
        }

        private static void StaticData()
        {
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:16", "LGH0101", "DÖIN", "0101A");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:20", "LGH0102", "DÖUT", "0102A");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:22", "LGH0102", "DÖIN", "0102B");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:25", "LGH0201", "DÖIN", "0201A");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:28", "LGH0201", "DÖUT", "0201B");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:30","VAKT", "FDIN", "0201C");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:32", "TVÄTT", "DÖIN", "0201D");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:35", "LGH0202", "DÖIN", "0202A");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:37", "LGH0302", "FDIN", "0202B");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:39", "SOPRUM", "DÖUT", "0202C");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:42", "SOPRUM", "DÖIN", "0301A");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:45", "UT", "DÖUT", "0301B");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:48", "UT", "FDIN", "0301C");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:50", "LGH0301", "DÖIN", "0301D");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:52", "LGH0302", "DÖUT", "0302A");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:56", "TVÄTT", "FDIN", "0302B");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 12:59", "LGH0302", "DÖIN", "0302C");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 13:05", "SOPRUM", "DÖUT", "0302D");
            Controllers.DoorEventsLog.LogEntry("2021-01-11 13:37", "VAKT", "DÖIN", "VAKT01");
            Console.WriteLine("Static Data created.");
        }
    }
}
