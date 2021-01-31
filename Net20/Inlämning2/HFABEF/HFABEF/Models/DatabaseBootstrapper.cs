using System.Linq;

namespace HFABEF.Models
{
    public static class DatabaseBootstrapper
    {
        /// <summary>
        /// Metod som kollar ifall alla tabeller är tomma när programmet startar. Och tillkallar metoderna som fyller på data till tabellerna ifall svaret är ja.
        /// </summary>
        public static void CheckTables()
        {
            using var db = new Database.MyDatabase();

            if (!db.Door_Explanation.Any() && !db.Doors.Any() && !db.Event.Any() && !db.Logs.Any() && !db.Tenants.Any() && !db.Tenants_Info.Any())
            {
                Helper.Seeder.TablesInsert();
                Helper.Seeder.LogsInsert();
            }
        }
    }
}
