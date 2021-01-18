using System.Data.SQLite;
using System.IO;

namespace DoorEventLogProject
{
    class Create
    {
        //Initiate and create database file if not existing already
        public static bool DatabaseFile()
        {
            FileInfo fi = new FileInfo(Settings.Database);

            if(!fi.Exists || fi.Length == 0)
            {
                SQLiteConnection.CreateFile(Settings.Database);
                Database.CreateTables();
                InsertData.BuildingAndTenantData();
                InsertData.EventLogData();
                return true;
            }
            return false;
        }
    }
}