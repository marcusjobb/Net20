using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApartmentDB
{
    class Database
    {

       
        public const string DatabaseLocation = @".\ApartmentDatabase.db";

        public static void ExecuteSQL(string sql, params string[] values)
        {
            // Skapa en koppling till databasen
            using (var sqlite2 = new SQLiteConnection("data source=" + DatabaseLocation))
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

        public static DataTable GetDataTable(string sql, params string[] values)
        {
            var data = new DataTable();
            using (var conn = new SQLiteConnection("data source=" + DatabaseLocation))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);

                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }

                var da = new SQLiteDataAdapter(cmd);
                da.Fill(data);
            }
            return data;
        }

        public static void CreateDatabase()
        {
            // Hämta filinfo
            FileInfo fi = new FileInfo(DatabaseLocation);

            // Kontrollera att databasfilen finns eller om den är tom
            if (!fi.Exists || fi.Length == 0)
            {
                // Om databasfilen inte finns, skapa en
                SQLiteConnection.CreateFile(DatabaseLocation);
                System.Diagnostics.Debug.WriteLine("Skapade en databas");

                // Skapa tabeller



                ExecuteSQL(@"CREATE TABLE ""Apartments""(""ID"" INTEGER UNIQUE, ""Apartmentnumber"" TEXT, ""IDDoor"" INTEGER, PRIMARY KEY(""ID"")); ");
                ExecuteSQL(@"CREATE TABLE ""Tenants""(""ID"" INTEGER UNIQUE, ""Name"" TEXT, ""IDTag"" INTEGER, ""IDApartment"" INTEGER, PRIMARY KEY(""ID"")); ");
                ExecuteSQL(@"CREATE TABLE ""Tags""(""ID"" INTEGER NOT NULL UNIQUE, ""Tag"" TEXT, ""IDTenant"" INTEGER, ""IDApartment"" INTEGER, PRIMARY KEY(""ID"")); ");
                ExecuteSQL(@"CREATE TABLE ""Doors""(""ID"" INTEGER NOT NULL UNIQUE, ""Door"" TEXT NOT NULL, ""Explanation"" TEXT NOT NULL, ""Apartment ID"" INTEGER NOT NULL, PRIMARY KEY(""ID"")); ");
                ExecuteSQL(@"CREATE TABLE ""Actions""(""ID"" INTEGER NOT NULL UNIQUE, ""Action"" TEXT, PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Codes""(""ID"" INTEGER NOT NULL UNIQUE, ""Code"" TEXT , ""Explanation"" TEXT NOT NULL, PRIMARY KEY(""ID"")); ");
                ExecuteSQL(@"CREATE TABLE ""Events""(""ID"" INTEGER NOT NULL UNIQUE,""Time"" Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,""IDTag"" INTEGER NOT NULL,""IDAction"" INTEGER NOT NULL,""IDDoor"" INTEGER NOT NULL,""IDCode"" INTEGER NOT NULL,PRIMARY KEY(""ID"" AUTOINCREMENT)); ");


                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('1','0101','1');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('2','0102','3');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('3','0103','5');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('4','0201','7');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('5','0202','9');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('6','0301','11');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('7','0302','13');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('8','Janitor','18');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('9','Laundryroom','17');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('10','Garbageroom','16');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('11','Entrance','15');");

                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('1','Liam Jönsson','1','1');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('2','Elias Petterson','2','2');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('3','Wilma Johansson','3','2');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('4','Alicia Sanchez','4','3');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('5','Aaron Sanchez','5','3');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('6','Olivia Erlander','6','4');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('7','William Erlander','7','4');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('8','Alexander Erlander','8','4');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('9','Astrid Erlander','9','4');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('10','Lucas Adolfsson','10','5');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('11','Ebba Adolfsson','11','5');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('12','Lilly Adolfsson','12','5');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('13','Ella Ahlström','13','6');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('14','Alma Alfredsson','14','6');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('15','Elsa Ahlström','15','6');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('16','Maja Ahlström','16','6');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('17','Noah Almgren','17','7');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('18','Adam Andersen','18','7');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('19','Kattis Backman','19','7');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('20','Oscar Chen','20','7');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('21','Janitor','21','8');");

                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('1','0101A','1','1');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('2','0102A','2','2');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('3','0102B','3','2');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('4','0103A','4','3');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('5','0103B','5','3');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('6','0201A','6','4');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('7','0201B','7','4');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('8','0201C','8','4');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('9','0201D','9','4');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('10','0202A','10','5');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('11','0202B','11','5');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('12','0202C','12','5');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('13','0301A','13','6');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('14','0301B','14','6');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('15','0301C','15','6');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('16','0301D','16','6');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('17','0302A','17','7');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('18','0302B','18','7');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('19','0302C','19','7');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('20','0302D','20','7');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('21','VAKT01','21','8');");

                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('1','0101LGH','Door to apartment','1');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('2','0101BLK','Door to balcony','1');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('3','0102LGH','Door to apartment','2');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('4','0102BLK','Door to balcony','2');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('5','0103LGH','Door to apartment','3');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('6','0103BLK','Door to balcony','3');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('7','0201LGH','Door to apartment','4');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('8','0201BLK','Door to balcony','4');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('9','0202LGH','Door to apartment','5');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('10','0202BLK','Door to balcony','5');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('11','0301LGH','Door to apartment','6');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('12','0301BLK','Door to balcony','6');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('13','0302LGH','Door to apartment','7');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('14','0302BLK','Door to balcony','7');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('15','Entrance','Door to street','11');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('16','Garbage','Door to garbage room','10');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('17','Laundry','Door to laundry room','9');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explanation"", ""Apartment ID"") VALUES ('18','Janitor','Door to janitor','8');");

                ExecuteSQL(@"INSERT INTO Actions (""ID"", ""Action"") VALUES ('1','Opened');");
                ExecuteSQL(@"INSERT INTO Actions (""ID"", ""Action"") VALUES ('2','FailedToOpen');");

                ExecuteSQL(@"INSERT INTO Codes (""ID"", ""Code"",""Explanation"") VALUES ('1','DI','door in');");
                ExecuteSQL(@"INSERT INTO Codes (""ID"", ""Code"",""Explanation"") VALUES ('2','DO','door out');");
                ExecuteSQL(@"INSERT INTO Codes (""ID"", ""Code"",""Explanation"") VALUES ('3','WDI','wrong door in');");
                ExecuteSQL(@"INSERT INTO Codes (""ID"", ""Code"",""Explanation"") VALUES ('4','WDO','wrong door out');");



                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 09:21:51','3','1','15','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 10:10:04','2','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 10:11:43','2','1','3','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 10:33:04','5','1','5','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 10:34:00','5','1','15','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 11:01:01','4','1','5','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 11:02:30','4','1','16','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 11:03:15','4','1','16','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 11:04:47','4','1','5','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 11:44:02','3','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 11:45:03','3','1','3','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 13:42:13','14','1','11','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 13:43:05','14','1','15','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 13:55:22','14','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 13:57:04','14','2','1','3');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 13:58:16','14','1','11','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 14:00:04','21','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 14:09:09','21','1','18','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 14:15:33','21','1','18','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 14:17:01','21','1','15','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 14:33:04','6','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 14:34:14','6','1','8','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 14:43:00','18','1','13','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 14:44:28','18','1','15','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 14:58:02','12','1','9','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:01:01','12','1','17','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:04:53','19','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:06:00','19','1','13','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:20:03','12','1','17','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:22:23','12','1','9','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:26:04','19','1','13','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:27:15','19','1','16','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:28:01','19','1','16','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:29:02','19','1','13','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:33:43','1','1','1','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 15:34:58','1','1','15','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:00:01','7','1','7','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:02:04','7','1','16','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:03:09','7','1','16','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:04:57','7','1','15','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:05:45','7','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:06:43','7','1','7','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:09:23','17','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:09:59','17','1','13','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:15:04','13','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:17:02','13','1','11','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:30:03','5','1','5','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:33:06','5','1','16','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:44:55','5','1','16','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:45:59','5','1','5','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:50:50','2','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 16:51:59','2','1','3','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 17:03:11','8','1','7','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 17:05:04','8','1','15','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 17:06:15','8','1','15','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 17:08:00','8','1','7','1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 17:33:01','19','1','13','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 17:34:18','19','1','15','2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"",""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-11-27 17:50:04','19','1','15','1');");




            }
        }


    }




    
}


