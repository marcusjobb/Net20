namespace ooa_2_husrum_ef.Database.Seeders
{
  using ooa_2_husrum_ef.Models;
  using System;
  using System.Collections.Generic;

  static class LogsDataSeeder
  {
    /// <summary>
    /// Sets up seed data in DBContext LogsContext.
    /// </summary>
    public static void Seed()
    {
      // Open database connection.
      using (var context = new LogsContext())
      {
        // Start transaction.
        context.Database.BeginTransaction();
        try
        {
          #region Add Locations
          var locations = new List<Location>
          {
            new Location() { Id = "UT" },
            new Location() { Id = "SOPRUM" },
            new Location() { Id = "TVÄTT" },
            new Location() { Id = "VAKT" },

            new Location() { Id = "0101" },
            new Location() { Id = "0102" },
            new Location() { Id = "0103" },

            new Location() { Id = "0201" },
            new Location() { Id = "0202" },

            new Location() { Id = "0301" },
            new Location() { Id = "0302" },
          };
          context.AddRange(locations);
          #endregion

          #region Add Doors
          // Add doors
          var doors = new List<Door>
          {
            new Door() { Id = "UT01",     LocationId = "UT",     Description = "Dörr ut mot gatan." },
            new Door() { Id = "SOPRUM01", LocationId = "SOPRUM", Description = "Dörr mot soprummet." },
            new Door() { Id = "TVÄTT01",  LocationId = "TVÄTT",  Description = "Dörr mot tvättstugan." },
            new Door() { Id = "VAKT01",   LocationId = "VAKT",   Description = "Dörr mot vaktmästarens rum." },

            // doors for apartments 0101, 0102, 0103
            new Door() { Id = "LGH0101",  LocationId = "0101",   Description = "Dörr till lägenhet." },
            new Door() { Id = "BLK0101",  LocationId = "0101",   Description = "Dörr till balkong/altan." },
            new Door() { Id = "LGH0102",  LocationId = "0102",   Description = "Dörr till lägenhet." },
            new Door() { Id = "BLK0102",  LocationId = "0102",   Description = "Dörr till balkong/altan." },
            new Door() { Id = "LGH0103",  LocationId = "0103",   Description = "Dörr till lägenhet." },
            new Door() { Id = "BLK0103",  LocationId = "0103",   Description = "Dörr till balkong/altan." },
          
            // ... 0201, 0202
            new Door() { Id = "LGH0201",  LocationId = "0201",   Description = "Dörr till lägenhet." },
            new Door() { Id = "BLK0201",  LocationId = "0201",   Description = "Dörr till balkong/altan." },
            new Door() { Id = "LGH0202",  LocationId = "0202",   Description = "Dörr till lägenhet." },
            new Door() { Id = "BLK0202",  LocationId = "0202",   Description = "Dörr till balkong/altan." },
          
            // ... 0301, 0302
            new Door() { Id = "LGH0301",  LocationId = "0301",   Description = "Dörr till lägenhet." },
            new Door() { Id = "BLK0301",  LocationId = "0301",   Description = "Dörr till balkong/altan." },
            new Door() { Id = "LGH0302",  LocationId = "0302",   Description = "Dörr till lägenhet." },
            new Door() { Id = "BLK0302",  LocationId = "0302",   Description = "Dörr till balkong/altan." },
          };
          context.AddRange(doors);
          #endregion

          #region Add Events
          var events = new List<Event>
          {
            new Event() { Id = "DÖUT", Description = "Dörr öppnad - utifrån."},
            new Event() { Id = "DÖIN", Description = "Dörr öppnad - inifrån"},
            new Event() { Id = "DS",   Description = "Dörr stängd."},
            new Event() { Id = "FDUT", Description = "Fel dörr - Otillåtet försök att öppna en dörr utifrån."},
            new Event() { Id = "FDIN", Description = "Fel dörr - Otillåtet försök att öppna en dörr inifrån."}
          };
          context.AddRange(events);

          #endregion
          
          #region Add Tenants
          var tenants = new List<Tenant>
          {
            new Tenant() { Id = "00010101-0001",  Name = "Liam Jönsson",       ApartmentId = "0101" },

            new Tenant() { Id = "00010101-0002",  Name = "Elias Petterson",    ApartmentId = "0102" },
            new Tenant() { Id = "00010101-0003",  Name = "Wilma Johansson",    ApartmentId = "0102" },

            new Tenant() { Id = "00010101-0004",  Name = "Alicia Sanchez",     ApartmentId = "0103" },
            new Tenant() { Id = "00010101-0005",  Name = "Aaron Sanchez",      ApartmentId = "0103" },

            new Tenant() { Id = "00010101-0006",  Name = "Olivia Erlander",    ApartmentId = "0201" },
            new Tenant() { Id = "00010101-0007",  Name = "William Erlander",   ApartmentId = "0201" },
            new Tenant() { Id = "00010101-0008",  Name = "Alexander Erlander", ApartmentId = "0201" },
            new Tenant() { Id = "00010101-0009",  Name = "Astrid Erlander",    ApartmentId = "0201" },

            new Tenant() { Id = "00010101-0010", Name = "Lucas Adolfsson",     ApartmentId = "0202" },
            new Tenant() { Id = "00010101-0011", Name = "Ebba Adolfsson",      ApartmentId = "0202" },
            new Tenant() { Id = "00010101-0012", Name = "Lilly Adolfsson",     ApartmentId = "0202" },

            new Tenant() { Id = "00010101-0013", Name = "Ella Ahlström",       ApartmentId = "0301" },
            new Tenant() { Id = "00010101-0014", Name = "Alma Alfredsson",     ApartmentId = "0301" },
            new Tenant() { Id = "00010101-0015", Name = "Elsa Ahlström",       ApartmentId = "0301" },
            new Tenant() { Id = "00010101-0016", Name = "Maja Ahlström",       ApartmentId = "0301" },

            new Tenant() { Id = "00010101-0017", Name = "Noah Almgren",        ApartmentId = "0302" },
            new Tenant() { Id = "00010101-0018", Name = "Adam Andersen",       ApartmentId = "0302" },
            new Tenant() { Id = "00010101-0019", Name = "Kattis Backman",      ApartmentId = "0302" },
            new Tenant() { Id = "00010101-0020", Name = "Oscar Chen",          ApartmentId = "0302" },

            new Tenant() { Id = "00010101-0021", Name = "Vaktmästare",         ApartmentId = "VAKT" },
          };
          context.AddRange(tenants);
          #endregion

          #region Add Tags
          var tags = new List<Tag>
          {
            new Tag() { Id = "0101A", TenantId = "00010101-0001" },

            new Tag() { Id = "0102A", TenantId = "00010101-0002" },
            new Tag() { Id = "0102B", TenantId = "00010101-0003" },

            new Tag() { Id = "0103A", TenantId = "00010101-0004" },
            new Tag() { Id = "0103B", TenantId = "00010101-0005" },

            new Tag() { Id = "0201A", TenantId = "00010101-0006" },
            new Tag() { Id = "0201B", TenantId = "00010101-0007" },
            new Tag() { Id = "0201C", TenantId = "00010101-0008" },
            new Tag() { Id = "0201D", TenantId = "00010101-0009" },

            new Tag() { Id = "0202A", TenantId = "00010101-0010" },
            new Tag() { Id = "0202B", TenantId = "00010101-0011" },
            new Tag() { Id = "0202C", TenantId = "00010101-0012" },

            new Tag() { Id = "0301A", TenantId = "00010101-0013" },
            new Tag() { Id = "0301B", TenantId = "00010101-0014" },
            new Tag() { Id = "0301C", TenantId = "00010101-0015" },
            new Tag() { Id = "0301D", TenantId = "00010101-0016" },

            new Tag() { Id = "0302A", TenantId = "00010101-0017" },
            new Tag() { Id = "0302B", TenantId = "00010101-0018" },
            new Tag() { Id = "0302C", TenantId = "00010101-0019" },
            new Tag() { Id = "0302D", TenantId = "00010101-0020" },

            new Tag() { Id = "VAKT01", TenantId = "00010101-0021" },
          };
          context.AddRange(tags);
          #endregion

          #region Add Access
          var accesses = new List<Access>
          {
            new Access() { TagId = "VAKT01", DoorId = "VAKT01" },
            // TODO add more...
          };
          #endregion

          #region Add Logs
          var logs = new List<LogEntry>
          {
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:07:00", "dd-MM-yy HH:mm:ss", null), TagId = "0201C", DoorId = "LGH0201",  EventId = "DÖIN"}, // william erlander tar in tidningen
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:08:00", "dd-MM-yy HH:mm:ss", null), TagId = "0201C", DoorId = "LGH0201",  EventId = "DÖUT"},
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:19:00", "dd-MM-yy HH:mm:ss", null), TagId = "0302A", DoorId = "LGH0302",  EventId = "DÖIN"}, // noah almgren slänger soporna
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:19:00", "dd-MM-yy HH:mm:ss", null), TagId = "0201A", DoorId = "LGH0201",  EventId = "DÖIN"}, // olivia erlander går till jobbet
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:20:00", "dd-MM-yy HH:mm:ss", null), TagId = "0302A", DoorId = "SOPRUM01", EventId = "DÖUT"},
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:20:33", "dd-MM-yy HH:mm:ss", null), TagId = "0201A", DoorId = "UT01",     EventId = "DÖIN"},
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:21:00", "dd-MM-yy HH:mm:ss", null), TagId = "0302A", DoorId = "SOPRUM01", EventId = "DÖIN"},
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:22:00", "dd-MM-yy HH:mm:ss", null), TagId = "0302A", DoorId = "LGH0302",  EventId = "DÖUT"},
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:55:00", "dd-MM-yy HH:mm:ss", null), TagId = "0202A", DoorId = "LGH0202",  EventId = "DÖIN"}, // lucas adolfson hämtar posten
            new LogEntry() { When = DateTime.ParseExact("23-10-20 10:56:00", "dd-MM-yy HH:mm:ss", null), TagId = "0202A", DoorId = "LGH0202",  EventId = "DÖUT"},
            new LogEntry() { When = DateTime.ParseExact("23-10-20 11:03:00", "dd-MM-yy HH:mm:ss", null), TagId = "0301D", DoorId = "LGH0301",  EventId = "DÖIN"}, // maja ahlström hämtar posten
            new LogEntry() { When = DateTime.ParseExact("23-10-20 11:04:00", "dd-MM-yy HH:mm:ss", null), TagId = "0301D", DoorId = "LGH0301",  EventId = "DÖUT"},
            new LogEntry() { When = DateTime.ParseExact("23-10-19 08:19:12", "dd-MM-yy HH:mm:ss", null), TagId = "0101A", DoorId = "BLK0101",  EventId = "DÖIN"}, // liam går ut på altanen
            new LogEntry() { When = DateTime.ParseExact("23-10-19 08:22:45", "dd-MM-yy HH:mm:ss", null), TagId = "0201D", DoorId = "BLK0201",  EventId = "DÖIN"}, // astrid går ut på balkongen
            new LogEntry() { When = DateTime.ParseExact("23-10-19 08:25:09", "dd-MM-yy HH:mm:ss", null), TagId = "0201D", DoorId = "BLK0201",  EventId = "DÖUT"},
            new LogEntry() { When = DateTime.ParseExact("23-10-19 08:27:10", "dd-MM-yy HH:mm:ss", null), TagId = "0101A", DoorId = "BLK0101",  EventId = "DÖUT"},
          };
          context.AddRange(logs);
          #endregion

          context.SaveChanges();
          context.Database.CommitTransaction();
        }
        catch (Exception)
        {
          // Roll back transaction if there's any exception inserting data.
          context.Database.RollbackTransaction();
          return;
        }
      }
    }
  }
}
