using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace DatabaseUppg1Albin
{
    // Skapar nytt DataTable och returnerar data.
    public static class Datatable
    {
        private const string database = @".\HusData.db";
        public static DataTable GetDataTable(string sql, params string[] values)
        {
            DataTable data = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(data);
            }
            return data;
        }
    }
}
