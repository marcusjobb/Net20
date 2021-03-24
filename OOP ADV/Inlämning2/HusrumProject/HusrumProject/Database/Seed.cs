namespace HusrumProject.Utils
{
    using System.Linq;

    internal static class Seed
    {
        /// <summary>
        /// Check if database contain information about tenants
        /// Add preset data if database is empty
        /// Add info if database is empty
        /// </summary>
        public static void CheckDbPopulation()
        {
            using var db = new Database.DatabaseFilePath();
            var presetData = db.Tenants
                .Take(2)
                .ToList();
            var presetLogData = db.EventLogs
                .Take(2)
                .ToList();
            if (presetData.Count == 0)
                PresetData();
            if (presetLogData.Count == 0)
                PresetLogData();
        }

        /// <summary>
        /// Adds tables with standard data about the building
        /// Fills tables with standard data
        /// </summary>
        public static void PresetData()
        {
            using var db = new Database.DatabaseFilePath();
            var doorEvent = new[] { "DÖIN", "DÖUT", "FDIN", "FDUT" };
            var doorLocation = new[] { "0101", "0102", "0103", "0201", "0202", "0301", "0302", "VAKT", "SOPRUM", "TVÄTT" };
            var doorName = new[] { "LGH0101", "LGH0102", "LGH0103", "LGH0201", "LGH0202", "LGH0301", "LGH0302", "VAKT", "SOPRUM", "TVÄTT", "UT" };

            foreach (var Event in doorEvent)
                db.DoorEvents
                    .Add(new Models.DoorEvent { Code = Event });
            db.SaveChanges();

            foreach (var location in doorLocation)
                db.DoorLocations
                    .Add(new Models.DoorLocation { Name = location });
            db.SaveChanges();

            foreach (var name in doorName)
                db.DoorNames
                    .Add(new Models.DoorName { Name = name });
            db.SaveChanges();

            var tenants = new[,]
            {
                { "Liam","Jönsson", "0101A", "1" },
                { "Elias", "Petterson", "0102A", "2" },
                { "Wilma", "Johansson", "0102B", "2"},
                { "Alicia", "Sanchez", "0103A", "3"},
                { "Aaron", "Sanchez", "0103B", "3"},
                { "Olivia", "Erlander", "0201A", "4"},
                { "William", "Erlander", "0201B", "4"},
                { "Alexander", "Erlander", "0201C", "4"},
                { "Astrid", "Erlander", "0201D", "4"},
                { "Lucas", "Adolfsson", "0202A", "5"},
                { "Ebba", "Adolfsson", "0202B", "5"},
                { "Lilly", "Adolfsson", "0202C", "5"},
                { "Ella", "Ahlström", "0301A", "6"},
                { "Alma", "Alfredsson", "0301B", "6"},
                { "Elsa", "Ahlström", "0301C", "6"},
                { "Maja", "Ahlström", "0301D", "6"},
                { "Noah", "Almgren", "0302A", "7"},
                { "Adam", "Andersen", "0302B", "7"},
                { "Kattis", "Backman", "0302C", "7"},
                { "Oscar", "Chen", "0302D", "7"},
                { "Vaktmästare", "", "VAKT01", "8"}
            };

            for (int i = 0; i < tenants.GetLongLength(0); i++)
                db.Tenants
                    .Add(
                    new Models.Tenant
                    {
                        FirstName = tenants[i, 0],
                        LastName = tenants[i, 1],
                        TenantTag = tenants[i, 2],
                        Location = db.DoorLocations
                            .FirstOrDefault(l => l.ID == int.Parse(tenants[i, 3]))
                    });
            db.SaveChanges();
        }

        /// <summary>
        /// Adds premade logdata for building
        /// For testing functions
        /// </summary>
        public static void PresetLogData()
        {
            Controllers.DoorEventLog.Log("2020-10-23 10:07", "DÖIN", "LGH0201", "0201B");
            Controllers.DoorEventLog.Log("2020-10-23 10:08", "DÖUT", "LGH0201", "0201B");
            Controllers.DoorEventLog.Log("2020-10-23 10:19", "DÖIN", "LGH0302", "0302A");
            Controllers.DoorEventLog.Log("2020-10-23 10:19", "DÖIN", "LGH0201", "0201A");
            Controllers.DoorEventLog.Log("2020-10-23 10:20", "DÖUT", "SOPRUM", "0302A");
            Controllers.DoorEventLog.Log("2020-10-23 10:20", "DÖIN", "UT", "0201A");
            Controllers.DoorEventLog.Log("2020-10-23 10:21", "DÖIN", "SOPRUM", "0302A");
            Controllers.DoorEventLog.Log("2020-10-23 10:22", "DÖIN", "LGH0302", "0302A");
            Controllers.DoorEventLog.Log("2020-10-23 10:55", "DÖIN", "LGH0202", "0202A");
            Controllers.DoorEventLog.Log("2020-10-23 10:56", "DÖUT", "LGH0202", "0202A");
            Controllers.DoorEventLog.Log("2020-10-23 11:03", "DÖIN", "LGH0301", "0301D");
            Controllers.DoorEventLog.Log("2020-10-23 11:04", "DÖUT", "LGH0301", "0301D");
        }
    }
}