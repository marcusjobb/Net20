namespace MVCDemo.Views
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MainMenu
    {
        internal static void Display(string menu)
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------+\n|");
            foreach (var item in menu.Replace("\r", "").Split('\n'))
            {
                Console.WriteLine("| "+ item);
            }
            Console.WriteLine("+--------------------------------+");
        }
    }
}
