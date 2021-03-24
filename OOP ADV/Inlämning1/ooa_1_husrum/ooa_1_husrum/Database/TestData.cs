using System.Data;

namespace ooa_1_husrum
{
  static class TestData
  {
    /// <summary>
    /// Adds test data to the database, if the log table is empty.
    /// </summary>
    /// <param name="log">DoorEventsLog object with database handler.</param>
    public static void CreateTestData(DoorEventsLog log)
    {
      DBHandler dbh = log.DBHandler;

      // trying to avoid adding duplicate test data when program is run more than once without removing the call to create test data
      long LogEntriesCount = dbh.GetDataSet("SELECT COUNT(*) FROM Log;").Rows[0].Field<long>(0);

      if (LogEntriesCount == 0) 
      {
        System.Console.Write("Creating test data...");

        // add doors to database
        #region Doors
        // Creates doors for an apartment
        void CreateApartmentDoors(int floorLevel, int apartmentNumber)
        {
          dbh.CreateDoor($"LGH0{floorLevel}0{apartmentNumber}", $"LGH0{floorLevel}0{apartmentNumber}", "Dörr till lägenhet.");
          dbh.CreateDoor($"BLK0{floorLevel}0{apartmentNumber}", $"BLK0{floorLevel}0{apartmentNumber}", "Dörr till balkong/altan.");
        }

        CreateApartmentDoors(1, 1);
        CreateApartmentDoors(1, 2);
        CreateApartmentDoors(1, 3);
        CreateApartmentDoors(2, 1);
        CreateApartmentDoors(2, 2);
        CreateApartmentDoors(3, 1);
        CreateApartmentDoors(3, 2);

        dbh.CreateDoor("UT01", "UT", "Dörr ut mot gatan.");
        dbh.CreateDoor("SOPRUM01", "SOPRUM", "Dörr mot soprummet.");
        dbh.CreateDoor("TVÄTT01", "TVÄTT", "Dörr mot tvättstugan.");
        dbh.CreateDoor("VAKT01", "VAKT", "Dörr mot vaktmästarens rum.");
        #endregion
        // add events to database
        #region Events
        dbh.CreateEvent("DÖUT", "Dörr öppnad - utifrån.");
        dbh.CreateEvent("DÖIN", "Dörr öppnad - inifrån");
        dbh.CreateEvent("DS", "Dörr stängd.");
        dbh.CreateEvent("FDUT", "Fel dörr - Otillåtet försök att öppna en dörr utifrån.");
        dbh.CreateEvent("FDIN", "Fel dörr - Otillåtet försök att öppna en dörr inifrån.");
        #endregion
        // add tenants to database
        #region Tenants
        dbh.CreateTenant("Liam Jönsson", "0101");

        dbh.CreateTenant("Elias Petterson", "0102");
        dbh.CreateTenant("Wilma Johansson", "0102");

        dbh.CreateTenant("Alicia Sanchez", "0103");
        dbh.CreateTenant("Aaron Sanchez", "0103");

        dbh.CreateTenant("Olivia Erlander", "0201");
        dbh.CreateTenant("William Erlander", "0201");
        dbh.CreateTenant("Alexander Erlander", "0201");
        dbh.CreateTenant("Astrid Erlander", "0201");

        dbh.CreateTenant("Lucas Adolfsson", "0202");
        dbh.CreateTenant("Ebba Adolfsson", "0202");
        dbh.CreateTenant("Lilly Adolfsson", "0202");

        dbh.CreateTenant("Ella Ahlström", "0301");
        dbh.CreateTenant("Alma Alfredsson", "0301");
        dbh.CreateTenant("Elsa Ahlström", "0301");
        dbh.CreateTenant("Maja Ahlström", "0301");

        dbh.CreateTenant("Noah Almgren", "0302");
        dbh.CreateTenant("Adam Andersen", "0302");
        dbh.CreateTenant("Kattis Backman", "0302");
        dbh.CreateTenant("Oscar Chen", "0302");

        dbh.CreateTenant("Vaktmästare", "VAKT");
        #endregion
        // add keys to database
        #region Keys
        dbh.CreateTag("0101A", "Liam Jönsson");

        dbh.CreateTag("0102A", "Elias Petterson");
        dbh.CreateTag("0102B", "Wilma Johansson");

        dbh.CreateTag("0103A", "Alicia Sanchez");
        dbh.CreateTag("0103B", "Aaron Sanchez");

        dbh.CreateTag("0201A", "Olivia Erlander");
        dbh.CreateTag("0201B", "William Erlander");
        dbh.CreateTag("0201C", "Alexander Erlander");
        dbh.CreateTag("0201D", "Astrid Erlander");

        dbh.CreateTag("0202A", "Lucas Adolfsson");
        dbh.CreateTag("0202B", "Ebba Adolfsson");
        dbh.CreateTag("0202C", "Lilly Adolfsson");

        dbh.CreateTag("0301A", "Ella Ahlström");
        dbh.CreateTag("0301B", "Alma Alfredsson");
        dbh.CreateTag("0301C", "Elsa Ahlström");
        dbh.CreateTag("0301D", "Maja Ahlström");

        dbh.CreateTag("0302A", "Noah Almgren");
        dbh.CreateTag("0302B", "Adam Andersen");
        dbh.CreateTag("0302C", "Kattis Backman");
        dbh.CreateTag("0302D", "Oscar Chen");

        dbh.CreateTag("VAKT01", "Vaktmästare");
        #endregion
        // add access for keys to the doors
        #region Access
        dbh.CreateAccess("0101A", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0101", "BLK0101" });

        dbh.CreateAccess("0102A", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0102", "BLK0102" });
        dbh.CreateAccess("0102B", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0102", "BLK0102" });

        dbh.CreateAccess("0103B", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0103", "BLK0103" });
        dbh.CreateAccess("0103B", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0103", "BLK0103" });

        dbh.CreateAccess("0201A", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0201", "BLK0201" });
        dbh.CreateAccess("0201B", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0201", "BLK0201" });
        dbh.CreateAccess("0201C", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0201", "BLK0201" });
        dbh.CreateAccess("0201D", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0201", "BLK0201" });

        dbh.CreateAccess("0202A", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0202", "BLK0202" });
        dbh.CreateAccess("0202B", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0202", "BLK0202" });
        dbh.CreateAccess("0202C", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0202", "BLK0202" });

        dbh.CreateAccess("0301A", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0301", "BLK0301" });
        dbh.CreateAccess("0301B", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0301", "BLK0301" });
        dbh.CreateAccess("0301C", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0301", "BLK0301" });
        dbh.CreateAccess("0301D", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0301", "BLK0301" });

        dbh.CreateAccess("0302A", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0302", "BLK0302" });
        dbh.CreateAccess("0302B", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0302", "BLK0302" });
        dbh.CreateAccess("0302C", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0302", "BLK0302" });
        dbh.CreateAccess("0302D", new string[] { "UT", "SOPRUM", "TVÄTT", "LGH0302", "BLK0302" });

        // give caretaker access to all doors
        dbh.CreateAccess(
          "VAKT01",
          new string[]
          {
          "VAKT",
          "UT",
          "SOPRUM",
          "TVÄTT",
          "LGH0101", "BLK0101",
          "LGH0102", "BLK0102",
          "LGH0103", "BLK0103",
          "LGH0201", "BLK0201",
          "LGH0202", "BLK0202",
          "LGH0203", "BLK0203",
          "LGH0301", "BLK0301",
          "LGH0302", "BLK0302"
          }
        );

        #endregion
        // add some log entries
        #region Logs
        // tenant           tag
        // william erlander 0201C
        // noah almgren     0302A
        // olivia erlander  0201A
        // lucas adolfson   0202A
        // maja ahlström    0301D
        // liam             0101A
        // astrid           0201D

        log.LogEntry("0201C", "LGH0201",  "23-10-20", "10:07:00", "DÖIN"); // william erlander tar in tidningen
        log.LogEntry("0201C", "LGH0201",  "23-10-20", "10:08:00", "DÖUT");
        log.LogEntry("0302A", "LGH0302",  "23-10-20", "10:19:00", "DÖIN"); // noah almgren slänger soporna
        log.LogEntry("0201A", "LGH0201",  "23-10-20", "10:19:00", "DÖIN"); // olivia erlander går till jobbet
        log.LogEntry("0302A", "SOPRUM01", "23-10-20", "10:20:00", "DÖUT");
        log.LogEntry("0201A", "UT01",     "23-10-20", "10:19:00", "DÖIN");
        log.LogEntry("0302A", "SOPRUM01", "23-10-20", "10:21:00", "DÖIN");
        log.LogEntry("0302A", "LGH0302",  "23-10-20", "10:22:00", "DÖUT");
        log.LogEntry("0202A", "LGH0202",  "23-10-20", "10:55:00", "DÖIN"); // lucas adolfson hämtar posten
        log.LogEntry("0202A", "LGH0202",  "23-10-20", "10:56:00", "DÖUT");
        log.LogEntry("0301D", "LGH0301",  "23-10-20", "11:03:00", "DÖIN"); // maja ahlström hämtar posten
        log.LogEntry("0301D", "LGH0301",  "23-10-20", "11:04:00", "DÖUT");
        log.LogEntry("0101A", "BLK0101",  "23-10-19", "08:19:12", "DÖIN"); // liam går ut på altanen
        log.LogEntry("0201D", "BLK0201",  "23-10-19", "08:22:45", "DÖIN"); // astrid går ut på balkongen
        log.LogEntry("0201D", "BLK0201",  "23-10-19", "08:25:09", "DÖUT");
        log.LogEntry("0101A", "BLK0101",  "23-10-19", "08:27:10", "DÖUT");
        #endregion 
        System.Console.WriteLine("\n");
      }
    }
  }
}
