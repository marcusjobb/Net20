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
    class ConsoleMenu
    {

        public static void Menu()
        {

            // "UI" för våran meny
            Console.Clear();
            Console.WriteLine("Welcome, please choose an option (enter 1-5):\n\n\n");
            Console.WriteLine("1. Find Entries By Door");
            Console.WriteLine("2. Find Entries By Event");
            Console.WriteLine("3. Find Entries By Location");
            Console.WriteLine("4. Find Entries By Tag");
            Console.WriteLine("5. Find Entries By Tenant");
            Console.WriteLine("6. ListTenants");
            Console.WriteLine("7. Log new entry");
            


            // en liten loop som säkerställer input i rätt format
            int userChoice;
            bool parsed = false;
            do
            {
                parsed = Int32.TryParse(Console.ReadLine(), out userChoice);
                if (!parsed)
                {
                    Console.WriteLine("Incorrect choice, please try again!");
                }

            }
            while (!parsed);


            DataTable searchData = new DataTable();
            // en switch för vår meny som baserat på val kör en metod
            switch (userChoice)
            {
                
                case 1:
                    
                    Console.Clear();
                    Console.WriteLine("Entries by door\n");
                    Console.WriteLine("Enter a door to search for:");
                    Console.WriteLine("Entrance/Garbage/Laundry/Janitor or XXXXLGH / XXXXBLK where XXXX = Appartmentnumber");
                    string input = Console.ReadLine();
                    searchData = DoorEventsLog.FindEntriesByDoor(input);
                    OutputHandler.PrintData(searchData);
                    Menu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Entries by event\n");
                    Console.WriteLine("Enter a codeID to search for:");
                    Console.WriteLine("\n DI, DO, WDI, WDO");
                    string input2 = Console.ReadLine();
                    searchData = DoorEventsLog.FindEntriesByEvent(input2);
                    OutputHandler.PrintData(searchData);
                    Menu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Entries by location\n");
                    Console.WriteLine("Enter a location to search for:");
                    Console.WriteLine("Entrance/Garbage/Laundry/Janitor or Apartmentnumber\n");
                    string input3 = Console.ReadLine();
                    searchData = DoorEventsLog.FindEntriesByLocation(input3);
                    OutputHandler.PrintData(searchData);
                    Menu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Entries by tag\n");
                    Console.WriteLine("Enter a tagID to search for:\n");
                    Console.WriteLine("XXXX + A/B/C");
                    string input4 = Console.ReadLine();
                    searchData = DoorEventsLog.FindEntriesByTag(input4);
                    OutputHandler.PrintData(searchData);
                    Menu();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Entries by tenant\n");
                    Console.WriteLine("Enter a tenant to search for:\n");
                    string input5 = Console.ReadLine();
                    searchData = DoorEventsLog.FindEntriesByTenant(input5);
                    OutputHandler.PrintData(searchData);
                    Menu();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("List tenants at\n");
                    Console.WriteLine("Enter an apartment to search for:\n");
                    string input6 = Console.ReadLine();
                    searchData = DoorEventsLog.ListTenanatsAt(input6);
                    OutputHandler.PrintData2(searchData);
                    Menu();
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Log Entry");
                    Console.WriteLine("Enter Tag, Action, Door, Code ");
                    Console.WriteLine("E.g. 0101A, Opened, Entrance, DI\n");
                    var input7 = Console.ReadLine();
                    DoorEventsLog.LogEntry(input7);
                    Console.WriteLine("Entry added. Press any key to continue");
                    Console.ReadKey();
                    Menu();
                    break;



            }
                




        }


         // våran fina välkomst-grafik, cred till Andreas som hittade den online
        public static void WelcomeGraphic()
        {
            Console.WriteLine(@"                   \  |  /         ___________
    ____________  \ \_# /         |  ___      |       _________
   |            |  \  #/          | |   |     |      | = = = = |
   | |   |   |  |   \\#           | |`v'|     |      |         |
   |            |    \#  //       |  --- ___  |      | |  || | |
   | |   |   |  |     #_//        |     |   | |      |         |
   |            |  \\ #_/_______  |     |   | |      | |  || | |
   | |   |   |  |   \\# /_____/ \ |      ---  |      |         |
   |            |    \# |+ ++|  | |  |^^^^^^| |      | |  || | |
   |            |    \# |+ ++|  | |  |^^^^^^| |      | |  || | |
^^^|    (^^^^^) |^^^^^#^| H  |_ |^|  | |||| | |^^^^^^|         |
   |    ( ||| ) |     # ^^^^^^    |  | |||| | |      | ||||||| |
   ^^^^^^^^^^^^^________/  /_____ |  | |||| | |      | ||||||| |
        `v'-                      ^^^^^^^^^^^^^      | ||||||| |
         || |`.      (__)    (__)                          ( )
                     (oo)    (oo)                       /---V
              /-------\/      \/ --------\             * |  |
             / |     ||        ||_______| \
            *  ||W---||        ||      ||  *
               ^^    ^^        ^^      ^^");
          
        }







    }
}
