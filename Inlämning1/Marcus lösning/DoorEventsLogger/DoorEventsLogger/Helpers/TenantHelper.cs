namespace DoorEventsLogger.Helpers
{
    using DoorEventsLogger.Handler;

    using System.Data;

    public static class TenantHelper
    {
        /// <summary>
        /// FindEntriesByTenant.
        /// </summary>
        /// <param name="Tenant">En sträng<see cref="string"/> med namnet på en hyresgäst.</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        internal static DataTable FindEntriesByTenant(string Tenant, int maxEntries)
        {
            return DBHandler.GetDataTable(Settings.GenericSQLSearch + $"WHERE Tenants.Name=@tenant ORDER BY Date DESC LIMIT {maxEntries}", "@tenant", Tenant);
        }

        /// <summary>
        /// ListTenantsAt.
        /// </summary>
        /// <param name="location">En sträng<see cref="string"/> med lägenhetsnummer.</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        internal static DataTable ListTenantsAt(string location, int maxEntries)
        {
            return DBHandler.GetDataTable($"SELECT Name as Tenant, Locations.Location, Tag FROM Tenants JOIN Locations ON Tenants.LocationId=Locations.Id WHERE Locations.Location=@location LIMIT {maxEntries}", "@location", location);
        }

        /// <summary>
        /// GetTenantId.
        /// </summary>
        /// <param name="tenant">En sträng<see cref="string"/> med hyresgästens namn.</param>
        /// <returns>Ett ID av typen long<see cref="long"/>.</returns>
        internal static long GetTenantId(string tenant)
        {
            DataTable doorId = DBHandler.GetDataTable("SELECT Id From Tenants Where Name = @tenant", "@tenant", tenant);
            return doorId.Rows.Count > 0 ? (long)doorId.Rows[0]["Id"] : -1;
        }

        /// <summary>
        /// GetTenantId.
        /// </summary>
        /// <param name="tag">En sträng<see cref="string"/> med taggens id.</param>
        /// <returns>Ett ID av typen long<see cref="long"/>.</returns>
        internal static long GetTenantByTagId(string tag)
        {
            DataTable tenant = DBHandler.GetDataTable("SELECT Id From Tenants Where tag = @tag", "@tag", tag);
            return tenant.Rows.Count > 0 ? (long)tenant.Rows[0]["Id"] : -1;
        }

        /// <summary>
        /// GetTenantName.
        /// </summary>
        /// <param name="tenantId">Long<see cref="long"/> med hyresgästens ID.</param>
        /// <returns>En sträng<see cref="string"/> med resultatet.</returns>
        internal static string GetTenantName(long tenantId)
        {
            DataTable doorId = DBHandler.GetDataTable("SELECT name From Tenants Where Id = @tenant", "@tenant", tenantId.ToString());
            return doorId.Rows.Count > 0 ? (string)doorId.Rows[0]["Name"] : "(Tenant not identified)";
        }
    }
}