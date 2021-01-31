using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace hus_AB
{
    class DoorEventsLog
    {
        //Skriver ut alla entery med dörrena 
        

        public DataTable FindEntriesByDoor(string Door)
        {
            // skapat kod för att hämta information från databasen och returnera en DataTable 


            string sql = (@"SELECT Koppling.Date_Tiden, Doors.Doors, Huset.Tag, Koder.Koder, Huset.Lghnum, Huset.Person, Koder.Förklarning
                            FROM Koppling
                        JOIN Doors on Koppling.Doors = Doors.ID
                        JOIN Huset on Koppling.Tag = Huset.ID
                        JOIN Koder on Koppling.Kod = Koder.ID
                        WHERE Doors.Doors = @Door");

            DataTable data = new DataTable();
            using (var conn = new SQLiteConnection("data source = Husrum_Fastigheter_AB_db.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Door", Door);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(data);
            }
            return data;


        }
        //Skriver ut alla entery by kod 

        public DataTable FindEntriesByEvent(string kod)
        {
            // skapat kod för att hämta information från databasen och returnera en DataTable 

            string sql = (@"SELECT Koppling.Date_Tiden, Doors.Doors, Huset.Tag, Koder.Koder, Huset.Lghnum, Huset.Person, Koder.Förklarning
                            FROM Koppling
                        JOIN Doors on Koppling.Doors = Doors.ID
                        JOIN Huset on Koppling.Tag = Huset.ID
                        JOIN Koder on Koppling.Kod = Koder.ID
                        WHERE Koder.Koder = @kod");
            
            DataTable data = new DataTable();
            using (var conn = new SQLiteConnection("data source = Husrum_Fastigheter_AB_db.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kod", kod);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(data);
            }
            return data;
          
        }
        //Skriver ut alla entery by Location

        public DataTable FindEntriesByLocation(string Location)
        {

            // skapat kod för att hämta information från databasen och returnera en DataTable 
            string sql = (@"SELECT Koppling.Date_Tiden, Doors.Doors, Huset.Tag, Koder.Koder, Huset.Lghnum, Huset.Person, Koder.Förklarning
                            FROM Koppling
                        JOIN Doors on Koppling.Doors = Doors.ID
                        JOIN Huset on Koppling.Tag = Huset.ID
                        JOIN Koder on Koppling.Kod = Koder.ID
                        WHERE Huset.Lghnum = @Location");
            DataTable data = new DataTable();
            using (var conn = new SQLiteConnection("data source = Husrum_Fastigheter_AB_db.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Location", Location);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(data);
            }
            return data;
        }

        //Skriver ut alla entery by Tag
        public DataTable FindEntriesByTag(string Tag)
        {
            // skapat kod för att hämta information från databasen och returnera en DataTable 
            string sql = (@"SELECT Koppling.Date_Tiden, Doors.Doors, Huset.Tag, Koder.Koder, Huset.Lghnum, Huset.Person, Koder.Förklarning
                            FROM Koppling
                        JOIN Doors on Koppling.Doors = Doors.ID
                        JOIN Huset on Koppling.Tag = Huset.ID
                        JOIN Koder on Koppling.Kod = Koder.ID
                        WHERE Huset.Tag = @Tag");
            DataTable data = new DataTable();
            using (var conn = new SQLiteConnection("data source = Husrum_Fastigheter_AB_db.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql,conn);
                cmd.Parameters.AddWithValue("@Tag", Tag);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(data);
            }
                return data;
        }
        //Skriver ut alla entery by Tenant
        public DataTable FindEntriesByTenant(string Tenant)
        {
            // skapat kod för att hämta information från databasen och returnera en DataTable 
            string sql = (@"SELECT Koppling.Date_Tiden, Doors.Doors, Huset.Tag, Koder.Koder, Huset.Lghnum, Huset.Person, Koder.Förklarning
                            FROM Koppling
                        JOIN Doors on Koppling.Doors = Doors.ID
                        JOIN Huset on Koppling.Tag = Huset.ID
                        JOIN Koder on Koppling.Kod = Koder.ID
                        WHERE Huset.Person = @Tenant");
            DataTable data = new DataTable();
            using(var conn = new SQLiteConnection("data source = Husrum_Fastigheter_AB_db.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Tenant", Tenant);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(data);
            }
                return data;
        }

            // Den här metoden ska ta emot information om en logg som ska skapas
        public void LogEntry(string LogEntry, string Data_Time,string Doors, string Tag, string kod)
        {
          string sql=(@"INSERT INTO Koppling ('Date_Tiden', 'Doors','Tag', 'Kod') 
            VALUES ('2020-11-25 10:00'), ('9','12','2')");
            Program.ExecuteSQL(sql);
            DataTable data = new DataTable();
            using (var conn = new SQLiteConnection("data source = Husrum_Fastigheter_AB_db.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Tenant",LogEntry);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(data);
            }
           
        }
        //skriver ut hyresgäster från specifik lägenhet, returnera en dataTable med deras namn och tagg-kod

        public  DataTable ListTenantsAt(string list)
        {
            // skapat kod för att hämta information från databasen och returnera en DataTable 
            string sql = (@"SELECT Huset.Lghnum, Huset.Person, Huset.Tag
                            FROM Huset
                          WHERE Huset.Lghnum = @TenantsAT");
           
            DataTable data = new DataTable();
            using (var conn = new SQLiteConnection("data source = Husrum_Fastigheter_AB_db.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenantsAT", list);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(data);
            }
            return data;
        }
    }

}
