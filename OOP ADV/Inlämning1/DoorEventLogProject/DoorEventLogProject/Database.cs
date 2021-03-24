using System;
using System.Data.SQLite;

namespace DoorEventLogProject
{
    class Database
    {
        //Creates relevant database tables and their relations
        public static void CreateTables()
        {
            using var conn = new SQLiteConnection("data source=" + Settings.Database);
            try
            {
                conn.Open();

                string sqlstring = @"CREATE TABLE IF NOT EXISTS 'DoorEventTable' (
                                'ID'            INTEGER,
	                            'OpeningDate'   TEXT,
	                            'DoorEventType' TEXT,
                                'DoorID'        TEXT,
                                'TenantID'      TEXT,
                                PRIMARY KEY(""ID"" AUTOINCREMENT)
                            ); ";
                SQLiteCommand cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();

                sqlstring = @"CREATE TABLE IF NOT EXISTS 'DoorLocationTable' (
                                'ID'                INTEGER,
                                'ApartmentNumber'	TEXT,
	                            PRIMARY KEY(""ID"" AUTOINCREMENT)
                            ); ";
                cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();

                sqlstring = @"CREATE TABLE IF NOT EXISTS 'DoorName' (
                                'ID'            INTEGER,
                                'DoorName'      TEXT,
                                PRIMARY KEY(""ID"" AUTOINCREMENT)
                            ); ";
                cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();

                sqlstring = @"CREATE TABLE IF NOT EXISTS 'DoorEvent' (
                                'ID'            INTEGER,
                                'EventCode'     TEXT,
                                PRIMARY KEY (""ID"" AUTOINCREMENT)
                            ); ";
                cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();

                sqlstring = @"CREATE TABLE IF NOT EXISTS 'TenantTable' (
                                'ID'                    INTEGER,
                                'TenantTag'             TEXT,
                                'ApartmentNumber_ID'    TEXT,
                                'FirstName'             TEXT,
	                            'LastName'              TEXT,
	                            PRIMARY KEY(""ID"" AUTOINCREMENT)
                            ); ";
                cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();
            }
            catch (System.StackOverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
