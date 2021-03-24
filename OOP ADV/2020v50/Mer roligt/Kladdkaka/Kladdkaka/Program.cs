namespace Recept
{
    using System;

    /// <summary>
    /// Definition av <see cref="Program" />.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Här deklareras Main.
        /// </summary>
        private static void Main()
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 60;
            Kladdkaka Kladdkaka = new Kladdkaka();
            Kladdkaka.Baka();
        }
    }
}
