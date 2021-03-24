namespace CSharpRepetition.Net20.MarcusMedina
{
    using CSharpRepetition.MarcusKod;

    using System;
    using System.Text;

    /// <summary>
    /// Definiton av <see cref="Checka" />.
    /// </summary>
    public static class Checka
    {
        /// <summary>
        /// Testar dina grundkunskaper.
        /// </summary>
        /// <param name="debugX">Debugtext position<see cref="int"/>.</param>
        /// <returns>Procentvärde av resultat.</returns>
        public static double Grund(int debugX = 7)
        {
            const int max = 10;
            int score = 0;
            CSRepGrund check = new CSRepGrund();
            NiceDebug.Reset(debugX);

            score += VerifyInput(check.SummeraText("112"), 4);
            score += VerifyInput(check.SummeraText("2+4=4"), 10);
            score += VerifyInput(check.SummeraText("marcus1970@mail4ever.com"), 21);
            score += VerifyInput(check.SummeraText("54.3"), 12);

            score += VerifyInput(check.Medelvärde(1, 4, 8, 12, 43, 12), 13);
            score += VerifyInput(check.Medelvärde(22, 32, 45, 67, 89, 11), 44);
            score += VerifyInput(check.Medelvärde(99, 44, 33, 22, 10), 41);
            score += VerifyInput(check.Medelvärde(10, 20), 15);

            score += VerifyInput(check.MinimiOchMaximiVärde(25, 234, 11, 4, 22), (4, 234));
            score += VerifyInput(check.MinimiOchMaximiVärde(-4, -22, -11, 0, 3), (-22, 3));

            return Math.Round((double)score / max * 100);
        }

        /// <summary>
        /// Testar dina ninjakunskaper.
        /// </summary>
        /// <param name="debugX">Debugtext position<see cref="int"/>.</param>
        /// <returns>Procentvärde av resultat.</returns>
        public static double Ninja(int debugX = 86)
        {
            Random rnd = new Random();
            const int max = 8;
            int score = 0;

            NiceDebug.Reset(debugX);
            score += Test("Doctor Who", rnd.Next(0, 29));
            score += Test("Doctor Strange", rnd.Next(0, 29));
            score += Test("Doctor Watson", rnd.Next(0, 29));
            score += Test("ZipaDee DooDah", -rnd.Next(0, 29));
            score += Test("Den spanska räven rev en annan räv", -rnd.Next(0, 29));
            score += Test("The quick brown fox jumps over the lazy dog", rnd.Next(0, 29));
            score += Test("Baskervilles hund", rnd.Next(0, 29));

            StringBuilder evilCheck = new StringBuilder("Flygande bäckasiner söka hwila på mjuka tuvor");
            for (int weird = 0; weird < evilCheck.Length; weird++)
            {
                evilCheck[weird] = rnd.Next(2) == 0 ?
                    evilCheck[weird].ToString().ToUpper()[0] :
                    evilCheck[weird].ToString().ToLower()[0];
            }

            score += Test(evilCheck.ToString(), rnd.Next(0, 29));

            return Math.Round((double)score / max * 100);
        }

        /// <summary>
        /// Testar chiffer
        /// </summary>
        /// <param name="code">Texten<see cref="string"/>.</param>
        /// <param name="key">Nyckeln<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        private static int Test(string code, int key)
        {
            CSRepNinja check = new CSRepNinja();
            string encoded = check.Caesarchiffer(code, key);
            string decoded = check.Caesardechiffer(encoded, key);
            return DoCheckBox(code == decoded ? 1 : 0);
        }

        /// <summary>
        /// Testar dina avancerade kunskaper.
        /// </summary>
        /// <param name="debugX">Debugtext position<see cref="int"/>.</param>
        /// <returns>Procentvärde av resultat.</returns>
        internal static double Avancerad(int debugX = 46)
        {
            const int max = 11;
            int score = 0;
            NiceDebug.Reset(debugX);
            CSRepAvancerad check = new CSRepAvancerad();
            score += VerifyInput(check.VarannanBokstav("Katt", "Hund"), "KHautntd");
            score += VerifyInput(check.VarannanBokstav("Nelson", "Mandela"), "NMealnsdoenla");
            score += VerifyInput(check.VarannanBokstav("Sherlock", "Holmes"), "SHhoelrmleosck");

            score += VerifyInput(check.AntalDagar(new DateTime(2020, 11, 18), new DateTime(2020, 12, 24)), 36);
            score += VerifyInput(check.AntalDagar(new DateTime(2020, 11, 18), new DateTime(2021, 12, 24)), 401);
            score += VerifyInput(check.AntalDagar(new DateTime(2020, 11, 11), new DateTime(2020, 12, 12)), 31);
            score += VerifyInput(check.AntalDagar(new DateTime(2020, 11, 18), new DateTime(2021, 1, 1)), 44);
            score += VerifyInput(check.AntalDagar(new DateTime(2021, 1, 1), new DateTime(2020, 1, 1)), -366);

            score += VerifyInput(check.LäggTillMånad(new DateTime(2020, 11, 18), 5), new DateTime(2021, 4, 18));
            score += VerifyInput(check.LäggTillMånad(new DateTime(2021, 11, 18), 2), new DateTime(2022, 01, 18));
            score += VerifyInput(check.LäggTillMånad(new DateTime(2021, 11, 18), -2), new DateTime(2021, 9, 18));

            return Math.Round((double)score / max * 100);
        }

        /// <summary>
        /// Poängsätter resultat.
        /// </summary>
        /// <param name="a">Resultat.</param>
        /// <param name="b">Förväntad resultat.</param>
        /// <returns>Poäng, 1 om OK, 0 om det inte stämmer.</returns>
        private static int VerifyInput(DateTime a, DateTime b) => DoCheckBox(a.Equals(b) ? 1 : 0);

        /// <summary>
        /// Rita en checkbox, ifylld om uppgiften är OK.
        /// </summary>
        /// <param name="text">Texten<see cref="int"/>.</param>
        /// <returns>Värde att utvärdera<see cref="int"/>.</returns>
        private static int DoCheckBox(int text)
        {
            ConsoleGUI gui = new ConsoleGUI();
            gui.PrintAt(NiceDebug.StartX - 4, NiceDebug.StartY - 1, text == 0 ? "[ ]" : "[X]");
            return text;
        }

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
    }
}