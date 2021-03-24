namespace CSharpRepetition.MarcusKod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CSharpRepetition.MarcusKod;

    public static class NiceDebug
    {
        public static int StartY { get; set; } = 10;
        public static int StartX { get; set; } = 3;
        public static int MaxLength { get; set; } = 34;

        public static void Reset(int x)
        {
            StartY = 9;
            StartX = x;
        }
        public static void DebugThis(string text)
        {
            var gui = new ConsoleGUI();
            if (text.Length > MaxLength) text = text.Substring(0, MaxLength);
            gui.PrintAt(StartX, StartY++, text);
        }

    }
}
