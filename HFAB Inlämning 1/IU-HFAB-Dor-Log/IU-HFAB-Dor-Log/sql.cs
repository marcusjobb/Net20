using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace IU_HFAB_Dor_Log
{
    internal static class Sql
    {
        /// <summary>
        /// creat db with all tables
        /// </summary>
        internal static void Create()
        {
            Console.WriteLine("chaking and creating Database");
            if (!File.Exists("HFAB_door_logg.db"))
            {
                SQLiteConnection.CreateFile("HFAB_door_logg.db");
            }
            //adding all tables id they do no exist
            using (var conn = new SQLiteConnection("data source=HFAB_door_logg.db"))
            {
                conn.Open();
                //add Person Tabel
                var sqlstring = @"CREATE TABLE  IF NOT EXISTS 'Person' (
                                            'ID'            INTEGER,
	                                        'FirstName'     TEXT NOT NULL,
	                                        'LastName'      TEXT,
	                                        'Tag'           TEXT UNIQUE,
                                            'appartment'    INTEGER,
	                                        PRIMARY KEY('ID' AUTOINCREMENT)); ";

                var cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //add table for each appartment
                sqlstring = @"CREATE TABLE IF NOT EXISTS 'Location' (
                                            'ID'        INTEGER,
	                                        'Name'      TEXT NOT NULL,
	                                        PRIMARY KEY('ID' AUTOINCREMENT)); ";
                cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();

                //add talbe for all the doors
                sqlstring = @"CREATE TABLE IF NOT EXISTS 'DoorName' (
                                            'ID'        INTEGER,
	                                        'Name'      TEXT NOT NULL,
	                                        PRIMARY KEY('ID' AUTOINCREMENT)); ";
                cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                sqlstring = @"CREATE TABLE IF NOT EXISTS 'Event' (
                                            'ID'        INTEGER,
	                                        'Code'       TEXT NOT NULL,
	                                        PRIMARY KEY('ID' AUTOINCREMENT)); ";
                cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //create the logg table this is comind evry table
                sqlstring = @"CREATE TABLE IF NOT EXISTS'Logg' (
                                            'ID'        INTEGER,
	                                        'Date'      TEXT NOT NULL,
	                                        'DoorID'  INTEGER NOT NULL,
	                                        'EventCodeID' INTEGER NOT NULL,
	                                        'PersonID'    INTEGER NOT NULL,
	                                        PRIMARY KEY('ID' AUTOINCREMENT)); ";
                cmd = new SQLiteCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            InsertStandadVlaueToDatabase();
            Console.WriteLine("Databese Fixed");
            Console.Clear();
        }

        /// <summary>
        /// Insert the standard Values into database
        /// </summary>
        internal static void InsertStandadVlaueToDatabase()
        {
            using (var conn = new SQLiteConnection("data source=HFAB_door_logg.db"))
            {
                conn.Open();
                string queary, checkqueary;
                SQLiteCommand cmd;

                //check id Event tabel have data
                checkqueary = "SELECT ID FROM Event LIMIT 2";
                var dataTable = Select(checkqueary, "");
                if (dataTable.Rows.Count < 1)
                {
                    //inserting door codes
                    queary = "INSERT INTO Event(Code) VALUES('DÖUT'),('DÖIN'),('FDIN'),('FDUT')";
                    cmd = new SQLiteCommand(queary, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                //check if Location have data
                checkqueary = "SELECT id FROM Location LIMIT 2";
                dataTable = Select(checkqueary, "");
                if (dataTable.Rows.Count < 1)
                {
                    //insert all locations/appartments
                    queary = "INSERT INTO Location(Name) VALUES('0101'),('0102'),('0103'),('0201'),('0202'),('0301'),('0302'),('VAKT'),('SOPRUM'),('TVÄTT')";
                    cmd = new SQLiteCommand(queary, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                //check if doorname have data
                checkqueary = "SELECT id FROM DoorName LIMIT 2";
                dataTable = Select(checkqueary, "");
                if (dataTable.Rows.Count < 1)
                {
                    //insert all doorname
                    queary = "INSERT INTO DoorName(Name) VALUES('LGH0101'),('LGH0102'),('LGH0103'),('LGH0201'),('LGH0202'),('LGH0301'),('LGH0302')," +
                                                                "('BLK0101'),('BLK0102'),('BLK0103'),('BLK0201'),('BLK0202'),('BLK0301'),('BLK0302')," +
                                                                "('VAKT'),('SOPRUM'),('TVÄTT'),('UT')";
                    cmd = new SQLiteCommand(queary, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                //check if person have data
                checkqueary = "SELECT id FROM Person LIMIT 2";
                dataTable = Select(checkqueary, "");
                if (dataTable.Rows.Count < 1)
                {
                    //insert all tendnts
                    queary = "INSERT INTO Person(FirstName,LastName,tag,appartment) VALUES('Liam','Jönsson','0101A','0')," +
                                                                                        "('Elias','Petterson','0102A','1'),('Wilma','Johansson','0102B','1')," +
                                                                                        "('Alicia','Sanchez','0103A','2'),('Aaron','Sanchez','0103B','2')," +
                                                                                        "('Olivia','Erlander','0201A','3'),('William','Erlander','0201B','3'),('Alexander','Erlander','0201C','3'),('Astrid','Erlander','0201D','3')," +
                                                                                        "('Lucas','Adolfsson','0202A','4'),('Ebba','Adolfsson','0202B','4'),('Lilly','Adolfsson','0202C','4')," +
                                                                                        "('Ella','Ahlström','0301A','5'),('Alma','Alfredsson','0301B','5'),('Elsa','Ahlström','0301C','5'),('Maja','Ahlström','0301D','5')," +
                                                                                        "('Noah','Almgren','0302A','6'),('Adam','Andersen','0302B','6'),('Kattis','Backman','0302C','6'),('Oscar','Chen','0302D','6')," +
                                                                                        "('Vaktmästare','','VAKT01','7')";
                    using (cmd = new SQLiteCommand(queary, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// insert test data to db
        /// </summary>
        internal static void CreateTestData()
        {
            Console.WriteLine("Creating Test Data");
            //look if data already exist because we dont need to add testdata if it already exist data
            const string queary = "SELECT id FROM Logg LIMIT 2";
            var dataTable = Select(queary, "");
            if (dataTable.Rows.Count < 1)
            {
                InsertData("2020-10-23 10:07", "LGH0201", "DÖIN", "0201B");
                InsertData("2020-10-23 10:08", "LGH0201", "DÖUT", "0201B");
                InsertData("2020-10-23 10:19", "LGH0302", "DÖIN", "0302A");
                InsertData("2020-10-23 10:19", "LGH0201", "DÖIN", "0201A");
                InsertData("2020-10-23 10:20", "SOPRUM", "DÖUT", "0302A");
                InsertData("2020-10-23 10:20", "UT", "DÖIN", "0201A");
                InsertData("2020-10-23 10:21", "SOPRUM", "DÖIN", "0302A");
                InsertData("2020-10-23 10:22", "LGH0201", "DÖUT", "0302A");
                InsertData("2020-10-23 10:55", "LGH0202", "DÖIN", "0202A");
                InsertData("2020-10-23 10:56", "LGH0202", "DÖUT", "0202A");
                InsertData("2020-10-23 10:56", "LGH0301", "DÖIN", "0301B");
                InsertData("2020-10-23 10:56", "LGH0301", "DÖUT", "0301B");
                InsertData("2020-10-23 12:55", "LGH0201", "DÖIN", "0201C");
                InsertData("2020-10-23 12:55", "LGH0201", "DÖIN", "0201A");
                InsertData("2020-10-23 12:58", "TVÄTT", "DÖUT", "0201C");
                InsertData("2020-10-23 12:58", "TVÄTT", "DÖUT", "0201A");
                InsertData("2020-10-23 13:15", "TVÄTT", "DÖIN", "0201C");
                InsertData("2020-10-23 13:15", "TVÄTT", "DÖIN", "0201A");
                InsertData("2020-10-23 13:16", "LGH0102", "DÖIN", "0102A");
                InsertData("2020-10-23 13:17", "UT", "DÖIN", "0201A");
                InsertData("2020-10-23 13:22", "LGH0201", "DÖUT", "0201C");
                InsertData("2020-10-23 13:22", "LGH0102", "DÖUT", "0102A");
            }
            Console.WriteLine("Test data done");
            Console.Clear();
        }

        /// <summary>
        /// Insert into the Log table
        /// </summary>
        /// <param name="date">todo: describe date parameter on InsertData</param>
        /// <param name="door">todo: describe door parameter on InsertData</param>
        /// <param name="code">todo: describe code parameter on InsertData</param>
        /// <param name="tag">todo: describe tag parameter on InsertData</param>
        public static bool InsertData(string date, string door, string code, string tag)
        {
            string queary;
            try
            {
                queary = "INSERT INTO Logg(Date, DoorID, EventCodeID, PersonID)" +
                                "VALUES(@date," +
                                "(SELECT ID From DoorName WHERE @door = DoorName.Name)," +
                                "(SELECT ID From Event WHERE @event = Event.Code)," +
                                "(SELECT ID FROM Person WHERE @tag = Person.Tag))";

                using (SQLiteConnection conn = new SQLiteConnection("data source=HFAB_door_logg.db"))
                {
                    conn.Open();
                    using (var command = new SQLiteCommand(queary, conn))
                    {
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@door", door);
                        command.Parameters.AddWithValue("@event", code);
                        command.Parameters.AddWithValue("@tag", tag);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Get data from DataBase
        /// </summary>
        /// <param name="sqlqueary">the SQL queary strign</param>
        /// <param name="where">where varible for teh sqlstring</param>
        public static DataTable Select(string sqlqueary, string where)
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = HFAB_door_logg.db"))
            {
                using (var cmd = new SQLiteCommand(sqlqueary, conn))
                {
                    var dataTable = new DataTable();
                    conn.Open();
                    cmd.Parameters.AddWithValue("@where", where);
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}