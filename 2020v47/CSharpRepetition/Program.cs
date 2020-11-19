#pragma warning disable IDE0059 // Unnecessary assignment of a value
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
    /// men du lär dig inget av det. Tanken är att du själv ska lösa det.
    ///
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Raden där statistiken skrivs
        /// </summary>
        private const int statsRow = 6;

        /// <summary>
        /// Titelraden
        /// </summary>
        private const int titleRow = 2;

        /// <summary>
        /// GUI objekt.
        /// </summary>
        private static readonly ConsoleGUI cgui = new ConsoleGUI();

        /// <summary>
        /// Mainmetoden.
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

            cgui.PrintAt(14, statsRow, $"Grund : {g}% ");
            cgui.PrintAt(54, statsRow, $"Avancerad : {a}% ");
            cgui.PrintAt(95, statsRow, $"Ninja : {n}% ");
            cgui.CenterTextAt(27, $"Totalt : {t}% ", true);

            cgui.SetPos(0, 0);
            Console.ReadLine();
        }

        /// <summary>
        /// Skapa GUI skelett
        /// </summary>
        private static void DrawGUI()
        {
            cgui.DrawBox();
            cgui.CenterTextAt(titleRow, "Testa dig själv");
            cgui.DrawPillar(cgui.MaxWidth / 3, statsRow - 2, 21);
            cgui.DrawPillar(2 * (cgui.MaxWidth / 3), statsRow - 2, 21);
        }
    }
}
#pragma warning restore IDE0059 // Unnecessary assignment of a value
