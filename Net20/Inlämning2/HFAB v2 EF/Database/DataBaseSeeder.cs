namespace HFAB_v2_EF.Database
{
    using System;
    using System.Linq;

    internal static class DataBaseSeeder
    {
        /// <summary>
        /// cheack if data need to be added
        /// </summary>
        public static void CheackIfDataExist()
        {
            using (var dataList = new HFABDataList())
            {
                Console.WriteLine("Check if data need to be added to DB");
                var standardDataList = dataList.Persons.Take(2).ToList();
                var DemonDataList = dataList.Loggs.Take(2).ToList();
                if (standardDataList.Count == 0)
                {
                    InserStandarData();
                }
                if (DemonDataList.Count == 0)
                {
                    DemonData();
                }

                Console.Clear();
            }
        }

        /// <summary>
        /// Insert the standard Value to the db
        /// </summary>
        private static void InserStandarData()
        {
            Console.WriteLine("adding StandrdData");
            using (var dataList = new HFABDataList())
            {
                var locations = new[] { "0101", "0102", "0103", "0201", "0202", "0301", "0302", "VAKT", "SOPRUM", "TVÄTT" };
                var events = new[] { "DÖUT", "DÖIN", "FDIN", "FDUT" };
                var doorNames = new[] { "LGH0101", "LGH0102", "LGH0103", "LGH0201", "LGH0202", "LGH0301", "LGH0302", "BLK0101", "BLK0102", "BLK0103", "BLK0201", "BLK0202", "BLK0301", "BLK0302", "VAKT", "SOPRUM", "TVÄTT", "UT" };

                foreach (var location in locations)

                {
                    dataList.Locations.Add(new Models.Location { Name = location });
                    dataList.SaveChanges();
                }
                foreach (var eventCode in events)
                {
                    dataList.Events.Add(new Models.Event { Code = eventCode });
                    dataList.SaveChanges();
                }
                foreach (var doorName in doorNames)
                {
                    dataList.DoorNames.Add(new Models.DoorName { Name = doorName });
                    dataList.SaveChanges();
                }

                var persons = new[,]
                {
                    { "Liam","Jönsson", "0101A", "1" },
                    { "Elias", "Petterson", "0102A", "2" }, { "Wilma", "Johansson", "0102B", "2"},
                    { "Alicia", "Sanchez", "0103A", "3"}, { "Aaron", "Sanchez", "0103B", "3"},
                    { "Olivia", "Erlander", "0201A", "4"}, { "William", "Erlander", "0201B", "4"}, { "Alexander", "Erlander", "0201C", "4"}, { "Astrid", "Erlander", "0201D", "4"},
                    { "Lucas", "Adolfsson", "0202A", "5"}, { "Ebba", "Adolfsson", "0202B", "5"}, { "Lilly", "Adolfsson", "0202C", "5"},
                    { "Ella", "Ahlström", "0301A", "6"}, { "Alma", "Alfredsson", "0301B", "6"}, { "Elsa", "Ahlström", "0301C", "6"}, { "Maja", "Ahlström", "0301D", "6"},
                    { "Noah", "Almgren", "0302A", "7"}, { "Adam", "Andersen", "0302B", "7"}, { "Kattis", "Backman", "0302C", "7"}, { "Oscar", "Chen", "0302D", "7"},
                    { "Vaktmästare", "", "VAKT01", "8"}
                };
                for (int i = 0; i < persons.GetLength(0); i++)
                {
                    dataList.Persons.Add(new Models.Person
                    {
                        FirstName = persons[i, 0],
                        LastName = persons[i, 1],
                        Tag = persons[i, 2],
                        Location = dataList.Locations.FirstOrDefault(l => l.ID == int.Parse(persons[i, 3]))
                    });
                    dataList.SaveChanges();
                }
            }
            Console.WriteLine("Standrad data done");
        }

        /// <summary>
        /// Insert Test Data
        /// </summary>
        private static void DemonData()
        {
            Console.WriteLine("Creating Test Data");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:07", "LGH0201", "DÖIN", "0201B");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:08", "LGH0201", "DÖUT", "0201B");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:19", "LGH0302", "DÖIN", "0302A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:19", "LGH0201", "DÖIN", "0201A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:20", "SOPRUM", "DÖUT", "0302A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:20", "UT", "DÖIN", "0201A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:21", "SOPRUM", "DÖIN", "0302A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:22", "LGH0201", "DÖUT", "0302A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:55", "LGH0202", "DÖIN", "0202A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:56", "LGH0202", "DÖUT", "0202A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:56", "LGH0301", "DÖIN", "0301B");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 10:56", "LGH0301", "DÖUT", "0301B");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 12:55", "LGH0201", "DÖIN", "0201C");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 12:55", "LGH0201", "DÖIN", "0201A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 12:58", "TVÄTT", "DÖUT", "0201C");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 12:58", "TVÄTT", "DÖUT", "0201A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 13:15", "TVÄTT", "DÖIN", "0201C");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 13:15", "TVÄTT", "DÖIN", "0201A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 13:16", "LGH0102", "DÖIN", "0102A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 13:17", "UT", "DÖIN", "0201A");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 13:22", "LGH0201", "DÖUT", "0201C");
            Controllers.DoorEventsLog.LogEntry("2020-10-23 13:22", "LGH0102", "DÖUT", "0102A");
            Console.WriteLine("Test Data Done");
        }
    }
}