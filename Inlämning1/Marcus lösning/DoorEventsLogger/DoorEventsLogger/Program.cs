namespace DoorEventsLogger
{
    using DoorEventsLogger.Helpers;

    using System;
    using System.Data;

    /// <summary>
    /// Definition av <see cref="Program" />.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Skapar en sträng av Datarown som skickas in.
        /// </summary>
        /// <param name="row">En datarow som ska läsas av<see cref="DataRow"/>.</param>
        /// <returns>Sträng<see cref="string"/> med information från datarown<see cref="DataRow"/>.</returns>
        private static string DoText(DataRow row)
        {
            string ev = row["event"].ToString();
            string what = ev.StartsWith("FD") ? "försökte öppna" : "öppnade";
            string where = ev.EndsWith("IN") ? "inifrån" : "utifrån";
            return row["Tenant"] + $" {what} dörr till {row["Location"]} {where}";
        }

        /// <summary>
        /// Main metoden.
        /// </summary>
        private static void Main()
        {
            DoorEventsLogHelper.InitDB();
            Console.WriteLine("DoorEventLog Demo");

            var tenantId = DoorEventsGenerator.GetRandomTenant();
            var location = DoorEventsGenerator.GetRandomLocation();
            var eventCode = DoorEventsGenerator.GetRandomEventCode();
            var eventDate = DateTime.Now.ToString(Settings.DateTimeFormat);
            var tag = TagHelper.GetTenantTag(tenantId);
            DoorEventsLog.LogEntry(eventDate, location, eventCode, tag);

            var byDoor = DoorEventsLog.FindEntriesByDoor("LGH0302")?.Rows;
            var byEvent = DoorEventsLog.FindEntriesByEvent("DÖIN")?.Rows;
            var byLocation = DoorEventsLog.FindEntriesByLocation("TVÄTT")?.Rows;
            var byTenant = DoorEventsLog.FindEntriesByTag("0102A")?.Rows;
            var byTag = DoorEventsLog.FindEntriesByTenant("Alexander Erlander")?.Rows;
            var tenants = DoorEventsLog.ListTenantsAt("0201")?.Rows;
            OutputData("Search by event code", byEvent);
            OutputData("Search by location", byLocation);
            OutputData("Search by door", byDoor);
            OutputData("Search by Tenant", byTenant);
            OutputData("Search by tag", byTag);
            OutputTenants(tenants);
        }

        /// <summary>
        /// Skriver ut information från Datarown som skickats in.
        /// </summary>
        /// <param name="title">Titeln som ska skrivas ut<see cref="string"/>.</param>
        /// <param name="datarow">En dataRow<see cref="DataRowCollection"/> som ska skrivas ut.</param>
        private static void OutputData(string title, DataRowCollection datarow)
        {
            Console.WriteLine(title);
            foreach (DataRow r in datarow)
            {
                Console.WriteLine($"{r["Date"]},{r["Door"]},{r["Event"]},{r["Tag"]},{r["Tenant"]},{DoText(r)}");
            }
        }

        /// <summary>
        /// Skriver ut hyrsgästernas namn från DataRown.
        /// </summary>
        /// <param name="tenants">En Datarow<see cref="DataRowCollection"/> med namn som ska skrivas ut.</param>
        private static void OutputTenants(DataRowCollection tenants)
        {
            Console.WriteLine("Tenants");
            foreach (DataRow r in tenants) { Console.WriteLine($"{r["Location"]} {r["Tag"]} {r["Tenant"]}"); }
        }
    }
}