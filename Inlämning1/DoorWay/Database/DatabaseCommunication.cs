using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;

namespace DoorWay
{
    public static class DatabaseCommunication
    {
        /// <summary>
        /// The connection string
        /// </summary>
        static string connectionString =
               ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        static string initialConnectionString =
               ConfigurationManager.ConnectionStrings["InitialConnectionString"].ConnectionString;
        static MySqlConnection initialSqlConnection = new MySqlConnection(initialConnectionString);
        static MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        /// <summary>
        /// Creates the database method.
        /// </summary>
        public static void CreateDatabase()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFo‌​lder.MyDocuments),
            "husrum_fastigheter.db");
            FileInfo file = new FileInfo(filePath);

            if (!file.Exists || file.Length == 0)
            {

                CreateSchema();
                CreateTables();
                Tagg.addData();
                Apartment.addData();
                Tenant.addData();
                Door.addData();
                Event.addData();
            }

        }
        public static void CreateSchema()
        {


            using (var command = new MySqlCommand { Connection = initialSqlConnection })
            {
                // SQL Statement för att skapa schema.
                var sqlQuery =
                     (@"
                       CREATE database IF NOT EXISTS `husrum_fastigheter` DEFAULT CHARACTER SET utf8;"
                     );
                ExecuteCommand(command, sqlQuery);
            }
        }
        /// <summary>
        /// Creates the tables in the database.
        /// </summary>
        public static void CreateTables()
        {
            using (var command = new MySqlCommand { Connection = mySqlConnection })
            {
                // SQL Statement för att skapa schema och tabeller.
                var sqlQuery =
                 (@"
                   USE husrum_fastigheter;
                 
                   CREATE TABLE IF NOT EXISTS `husrum_fastigheter`. `apartments` (
                      `apartment_id` varchar(16) PRIMARY KEY,
                      `apartment_name` varchar(255) Null
                    );
                    
                    CREATE TABLE `husrum_fastigheter`.`taggs` (
                      `tagg_id` varchar(255) PRIMARY KEY
                    );
                    
                    CREATE TABLE `husrum_fastigheter`.`tenants` (
                      `tenant_id` int PRIMARY KEY auto_increment,
                      `tenant_first_name` varchar(255),
                      `tenant_last_name` varchar(255),
                      `tagg_id` varchar(255),
                      `apartment_id` varchar(16)
                    );

                    CREATE TABLE `husrum_fastigheter`.`doors` (
                      `door_id` varchar(16) PRIMARY KEY,
                      `door_name` varchar(255)
                    );
                    CREATE TABLE `husrum_fastigheter`.`events` (
                      `event_id` int PRIMARY KEY auto_increment,
                      `event_cod` varchar(16),
                      `date_of_events` varchar(16),
                      `door_id` varchar(16),
                      `tagg_id` varchar(255),
                      `events_description` varchar(255)
                    );
                    
                    
                 
                    ALTER TABLE `tenants` ADD FOREIGN KEY (`apartment_id`) 
                         REFERENCES `apartments` (`apartment_id`);
                    
                    ALTER TABLE `tenants` ADD FOREIGN KEY (`tagg_id`) 
                         REFERENCES `taggs` (`tagg_id`);
                    
                                             
                    ALTER TABLE `events` ADD FOREIGN KEY (`door_id`) 
                         REFERENCES `doors` (`door_id`);
                    
                    ALTER TABLE `events` ADD FOREIGN KEY (`tagg_id`) 
                         REFERENCES `taggs` (`tagg_id`);
               ");
                ExecuteCommand(command, sqlQuery);
            }
        }
        /// <summary>
        /// Adds the tenants data.
        /// </summary>
        /// <param name="tenants">The tenants.</param>
        public static void AddTenants(List<Tenant> tenants)
        {
            using (var command = new MySqlCommand { Connection = mySqlConnection })
            {
                // SQL Statement för att skapa schema och tabeller.
                var sqlQuery =
                     (@"USE husrum_fastigheter;");

                //Adderar sql insert statment till "sqlQuery"
                foreach (var tenant in tenants)
                {
                    sqlQuery += $"insert into `tenants` (`tenant_first_name`, `tenant_last_name`,`tagg_id`,`apartment_id`) values ({tenant.First_name},{tenant.Last_name},{tenant.Tagg_id},{tenant.Apartment_id});";

                }
                ExecuteCommand(command, sqlQuery);
            }


        }
        /// <summary>
        /// Adds the taggs data.
        /// </summary>
        /// <param name="taggs">The taggs.</param>
        public static void AddTaggs(List<Tagg> taggs)
        {
            using (var command = new MySqlCommand { Connection = mySqlConnection })
            {
                var sqlQuery = @"USE husrum_fastigheter;";
                foreach (var tagg in taggs)
                {
                    sqlQuery += $"insert into `taggs` (`tagg_id`) values ({tagg.tagg_id});";
                }
                ExecuteCommand(command, sqlQuery);
            }


        }
        /// <summary>
        /// Adds the apartment.
        /// </summary>
        /// <param name="apartments">The apartments.</param>
        public static void AddApartment(List<Apartment> apartments)
        {
            using (var command = new MySqlCommand { Connection = mySqlConnection })
            {
                // SQL Statement för att skapa schema och tabeller.
                var sqlQuery = (@"USE husrum_fastigheter;");
                //Adderar sql insert statment till "sqlQuery"
                foreach (var apartment in apartments)
                {
                    sqlQuery += $"insert into `apartments` (`apartment_id`,`apartment_name`) values ({apartment.Apartment_id},{apartment.Apartment_name});";
                }
                ExecuteCommand(command, sqlQuery);
            }


        }
        /// <summary>
        /// Adds the events
        /// </summary>
        /// <param name="events"></param>
        public static void AddEvent(List<Event> events)
        {
            using (var command = new MySqlCommand { Connection = mySqlConnection })
            {
                // SQL Statement för att skapa schema och tabeller.
                var sqlQuery =
                     (@"USE husrum_fastigheter;");

                //Adderar sql insert statment till "sqlQuery" 
                foreach (var Event in events)
                {
                    sqlQuery += $"insert into `events` (`event_cod`,`date_of_events`,`door_id`,`tagg_id`,`events_description`) values ({Event.Event_cod},{Event.Date_of_Events},{Event.Door_id},{Event.Tagg_id},{Event.Events_description});";
                }
                ExecuteCommand(command, sqlQuery);
            }

        }
        /// <summary>
        /// Adds the doors
        /// </summary>
        /// <param name="doors"></param>
        public static void AddDoor(List<Door> doors)
        {
            using (var command = new MySqlCommand { Connection = mySqlConnection })
            {
                // SQL Statement för att skapa schema och tabeller.
                var sqlQuery =
                     (@"USE husrum_fastigheter;");

                //Adderar sql insert statment till "sqlQuery"
                foreach (var Door in doors)
                {
                    sqlQuery += $"insert into `doors` (`door_id`) values ({Door.Door_id});";
                }
                ExecuteCommand(command, sqlQuery);
            }

        }

        /// <summary>
        /// Executes the MySqlCommands.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="sqlQuery">The SQL query.</param>
        public static void ExecuteCommand(MySqlCommand command, string sqlQuery)
        {
            command.Connection.Open();
            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            mySqlConnection.Close();
        }



    }
}
