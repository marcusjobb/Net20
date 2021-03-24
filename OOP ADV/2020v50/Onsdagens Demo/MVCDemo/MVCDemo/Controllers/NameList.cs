using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.Controllers
{
    public class NameList
    {
        internal static void Run()
        {
            var Names = new List<string>()
            {
                "Martin","Johan","Karl"
            };

            Views.NameList.Display(Names);

            Console.ReadLine();

        }
    }
}
