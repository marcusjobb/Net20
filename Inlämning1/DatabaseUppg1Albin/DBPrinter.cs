using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DatabaseUppg1Albin
{
    // Metod för att printa datan och hur den struktureras.
    public static class DBPrinter
    {
        public static void PrintDB(DataTable data)
        {

            if (data != null && data.Rows != null)
            {
                foreach (DataRow item in data.Rows)
                {
                    var time = item["Time"].ToString();
                    var tag = item["Tag"].ToString();
                    var code = item["Code"].ToString();
                    var door = item["Door"].ToString();
                    var eventt = item["ID"].ToString();
                    var name = item["Name"].ToString();
                    var action = item["Action"].ToString();

                    Console.WriteLine($"{time} {eventt} {name} {code} {action} {door} {tag}");
                }
                Console.Read();
            }
            else
            {
                Console.WriteLine("Empty");
                Console.Read();
            }
        }
        // Metod för att printa ListTenantsAt
        public static void PrintList(DataTable data)
        {

            if (data != null && data.Rows != null)
            {
                foreach (DataRow item in data.Rows)
                {
                    var tag = item["Tag"].ToString();
                    var apartment = item["Apartmentnumber"].ToString();
                    var name = item["Name"].ToString();

                    Console.WriteLine($"{name} {apartment} {tag}");
                }
                Console.Read();
            }
            else
            {
                Console.WriteLine("Empty");
                Console.Read();
            }
        }
    }
}
