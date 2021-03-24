using System;

namespace Assignment_1_Architecture
{
    public static class InitiateDB
    {
        private static void CheckInput(string[] split, out string tenant, out string location, out string tag, out string door, out string date, out string doorCode)
        {
            // Hämta hyresgästen namn från input
            tenant = split[0].Trim();

            // Hämta lägenhetens benämning från input
            location = split[1].Trim();

            // Hämta taggens benämning från input
            tag = split[2].Trim();

            //Hämta dörrens benämning från input
            door = split[3].Trim();

            // Standarddatum och tid
            date = split[4].Trim();

            doorCode = split[5].Trim();
        }

        public static void CreateDB()
        {
            if (DBHandler.CreateDatabase())
            {
                //Skapar tabeller
                DBHandler.CreateTable("Tenants", "ID INTEGER NOT NULL UNIQUE", "Name TEXT NOT NULL", "Location TEXT NOT NULL", "Tag TEXT NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("Doors", "ID INTEGER NOT NULL UNIQUE", "Door TEXT NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("DoorCodes", "ID INTEGER NOT NULL UNIQUE", "DoorCode TEXT NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("Dates", "ID INTEGER NOT NULL UNIQUE", "Date TEXT NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");
                DBHandler.CreateTable("Events", "ID INTEGER NOT NULL UNIQUE", "DateID TEXT NOT NULL", "DoorID INTEGER NOT NULL", "DoorCodeID INTEGER NOT NULL",
                    "TagID INTEGER NOT NULL", "TenantID INTEGER NOT NULL", @"PRIMARY KEY(""ID"" AUTOINCREMENT)");

                DBHelper.InsertTenant("Liam Jönsson,0101,0101A",
                                    "Elias Pettersson,0102,0102A",
                                    "Wilma Johansson,0102,0102B",
                                    "Alicia Sanchez,0103,0103A",
                                    "Aaron Sanchez,0103,0103B",
                                    "Olivia Erlander,0201,0201A",
                                    "William Erlander,0201,0201B",
                                    "Alexander Erlander,0201,0201C",
                                    "Astrid Erlander,0201,0201D",
                                    "Lucas Adolfsson,0202,0202A",
                                    "Ebba Adolfsson,0202,0202B",
                                    "Lilly Adolfsson,0202,0202C",
                                    "Ella Ahlström,0301,0301A",
                                    "Alma Alfredsson,0301,0301B",
                                    "Elsa Ahlström,0301,0301C",
                                    "Maja Ahlström,0301,0301D",
                                    "Noah Almgren,0302,0302A",
                                    "Adam Andersen,0302,0302B",
                                    "Kattis Backman,0302,0302C",
                                    "Oscar Chen,0302,0302D",
                                    "Vaktmästare,VAKT,VAKT01");

                DBHelper.InsertDoor("LGH0101", "LGH0102", "LGH0103", "LGH0201", "LGH0202", "LGH0301", "LGH0302", "BLK0101", "BLK0102", "BLK0103", "BLK0201",
                    "BLK0202", "BLK0301", "BLK0302", "SOPRUM", "UT", "TVÄTT", "VAKT");

                DBHelper.InsertDoorCode("DÖUT", "DÖIN", "FDIN", "FDUT");

                DBHelper.InsertDate("2020-11-22", "2020-11-23", "2020-11-24", "2020-11-25", "2020-11-26", "2020-11-27", "2020-11-28", "2020-11-29", "2020-11-30",
                    "2020-12-01", "2020-12-02", "2020-12-03", "2020-12-04", "2020-12-05", "2020-12-06", "2020-12-07", "2020-12-08", "2020-12-09", "2020-12-10");

                DBHelper.InsertDoorEvent("2020-11-22 " + RandomTime(), "LGH0101", "DÖUT", "0101A", "Liam Jönsson");
                DBHelper.InsertDoorEvent("2020-11-22 " + RandomTime(), "TVÄTT", "DÖUT", "0102B", "Wilma Johansson");
                DBHelper.InsertDoorEvent("2020-11-23 " + RandomTime(), "UT", "DÖIN", "0301C", "Elsa Ahlström");
                DBHelper.InsertDoorEvent("2020-11-24 " + RandomTime(), "BLK0302", "DÖIN", "0302D", "Oscar Chen");
                DBHelper.InsertDoorEvent("2020-11-25 " + RandomTime(), "LGH0302", "DÖUT", "0302A", "Noah Almgren");
                DBHelper.InsertDoorEvent("2020-11-25 " + RandomTime(), "LGH0301", "DÖIN", "0301D", "Maja Ahlström");
                DBHelper.InsertDoorEvent("2020-11-26 " + RandomTime(), "LGH0302", "DÖUT", "0302B", "Adam Andersen");
                DBHelper.InsertDoorEvent("2020-11-26 " + RandomTime(), "LGH0202", "DÖUT", "0202B", "Ebba Adolfsson");
                DBHelper.InsertDoorEvent("2020-11-27 " + RandomTime(), "LGH0301", "DÖUT", "0301C", "Elsa Ahlström");
                DBHelper.InsertDoorEvent("2020-11-27 " + RandomTime(), "LGH0102", "FDIN", "0101A", "Liam Jönsson");
                DBHelper.InsertDoorEvent("2020-11-28 " + RandomTime(), "BLK0102", "DÖIN", "0102A", "Elias Pettersson");
                DBHelper.InsertDoorEvent("2020-11-28 " + RandomTime(), "LGH0103", "DÖIN", "0103A", "Alicia Sanchez");
                DBHelper.InsertDoorEvent("2020-11-29 " + RandomTime(), "BLK0103", "DÖIN", "0103A", "Alicia Sanchez");
                DBHelper.InsertDoorEvent("2020-11-29 " + RandomTime(), "LGH0103", "DÖUT", "0103A", "Alicia Sanchez");
                DBHelper.InsertDoorEvent("2020-11-30 " + RandomTime(), "SOPRUM", "DÖUT", "0202A", "Lucas Adolfsson");
                DBHelper.InsertDoorEvent("2020-11-30 " + RandomTime(), "SOPRUM", "DÖIN", "0103A", "Alicia Sanchez");
                DBHelper.InsertDoorEvent("2020-12-01 " + RandomTime(), "TVÄTT", "DÖIN", "0301A", "Ella Ahlström");
                DBHelper.InsertDoorEvent("2020-12-01 " + RandomTime(), "LGH0201", "DÖIN", "0201D", "Astrid Erlander");
                DBHelper.InsertDoorEvent("2020-12-01 " + RandomTime(), "LGH0201", "DÖUT", "0201D", "Astrid Erlander");
                DBHelper.InsertDoorEvent("2020-12-02 " + RandomTime(), "LGH0301", "FDIN", "0201B", "William Erlander");
                DBHelper.InsertDoorEvent("2020-12-02 " + RandomTime(), "LGH0302", "FDIN", "0201B", "William Erlander");
                DBHelper.InsertDoorEvent("2020-12-03 " + RandomTime(), "LGH0202", "FDIN", "0201B", "William Erlander");
                DBHelper.InsertDoorEvent("2020-12-03 " + RandomTime(), "LGH0103", "FDIN", "0201B", "William Erlander");
                DBHelper.InsertDoorEvent("2020-12-04 " + RandomTime(), "BLK0202", "DÖUT", "0202C", "Lilly Adolfsson");
                DBHelper.InsertDoorEvent("2020-12-04 " + RandomTime(), "LGH0301", "FDIN", "0102B", "Wilma Johansson");
                DBHelper.InsertDoorEvent("2020-12-04 " + RandomTime(), "LGH0201", "DÖIN", "0201A", "Olivia Erlander");
                DBHelper.InsertDoorEvent("2020-12-05 " + RandomTime(), "LGH0302", "DÖIN", "0302B", "Adam Andersen");
                DBHelper.InsertDoorEvent("2020-12-05 " + RandomTime(), "LGH0201", "DÖUT", "0201A", "Olivia Erlander");
                DBHelper.InsertDoorEvent("2020-12-05 " + RandomTime(), "TVÄTT", "DÖIN", "0201A", "Olivia Erlander");
                DBHelper.InsertDoorEvent("2020-12-05 " + RandomTime(), "TVÄTT", "DÖUT", "0201A", "Olivia Erlander");
                DBHelper.InsertDoorEvent("2020-12-05 " + RandomTime(), "BLK0202", "DÖIN", "0202A", "Lucas Adolfsson");
                DBHelper.InsertDoorEvent("2020-12-06 " + RandomTime(), "BLK0202", "DÖUT", "0202A", "Lucas Adolfsson");
                DBHelper.InsertDoorEvent("2020-12-06 " + RandomTime(), "LGH0202", "DÖUT", "0202A", "Lucas Adolfsson");
                DBHelper.InsertDoorEvent("2020-12-06 " + RandomTime(), "LGH0202", "DÖIN", "0202A", "Lucas Adolfsson");
                DBHelper.InsertDoorEvent("2020-12-06 " + RandomTime(), "TVÄTT", "DÖIN", "0103B", "Aaron Sanchez");
                DBHelper.InsertDoorEvent("2020-12-06 " + RandomTime(), "LGH0302", "DÖUT", "0302C", "Kattis Backman");
                DBHelper.InsertDoorEvent("2020-12-06 " + RandomTime(), "SOPRUM", "DÖIN", "0302C", "Kattis Backman");
                DBHelper.InsertDoorEvent("2020-12-06 " + RandomTime(), "SOPRUM", "DÖUT", "0302C", "Kattis Backman");
                DBHelper.InsertDoorEvent("2020-12-07 " + RandomTime(), "BLK0302", "DÖUT", "0302C", "Kattis Backman");
                DBHelper.InsertDoorEvent("2020-12-07 " + RandomTime(), "LGH0302", "DÖUT", "0302D", "Oscar Chen");
                DBHelper.InsertDoorEvent("2020-12-07 " + RandomTime(), "UT", "DÖUT", "0302D", "Oscar Chen");
                DBHelper.InsertDoorEvent("2020-12-07 " + RandomTime(), "UT", "DÖUT", "0301C", "Elsa Ahlström");
                DBHelper.InsertDoorEvent("2020-12-08 " + RandomTime(), "UT", "DÖIN", "0201C", "Alexander Erlander");
                DBHelper.InsertDoorEvent("2020-12-08 " + RandomTime(), "LGH0201", "DÖIN", "0201C", "Alexander Erlander");
                DBHelper.InsertDoorEvent("2020-12-09 " + RandomTime(), "UT", "DÖIN", "0201D", "Astrid Erlander");
                DBHelper.InsertDoorEvent("2020-12-09 " + RandomTime(), "UT", "DÖUT", "0201C", "Astrid Erlander");
                DBHelper.InsertDoorEvent("2020-12-09 " + RandomTime(), "LGH0301", "DÖIN", "0301D", "Maja Ahlström");
                DBHelper.InsertDoorEvent("2020-12-09 " + RandomTime(), "UT", "DÖIN", "VAKT01", "Vaktmästare");
                DBHelper.InsertDoorEvent("2020-12-09 " + RandomTime(), "UT", "DÖUT", "0301B", "Alma Alfredsson");
                DBHelper.InsertDoorEvent("2020-12-10 " + RandomTime(), "LGH0301", "DÖUT", "0301B", "Alma Alfredsson");
                DBHelper.InsertDoorEvent("2020-12-10 " + RandomTime(), "SOPRUM", "DÖUT", "0301B", "Alma Alfredsson");
                DBHelper.InsertDoorEvent("2020-12-10 " + RandomTime(), "BLK0301", "DÖUT", "0301B", "Alma Alfredsson");
            }
        }

        private static string RandomTime()
        {
            int hour = rand.Next(0, 24);
            int min = rand.Next(0, 59);
            int sec = rand.Next(0, 59);

            return $"{hour}:{min}:{sec}";
        }

        private static Random rand = new Random();
    }
}