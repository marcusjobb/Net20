using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace uppgift1_HFAB
{
    public static class Output
    {
        /// <summary>
        /// Här skrivs informationen ut i konsolen (Öppnade dörr inifrån / Utifrån).
        /// Som fungerar (delvis).
        /// </summary>
        /// <param name="searcher">Find by ... (används 2 argument i outPutData)</param>
        /// <param name="dataTable">Datan som printar ut</param>
        public static void outputData(string searcher, DataTable dataTable)
        {
            Console.WriteLine(searcher);

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string doorEvent;
                    if (row[2].ToString() == "DÖIN")
                    {
                        doorEvent = "Öppnade dörr " + row[1] + " inifrån";
                    }
                    else if (row[2].ToString() == "DÖUT")
                    {
                        doorEvent = "Öppnade dörr " + row[1] + " utifrån";
                    }
                    else
                    {
                        doorEvent = "";
                    }
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), doorEvent);
                }
            }
            else
            {
                Console.WriteLine("No results found!");
            }
        }
        public static void ThePrinterOfList(DataTable dataTable)
        {
            if(dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row[0].ToString());
                }
            }else
            {
                Console.WriteLine("No results found!");
            }
        }
        public static void PrintLoggEntry(bool trueFalse)
        {
            if (trueFalse)
            {
                Console.WriteLine("Loggen har blivit skapad!");
            }
            else
            {
                Console.WriteLine("Något gick fel när vi skulle lägga till loggen.");
            }
        }
    }
}
