using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.Controllers
{
    public class CarList
    {
        internal static void Run()
        {
            var cars = new List<string>()
            {
                "BMW", "Alfa Romero", "DeLorean"
            };
            cars.Sort();

            Views.Carlist.Display(cars);
            
            Console.ReadLine();
        }
    }
}
