using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace ConsoleAppSQL
{
    class SQL
    {
        public const string Database = @".\MinDatabase.db";

        public static void SkapaDatabas() //Skapar databasen

        {
            //Om databas filen är tom eller inte existerar, kommer en ny fil skapas med all info från tabellerna
            FileInfo fi = new FileInfo(Database);

            if (!fi.Exists || fi.Length == 0)
            {
                SQLiteConnection.CreateFile(Database);

                ExecuteSQL(@"CREATE TABLE ""Event""(""ID"" INTEGER,""Kod"" TEXT,""Förklaring"" TEXT)");
                ExecuteSQL(@"INSERT INTO ""Event""(""ID"", ""Kod"", ""Förklaring"") VALUES('1', 'DÖUT', 'Dörr har öppnats utifrån')");
                ExecuteSQL(@"INSERT INTO ""Event""(""ID"", ""Kod"", ""Förklaring"") VALUES('2', 'DÖIN', 'Dörr har öppnats inifrån')");
                ExecuteSQL(@"INSERT INTO ""Event""(""ID"", ""Kod"", ""Förklaring"") VALUES('3', 'FDIN', 'Fel dörr')");
                ExecuteSQL(@"INSERT INTO ""Event""(""ID"", ""Kod"", ""Förklaring"") VALUES('4', 'FDUT', 'Fel dörr')");

                ExecuteSQL(@"CREATE TABLE ""Location""(""ID"" INTEGER, ""Door"" TEXT)");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('1', 'LGH 0101')");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('2', 'LGH 0102')");
                ExecuteSQL(@"INSERT INTO ""Location""(""ID"", ""Door"") VALUES('3', 'LGH 0103')");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('4', 'LGH 0201')");
                ExecuteSQL(@"INSERT INTO ""Location""(""ID"", ""Door"") VALUES('5', 'LGH 0202')");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('6', 'LGH 0301')");
                ExecuteSQL(@"INSERT INTO ""Location""(""ID"", ""Door"") VALUES('7', 'LGH 0302')");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('8', 'BLK 0101')");
                ExecuteSQL(@"INSERT INTO ""Location""(""ID"", ""Door"") VALUES('9', 'BLK 0102')");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('10', 'BLK 0103')");
                ExecuteSQL(@"INSERT INTO ""Location""(""ID"", ""Door"") VALUES('11', 'BLK 0201')");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('12', 'BLK 0202')");
                ExecuteSQL(@"INSERT INTO ""Location""(""ID"", ""Door"") VALUES('13', 'BLK 0301')");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('14', 'BLK 0302')");
                ExecuteSQL(@"INSERT INTO ""Location""(""ID"", ""Door"") VALUES('15', 'UT')");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('16', 'SOPRUM')");
                ExecuteSQL(@"INSERT INTO ""Location""(""ID"", ""Door"") VALUES('17', 'TVÄTT')");
                ExecuteSQL(@"INSERT INTO ""Location"" (""ID"", ""Door"") VALUES('18', 'VAKT')");

                ExecuteSQL(@"CREATE TABLE ""Tenant""(""ID"" INTEGER,""LGHNR"" TEXT, ""PERSON"" TEXT,""TAGG"" TEXT)");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"", ""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0101', 'Liam Jönsson', '0101A')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"", ""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0102', 'Elias Petterson', '0102A')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"", ""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0102', 'Wilma Johansson', '0102B')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"", ""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0103', 'Alicia Sanchez', '0103A')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"", ""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0103', 'Aaron Sanchez ', '0103B')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"", ""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0201', 'Olivia Erlander', '0201A')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"", ""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0201', 'William Erlander', '0201B')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"", ""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0201', 'Alexander Erlander', '0201C')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"", ""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0201', 'Astrid Erlander', '0201D')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0202', 'Lucas Adolfsson', '0202A')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0202', 'Ebba Adolfsson', '0202B')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0202', 'Lilly Adolfsson', '0202C')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0301', 'Ella Ahlström', '0301A')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0301', 'Alma Alfredsson', '0301B')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0301', 'Elsa Ahlström', '0301C')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0301', 'Maja Ahlström', '0301D')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0302', 'Noah Almgren', '0302A')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0302', 'Adam Andersen', '0302B')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0302', 'Kattis Backman', '0302C')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', '0302', 'Oscar Chen', '0302D')");
                ExecuteSQL(@"INSERT INTO ""Tenant""(""ID"",""LGHNR"", ""PERSON"", ""TAGG"") VALUES('1', 'VAKT', 'Vaktmästare', 'VAKT01')");

                ExecuteSQL(@"CREATE TABLE ""Main""(""DatumTid""  TEXT,""Location"" TEXT,""Kod"" TEXT,""Tagg"" TEXT,""Tenant"" TEXT)");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2020-12-06 07 00', 'VAKT', 'FDIN', '0101A', 'Liam Jönsson')");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2020-12-07 15 54', 'LGH 0102', 'DÖIN', '0102B', 'Wilma Johansson')");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2020-12-23 09 06', 'LGH 0301', 'DÖUT', '0301A', 'Ella Ahlström')");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2021-01-02 14 54', 'LGH 0302', 'DÖUT', '0302C', 'Kattis Backman')");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2021-01-02 13 46', 'LGH 0202', 'DÖUT', '0202C', 'Lilly Adolfsson')");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2021-01-04 17 09', 'LGH 0102', 'DÖIN', '0102A', 'Elias Petterson')");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2021-01-06 14 52', 'LGH 0202', 'FDIN', '0201D', 'Astrid Erlander')");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2021-01-07 17 32', 'LGH 0202', 'DÖIN', '0202A', 'Lucas Adolfsson')");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2021-01-08 13 21', 'LGH 0302', 'DÖUT', '0302A', 'Noah Almgren')");
                ExecuteSQL(@"INSERT INTO ""Main""(""DatumTid"", ""Location"", ""Kod"", ""Tagg"", ""Tenant"") VALUES('2021-02-08 22 49', 'LGH 0103', 'FDIN', '0201C', 'Alexander Erlander')");

            }

        }
        public static void ExecuteSQL(string sql, params string[] values)
        {
            //Koppling till databas
            using (var sqlite2 = new SQLiteConnection("data source=" + "MinDatabase.db"))
            {
                
                sqlite2.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, sqlite2);
                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }
                cmd.ExecuteNonQuery();
            }
        }

    }
}