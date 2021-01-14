namespace DoorEventsLogger.Helpers
{
    using DoorEventsLogger.Handler;

    using System;

    /// <summary>
    /// Definition av <see cref="DoorEventsLogHelper" />.
    /// </summary>
    public static class DoorEventsLogHelper
    {
        /// <summary>
        /// InitDB.
        /// </summary>
        public static void InitDB()
        {
            if (DBHandler.InitDatabase())
            {
                // Skapa tabeller
                Console.WriteLine("Creating tables");
                DBHandler.CreateTable("Doors", "Id INTEGER NOT NULL UNIQUE", "Door TEXT NOT NULL", "LocationId INTEGER NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("EventCodes", "Id INTEGER NOT NULL UNIQUE", "Code TEXT NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("Events", "Id INTEGER NOT NULL UNIQUE", "EventDate TEXT NOT NULL", "TenantId INTEGER NOT NULL", "EventCodeId INTEGER NOT NULL", "DoorId INTEGER NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("Locations", "Id INTEGER NOT NULL UNIQUE", "Location TEXT NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("Tenants", "Id INTEGER NOT NULL UNIQUE ", "Name TEXT NOT NULL", "Tag TEXT NOT NULL", "LocationId INTEGER NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");

                Console.WriteLine("Creating People");
                AddPeople("0101", "Liam Jönsson", "0101A");
                AddPeople("0102", "Elias Petterson", "0102A");
                AddPeople("0102", "Wilma Johansson", "0102B");
                AddPeople("0103", "Alicia Sanchez", "0103A");
                AddPeople("0103", "Aaron Sanchez", "0103B");
                AddPeople("0201", "Olivia Erlander", "0201A");
                AddPeople("0201", "William Erlander", "0201B");
                AddPeople("0201", "Alexander Erlander", "0201C");
                AddPeople("0201", "Astrid Erlander", "0201D");
                AddPeople("0202", "Lucas Adolfsson", "0202A");
                AddPeople("0202", "Ebba Adolfsson", "0202B");
                AddPeople("0202", "Lilly Adolfsson", "0202C");
                AddPeople("0301", "Ella Ahlström", "0301A");
                AddPeople("0301", "Alma Alfredsson", "0301B");
                AddPeople("0301", "Elsa Ahlström", "0301C");
                AddPeople("0301", "Maja Ahlström", "0301D");
                AddPeople("0302", "Noah Almgren", "0302A");
                AddPeople("0302", "Adam Andersen", "0302B");
                AddPeople("0302", "Kattis Backman", "0302C");
                AddPeople("0302", "Oscar Chen", "0302D");
                AddPeople("VAKT", "Vaktmästare", "VAKT01");

                Console.WriteLine("Creating location");
                CreateLocation("TVÄTT");
                CreateLocation("SOPRUM");

                Console.WriteLine("Creating doors");
                CreateDoors("010", 3);
                CreateDoors("020", 2);
                CreateDoors("030", 2);
                CreateDoors("SOPRUM");
                CreateDoors("TVÄTT");
                CreateDoors("VAKT");
                CreateDoors("CYKELRUM");
                CreateDoors("UT");

                Console.WriteLine("Creating codes");
                CreateEventCodes("DÖUT", "DÖIN", "FDUT", "FDIN", "DÖST");
                Console.WriteLine("Creating events");
                DoorEventsGenerator.CreateEvents();
            }
        }

        /// <summary>
        /// AddPeople.
        /// </summary>
        /// <param name="location">Sträng<see cref="string"/> med rum eller lägenhetsbeteckning.</param>
        /// <param name="tenant">En sträng<see cref="string"/> med hyresgästens namn.</param>
        /// <param name="tag">En sträng<see cref="string"/> med tagg beteckning.</param>
        private static void AddPeople(string location, string tenant, string tag)
        {
            long locationId = CreateLocation(location);
            Console.WriteLine($"Created tenant {tenant} on {location} with tag {tag}");
            CreateTenant(tenant, tag, locationId);
        }

        /// <summary>
        /// CreateDoor.
        /// </summary>
        /// <param name="door">En sträng<see cref="string"/> med dörrbeteckning.</param>
        /// <param name="locationId">En long<see cref="long"/> med rum eller lägenhets ID nummer (från databasen).</param>
        private static void CreateDoor(string door, long locationId)
        {
            Console.WriteLine($"Created door {door}");
            DBHandler.ExecuteSQL("INSERT INTO Doors (Door, LocationId) VALUES(@name, @locationId)",
                                 "@name", door,
                                 "@locationId", locationId.ToString()
                                );
        }

        /// <summary>
        /// CreateDoors.
        /// </summary>
        /// <param name="door">Sträng<see cref="string"/> med dörrbeteckning.</param>
        private static void CreateDoors(string door)
        {
            long locationId = CreateLocation(door);
            CreateDoor(door, locationId);
        }

        /// <summary>
        /// CreateDoors.
        /// </summary>
        /// <param name="door">En sträng<see cref="string"/> med dörrbeteckning.</param>
        /// <param name="amountOfAppartments">En int<see cref="int"/> med antal lägenheter som ska registreras.</param>
        private static void CreateDoors(string door, int amountOfAppartments)
        {
            for (int i = 1; i <= amountOfAppartments; i++)
            {
                string location = door + i.ToString();
                long locationId = CreateLocation(location);
                CreateDoor("LGH" + location, locationId);
                CreateDoor("BLK" + location, locationId);
            }
        }

        /// <summary>
        /// CreateEventCodes.
        /// </summary>
        /// <param name="codes">En Array med koder<see cref="string[]"/>.</param>
        private static void CreateEventCodes(params string[] codes)
        {
            foreach (string code in codes)
            {
                Console.WriteLine($"Created event code {code}");
                DBHandler.ExecuteSQL("INSERT INTO EventCodes (Code) VALUES(@code)", "@code", code);
            }
        }

        /// <summary>
        /// CreateLocation.
        /// </summary>
        /// <param name="location">Sträng<see cref="string"/> med rum eller lägenhetsbeteckning.</param>
        /// <returns>Ett ID av typen long<see cref="long"/>.</returns>
        private static long CreateLocation(string location)
        {
            long id = GetLocationId(location);
            if (id > 0)
            {
                return id;
            }
            else
            {
                Console.WriteLine($"Created location {location}");
                return DBHandler.ExecuteSQL("INSERT INTO Locations (Location) VALUES(@location)",
                                            "@location", location
                                           );
            }
        }

        /// <summary>
        /// CreateTenant.
        /// </summary>
        /// <param name="tenant">En sträng<see cref="string"/> med hyresgästens namn.</param>
        /// <param name="tag">En sträng<see cref="string"/> med tagg beteckning.</param>
        /// <param name="locationId">En long<see cref="long"/> med rum eller lägenhets ID nummer (från databasen).</param>
        private static void CreateTenant(string tenant, string tag, long locationId)
        {
            Console.WriteLine($"Created table {tenant}");
            DBHandler.ExecuteSQL("INSERT INTO Tenants (Name, Tag, LocationId) VALUES(@name, @tag, @locationId)",
                                 "@name", tenant,
                                 "@tag", tag,
                                 "@locationId", locationId.ToString()
                                );
        }

        /// <summary>
        /// GetLocationId.
        /// </summary>
        /// <param name="location">Sträng<see cref="string"/> med rum eller lägenhetsbeteckning.</param>
        /// <returns>Ett ID av typen long<see cref="long"/>.</returns>
        private static long GetLocationId(string location)
        {
            System.Data.DataTable loc = DBHandler.GetDataTable("Select Id from Locations WHERE location=@location", "@location", location);
            return loc?.Rows.Count > 0 ? (long)loc.Rows[0]["Id"] : -1;
        }
    }
}