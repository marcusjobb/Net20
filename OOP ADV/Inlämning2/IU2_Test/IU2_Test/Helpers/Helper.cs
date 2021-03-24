namespace IU2_Test.Helpers
{
    using IU2_Test.Database;
    using IU2_Test.Controllers;
    using System;

    public class Helper : DoorEventsLog
    {
        /// <summary>
        /// Hämtar data från,
        /// DoorEventsLog.cs och Seeder.cs med dess parametrar.
        /// </summary>
        public static void AddToDB()
        {
            Seeder.AddTenantsToDatabase();
            Seeder.AddDoorType();
            Seeder.AddEvents();
            Seeder.AddRelations();
            MoveTenant("0102B");
            MoveTenant("0102A");
            AddTenant("Alice Olsson","0102C");
            AddTenant("Lucas Olsson", "0102D");
            LogEntry(DateTime.Now.ToString("yyyy-MM-dd hh:mm"), "tag", "door", "event");
        }
    }
}
