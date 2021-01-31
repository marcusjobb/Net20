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
    class DoorEventsLog
    {

        public int MaxEntries { get; set; }
        /// <summary>
        /// Finds the entries by door.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public static DataTable FindEntriesByDoor(string door)
        {

            string connectionString =
              ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            //Sök de senaste loggar från en viss dörr, returnera en DataTable 

            var sqlQuery =
                     (@"
                      use husrum_fastigheter;
                      SELECT date_of_events, door_id,apartment_id, event_cod, tenants.tagg_id, tenant_first_name, tenant_last_name
                      FROM husrum_fastigheter.events
                      join tenants 
                      on events.tagg_id = tenants.tagg_id
                        where door_id = @door_id;
                    ");
            DataTable datatable = new DataTable();

            mySqlConnection.Open();
            using (var command = new MySqlCommand(sqlQuery, mySqlConnection))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                command.Parameters.AddWithValue("@door_id", door);

                adapter.Fill(datatable);
            }
            return datatable;

        }
        /// <summary>
        /// Finds the entries by event.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public static DataTable FindEntriesByEvent(string Event)
        {
            
            string connectionString =
              ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            var sqlQuery =
                     (@"
                      use husrum_fastigheter;
                      SELECT date_of_events, door_id,apartment_id, event_cod, tenants.tagg_id, tenant_first_name, tenant_last_name
                      FROM husrum_fastigheter.events
                      join tenants 
                      on events.tagg_id = tenants.tagg_id
                      where event_cod = @event_cod;
                    ");
            DataTable datatable = new DataTable();

            mySqlConnection.Open();
            using (var command = new MySqlCommand(sqlQuery, mySqlConnection))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                command.Parameters.AddWithValue("@event_cod", Event);

                adapter.Fill(datatable);
            }
            return datatable;

        }
        /// <summary>
        /// Finds the entries by location.
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable FindEntriesByLocation(string Location)
        {
            string connectionString =
               ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            //Sök de senaste loggar från en viss dörr, returnera en DataTable 

            var sqlQuery =
                     (@"
                      use husrum_fastigheter;
                      SELECT date_of_events, door_id,apartment_id, event_cod, tenants.tagg_id, tenant_first_name, tenant_last_name
                      FROM husrum_fastigheter.events
                      join tenants 
                      on events.tagg_id = tenants.tagg_id
                      where events.door_id = @door_location;
                    ");
            DataTable datatable = new DataTable();

            mySqlConnection.Open();
            using (var command = new MySqlCommand(sqlQuery, mySqlConnection))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                command.Parameters.AddWithValue("@door_location", Location);

                adapter.Fill(datatable);
            }
            return datatable;
        }
        /// <summary>
        /// Finds the entries by tag.
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable FindEntriesByTag(string Tagg)
        {
            string connectionString =
               ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            //Sök de senaste loggar från en viss dörr, returnera en DataTable 

            var sqlQuery =
                     (@"
                      use husrum_fastigheter;
                      SELECT date_of_events, door_id,apartment_id, event_cod, tenants.tagg_id, tenant_first_name, tenant_last_name
                      FROM husrum_fastigheter.events
                      join tenants 
                      on events.tagg_id = tenants.tagg_id
                        where events.tagg_id = @tagg_id;
                    ");
            DataTable datatable = new DataTable();

            mySqlConnection.Open();
            using (var command = new MySqlCommand(sqlQuery, mySqlConnection))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                command.Parameters.AddWithValue("@tagg_id", Tagg);

                adapter.Fill(datatable);
            }
            return datatable;
        }
        /// <summary>
        /// Finds the entries by tenant.
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable FindEntriesByTenant(string Tenant)
        {

            string connectionString =
                  ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            var sqlQuery =
                     (@"
                      use husrum_fastigheter;
                      SELECT date_of_events, door_id,apartment_id, event_cod, tenants.tagg_id, tenant_first_name, tenant_last_name
                      FROM husrum_fastigheter.events
                      join tenants 
                      on events.tagg_id = tenants.tagg_id
                      where tenant_first_name = @tenant1 and tenant_last_name = @tenant2;
                    ");
            DataTable datatable = new DataTable();

            mySqlConnection.Open();
            using (var command = new MySqlCommand(sqlQuery, mySqlConnection))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                var name = Tenant.Split(' ');
                command.Parameters.AddWithValue("@tenant1", name[0]);
                command.Parameters.AddWithValue("@tenant2", name[1]);

                adapter.Fill(datatable);
            }
            return datatable;
        }
        /// <summary>
        /// Lists the tenants at.
        /// </summary>
        public static DataTable ListTenantsAt(string SpApartme)
        {
            //Söker hyresgäster från specifik lägenhet, listar upp deras namn och tagg-kod ListTenantsAt("0201")
            string connectionString =
              ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);


            var sqlQuery =
                     (@"
                      USE husrum_fastigheter;
                      SELECT tenant_first_name, tenant_last_name, tagg_id
                      FROM husrum_fastigheter.tenants
                      join apartments
                      on tenants.apartment_id = apartments.apartment_id
                      where apartments.apartment_id = @apartment;
                    ");
            DataTable datatable = new DataTable();

            mySqlConnection.Open();
            using (var command = new MySqlCommand(sqlQuery, mySqlConnection))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                command.Parameters.AddWithValue("@apartment", SpApartme);

                adapter.Fill(datatable);
            }
            return datatable;
        }
        /// <summary>
        /// Logs the entry, savs the serch in textform.
        /// </summary>
        public static void LogEntry(string title, DataTable dataTable)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFo‌​lder.MyDocuments),
            "Log" + DateTime.Now.ToString(", dd-MM-yyyy") + ".txt");

            StreamWriter LogFile = new StreamWriter(filePath, true);
            
            dataTable.Columns.Add();
            
            
            int i;
            
            LogFile.Write(Environment.NewLine);
            LogFile.WriteLine("Date - location - events_code - tagg_id \n");
            foreach (DataRow row in dataTable.Rows)
            {
                
                object[] datarow = row.ItemArray;
                for (i = 0; i < datarow.Length - 4; i++)
                {
                    LogFile.Write(datarow[i].ToString() + " - ");
                }
                LogFile.WriteLine(datarow[i].ToString());
            }
            LogFile.Write("------------------------------------------------"+
                         "\nEND OF DATA, Serch date was " + DateTime.Now.ToString()
                       +"\n------------------------------------------------");
            LogFile.Flush();
            LogFile.Close();


        }

    }
}
