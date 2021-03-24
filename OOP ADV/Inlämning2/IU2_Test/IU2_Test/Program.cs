namespace IU2_Test
{
    using IU2_Test.Controllers;
    using IU2_Test.Helpers;
    using IU2_Test.Models;

    internal class Program : Helper
    {
        private static void Main(string[] args)
        {
            AddToDB();
            Interfaces.IOutput output = new Output();

            var byDoor = FindEntriesByDoor("LGH");
            var byEvent = FindEntriesByEvent("DÖUT");
            var byLocation = FindEntriesByLocation("TVÄTT");
            var byTag = FindEntriesByTag("0103A");
            var byTenant = FindEntriesByTenant("Alexander Erlander");
            var tenants = ListTenantsAt("0201");

            output.OutputByLocation("Find by location", byLocation);
            output.OutputByEvent("Find by event", byEvent);
            output.OutputByDoor("Find by door", byDoor);
            output.OutputByTag("Find by tag", byTag);
            output.OutputByTenant("Find by Tenant", byTenant);
            output.OutputListTenant(tenants);
        }
    }
}