using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace HFAB
{
    internal static class LogSeeder
    {
        public static void GetRandomLogInput()
        {
            Random rnd = new Random();

            List<string> doorList = new List<string>()
            {
                "LGH0101",
                "BLK0101",
                "LGH0102",
                "BLK0102",
                "LGH0103",
                "BLK0103",
                "LGH0201",
                "BLK0201",
                "LGH0202",
                "BLK0202",
                "LGH0301",
                "BLK0301",
                "LGH0302",
                "BLK0302",
                "UT",
                "SOPRUM",
                "TVÄTT",
                "VAKT"
            };

            List<string> eventList = new List<string>()
            {
                "DÖUT",
                "DÖIN",
                "FDIN",
                "FDUT"
            };

            List<string> tagList = new List<string>()
            {
                "0101A",
                "0102A",
                "0102B",
                "0103A",
                "0103B",
                "0201A",
                "0201B",
                "0201C",
                "0201D",
                "0202A",
                "0202B",
                "0202C",
                "0301A",
                "0301B",
                "0301C",
                "0301D",
                "0302A",
                "0302B",
                "0302C",
                "0302D",
                "VAKTO1"
            };

            var year = 2018 + rnd.Next(2);
            var month = rnd.Next(1, 13);
            var day = rnd.Next(1, 28);
            var hour = rnd.Next(1, 23);
            var minute = rnd.Next(1, 59);
            var second = rnd.Next(1, 59);

            var date = new DateTime(year, month, day, hour, minute, second).ToString("yyyy-MM-dd HH:mm:ss");

            string door = doorList[rnd.Next(1, 18)];
            string evnt = eventList[rnd.Next(1, 4)];
            string tag = tagList[rnd.Next(1, 21)];

            //var logs = events.LogEntry("2020-10-23 10:23", "LGH0301", "DÖIN", "0301A")?.Rows;

            const string sql = "INSERT INTO Logs (Date, Door, Event, Tag) VALUES(@date, @door, @evnt, @tag)";

            // Skapa en koppling till databasen
            using var conn = new SQLiteConnection("data source=" + Settings.Database);

            // Öppna kommunikationen
            conn.Open();

            // Skapa ett SQL-kommando
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@door", door);
            cmd.Parameters.AddWithValue("@evnt", evnt);
            cmd.Parameters.AddWithValue("@tag", tag);
            cmd.ExecuteNonQuery();
            // Lägg till standarddata i databasen
        }
    }
}