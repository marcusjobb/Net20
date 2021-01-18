namespace DoorEventsLogger.Helpers
{
    using DoorEventsLogger.Handler;

    using System.Data;

    public static class TagHelper
    {
        /// <summary>
        /// GetTenantTag.
        /// </summary>
        /// <param name="tenantId">Long<see cref="long"/> med hyresgästens ID.</param>
        /// <returns>En sträng<see cref="string"/> med resultatet.</returns>
        internal static string GetTenantTag(long tenantId)
        {
            DataTable doorId = DBHandler.GetDataTable("SELECT tag From Tenants Where Id = @tenant", "@tenant", tenantId.ToString());
            return doorId.Rows.Count > 0 ? (string)doorId.Rows[0]["tag"] : "(Tag not identified)";
        }

        /// <summary>
        /// FindEntriesByTag.
        /// </summary>
        /// <param name="TenantTag">En sträng<see cref="string"/> med koden till hyresgästens tagg.</param>
        /// <returns>En DataTable<see cref="DataTable"/> med sökresultat.</returns>
        internal static DataTable FindEntriesByTag(string TenantTag, int maxEntries)
        {
            return DBHandler.GetDataTable(Settings.GenericSQLSearch + $"WHERE Tenants.Tag=@tag ORDER BY Date DESC LIMIT {maxEntries}", "@tag", TenantTag);
        }
    }
}