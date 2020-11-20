namespace SimpleDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class Program
    {
        private const string database = @".\MinDatabase.db";
        private static void Main()
        {
            // Steg 1 - Skapa databasen om den inte finns
            SkapaDatabas();

            // Steg 2 - Hämta data
            const string sqlSaga =
                "SELECT Personer.Namn,Händelser.händelse, Objekt.Text, Mottagare.Namn " +
                "FROM Koppling " +
                "JOIN Personer ON Koppling.Person1=Personer.ID " +
                "JOIN Händelser on Koppling.Handling=Händelser.ID " +
                "JOIN Objekt on Koppling.Objekt=Objekt.ID " +
                "LEFT JOIN Personer as Mottagare on Koppling.Person2 = Mottagare.ID";

            var data = GetDataTable(sqlSaga);
            PrintStory(data);

            Console.WriteLine("-----------------------------------------------------------");

            bool stopIt = false;
            while (!stopIt)
            {
                Console.WriteLine("Ange ett namn");
                var namn = Console.ReadLine();
                stopIt = namn?.Length == 0;
                if (!stopIt)
                {
                    var sql = "Select ID from Personer WHERE Namn LIKE @namn";
                    // Kollar om namnet eller liknande finns i databasen
                    data = GetDataTable(sql, "@namn", "%" + namn + "%");
                    if (data.Rows.Count > 0)
                    {
                        // Hämta givna namets sagodel
                        sql = sqlSaga + " WHERE Koppling.Person1=" + data.Rows[0]["ID"].ToString();
                        data = GetDataTable(sql);
                        PrintStory(data);
                    }
                }
            }
        }

        private static void PrintStory(DataTable data)
        {
            if (data != null && data.Rows != null)
            {
                foreach (DataRow item in data.Rows)
                {
                    var person = item["Namn"].ToString();
                    var händelse = item["Händelse"].ToString();
                    var sak = item["Text"].ToString();
                    var mottagare = item["Namn1"].ToString();

                    if (mottagare != "")
                    {
                        mottagare = " till " + mottagare;
                    }
                    else
                    {
                        mottagare = ".";
                    }

                    Console.WriteLine($"{person} {händelse} {sak}{mottagare}");
                }
            }
        }

        private static void SkapaDatabas()
        {
            // Hämta filinfo
            FileInfo fi = new FileInfo(database);

            // Kontrollera att databasfilen finns eller om den är tom
            if (!fi.Exists || fi.Length == 0)
            {
                // Om databasfilen inte finns, skapa en
                SQLiteConnection.CreateFile(database);
                System.Diagnostics.Debug.WriteLine("Skapade en databas");

                // Skapa tabeller
                ExecuteSQL(@"CREATE TABLE ""Personer"" (""ID"" INTEGER NOT NULL,""Namn"" TEXT,PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Händelser"" (""ID"" INTEGER NOT NULL,""Händelse"" TEXT,PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Objekt""  (""ID"" INTEGER NOT NULL, ""Text"" TEXT, PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Koppling"" (""ID"" INTEGER NOT NULL,""Person1"" INTEGER,""Handling"" INTEGER,""Objekt"" INTEGER,""Person2"" INTEGER,PRIMARY KEY(""ID""));");

                ExecuteSQL(@"INSERT INTO Personer (""ID"", ""Namn"") VALUES ('1', 'Johanna');");
                ExecuteSQL(@"INSERT INTO Personer (""ID"", ""Namn"") VALUES ('2', 'Marie');");
                ExecuteSQL(@"INSERT INTO Personer (""ID"", ""Namn"") VALUES ('3', 'Niklas');");
                ExecuteSQL(@"INSERT INTO Personer (""ID"", ""Namn"") VALUES ('4', 'Magnus');");
                ExecuteSQL(@"INSERT INTO Personer (""ID"", ""Namn"") VALUES ('5', 'Peter');");
                ExecuteSQL(@"INSERT INTO Personer (""ID"", ""Namn"") VALUES ('6', 'Marcus');");

                ExecuteSQL(@"INSERT INTO Händelser (""ID"", ""Händelse"") VALUES ('1', 'ger');");
                ExecuteSQL(@"INSERT INTO Händelser (""ID"", ""Händelse"") VALUES ('2', 'tycker om');");
                ExecuteSQL(@"INSERT INTO Händelser (""ID"", ""Händelse"") VALUES ('3', 'handlar');");
                ExecuteSQL(@"INSERT INTO Händelser (""ID"", ""Händelse"") VALUES ('4', 'lägger undan');");
                ExecuteSQL(@"INSERT INTO Händelser (""ID"", ""Händelse"") VALUES ('5', 'äter');");
                ExecuteSQL(@"INSERT INTO Händelser (""ID"", ""Händelse"") VALUES ('6', 'går');");
                ExecuteSQL(@"INSERT INTO Händelser (""ID"", ""Händelse"") VALUES ('7', 'lämnar');");
                ExecuteSQL(@"INSERT INTO Händelser (""ID"", ""Händelse"") VALUES ('8', 'tar hand om');");

                ExecuteSQL(@"INSERT INTO Objekt (""ID"", ""Text"") VALUES ('1', 'ett fint rött äpple');");
                ExecuteSQL(@"INSERT INTO Objekt (""ID"", ""Text"") VALUES ('2', 'en stor gul banan');");
                ExecuteSQL(@"INSERT INTO Objekt (""ID"", ""Text"") VALUES ('3', 'en stor mumsig chokladkaka');");
                ExecuteSQL(@"INSERT INTO Objekt (""ID"", ""Text"") VALUES ('4', 'en söt clementin');");
                ExecuteSQL(@"INSERT INTO Objekt (""ID"", ""Text"") VALUES ('5', 'restaurang');");
                ExecuteSQL(@"INSERT INTO Objekt (""ID"", ""Text"") VALUES ('6', 'en stor muffin');");
                ExecuteSQL(@"INSERT INTO Objekt (""ID"", ""Text"") VALUES ('7', 'shoppinglista');");

                ExecuteSQL(@"INSERT INTO Koppling (""ID"", ""Person1"", ""Handling"", ""Objekt"", ""Person2"") VALUES ('1', '1', '1', '1', '3');");
                ExecuteSQL(@"INSERT INTO Koppling (""ID"", ""Person1"", ""Handling"", ""Objekt"", ""Person2"") VALUES ('2', '3', '2', '1', '');");
                ExecuteSQL(@"INSERT INTO Koppling (""ID"", ""Person1"", ""Handling"", ""Objekt"", ""Person2"") VALUES ('3', '3', '1', '2', '5');");
                ExecuteSQL(@"INSERT INTO Koppling (""ID"", ""Person1"", ""Handling"", ""Objekt"", ""Person2"") VALUES ('4', '5', '3', '3', '');");
                ExecuteSQL(@"INSERT INTO Koppling (""ID"", ""Person1"", ""Handling"", ""Objekt"", ""Person2"") VALUES ('5', '5', '2', '2', '');");
                ExecuteSQL(@"INSERT INTO Koppling (""ID"", ""Person1"", ""Handling"", ""Objekt"", ""Person2"") VALUES ('6', '5', '1', '3', '2');");
            }
        }

        /// <summary>
        /// Executes a SQL string to the database
        /// </summary>
        /// <param name="sql">SQL code string</param>
        /// <param name="values">Values separated by comma e.g  ["@name", "My name"] </param>
        public static void ExecuteSQL(string sql, params string[] values)
        {
            // Skapa en koppling till databasen
            using (var sqlite2 = new SQLiteConnection("data source=" + database))
            {
                // Öppna kommunikationen
                sqlite2.Open();
                // Skapa ett SQL-kommando
                SQLiteCommand cmd = new SQLiteCommand(sql, sqlite2);
                // Kör SQL-koden
                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }
                cmd.ExecuteNonQuery();
                // Lägg till standarddata i databasen
            }
        }

        /// <summary>
        /// Gets a Datatable from the database
        /// </summary>
        /// <param name="sql">SQL code</param>
        /// <param name="values">Values separated by comma e.g  ["@name", "My name"] </param>
        public static DataTable GetDataTable(string sql, params string[] values)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
