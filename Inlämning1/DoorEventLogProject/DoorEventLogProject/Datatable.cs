using System.Data;
using System.Data.SQLite;

namespace DoorEventLogProject
{
    class Datatable
    {
        //Retrieve data from database
        public static DataTable DataTable(string sql, string values)
        {

            using SQLiteConnection conn = new SQLiteConnection("data source=" + Settings.Database);
            using var cmd = new SQLiteCommand(sql, conn);
            var dt = new DataTable();

            conn.Open();

            cmd.Parameters.AddWithValue("@values", values);

            using var da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
