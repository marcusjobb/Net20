using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseUppg1Albin
{
    public static class FindEntry
    {
        /*
         * public / private  = hur metoden kan nås av andra utanför classen
         * static = classen behöver inte instansieras för att köra metoden
         * string / void / int mm  = vad man får tillbaka när man kallar på metoden
         * TaggId = metodens namn
         * (string something, string something more) = input till metoden
         */

        public static string TaggID(string input)
        {
            string sql = @"SELECT * FROM Tags WHERE Tag LIKE @input";
            var data = Datatable.GetDataTable(sql, "@input", input.Trim());
            
            // Steg 1 - kolla om data är null
            if (data != null && data.Rows != null)
            {
                // steg 2 - Kolla om data.rows är större än 0 (i så fall har du fått datarader)
                if (data.Rows.Count>0)
                {
                    // steg 3 - Läs av din datarow
                    var id = data.Rows[0]["Id"].ToString();

                    // steg 4 -  returnera ID
                    return id;
                }
            }
            return "";
        }
        public static string ActionID(string input)
        {
            string sql = @"SELECT * FROM Actions WHERE Action LIKE @input";
            var data = Datatable.GetDataTable(sql, "@input", input.Trim());

            // Steg 1 - kolla om data är null
            if (data != null && data.Rows != null)
            {
                // steg 2 - Kolla om data.rows är större än 0 (i så fall har du fått datarader)
                if (data.Rows.Count > 0)
                {
                    // steg 3 - Läs av din datarow
                    var id = data.Rows[0]["Id"].ToString();

                    // steg 4 -  returnera ID
                    return id;
                }
            }
            return "";
        }
        public static string DoorID(string input)
        {
            string sql = @"SELECT * FROM Doors WHERE Door LIKE @input";
            var data = Datatable.GetDataTable(sql, "@input", input.Trim());

            // Steg 1 - kolla om data är null
            if (data != null && data.Rows != null)
            {
                // steg 2 - Kolla om data.rows är större än 0 (i så fall har du fått datarader)
                if (data.Rows.Count > 0)
                {
                    // steg 3 - Läs av din datarow
                    var id = data.Rows[0]["Id"].ToString();

                    // steg 4 -  returnera ID
                    return id;
                }
            }
            return "";
        }
        public static string CodeID(string input)
        {
            string sql = @"SELECT * FROM Codes WHERE Code LIKE @input";
            var data = Datatable.GetDataTable(sql, "@input", input.Trim());

            // Steg 1 - kolla om data är null
            if (data != null && data.Rows != null)
            {
                // steg 2 - Kolla om data.rows är större än 0 (i så fall har du fått datarader)
                if (data.Rows.Count > 0)
                {
                    // steg 3 - Läs av din datarow
                    var id = data.Rows[0]["Id"].ToString();

                    // steg 4 -  returnera ID
                    return id;
                }
            }
            return "";
        }
    }
}
