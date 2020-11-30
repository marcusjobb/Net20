namespace CSharpRepetition.Net20.MarcusMedina
{
    using CSharpRepetition.MarcusKod;

    using System;
    using System.Text;

    /// <summary>
    /// För att få programmet att fungera kolla koden för classerna
    ///
    /// * <see cref="CSRepGrund"/>Grund
    /// * <see cref="CSRepAvancerad"/>Avancerad
    /// * <see cref="CSRepNinja"> Ninja
    ///
    /// Programmet försöker köra alla metoder i classerna,
    /// och kommer att visa dig procent av hur många metoder
    /// som fungerar som de ska
    ///
    /// Gott råd: Undvik Linq och StackOverflow, det kan lösa problemet
    /// men du lär dig inget av det. Tanken är att du själv ska lösa det
    ///.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Mainmetoden
        /// </summary>
        private static void Main()
        {
            DrawGUI();

            StringBuilder result = new System.Text.StringBuilder("\nResultat:");
            double g = Checka.Grund();
            double a = Checka.Avancerad();
            double n = Checka.Ninja();
            double s = (g + a + n) / 300;
            double t = Math.Round(s * 100, 1);

            cgui.PrintAt(14, StatsRow, $"Grund : {g}% ");
            cgui.PrintAt(54, StatsRow, $"Avancerad : {a}% ");
            cgui.PrintAt(95, StatsRow, $"Ninja : {n}% ");
            cgui.CenterTextAt(27, $"Totalt : {t}% ", true);

            cgui.SetPos(0, 0);
            Console.ReadLine();
        }

        private static int StatsRow = 6;
        private static int topRow = 2;
        private static ConsoleGUI cgui = new ConsoleGUI();
        private static void DrawGUI()
        {
            cgui.DrawBox();
            cgui.CenterTextAt(topRow, "Testa dig själv");

            cgui.PrintAt(14, StatsRow, "Grund :   0% ");
            cgui.PrintAt(54, StatsRow, "Avancerad :   0% ");
            cgui.PrintAt(95, StatsRow, "Ninja :    % ");
            cgui.CenterTextAt(27, "Totalt :    % ",true);

            cgui.DrawPillar(cgui.MaxWidth / 3, StatsRow - 2, 21);
            cgui.DrawPillar(2 * (cgui.MaxWidth / 3), StatsRow - 2, 21);
        }
    }
}
