namespace Twelve_days_of_Christmas
{
    using System;
    internal static class Program
    {
        private static TextData t = new TextData();

        private static void Main()
        {
            for (var i = 0; i < 12; i++)
            {
                Console.WriteLine(
                    string.Format
                        (
                        t.Verse,
                            t.Days[i],
                            WriteTheSong(i)
                        )
                    );
                Console.WriteLine();
            }
        }

        private static string WriteTheSong(int gift)
        {
            if (gift > 0)
            {
                var say = t.Gifts[gift];
                if (gift == 1)
                    say += "\nand ";
                else
                    say += ",\n";
                say += WriteTheSong(gift - 1);
                return say;
            }
            else
            {
                return t.Gifts[gift];
            }
        }
    }
}