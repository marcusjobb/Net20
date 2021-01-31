using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework_HFAB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates database and/or generates test data if needed
            Database.Seeder.GenerateDatabase(1000);

            //Calls on method in MyView-class to print info in console
            Views.ConsoleViews.ConsoleView();
        }
    }
}
