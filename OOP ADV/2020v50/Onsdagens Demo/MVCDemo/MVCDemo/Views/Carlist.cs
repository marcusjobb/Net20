namespace MVCDemo.Views
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Carlist
    {
        public static void Display(List<string> cars)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 110));
            foreach (var car in cars)
            {
                Console.WriteLine($"  {car}");
            }
            Console.WriteLine(new string('-', 110));
        }
    }
}
