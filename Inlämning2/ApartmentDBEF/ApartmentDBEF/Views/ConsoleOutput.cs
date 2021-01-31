using ApartmentDBEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentDBEF.Views
{
    public class ConsoleOutput : IView
    {   
        //Printar data till konsollen ifrån samtliga FindEntriesBy... i DoorEventsLog.
        public static void printData(IQueryable<Models.Result> showEvents)
        {
            Console.WriteLine(" --   Date/Time   --  Tenant name  -- Action -- Doortype -- Door -- in/out");
            foreach (var obj in showEvents)
            {             
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", obj.Time, obj.Tenant, obj.Action, obj.Doorexp, obj.Door, obj.InorOut);
            }                
            Console.Read();
        }


        //Printar data till konsollen ifrån ListTenantsAt... i DoorEventsLog.
        public static void printTenantsAt(IQueryable<Models.TenantsAt> showTenants)
        {

            Console.WriteLine(" -- Tenant --  Tag -- Apartment --  ");
            foreach (var obj in showTenants)
            {

                Console.WriteLine("{0}, {1}, {2}", obj.Tenant, obj.Tag, obj.Apartment);
            }

            Console.Read();
        }





    }
}
