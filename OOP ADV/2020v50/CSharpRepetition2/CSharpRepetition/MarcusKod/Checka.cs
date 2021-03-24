namespace CSharpRepetition.Net20.MarcusMedina
{
    using CSharpRepetition.MarcusKod;

    using System;

    /// <summary>
    /// Defines the <see cref="Checka" />.
    /// </summary>
    public static class Checka
    {
        /// <summary>
        /// Testar dina grundkunskaper.
        /// </summary>
        /// <returns>Procentvärde av resultat.</returns>
        public static double Grund(int debugX = 7)
        {
            const int max = 9;
            int score = 0;
            var check = new CSRepvGrund();
            NiceDebug.Reset(debugX);

            score += VerifyInput(check.FörstaVärden(3, "A", "B", "C", "D", "Katt", "Hund"), "ABC");
            score += VerifyInput(check.FörstaVärden(9, "R", "A", "M", "M", "S", "T", "E", "I", "N", "Du Hast"), "RAMMSTEIN");

            score += VerifyInput(check.ForSkip(10, 3, '*'), new string('*', 6));
            score += VerifyInput(check.ForSkip(32, 7, '*'), new string('*', 27));

            score += VerifyInput(check.EleversBetyg("g", "G", "VG", "vg", "GV", "v", "V"), (2, 5));
            score += VerifyInput(check.EleversBetyg("vg", "vG", "G", "g", "V", "G", "v", "V", "VG", "KATT"), (3, 6));

            score += VerifyInput(check.VändPåOrdet("julafton"), "notfaluj");
            score += VerifyInput(check.VändPåOrdet("aluminium"), "muinimula");
            score += VerifyInput(check.VändPåOrdet("tacocat"), "tacocat");

            return Math.Round((double)score / max * 100);
        }

        /// <summary>
        /// Testar dina ninjakunskaper.
        /// </summary>
        /// <returns>Procentvärde av resultat.</returns>
        public static double Ninja(int debugX = 86)
        {
            var rnd = new Random();
            const int max = 8;
            int score = 0;

            NiceDebug.Reset(debugX);
            NiceDebug.MaxLength -= 4;
            var check = new CSRepvNinja();
            score += VerifyInput(check.TicTacToe(new string[] { "XOX", "O X", "OXO" }, 1, 1, 'X').ToLower(), "draw");
            score += VerifyInput(check.TicTacToe(new string[] { "XOX", "O X", "OXX" }, 1, 1, 'X').ToLower(), "x wins");
            score += VerifyInput(check.TicTacToe(new string[] { "X X", "OOX", "OXX" }, 1, 1, 'X').ToLower(), "error");
            score += VerifyInput(check.TicTacToe(new string[] { "X X", "OOX", "OXO" }, 0, 1, 'O').ToLower(), "draw");
            score += VerifyInput(check.TicTacToe(new string[] { "X X", "   ", "OXO" }, 0, 1, 'O').ToLower(), "next move");
            score += VerifyInput(check.TicTacToe(new string[] { "XOX", "OXO", "   " }, 2, 1, 'O').ToLower(), "next move");
            score += VerifyInput(check.TicTacToe(new string[] { "OOX", "OXO", "O X" }, 2, 1, 'X').ToLower(), "o wins");
            score += VerifyInput(check.TicTacToe(new string[] { "XOX", "OXO", "O O" }, 2, 1, 'X').ToLower(), "draw");

            return Math.Round((double)score / max * 100);
        }

        /// <summary>
        /// Testar dina avancerade kunskaper.
        /// </summary>
        /// <param name="debugX">Vilken kolumn på consolen som texten ska läggas in i</param>
        /// <returns>Procentvärde av resultat.</returns>
        internal static double Avancerad(int debugX = 46)
        {
            const int max = 15;
            var score = 0;
            NiceDebug.Reset(debugX);
            var check = new CSRepAvancerad();
            score += VerifyInput(check.LessIsFirst(10, 2), 2, 10);
            score += VerifyInput(check.LessIsFirst(4, 3), 3, 4);
            score += VerifyInput(check.LessIsFirst(12, 22), 12, 22);

            score += VerifyInput(check.Swap("AA", "BB"), "BB", "AA");
            score += VerifyInput(check.Swap("Hej", "Ciao"), "Ciao", "Hej");
            score += VerifyInput(check.Swap("Katt", "Hund"), "Hund", "Katt");

            score += VerifyInput(check.LinQSum(2, 5, 23, 342, 12, 11, 24, 76), 495);
            score += VerifyInput(check.LinQAvg(2, 5, 23, 342, 12, 11, 24, 76), 61.875);

            score += VerifyInput(check.SortText("marcus"), "acmrsu");
            score += VerifyInput(check.SortText("jultomten"), "ejlmnottu");

            score += VerifyInput(check.FindWord(3, "Katt", "Hund", "Ros", "Röd ros", "Jultomte"), "Ros");
            score += VerifyInput(check.FindWord(5, "Elefant", "Tidtabell", "Planering", "Musik", "Spotify"), "Musik");

            score += VerifyInput(check.LinQHiscore(100, 32, 127, 95, 47, 89, 112), 127);
            score += VerifyInput(check.LinQWorstPlayer(100, 32, 127, 95, 47, 89, 112), 32);
            score += VerifyInput(check.IsLeet(100, 1773, 127, 95, 47, 89, 112), true);

            return Math.Round((double)score / max * 100);
        }

        private static int DoCheckBox(int v)
        {
            var gui = new ConsoleGUI();
            gui.PrintAt(NiceDebug.StartX - 4, NiceDebug.StartY - 1, v == 0 ? "[ ]" : "[X]");
            return v;
        }

        /// <summary>
        /// Poängsätter resultat.
        /// </summary>
        /// <param name="v1">Kontrollvärde 1</param>
        /// <param name="v2">Kontrollvärde 2</param>
        /// <returns>Poäng, 1 om OK, 0 om det inte stämmer.</returns>
        private static int VerifyInput(bool v1, bool v2)
        {
            return DoCheckBox(v1 == v2 ? 1 : 0);
        }

        /// <summary>
        /// Poängsätter resultat.
        /// </summary>
        /// <param name="p">värdet som ska kollas</param>
        /// <param name="v1">Kontrollvärde 1</param>
        /// <param name="v2">Kontrollvärde 2</param>
        /// <returns>Poäng, 1 om OK, 0 om det inte stämmer.</returns>
        private static int VerifyInput((int, int) p, int v1, int v2)
        {
            return DoCheckBox((p.Item1 == v1 && p.Item2 == v2) ? 1 : 0);
        }

        /// <summary>
        /// Poängsätter resultat.
        /// </summary>
        /// <param name="p">värdet som ska kollas</param>
        /// <param name="v1">Kontrollvärde 1</param>
        /// <param name="v2">Kontrollvärde 2</param>
        /// <returns>Poäng, 1 om OK, 0 om det inte stämmer.</returns>
        private static int VerifyInput((string, string) p, string v1, string v2)
        {
            return DoCheckBox((p.Item1 == v1 && p.Item2 == v2) ? 1 : 0);
        }

        /// <summary>
        /// Poängsätter resultat.
        /// </summary>
        /// <param name="a">Resultat.</param>
        /// <param name="b">Förväntad resultat.</param>
        /// <returns>Poäng, 1 om OK, 0 om det inte stämmer.</returns>
        private static int VerifyInput(DateTime a, DateTime b) => DoCheckBox(a.Equals(b) ? 1 : 0);

        /// <summary>
        /// Poängsätter resultat.
        /// </summary>
        /// <param name="a">Resultat.</param>
        /// <param name="b">Förväntad resultat.</param>
        /// <returns>Poäng, 1 om OK, 0 om det inte stämmer.</returns>
        private static int VerifyInput(string a, string b) => DoCheckBox(a == b ? 1 : 0);

        /// <summary>
        /// Poängsätter resultat.
        /// </summary>
        /// <param name="a">Resultat.</param>
        /// <param name="b">Förväntad resultat.</param>
        /// <returns>Poäng, 1 om OK, 0 om det inte stämmer.</returns>
        private static int VerifyInput((int, int) a, (int, int) b) => DoCheckBox(a == b ? 1 : 0);

        /// <summary>
        /// Poängsätter resultat.
        /// </summary>
        /// <param name="a">Resultat.</param>
        /// <param name="b">Förväntad resultat.</param>
        /// <returns>Poäng, 1 om OK, 0 om det inte stämmer.</returns>
        private static int VerifyInput(int a, int b) => DoCheckBox(a == b ? 1 : 0);

        /// <summary>
        /// Poängsätter resultat.
        /// </summary>
        /// <param name="a">Resultat.</param>
        /// <param name="b">Förväntad resultat.</param>
        /// <returns>Poäng, 1 om OK, 0 om det inte stämmer.</returns>
        private static int VerifyInput(double a, double b) => DoCheckBox(a == b ? 1 : 0);
    }
}