using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IU_HFAB_Dor_Log
{
    internal static class Print
    {
        /// <summary>
        /// Print out data into the Console
        /// </summary>
        /// <param name="serchBy">serch by</param>
        /// <param name="dataTable">data to printout</param>
        public static void PrintData(string serchBy, DataTable dataTable)
        {
            Console.WriteLine();
            Console.WriteLine(serchBy);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string doorEvent;
                    if (dataRow[2].ToString() == "DÖIN")
                    {
                        doorEvent = "Öppnade dörren " + dataRow[1] + " inifrån";
                    }
                    else if (dataRow[2].ToString() == "DÖUT")
                    {
                        doorEvent = "Öppnade dörren " + dataRow[1] + " utifrån";
                    }
                    else
                    {
                        doorEvent = "";
                    }
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4} {5} ", dataRow[0].ToString(), dataRow[1].ToString(), dataRow[2].ToString(), dataRow[3].ToString(), dataRow[4].ToString(), doorEvent);
                }
            }
            else
            {
                Console.WriteLine("Inga Result httades");
            }
        }
        /// <summary>
        /// Prind data like List
        /// </summary>
        /// <param name="dataTable">data with the list</param>
        public static void PrintList(DataTable dataTable)
        {
            Console.WriteLine();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Console.WriteLine(dataRow[0].ToString());
                }
            }
            else
            {
                Console.WriteLine("Inga Result httades");
            }
        }

        public static void PrintLoggEntry(bool trueFalse)
        {
            if (trueFalse)
            {
                Console.WriteLine("Loog have been added");
            }
            else
            {
                Console.WriteLine("something when wrong adding the data");
            }
        }
    }
}
