namespace Importer
{
    using System;
    using System.Collections.Generic;

    using HFAB_v2;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //Sets console window to a fixed width for better display
            Console.SetWindowSize(130, 30);

            //HFAB_v2.Program.CreateDatabaseOnStartup();
            //var log = new DoorEventsLog();
            //var byDoor = log.FindEntriesByDoor("LGH0101")?.Rows;
            //HFAB_v2.Program.OutputData("Search by door", byDoor);

            var csv = new List<string>();
            csv.Add(@"2021-01-13 20:35,DÖIN,LGH0201,0201A,Olivia Erlander");
            csv.Add(@"2021-01-13 20:36,DÖIN,TVÄTT,0201A,Olivia Erlander");
            csv.Add(@"2021-01-13 20:54,DÖUT,TVÄTT,0201A,Olivia Erlander");
            csv.Add(@"2021-01-13 20:55,DÖUT,LGH0201,0201A,Olivia Erlander");
            csv.Add(@"FindEntriesByTag,VAKT01");
            csv.Add(@"MaxEntries,7");
            csv.Add(@"ListTenantsAt,VAKT");
            csv.Add(@"FindEntriesByDoor,LGH0103");
            csv.Add(@"FindEntriesByEvent,DÖIN");
            csv.Add(@"FindEntriesByLocation,0201");
            csv.Add(@"FindEntriesByTag,VAKT01");

            // Läser filen som array
            var file = System.IO.File.ReadAllLines("minfil.txt");
            foreach (var item in file)
            {
                Console.WriteLine(item);
                // Splittar stringen
                var row = item.Split(',');
                // 5 = logg
                if (row.Length == 5)
                    Console.WriteLine($"{row[0]}\t{row[1]}\t{row[2]}\t{row[3]}\t{row[4]}\t");
                else
                    // kommando
                    Console.WriteLine($"{row[0]}\t{row[1]}");
            }
        }
    }
}