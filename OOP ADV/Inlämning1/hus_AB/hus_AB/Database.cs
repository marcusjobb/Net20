using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace hus_AB
{
    class Database
    {
        // skapat databaes med alla table 
        public static void creatdatabes()
        {
            if (!File.Exists("Husrum_Fastigheter_AB_db.db"))
            {
                SQLiteConnection.CreateFile("Husrum_Fastigheter_AB_db.db");

                //la till alla table id om det inte finns
                using (var conn = new SQLiteConnection("data source = Husrum_Fastigheter_AB_db.db"))
                {
                    conn.Open();
                    string sql;
                   
                    //add Doors Tabel
                    sql = @"CREATE TABLE IF NOT EXISTS'Doors'(" +
                        "'ID'    INTEGER NOT NULL," +
                        "'Lghnum'   INTEGER," +
                        "'Doors'  TEXT NOT NULL," +
                       "PRIMARY KEY('ID' AUTOINCREMENT));";

                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    //add Person Tabel
                    sql = @"CREATE TABLE IF NOT EXISTS 'Huset'(" +
                            "'ID'    INTEGER NOT NULL," +
                             "'Lghnum'   INTEGER NOT NULL," +
                            "'Person'    TEXT NOT NULL," +
                            "'Tag'    TEXT NOT NULL," +
                            "PRIMARY KEY('ID' AUTOINCREMENT));";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    //add kod tabel
                    sql = @"CREATE TABLE IF NOT EXISTS 'Koder'(" +
                        "'ID'    INTEGER NOT NULL UNIQUE," +
                        "'Koder'   TEXT," +
                        "'Förklarning'   TEXT," +
                        "PRIMARY KEY('ID' AUTOINCREMENT));";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    //add koppling tabel
                    sql = @"CREATE TABLE IF NOT EXISTS 'Koppling'(" +
                   "'ID'    INTEGER NOT NULL UNIQUE," +
                   "'Date_Tiden'    TEXT," +
                   "'Doors'  INTEGER NOT NULL," +
                   "'Tag'  INTEGER NOT NULL," +
                   "'Kod'   INTEGER NOT NULL," +
                   "PRIMARY KEY('ID' AUTOINCREMENT));";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    //skriv in alla dörrar
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('1', '0101', 'BLK0101');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('2', '0102', 'BLK0102');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('3', '0103', 'BLK0103');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('4', '0201', 'BLK0201');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('5', '0202', 'BLK0202');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('6', '0301', 'BLK0301');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('7', '0302', 'BLK0302');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('8', 'VAKTRUM', 'VAKTRUM');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('9', 'TVÄTTRUM', 'TVÄTT');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Doors ('ID', 'Lghnum', 'Doors') VALUES ('10', 'SOPPRUM', 'SOPP');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    //skriv in alla personamn och Lghnummer
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('1', '0101', 'Liam Jönsson','0101A');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('2', '0102', 'Elias Petterson ','0102A');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('3', '0102', 'Wilma Johansson','0102B');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('4', '0103', 'Alicia Sanchez','0103A');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('5', '0103', 'Aaron Sanchez','0103B');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('6', '0201', 'Olivia Erlander','0201A');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('7', '0201', 'William Erlander','0201B');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('8', '0201', 'Alexander Erlander','0201C');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('9', '0201', 'Astrid Erlander','0201D');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('10', '0202', 'Lucas Adolfsson','0202A');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('11', '0202', 'Ebba Adolfsson','0202B');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('12', '0202', 'Lilly Adolfsson','0202C');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('13', '0301', 'Ella Ahlström','0301A');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('14', '0301', 'Alma Alfredsson','0301B');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('15', '0301', 'Elsa Ahlström','0301C');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('16', '0301', 'Maja Ahlström','0301D');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('17', '0302', 'Noah Almgren','0302A');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('18', '0302', 'Adam Andersen','0302B');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('19', '0302', 'Kattis Backman','0302C');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('20', '0302', 'Oscar Chen','0302D');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Huset ('ID', 'Lghnum', 'Person','Tag') VALUES ('21', 'VAKT', 'Vaktmästare ','VAKT01');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    //skriv in alla koder
                    sql = (@"INSERT INTO Koder  ('ID', 'Koder', 'Förklarning') VALUES ('1', 'DÖIN', 'Doors har öppnats inifrån');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koder  ('ID', 'Koder', 'Förklarning') VALUES ('2', 'DÖUT', 'Doors har öppnats UTifrån');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koder  ('ID', 'Koder', 'Förklarning') VALUES ('3', 'FDIN', 'Fel Doors utan tillstånd');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koder  ('ID', 'Koder', 'Förklarning') VALUES ('4', 'FDUT', 'Fel Doors taggen inte tillåter');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    //kopplat ihop allt
                    sql = (@"INSERT INTO Koppling ('Date_Tiden', 'Doors','Tag', 'Kod') VALUES ('2020-11-28 20:00', '1','2','1');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koppling ('Date_Tiden', 'Doors','Tag', 'Kod') VALUES ('2020-11-28 19:00', '1','2','1');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koppling ('Date_Tiden', 'Doors','Tag', 'Kod') VALUES ('2020-11-28 22:00', '5','3','2');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koppling ('Date_Tiden', 'Doors','Tag', 'Kod') VALUES ('2020-11-29 23:00', '4','4','2');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koppling ('Date_Tiden', 'Doors','Tag', 'Kod') VALUES ('2020-11-27 13:00', '2','6','1');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koppling ('Date_Tiden', 'Doors','Tag', 'Kod') VALUES ('2020-11-30 14:00', '3','10','2');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koppling ('Date_Tiden', 'Doors','Tag', 'Kod') VALUES ('2020-11-25 11:00', '8','1','4');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    sql = (@"INSERT INTO Koppling ('Date_Tiden', 'Doors','Tag', 'Kod') VALUES ('2020-11-25 10:00', '9','12','2');");
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
