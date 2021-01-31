using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentDB
{
    class InputHandler
    {



        // tar användarens input och delar upp den efter kommatecken samt tar bort eventuella mellanrum, sparar sedan in varje enskilt värde i en string array vid namn values med ett eget index.
        internal static string[] HandleInput(string input)
        {
            string[] values = input.Trim().TrimEnd(',').Split(',');


            return new string[] { values[0], values[1], values[2], values[3] };
        }


        internal static void InsertEntry(string Tag, string Action, string Door, string Code)
        {

            // path till databas
            using (var conn = new SQLiteConnection("data source=" + Database.DatabaseLocation))
            {
                // Öppna filen och låt databasmotorn hantera det
                conn.Open();

                // Hämta SQL commando för att hantera SQL-sträng och parameter
                SQLiteCommand cmd = new SQLiteCommand(SQLStrings.sqlInput, conn);

                // Ange parametrar
                cmd.Parameters.AddWithValue("@Tag", Tag);
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Door", Door);
                cmd.Parameters.AddWithValue("@Code", Code);

                // Exekvera SQL koden
                cmd.ExecuteNonQuery();

               
                
            }
        }
    }
}
