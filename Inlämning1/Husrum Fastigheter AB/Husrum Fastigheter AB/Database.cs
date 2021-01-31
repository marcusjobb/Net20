using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Husrum_Fastigheter_AB
{
    class Database
    {
        public void SQL_Execution (string query, string[] values)
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"data source= .\House.db"))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                for (int i = 0; i < values.Length; i += 2)
                {
                    command.Parameters.AddWithValue(values[i], values[i + 1]);
                }
                command.ExecuteNonQuery();
            }
        }
        public void SQL_Execution (string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(@"data source= .\House.db"))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public DataTable Data_Fetcher (string query, string[] values)
        {
            DataTable DataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(@"data source= .\House.db"))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                for (int i = 0; i < values.Length; i += 2)
                {
                    command.Parameters.AddWithValue(values[i], values[i + 1]);
                }
                SQLiteDataAdapter DataAdapter = new SQLiteDataAdapter(command);
                DataAdapter.Fill(DataTable);
            }
            return DataTable;
        }
    }
}
