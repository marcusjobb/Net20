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
    class DoorEventsLog
    {

        // Sök de senaste loggar från en viss dörr, returnera en DataTable
        
        public static DataTable FindEntriesByDoor(string input)
        {
            string sql = SQLStrings.sqlBase + SQLStrings.byDoor + SQLStrings.orderBy + SQLStrings.limit;
            var data = Database.GetDataTable(sql, "@input", input);
            return data;
        }

        // Sök de senaste loggar med given kod, returnera en DataTable
        
        public static DataTable FindEntriesByEvent(string input)
        {
            string sql = SQLStrings.sqlBase + SQLStrings.byCode + SQLStrings.orderBy + SQLStrings.limit; 
            var data = Database.GetDataTable(sql, "@input", input);
            return data;
        }

        // Sök de senaste loggar från en viss lägenhet/rum, returnera en DataTable
        
        public static DataTable FindEntriesByLocation(string input)
        {
            string sql = SQLStrings.sqlBase + SQLStrings.byLocation + SQLStrings.orderBy + SQLStrings.limit;
            var data = Database.GetDataTable(sql, "@input", input);
            return data;
        }

        // Sök de senaste loggar från en viss tagg, returnera en DataTable

        public static DataTable FindEntriesByTag(string input)
        {
            string sql = SQLStrings.sqlBase + SQLStrings.byTag + SQLStrings.orderBy + SQLStrings.limit;  
            var data = Database.GetDataTable(sql, "@input", input);
            return data;
        }

        // Sök de senaste loggar från en viss hyresgäst, returnera en DataTable

        public static DataTable FindEntriesByTenant(string input)
        {
            string sql = SQLStrings.sqlBase + SQLStrings.byTenant + SQLStrings.orderBy + SQLStrings.limit;
            var data = Database.GetDataTable(sql, "@input", input);
            return data;
        }

        // Söker hyresgäster från specifik lägenhet, returnera en DataTable med deras namn och tagg-kod

        public static DataTable ListTenanatsAt(string input)
        {
            string sql = SQLStrings.tenantsAt;
            var data = Database.GetDataTable(sql, "@input", input);
            return data;

        }

        // Informationen skickas in i textform och sparas i lämplig form och i lämpliga tabeller i databasen, returnerar inget

        public static void LogEntry(string input)
        {

            var split = InputHandler.HandleInput(input);

            var Tag = split[0].Trim();
            var Action = split[1].Trim();
            var Door = split[2].Trim();
            var Code = split[3].Trim();
            InputHandler.InsertEntry(Tag, Action, Door, Code);
        }





        




    }
}
