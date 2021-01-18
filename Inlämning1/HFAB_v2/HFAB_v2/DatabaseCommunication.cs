using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace HFAB_v2
{
    class DatabaseCommunication
    {
        public static void ExecuteSQL(string sql, params string[] values)
        {
            using (var sqlite2 = new SQLiteConnection("data source=" + CreateDatabase.database))
            {
                sqlite2.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, sqlite2);
                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i+1]);
                }
                cmd.ExecuteNonQuery();
            }
        }
        public static DataTable GetDataTable(string sql, params string[] values)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("data source=" + CreateDatabase.database))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                for (int i = 0; i < values.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(values[i], values[i + 1]);
                }

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
