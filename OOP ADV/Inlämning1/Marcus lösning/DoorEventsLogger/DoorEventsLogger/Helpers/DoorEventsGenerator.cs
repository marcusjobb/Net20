namespace DoorEventsLogger.Helpers
{
    using DoorEventsLogger.Handler;

    using System;
    using System.Data;

    /// <summary>
    /// Definition av <see cref="DoorEventsGenerator" />.
    /// </summary>
    public static class DoorEventsGenerator
    {
        /// <summary>
        /// Definition av CurrentTime..
        /// </summary>
        private static DateTime CurrentTime;

        /// <summary>
        /// CreateEvents.
        /// </summary>
        internal static void CreateEvents()
        {
            DataTable tenants = DBHandler.GetDataTable("SELECT Tenants.Id, Name, Tag, Location FROM Tenants JOIN Locations ON Locations.Id = LocationId WHERE (NAME NOT LIKE 'Vaktmästare' AND NAME NOT LIKE 'Lilly Adolfsson')");
            if (tenants?.Rows.Count > 0)
            {
                foreach (DataRow item in tenants.Rows)
                {
                    bool hasBike = GetRandomProbability();
                    bool takesBikeToWork = GetRandomProbability();
                    bool morningWashing = GetRandomProbability();
                    bool breakfastShopping = GetRandomProbability();
                    bool eveningWashing = GetRandomProbability();
                    bool morningTrash = GetRandomProbability();
                    bool eveningTrash = GetRandomProbability();
                    bool visitSuper = GetRandomProbability();
                    bool goesToWork = GetRandomProbability();
                    long tenantId = (long)item["Id"];
                    string home = item["Location"].ToString();

                    GetStartTime(5);

                    Console.Write($"{item["Name"]} ");

                    if (breakfastShopping)
                    {
                        // Går ut och handlar frukost
                        Console.WriteLine("Buying breakfast");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime());
                        if (hasBike)
                        {
                            // Tar cykeln
                            Console.WriteLine("Takes the bike");
                            LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("CYKELRUM"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                            LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("CYKELRUM"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: 2));
                        }
                        // Lämnar huset
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("UT"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: 1));
                        Console.WriteLine("Leaves the house");

                        // Kommer tillbaka
                        Console.WriteLine("Comes back");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("UT"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: -1));
                        if (hasBike)
                        {
                            // Ställer in cykeln
                            Console.WriteLine("Puts back the bike");
                            LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("CYKELRUM"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                            LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("CYKELRUM"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: 2));
                        }
                        // Går hem igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                    }

                    if (morningWashing)
                    {
                        // Går ut till tvättstugan
                        Console.WriteLine("Morning laundry");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime());
                        // Går in
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("TVÄTT"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        // Stannar en stund
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("TVÄTT"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: -1));
                        // Går hem igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        GetTime(addMinutes: 45);
                        // Går ut till tvättstugan igen
                        Console.WriteLine("Back to the laundry");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime());
                        // Går in
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("TVÄTT"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        // Stannar en stund
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("TVÄTT"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: -1));
                        // Går hem igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                    }

                    if (morningTrash)
                    {
                        // Går ut till soprummet
                        Console.WriteLine("Throwing out some trash");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime());
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("SOPRUM"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("SOPRUM"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: 1));
                        // Går hem igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                    }

                    if (visitSuper)
                    {
                        // Går ut till vaktmästaren
                        Console.WriteLine("Visits the super");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime());
                        if (GetRandomProbability())
                        {
                            Console.WriteLine("Tries to open the door to the super");
                            LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("VAKT"), EventHelper.GetEventCodeId("FDUT"), GetTime(addMinutes: 1));
                        }

                        long superId = TenantHelper.GetTenantId("Vaktmästare");

                        // Vaktmästaren öppnar dörren inifrån
                        Console.WriteLine("Knocks on the door and the super opens it");
                        LogHelper.CreateLog(superId, DoorHelper.GetDoorId("VAKT"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: 1));
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("VAKT"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: -1));
                        // Går hem igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        DateTime oldTime = CurrentTime;
                        GetTime(addHours: Settings.Rnd.Next(1, 4));
                        GetTime(addMinutes: -1);
                        Console.WriteLine("The super goes to fix the problem at the tenants home");
                        LogHelper.CreateLog(superId, DoorHelper.GetDoorId("VAKT"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        LogHelper.CreateLog(superId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        LogHelper.CreateLog(superId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: -1));
                        LogHelper.CreateLog(superId, DoorHelper.GetDoorId("VAKT"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: 1));
                        CurrentTime = oldTime;
                    }

                    if (goesToWork)
                    {
                        // Går ut till soprummet
                        Console.WriteLine("Goes to work");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime());
                        if (hasBike && takesBikeToWork)
                        {
                            // Ställer in cykeln
                            Console.WriteLine("Takes the bike to work");
                            LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("CYKELRUM"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                            LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("CYKELRUM"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: 2));
                        }
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("UT"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));

                        Console.WriteLine("Comes back from work");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("UT"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addHours: 8, addMinutes: 1));
                        if (hasBike && takesBikeToWork)
                        {
                            // Ställer in cykeln
                            Console.WriteLine("Returns the bike");
                            LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("CYKELRUM"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                            LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("CYKELRUM"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: 2));
                        }
                        // Går hem igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                    }

                    if (CurrentTime.Hour < 18)
                    {
                        CurrentTime = CurrentTime.AddHours(19 - CurrentTime.Hour);
                    }

                    if (eveningWashing)
                    {
                        // Går ut till tvättstugan
                        Console.WriteLine("Doing some laundry");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime());
                        // Går in
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("TVÄTT"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        // Stannar en stund
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("TVÄTT"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: -1));
                        // Går hem igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        GetTime(addMinutes: 45);
                        // Går ut till tvättstugan igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime());
                        // Går in
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("TVÄTT"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        // Stannar en stund
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("TVÄTT"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: -1));
                        // Går hem igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                    }

                    if (eveningTrash)
                    {
                        // Går ut till soprummet
                        Console.WriteLine("Discarding some trash");
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖIN"), GetTime());
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("SOPRUM"), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("SOPRUM"), EventHelper.GetEventCodeId("DÖIN"), GetTime(addMinutes: 1));
                        // Går hem igen
                        LogHelper.CreateLog(tenantId, DoorHelper.GetDoorId("LGH" + home), EventHelper.GetEventCodeId("DÖUT"), GetTime(addMinutes: 1));
                    }
                }
            }
        }

        internal static string GetRandomEventCode()
        {
            DataTable locationId = DBHandler.GetDataTable("SELECT * FROM EventCodes ORDER BY random() LIMIT 1");
            return locationId.Rows.Count > 0 ? (string)locationId.Rows[0]["Code"] : "DÖUT";
        }

        internal static string GetRandomLocation()
        {
            DataTable locationId = DBHandler.GetDataTable("SELECT * FROM Locations ORDER BY random() LIMIT 1");
            return locationId.Rows.Count > 0 ? (string)locationId.Rows[0]["Location"] : "TVÄTT";
        }

        internal static long GetRandomTenant()
        {
            DataTable locationId = DBHandler.GetDataTable("SELECT * FROM Tenants ORDER BY random() LIMIT 1");
            return locationId.Rows.Count > 0 ? (long)locationId.Rows[0]["Id"] : -1;
        }

        /// <summary>
        /// GetRandomProbability.
        /// </summary>
        /// <returns>Parameter av typen <see cref="bool"/>.</returns>
        private static bool GetRandomProbability()
        {
            return Settings.Rnd.Next(1, 10) > 7;
        }

        /// <summary>
        /// GetStartTime.
        /// </summary>
        /// <param name="startHour">Parameter av typen startHour<see cref="int"/>.</param>
        /// <returns>En sträng<see cref="string"/> med resultatet.</returns>
        private static string GetStartTime(int startHour)
        {
            int hour = startHour + Settings.Rnd.Next(0, 5);
            int minute = Settings.Rnd.Next(0, 12) * 5;
            DateTime now = DateTime.Now;
            CurrentTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, 2);
            return GetTime();
        }

        /// <summary>
        /// GetTime.
        /// </summary>
        /// <param name="addHours">Parameter av typen addHours<see cref="int"/>.</param>
        /// <param name="addMinutes">Parameter av typen addMinutes<see cref="int"/>.</param>
        /// <returns>En sträng<see cref="string"/> med resultatet.</returns>
        private static string GetTime(int addHours = 0, int addMinutes = 0)
        {
            if (addMinutes == -1)
            {
                addMinutes = Settings.Rnd.Next(1, 50);
            }

            CurrentTime = CurrentTime.AddMinutes(addMinutes).AddHours(addHours);
            return CurrentTime.ToString(Settings.DateTimeFormat);
        }
    }
}