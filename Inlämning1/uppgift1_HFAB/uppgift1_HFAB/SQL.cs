using System;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace uppgift1_HFAB
{
    public class Database
    {
        public static void CreateDatabase()
        {
            if (!File.Exists("database.db"))
            {
                SQLiteConnection.CreateFile("database.db");
            }
            using (var con = new SQLiteConnection("data source = database.db"))
            {
                con.Open();
                var cmd = new SQLiteCommand();
                string sql;

                //---------------------------------------------------------------------------------\\
                sql = @"CREATE TABLE IF NOT EXISTS 'Koppling'(" +
                             "'ID'    INTEGER NOT NULL UNIQUE," +
                             "'Date'  TEXT NOT NULL," +
                             "'PersonID'  INTEGER NOT NULL," +
                             "'DoorID'    INTEGER NOT NULL," +
                             "'EventID'   INTEGER NOT NULL," +
                             "PRIMARY KEY('ID' AUTOINCREMENT))";

                cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();

                //---------------------------------------------------------------------------------\\
                sql = @"CREATE TABLE IF NOT EXISTS 'Door'(" +
                         "'ID'    INTEGER NOT NULL UNIQUE," +
                         "'Name'  TEXT NOT NULL," +
                         "PRIMARY KEY('ID' AUTOINCREMENT))";

                cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();

                //---------------------------------------------------------------------------------\\
                sql = @"CREATE TABLE IF NOT EXISTS 'Event'(" +
                                 "'ID'    INTEGER NOT NULL," +
                                 "'Name'  TEXT NOT NULL," +
                                 "PRIMARY KEY('ID' AUTOINCREMENT))";

                cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();

                //---------------------------------------------------------------------------------\\
                sql = @"CREATE TABLE IF NOT EXISTS 'Personer'(" +
                             "'ID'    INTEGER NOT NULL UNIQUE," +
                             "'firstname' TEXT NOT NULL," +
                             "'lastname'  TEXT NOT NULL," +
                             "'Tagg'  TEXT NOT NULL," +
                             "'Lägenhetsnummer'   TEXT NOT NULL," +
                             "PRIMARY KEY('ID' AUTOINCREMENT))";

                cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();

                SQL.SkapatPersoner();
                SQL.AddingToKoppling();
                SQL.AddingToDoor();
                SQL.AddingToEvent();
            }
        }
    }
    public static class SQL
    {

        /// <summary>
        /// Här skapas databasen om den inte finns och döps till "database.db".
        /// Har även lagt in metoderna som skapar de olika tabeller.
        /// //------\\ <---- Använder jag för att lättare dela upp koden (för nya kodare)
        /// </summary>
        

        /// <summary>
        /// Här skapas personerna i Databasen.
        /// </summary>
        public static void SkapatPersoner()
        {
            using (var con = new SQLiteConnection("data source = database.db"))
            {
                con.Open();
                string checkers = @"SELECT ID FROM Personer";
                var data = GetDataTable(checkers, "");
                if (data.Rows.Count < 1)
                {


                    string sql = @"INSERT INTO Personer (ID, firstname, lastname, Tagg, Lägenhetsnummer) VALUES
                                                               ('1', 'Liam', 'Jönsson', '0101A', '0101'),
                                                               ('2', 'Elias', 'Petterson', '0102A', '0102'),
                                                               ('3', 'Wilma', 'Johansson', '0102B', '0102'),
                                                               ('4', 'Alicia', 'Sanchez', '0103A', '0103'),
                                                               ('5', 'Aaron', 'Sanchez', '0103B', '0103'),
                                                               ('6', 'Olivia', 'Erlander', '0201A', '0201'),
                                                               ('7', 'William', 'Erlander', '0201B', '0201'),
                                                               ('8', 'Alexander', 'Erlander', '0201C', '0201'),
                                                               ('9', 'Astrid', 'Erlander', '0201D', '0201'),
                                                               ('10', 'Lucas', 'Adolfsson', '0202A', '0202'),
                                                               ('11', 'Ebba', 'Adolfsson', '0202B', '0202'),
                                                               ('12', 'Lilly', 'Adolfsson', '0202C', '0202'),
                                                               ('13', 'Ella', 'Ahlström', '0301A', '0301'),
                                                               ('14', 'Alma', 'Alfredsson', '0301B', '0301'),
                                                               ('15', 'Elsa', 'Ahlström', '0301C', '0301'),
                                                               ('16', 'Maja', 'Ahlström', '0301D', '0301'),
                                                               ('17', 'Noah', 'Almgren', '0302A', '0302'),
                                                               ('18', 'Adam', 'Andersen', '0302B', '0302'), 
                                                               ('19', 'Kattis', 'Backman', '0302C', '0302'), 
                                                               ('20', 'Oscar', 'Chen', '0302D', '0302'),
                                                               ('21', 'Vaktmästare', '', 'VAKT01', 'VAKT')";

                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// Här är databasens kopplings tabell. 
        /// Från vänster, Första = PersonID, DoorID, EventID(Dörr händelse), Date.
        /// </summary>
        public static void AddingToKoppling()
        {
            using (var con = new SQLiteConnection("data source = database.db"))
            {
                con.Open();
                string checkers = @"SELECT ID FROM Koppling";
                var data = GetDataTable(checkers, "");
                if (data.Rows.Count < 1)
                {
                    var sql = @"INSERT INTO Koppling ('PersonID', 'DoorID', 'EventID', 'Date') VALUES 
                                                 ('1', '1', '2', '2020-12-04 - 16:15'),
                                                 ('5', '7', '3', '2020-12-05 - 03:42'), 
                                                 ('2', '3', '2', '2020-11-28 - 18:32'), 
                                                 ('2', '5', '1', '2020-11-28 - 18:35'), 
                                                 ('3', '2', '1', '2020-11-29 - 12:53'), 
                                                 ('4', '6', '1', '2020-11-30 - 15:00'), 
                                                 ('6', '1', '2', '2020-12-02 - 16:32'),
                                                 ('7', '1', '2', '2020-12-02 - 16:33'),
                                                 ('8', '6', '2', '2020-12-03 - 18:00'),
                                                 ('9', '6', '1', '2020-12-03 - 18:00'),
                                                 ('10', '5', '1', '2020-12-03 - 19:22'),
                                                 ('21', '3', '2', '2020-12-04 - 11:14')";

                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        /// <summary>
        /// Har gjort testdata för databasen.
        /// </summary>
        public static void TestData()
        {
            // SQL.CreateDatabase skapar databasen åt nya användare.
            Database.CreateDatabase();
            string sql =

            @"SELECT ID FROM Koppling";

            var dataTable = GetDataTable(sql, "");
            if (dataTable.Rows.Count < 1)
            {
                Input("2020-12-04 - 16:15", "LGH0101A", "DÖUT", "0101A");
                Input("2020-12-05 - 03:42", "VAKT", "FDIN", "0103B");
                Input("2020-11-28 - 18:32", "SOPRUMIN", "DÖIN", "0102A");
                Input("2020-11-28 - 18:35", "SOPRUMUT", "DÖUT", "0102A");
                Input("2020-11-29 - 12:53", "BLK", "DÖUT", "0102B");
                Input("2020-11-30 - 15:00", "TVÄTT", "DÖUT", "0103B");
                Input("2020-12-02 - 16:32", "LGH0201", "DÖIN", "0201A");
                Input("2020-12-02 - 16:33", "LGH0201", "DÖIN", "0201B");
                Input("2020-12-03 - 18:00", "TVÄTT", "DÖIN", "0201C");
                Input("2020-12-03 - 18:00", "TVÄTT", "DÖUT", "0201D");
                Input("2020-12-03 - 19:22", "SOPRUMUT", "DÖUT", "0202A");
            }
            Console.Clear();
        }

        public static void AddingToDoor()
        {
            using (var con = new SQLiteConnection("data source = database.db"))
            {
                con.Open();
                string checkers = @"SELECT ID FROM Door";
                var data = GetDataTable(checkers, "");
                if (data.Rows.Count < 1)
                {
                    var sql = @"INSERT INTO Door ('ID', 'Name') VALUES 
                                             ('1', 'LGH'),
                                             ('2', 'BLK'),
                                             ('3', 'SOPRUM_IN'),
                                             ('4', 'UT'),
                                             ('5', 'SOPRUM_UT'),
                                             ('6', 'TVÄTT'),
                                             ('7', 'VAKT')";

                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public static void AddingToEvent()
        {
            using (var con = new SQLiteConnection("data source = database.db"))
            {
                con.Open();
                string checkers = @"SELECT ID FROM Event";
                var data = GetDataTable(checkers, "");
                if (data.Rows.Count < 1)
                {
                    var sql = @"INSERT INTO Event ('ID', 'Name') VALUES
                                              ('1', 'DÖUT'),
                                              ('2', 'DÖIN'),
                                              ('3', 'FDIN'),
                                              ('4', 'FDUT')";


                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        /// <summary>
        /// Datan läggs in i Kopplings tabellen.
        /// </summary>
        /// <param name="door">Dörr</param>
        /// <param name="tag">Tagg</param>
        /// <param name="events">Händelse</param>
        /// <param name="date">Datum</param>
        public static void Input(string door, string tag, string events, string date)
        {
            
            string sql;
            try
            {
                sql = @"INSERT INTO Koppling(Date, PersonID, DoorID, EventID) 
                        VALUES(@date, 
                        (SELECT ID From Door WHERE @door = Door.Name), 
                        (SELECT ID From Event WHERE @event = Event.Name), 
                        (SELECT ID FROM Personer WHERE @tagg = Personer.Tagg))";

                using (SQLiteConnection con = new SQLiteConnection("data source = database.db"))
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@door", door);
                        cmd.Parameters.AddWithValue("@event", events);
                        cmd.Parameters.AddWithValue("@tagg", tag);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exceptionOps)
            {
                Console.WriteLine(exceptionOps);
            }
            Console.Clear();
        }
        /// <summary>
        /// Information ifrån databasen.
        /// </summary>
        /// <param name="sql">SQL kod i sträng.</param>
        /// <param name="where">@where i SQL koden.</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, string where)
        {
            using (SQLiteConnection con = new SQLiteConnection("data source = database.db"))
            {
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    var data = new DataTable();
                    con.Open();
                    cmd.Parameters.AddWithValue("@where", where);

                    using (var adapt = new SQLiteDataAdapter(cmd))
                    {
                        adapt.Fill(data);
                        return data;
                    }
                }
            }
        }
    }
}

