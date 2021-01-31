namespace Assignment_1_Architecture
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            InitiateDB.CreateDB();
            var byDoor = DoorEventsLog.FindEntriesByDoor("LGH0301");
            var byCode = DoorEventsLog.FindEntriesByEvent("DÖIN");
            var byLocation = DoorEventsLog.FindEntriesByLocation("TVÄTT");
            var byTag = DoorEventsLog.FindEntriesByTag("0201B");
            var byTenant = DoorEventsLog.FindEntriesByTenant("Alexander Erlander");
            var tenants = DoorEventsLog.ListTenantsAt("0201");
            Outputs.Data("Search by door", byDoor);
            Outputs.Data("Search by code", byCode);
            Outputs.Data("Search by location", byLocation);
            Outputs.Data("Search by tenant", byTenant);
            Outputs.Data("Search by tag", byTag);
            Outputs.Tenants(tenants);
        }
    }
}