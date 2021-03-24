namespace MVCDemo.Views
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class NameList
    {
        internal static void Display(List<string> names)
        {
            Console.Clear();
            Console.WriteLine("Name list");

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
