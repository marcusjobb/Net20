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
        
        public static void FindEntriesByDoor()
        {
            Console.Clear();
            Console.WriteLine("Entries by door\n");
            Console.WriteLine("Enter a door to search for:");
            Console.WriteLine("Entrance/Garbage/Laundry/Janitor or XXXXLGH / XXXXBLK where XXXX = Appartmentnumber");
            string input = Console.ReadLine();
            string sql = SQLStrings.sqlBase + SQLStrings.byDoor + SQLStrings.orderBy;
            var data = Database.GetDataTable(sql, "@input", input);
            Database.PrintData(data);
            ConsoleMenu.Menu();
        }

        // Sök de senaste loggar med given kod, returnera en DataTable
        
        public static void FindEntriesByEvent()
        {
            Console.Clear();
            Console.WriteLine("Entries by event\n");
            Console.WriteLine("Enter a codeID to search for:");
            Console.WriteLine("\n DI, DO, WDI, WDO");
            string input = Console.ReadLine();
            string sql = SQLStrings.sqlBase + SQLStrings.byCode + SQLStrings.orderBy; 
            var data = Database.GetDataTable(sql, "@input", input);
            Database.PrintData(data);
            ConsoleMenu.Menu();
        }

        // Sök de senaste loggar från en viss lägenhet/rum, returnera en DataTable
        
        public static void FindEntriesByLocation()
        {
            Console.Clear();
            Console.WriteLine("Entries by location\n");
            Console.WriteLine("Enter a location to search for:");
            Console.WriteLine("Entrance/Garbage/Laundry/Janitor or Apartmentnumber\n");
            string input = Console.ReadLine();
            string sql = SQLStrings.sqlBase + SQLStrings.byLocation + SQLStrings.orderBy;
            var data = Database.GetDataTable(sql, "@input", input);
            Database.PrintData(data);
            ConsoleMenu.Menu();
        }

        // Sök de senaste loggar från en viss tagg, returnera en DataTable

        public static void FindEntriesByTag()
        {
            Console.Clear();
            Console.WriteLine("Entries by tag\n");
            Console.WriteLine("Enter a tagID to search for:\n");
            Console.WriteLine("XXXX + A/B/C");
            string input = Console.ReadLine();
            string sql = SQLStrings.sqlBase + SQLStrings.byTag + SQLStrings.orderBy;  
            var data = Database.GetDataTable(sql, "@input", input);
            Database.PrintData(data);
            ConsoleMenu.Menu();
        }

        // Sök de senaste loggar från en viss hyresgäst, returnera en DataTable

        public static void FindEntriesByTenant()
        {
            Console.Clear();
            Console.WriteLine("Entries by tenant\n");
            Console.WriteLine("Enter a tenant to search for:\n");
            string input = Console.ReadLine();
            string sql = SQLStrings.sqlBase + SQLStrings.byTenant + SQLStrings.orderBy;
            var data = Database.GetDataTable(sql, "@input", input);
            Database.PrintData(data);
            ConsoleMenu.Menu();
        }

        // Söker hyresgäster från specifik lägenhet, returnera en DataTable med deras namn och tagg-kod

        public static void ListTenanatsAt()
        {
            Console.Clear();
            Console.WriteLine("List tenants at\n");
            Console.WriteLine("Enter an apartment to search for:\n");
            string input = Console.ReadLine();
            string sql = SQLStrings.sqlBase + SQLStrings.tenantsAt;
            var data = Database.GetDataTable(sql, "@input", input);
            Database.PrintData2(data);
            ConsoleMenu.Menu();

        }

        // Informationen skickas in i textform och sparas i lämplig form och i lämpliga tabeller i databasen, returnerar inget

        public static void LogEntry()
        {
            Console.Clear();
            Console.WriteLine("Log Entry");
            Console.WriteLine("Enter Tag, Action, Door, Code ");
            Console.WriteLine("E.g. 0101A, Opened, Entrance, DI\n");
            var input = Console.ReadLine();
            var split = InputHandler.HandleInput(input);

            var Tag = split[0].Trim();
            var Action = split[1].Trim();
            var Door = split[2].Trim();
            var Code = split[3].Trim();
            InputHandler.InsertEntry(Tag, Action, Door, Code);
            Console.WriteLine("Entry added. Press any key to continue");
            Console.ReadKey();
            ConsoleMenu.Menu();
        }





        




    }
}
