using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework_HFAB.Controllers
{
    class Controllers
    {
        public Controllers()
        {
        }

         public List<Database.StaticData> FindEntriesByDoor(string byDoor)
        {
            List<Database.StaticData> findEntriesByDoor = new List<Database.StaticData>();

            //foreach (var item in Database.Seeder.LogEntry)
            //{
            //    if (item.door == byDoor)
            //        findEntriesByDoor.Add(item);
            //}

            return findEntriesByDoor;
        }


        List<Database.StaticData> findEntriesByEvent = new List<Database.StaticData>();

        List<Database.StaticData> findEntriesByLocation = new List<Database.StaticData>();

        List<Database.StaticData> findEntriesByTag = new List<Database.StaticData>();

        List<Database.StaticData> findEntriesByTenant = new List<Database.StaticData>();

        List<Database.StaticData> fistTenantsAt = new List<Database.StaticData>();

    }
}
