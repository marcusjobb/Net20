using System;
using System.Data;

namespace DoorEventLogProject
{
    internal static class PrintToConsole
    {
        //Prints data to console
        public static void PrintData(string find, DataTable dt)
        {
            Console.WriteLine();
            Console.WriteLine(find);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows) 
                {
                    string doorEvent;

                    if (dr[2].ToString() == "DÖIN")
                    {
                        doorEvent = "Öppnade dörren " + dr[1] + " inifrån";
                    }
                    else if (dr[2].ToString() == "DÖUT")
                    {
                        doorEvent = "Öppnade dörren " + dr[1] + " utifrån";
                    }
                    else
                    {
                        doorEvent = "";
                    }

                    Console.WriteLine("{0}, {1}, {2}, {3}, {4} {5} ", dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), doorEvent);
                }
            }
            else
            {
                Console.WriteLine("Inget resultat");
            }
        }
        //prints if log was successfully recorded or not
        public static void PrintLogEntry(bool run)
        {
            if (run)
            {
                Console.WriteLine("--------------");
                Console.WriteLine();
                Console.WriteLine("Log recorded");
            }
            else
            {
                Console.WriteLine("Oh no, something went wrong");
            }
        }
        //Prints data in a list
        public static void PrintList(DataTable dt)
        {
            Console.WriteLine();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine(dr[0].ToString());
                }
            }
            else
            {
                Console.WriteLine("Inget resultat");
            }
        }
    }
}
