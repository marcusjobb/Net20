namespace HFAB_v2_EF.Views
{
    using System;
    using System.Collections.Generic;

    internal static class Print
    {
        /// <summary>
        /// Print out the Logg
        /// </summary>
        /// <param name="searchBy">string what you search for</param>
        /// <param name="loggs">llist of log form db</param>
        public static void PrintLogg(string searchBy, List<Models.Logg> loggs)
        {
            Console.WriteLine();
            Console.WriteLine(searchBy);
            if (loggs != null)
            {
                foreach (var logg in loggs)
                {
                    var eventDescription = "";
                    if (logg.Event.Code == "DÖIN")
                    {
                        eventDescription = "Öppnade dörr " + logg.Door.Name + " inifrån";
                    }
                    else if (logg.Event.Code == "DÖUT")
                    {
                        eventDescription = "Öppnade dörr " + logg.Door.Name + " utifrån";
                    }
                    else if (logg.Event.Code == "FDIN")
                    {
                        eventDescription = "försökte öppna dörr " + logg.Door.Name + " inifrån utan tilstånd";
                    }
                    else if (logg.Event.Code == "FDUT")
                    {
                        eventDescription = "försökte öppna dörr " + logg.Door.Name + " utifrån utan tilstånd";
                    }
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4} {5} {6}", logg.Date, logg.Door.Name, logg.Event.Code, logg.Person.Tag, logg.Person.FirstName, logg.Person.LastName, eventDescription);
                }
            }
            else
            {
                Console.WriteLine("Hittade tyvärr inga resultat");
            }
        }

        /// <summary>
        /// Prints out a list
        /// </summary>
        /// <param name="persons">List of persons</param>
        public static void PrintList(List<string> persons)
        {
            Console.WriteLine();
            Console.WriteLine("Lista personer i lägenhet");
            if (persons != null)
            {
                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                }
            }
            else
            {
                Console.WriteLine("Tyävrr hittade vi inga i den lägenheten");
            }
        }

        /// <summary>
        /// print out if bool was succesfull or not
        /// </summary>
        /// <param name="trueFalse"></param>
        public static void PrintBool(bool trueFalse)
        {
            Console.WriteLine();
            if (!trueFalse)
            {
                Console.WriteLine("Something went wrong doing that");
            }
            else if (trueFalse)
            {
                Console.WriteLine("Sucsessfull");
            }
        }
    }
}