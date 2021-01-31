using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentDB
{
    public class OutputHandler
    {
        public static void PrintData(DataTable data)
        {




            if (data != null && data.Rows != null)
            {

                Console.WriteLine("Event ID -- Date/Time -- Code -- Tag -- Action -- Door -- Kind of door -- Tenant name");
                foreach (DataRow item in data.Rows)
                {
                    var id = item["ID"].ToString();
                    var time = item["Time"].ToString();
                    var code = item["Code"].ToString();
                    var tag = item["Tag"].ToString();
                    var actions = item["Action"].ToString();
                    var door1 = item["Door"].ToString();
                    var doorexp = item["Explanation"].ToString();
                    var name = item["Name"].ToString();




                    Console.WriteLine($"{id} -- {time} -- {code} -- {tag} -- {actions} -- {door1} -- {doorexp} -- {name}");
                }
                Console.Read();
            }
            else
            {
                Console.WriteLine("Empty");
                Console.Read();
            }
        }



        public static void PrintData2(DataTable data)
        {




            if (data != null && data.Rows != null)
            {

                Console.WriteLine("Name -- Tag -- Apartmentnumber");
                foreach (DataRow item in data.Rows)
                {
                    var name = item["Name"].ToString();
                    var tag = item["Tag"].ToString();
                    var apartment = item["Apartmentnumber"].ToString();

                    Console.WriteLine($"{name} -- {tag} -- {apartment}");
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
