using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Data;
using System.IO;

namespace HFAB_v2
{
    class CreateDatabase
    {
        public const string database = @".\HFAB.db";
        public static void CreateMainDatabase()
        {
            //Create database
            SQLiteConnection.CreateFile(database);

            //Create tables
            DatabaseCommunication.ExecuteSQL("CREATE TABLE Tenants (ID INTEGER NOT NULL UNIQUE, Tenant TEXT NOT NULL, Location TEXT, Tag TEXT UNIQUE, PRIMARY KEY(ID AUTOINCREMENT))");
            DatabaseCommunication.ExecuteSQL("CREATE TABLE Event (ID INTEGER NOT NULL UNIQUE, Event TEXT, PRIMARY KEY(ID AUTOINCREMENT))");
            DatabaseCommunication.ExecuteSQL("CREATE TABLE Door (ID INTEGER NOT NULL UNIQUE, Door TEXT NOT NULL, Location TEXT, PRIMARY KEY(ID AUTOINCREMENT))");
            DatabaseCommunication.ExecuteSQL("CREATE TABLE LogEntry (ID INTEGER NOT NULL UNIQUE, Date TEXT, Door TEXT, Tag TEXT, Event TEXT, PRIMARY KEY(ID AUTOINCREMENT))");

        }
    }

}
