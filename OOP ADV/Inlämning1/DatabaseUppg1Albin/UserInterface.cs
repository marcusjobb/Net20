using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DatabaseUppg1Albin
{
    class UserInterface
    {
        public static void Interface()
        {
            Console.WriteLine("Välkommen till Husrum Fastigheter AB, var god välj ett av alternativen nedan.:\n\n\n");
            while (true)
            {
                Console.WriteLine("1. Hitta den senaste informationen per Dörr som öppnats/stängts.");
                Console.WriteLine("2. Hitta de senaste händelserna.");
                Console.WriteLine("3. Hitta de senaste händelserna per Tag som använts.");
                Console.WriteLine("4. Hitta de senaste händelserna per Hyresgäst.");
                Console.WriteLine("5. Få en lista på de Hyresgäster som bor i en specifik lägenhet.");
                Console.WriteLine("6. Rapportera in en händelse att logga.");

                int userInput;
                bool parsed = false;

                do
                {
                    parsed = Int32.TryParse(Console.ReadLine(), out userInput);

                    if (!parsed)
                    {
                        Console.WriteLine("Något gick fel! Försök att välja ett nummer på nytt.");
                    }
                }
                while (!parsed);
                  
                string input = "";

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Skriv in en dörr att söka efter:");
                        Console.WriteLine("Exempelvis, Ingång/Utgång - XXXXLGH - XXXXBLK - Soprum - Tvätt - Vaktmästarens rum");
                        Console.WriteLine(@"Det går även att skriva ""%"" för att får alla händelser.");
                        input = Console.ReadLine();
                        var dataByDoor = DoorEventsLog.FindEntriesByDoor(input);
                        DBPrinter.PrintDB(dataByDoor);
                        break;
                    case 2:
                        Console.WriteLine("Skriv in en händelse att söka efter:");
                        Console.WriteLine("Exempelvis, DÖIN - DÖUT - FDÖIN - FDÖUT");
                        Console.WriteLine(@"Det går även att skriva ""%"" för att får alla händelser.");
                        input = Console.ReadLine();
                        var dataByEvent = DoorEventsLog.FindEntriesByEvent(input);
                        DBPrinter.PrintDB(dataByEvent);
                        break;
                    case 3:
                        Console.WriteLine(@"Skriv in en Tag att söka efter ""0X0XX"":");
                        Console.WriteLine("Exempelvis, 0101A - 0301C - Vakt");
                        Console.WriteLine(@"Det går även att skriva ""%"" för att får alla händelser.");
                        input = Console.ReadLine();
                        var dataByTag = DoorEventsLog.FindEntriesByTag(input);
                        DBPrinter.PrintDB(dataByTag);
                        break;
                    case 4:
                        Console.WriteLine(@"Skriv in en Hyresgäst att söka efter:");
                        Console.WriteLine("Exempelvis, Maja Ahlström - Adam Andersen - Vaktmästare");
                        Console.WriteLine(@"Det går även att skriva ""%"" för att får alla händelser.");
                        input = Console.ReadLine();
                        var dataByTenant = DoorEventsLog.FindEntriesByTenant(input);
                        DBPrinter.PrintDB(dataByTenant);
                        break;
                    case 5:
                        Console.WriteLine(@"Skriv in en Lägenhet att söka efter ""0X0X"":");
                        Console.WriteLine("Exempelvis, 0101 - 0201 - 0302");
                        Console.WriteLine(@"Det går även att skriva ""%"" för att får alla händelser.");
                        input = Console.ReadLine();
                        var dataTenantsAt = DoorEventsLog.ListTenantsAt(input);
                        DBPrinter.PrintList(dataTenantsAt);
                        break;
                    case 6:
                        Console.WriteLine("Logg att rapportera:");
                        Console.WriteLine("exempel: 2020-10-23 10:23, LGH0301, DÖIN, 0301A, opened");
                        input = Console.ReadLine();
                        string[] inputSplit = input.Split(','); // {"2020-10-23 10:23", "LGH0301", "DÖIN", "0301A"}
                        /*
                         * [0] = 2020-10-23 10:23
                         * [1] = LGH0301
                         * [2] = DÖIN
                         * [3] = 0301A
                         */
                        string Time = inputSplit[0]; //  2020-10-23 10:23
                        string IDTag = inputSplit[3]; //  0301A
                        string IDAction = inputSplit[4]; // opened
                        string IDDoor = inputSplit[1]; //   LGH0301
                        string IDCode = inputSplit[2]; // DÖIN

                        DoorEventsLog.LogEntry(Time, IDTag, IDAction, IDDoor, IDCode);
                        break;
                }
            }
        }
    }
}