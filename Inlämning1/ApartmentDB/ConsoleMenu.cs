using System;
using System.Collections.Generic;
using System.Text;

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


            // en switch för vår meny som baserat på val kör en metod
            switch (userChoice)
            {
                case 1:
                    DoorEventsLog.FindEntriesByDoor();
                    break;
                case 2:
                    DoorEventsLog.FindEntriesByEvent();
                    break;
                case 3:
                    DoorEventsLog.FindEntriesByLocation();
                    break;
                case 4:
                    DoorEventsLog.FindEntriesByTag();
                    break;
                case 5:
                    DoorEventsLog.FindEntriesByTenant();
                    break;
                case 6:
                    DoorEventsLog.ListTenanatsAt();
                    break;
                case 7:
                    DoorEventsLog.LogEntry();
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
