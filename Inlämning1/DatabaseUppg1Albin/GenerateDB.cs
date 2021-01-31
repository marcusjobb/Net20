using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DatabaseUppg1Albin
{
    public static class GenerateDB
    {
        // Pplatsen där ett DB bör ligga (ifall det inte gör det gå till rad 75).
        private const string database = @".\HusData.db";

        // Exekverings metoden för att komunicera mellan koden och DBt.
        static void ExecuteSQL(string sql, params string[] values)
        {
            // Skapar en koppling till databasen.
            using (var sqlite2 = new SQLiteConnection("data source=" + database))
            {
                // Öppnar kommunikationen.
                sqlite2.Open();
                // Skapar ett SQL-kommando.
                SQLiteCommand cmd = new SQLiteCommand(sql, sqlite2);
                // Kör SQL-koden.
                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }
                cmd.ExecuteNonQuery();
                // Lägger till standard data i databasen.
            }
        }
        // Ifall databasen inte finns via sökvägen (rad 10) så skapas en ny databas.
        public static void SkapaDB()
        {
            FileInfo fi = new FileInfo(database);
            if (!fi.Exists || fi.Length == 0)
            {
                SQLiteConnection.CreateFile(database);
                System.Diagnostics.Debug.WriteLine("Skapade en databas");

                // Skapar tabeller.
                ExecuteSQL(@"CREATE TABLE ""Apartments"" (""ID"" INTEGER UNIQUE,""Apartmentnumber"" TEXT,""IDDoor"" INTEGER, PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Tenants"" (""ID"" INTEGER UNIQUE,""Name"" TEXT,""IDTag"" INTEGER,""IDApartment"" INTEGER, PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Tags"" (""ID"" INTEGER NOT NULL UNIQUE,""Tag"" TEXT,""IDTenant"" INTEGER,""IDApartment"" INTEGER, PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Doors"" (""ID"" INTEGER NOT NULL UNIQUE,""Door"" TEXT NOT NULL,""Explaination"" TEXT NOT NULL,""IDApartment"" INTEGER, PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Actions"" (""ID"" INTEGER NOT NULL UNIQUE,""Action"" TEXT, PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Codes"" (""ID"" INTEGER NOT NULL UNIQUE,""Code"" TEXT,""Explaination"" TEXT NOT NULL, PRIMARY KEY(""ID""));");
                ExecuteSQL(@"CREATE TABLE ""Events"" (""ID"" INTEGER NOT NULL UNIQUE,""Time"" Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,""IDTag"" INTEGER NOT NULL,""IDAction"" INTEGER NOT NULL,""IDDoor"" INTEGER NOT NULL,""IDCode"" INTEGER NOT NULL, PRIMARY KEY(""ID""));");

                // Alla locations insertade till Apartments tabellen.
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('1', '0101', '1');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('2', '0102', '3');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('3', '0103', '5');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('4', '0201', '7');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('5', '0202', '9');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('6', '0301', '11');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('7', '0302', '13');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('9', 'Ingång/Utgång', '15');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('10', 'Soprum', '16');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('11', 'Tvätt', '17');");
                ExecuteSQL(@"INSERT INTO Apartments (""ID"", ""Apartmentnumber"",""IDDoor"") VALUES ('12', 'Vakt', '18');");

                // Alla hyresgäster insertade till Tenants tabellen.
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('1', 'Liam Jönsson', '1', '1');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('2', 'Elias Petterson', '2', '2');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('3', 'Wilma Johansson', '3', '2');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('4', 'Alicia Sanchez', '4', '3');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('5', 'Aaron Sanchez', '5', '3');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('6', 'Olivia Erlander', '6', '4');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('7', 'William Erlander', '7', '4');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('8', 'Alexander Erlander', '8', '4');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('9', 'Astrid Erlander', '9', '4');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('10', 'Lucas Adolfsson', '10', '5');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('11', 'Ebba Adolfsson', '11', '5');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('12', 'Lilly Adolfsson', '12', '5');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('13', 'Ella Ahlström', '13', '6');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('14', 'Alma Alfredsson', '14', '6');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('15', 'Elsa Ahlström', '15', '6');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('16', 'Maja Ahlström', '16', '6');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('17', 'Noah Almgren', '17', '7');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('18', 'Adam Andersen', '18', '7');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('19', 'Kattis Backman', '19', '7');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('20', 'Oscar Chen', '20', '7');");
                ExecuteSQL(@"INSERT INTO Tenants (""ID"", ""Name"",""IDTag"",""IDApartment"") VALUES ('21', 'Vaktmästare', '21', '8');");

                // Alla taggar insertade till Tags tabellen.
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('1', '0101A', '1', '1');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('2', '0102A', '2', '2');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('3', '0102B', '3', '2');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('4', '0103A', '4', '3');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('5', '0103B', '5', '3');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('6', '0201A', '6', '4');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('7', '0201B', '7', '4');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('8', '0201C', '8', '4');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('9', '0201D', '9', '4');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('10', '0202A', '10', '5');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('11', '0202B', '11', '5');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('12', '0202C', '12', '5');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('13', '0301A', '13', '6');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('14', '0301B', '14', '6');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('15', '0301C', '15', '6');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('16', '0301D', '16', '6');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('17', '0302A', '17', '7');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('18', '0302B', '18', '7');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('19', '0302C', '19', '7');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('20', '0302D', '20', '7');");
                ExecuteSQL(@"INSERT INTO Tags (""ID"", ""Tag"",""IDTenant"",""IDApartment"") VALUES ('21', 'Vakt', '21', '12');");

                // Alla dörrar in/ut insertade till Doors tabellen.
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('1', '0101LGH', 'Dörr till lägenhet', '1');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('2', '0101BLK', 'Dörr till balkong', '1');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('3', '0102LGH', 'Dörr till lägenhet', '2');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('4', '0102BLK', 'Dörr till balkong', '2');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('5', '0103LGH', 'DDörr till lägenhet', '3');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('6', '0103BLK', 'Dörr till balkong', '3');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('7', '0201LGH', 'Dörr till lägenhet', '4');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('8', '0201BLK', 'Dörr till balkong', '4');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('9', '0202LGH', 'Dörr till lägenhet', '5');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('10', '0202BLK', 'Dörr till balkong', '5');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('11', '0301LGH', 'Dörr till lägenhet', '6');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('12', '0301BLK', 'Dörr till balkong', '6');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('13', '0302LGH', 'Dörr till lägenhet', '7');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('14', '0301BLK', 'Dörr till balkong', '6');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('15', 'Ingång/Utgång', 'Dörr ut mot gatan', '18');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('16', 'Soprum', 'Dörr till soprummet', '10');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('17', 'Tvätt', 'Dörr till tvättstuga', '20');");
                ExecuteSQL(@"INSERT INTO Doors (""ID"", ""Door"",""Explaination"",""IDApartment"") VALUES ('18', 'Vakt', 'Dörr till vaktmästarens rum', '21');");

                // De två fallen som kan ske då en dörr försöker öppnas insertade till Actions tabellen.
                ExecuteSQL(@"INSERT INTO Actions (""ID"", ""Action"") VALUES ('1', 'opened');");
                ExecuteSQL(@"INSERT INTO Actions (""ID"", ""Action"") VALUES ('2', 'failed');");

                // Meddelandena som kommer med den åtgärden som vidtas, insertade i Codes tabellen.
                ExecuteSQL(@"INSERT INTO Codes (""ID"",""Code"",""Explaination"") VALUES ('1', 'DÖIN', 'Dörr in');");
                ExecuteSQL(@"INSERT INTO Codes (""ID"",""Code"",""Explaination"") VALUES ('2', 'DÖUT', 'Dörr ut');");
                ExecuteSQL(@"INSERT INTO Codes (""ID"",""Code"",""Explaination"") VALUES ('3', 'FDÖIN', 'Fel dörr in');");
                ExecuteSQL(@"INSERT INTO Codes (""ID"",""Code"",""Explaination"") VALUES ('4', 'FDÖUT', 'Fel dörr ut');");

                // Eventlogg som insertas i Events tabellen.
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:45', '1', '1', '1', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:53', '3', '1', '3', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 16:01', '3', '1', '1', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 16:03', '1', '1', '3', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:53', '2', '1', '3', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 17:45', '2', '1', '3', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 10:36', '21', '1', '18', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 10:43', '21', '1', '18', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 07:42', '4', '1', '5', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 07:42', '5', '1', '5', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 16:45', '4', '1', '5', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 16:45', '5', '1', '5', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 09:45', '6', '1', '7', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 09:45', '7', '1', '7', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 09:45', '8', '1', '7', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 09:45', '9', '1', '7', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 13:30', '6', '1', '7', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 13:30', '7', '1', '7', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 13:30', '8', '1', '7', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 13:30', '9', '1', '7', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 10:00', '10', '1', '9', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 10:00', '11', '1', '9', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 10:00', '12', '1', '9', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 11:56', '10', '1', '9', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 11:56', '11', '1', '9', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 14:52', '12', '1', '9', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:01', '13', '1', '11', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:01', '14', '1', '11', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:01', '15', '1', '11', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:01', '16', '1', '11', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 17:52', '13', '1', '11', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 17:52', '14', '1', '11', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 17:52', '15', '1', '11', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 17:52', '16', '1', '11', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:13', '17', '1', '13', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:13', '18', '1', '13', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:13', '19', '1', '13', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 08:13', '20', '1', '13', '1');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 18:14', '17', '1', '13', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 18:14', '18', '1', '13', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 18:14', '19', '1', '13', '2');");
                ExecuteSQL(@"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES ('2020-12-7 18:14', '20', '1', '13', '2');");
            }
        }        
    }
}