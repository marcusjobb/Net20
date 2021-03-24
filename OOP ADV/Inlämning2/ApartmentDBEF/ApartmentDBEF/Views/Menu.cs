using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDBEF.Views
{
    public static class Menu
    {
        public static void MainMenu()
        {

            // "UI" för menyn.
            Console.Clear();
            Console.WriteLine("Welcome, please choose an option (enter 1-9):\n");
            Console.WriteLine("1. Find Entries By Door");
            Console.WriteLine("2. Find Entries By Event");
            Console.WriteLine("3. Find Entries By Location");
            Console.WriteLine("4. Find Entries By Tag");
            Console.WriteLine("5. Find Entries By Tenant");
            Console.WriteLine("6. ListTenants");
            Console.WriteLine("7. Log new entry");
            Console.WriteLine("8. Add new tenant");
            Console.WriteLine("9. Move tenant");



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


            // en switch för menyn som baserat på val kör en (eller flera) metoder.
            switch (userChoice)
            {

                case 1:

                    Console.Clear();
                    Console.WriteLine("Entries by door\n");
                    Console.WriteLine("Enter a door to search for:");
                    Console.WriteLine("Entrance/Garbage/Laundry/Janitor or XXXXLGH / XXXXBLK where XXXX = Appartmentnumber");
                    string input = Console.ReadLine();
                    var showEvent = Controllers.DoorEventsLog.FindEntriesByDoor(input);
                    ConsoleOutput.printData(showEvent);
                    MainMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Entries by event\n");
                    Console.WriteLine("Enter a codeID to search for:");
                    Console.WriteLine("\n DI, DO, WDI, WDO");
                    string input2 = Console.ReadLine();
                    var showEvent2 = Controllers.DoorEventsLog.FindEntriesByEvent(input2);
                    ConsoleOutput.printData(showEvent2);
                    MainMenu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Entries by location\n");
                    Console.WriteLine("Enter a location to search for:");
                    Console.WriteLine("Entrance/Garbage/Laundry/Janitor or Apartmentnumber\n");
                    string input3 = Console.ReadLine();
                    var showEvent3 = Controllers.DoorEventsLog.FindEntriesByLocation(input3);
                    ConsoleOutput.printData(showEvent3);
                    MainMenu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Entries by tag\n");
                    Console.WriteLine("Enter a tagID to search for:\n");
                    Console.WriteLine("XXXX + A/B/C");
                    string input4 = Console.ReadLine();
                    var showEvent4 = Controllers.DoorEventsLog.FindEntriesByTag(input4);
                    ConsoleOutput.printData(showEvent4);
                    MainMenu();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Entries by tenant\n");
                    Console.WriteLine("Enter a tenant to search for:\n");
                    string input5 = Console.ReadLine();
                    var showEvent5 = Controllers.DoorEventsLog.FindEntriesByTenant(input5);
                    ConsoleOutput.printData(showEvent5);
                    MainMenu();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("List tenants at\n");
                    Console.WriteLine("Enter an apartment to search for:\n");
                    string input6 = Console.ReadLine();
                    var showTenants = Controllers.DoorEventsLog.ListTenantsAt(input6);
                    ConsoleOutput.printTenantsAt(showTenants);
                    MainMenu();
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Log Entry");
                    Console.WriteLine("Enter Tag, Action, Door, Code ");
                    Console.WriteLine("E.g. 0101A, Opened, Entrance, DI\n");
                    var input7 = Console.ReadLine();
                    Controllers.InputHandler.HandleInputEvent(input7);
                    Console.WriteLine("Entry added. Press any key to continue");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Enter the name of the tenant to add:");
                    string userinput = Console.ReadLine();
                    var success = Controllers.DoorEventsLog.addTenant(userinput);
                    if (success)
                    {
                        Console.WriteLine("Tenant {0} has been added.\n Press any key to continue", userinput);

                    }
                    else if (!success)
                    {
                        Console.WriteLine("Adding tenant {0} failed. Press any key to continue", userinput);

                    }
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine("Enter the name or tag of tenant and appartmentnumber to move to:");
                    Console.WriteLine("E.g. Elvis Presley, 1234");
                    Console.WriteLine("To move someone out enter 'tag/name, 0000'");
                    Console.WriteLine("E.g. Justin Bieber, 0000");
                    var movetenant = Console.ReadLine();
                    var handled = Controllers.InputHandler.HandleInputMoveTenant(movetenant);
                    var tagOrName = handled[0].Trim();
                    var toApartment = handled[1].Trim();
                    if (toApartment == "0000")
                    {
                        var moveOutSuccessful = Controllers.DoorEventsLog.MoveOutTenant(tagOrName);
                        
                        if (moveOutSuccessful)
                        {
                            Console.Clear();
                            Console.WriteLine("Move out of tenant '{0}' successfull!", tagOrName);
                            Console.WriteLine("\n Press any key to continute.");
                            Console.ReadKey();
                            MainMenu();
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong.");
                            Console.WriteLine("\n Press any key to continute.");
                            Console.ReadKey();
                            MainMenu();
                        }
                    }
                    
                    
                        var moveSuccessful = Controllers.DoorEventsLog.MoveTenant(tagOrName, toApartment);
                    
                    if (moveSuccessful)
                    {
                        Console.Clear();
                        Console.WriteLine("Move '{0}' successfull!",movetenant );
                        Console.WriteLine("\n Press any key to continute.");
                        Console.ReadKey();
                        MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong.");
                    }

                    break;




            }





        }




    }
}
