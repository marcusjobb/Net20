namespace CSharpRepetition.Net20.MarcusMedina
{
    using CSharpRepetition.MarcusKod;

    using System;

    /// <summary>
    /// Testa dina avancerade kunskaper i C#
    /// </summary>
    public class CSRepAvancerad
    {
        /// <summary>
        /// The AntalDagar.
        /// </summary>
        /// <param name="start">Startdatum<see cref="DateTime"/>.</param>
        /// <param name="slut">Slutdatum<see cref="DateTime"/>.</param>
        /// <returns>Antal dagar - <see cref="int"/>.</returns>
        public int AntalDagar(DateTime start, DateTime slut)
        {
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            var dagar = slut - start;
            var resultat = dagar.Days;

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"Antal dagar : {resultat}");
            return resultat;
        }

        /// <summary>
        /// Den här metoden lägger till x antal månader till det datumet som skickats in
        /// </summary>
        /// <returns>Det nya datumet</returns>
        public DateTime LäggTillMånad(DateTime date, int month)
        {
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            var resultat = date.AddMonths(month);

            // ---------------------------------------------------------------------------------

            NiceDebug.DebugThis($"Datum       : {resultat}");
            return resultat;
        }

        /// <summary>
        /// Den här metoden ska ta trå strängar och addera dem
        /// varannan bokstav,
        /// Exempel: Katt,Hund = KHautntd.
        /// </summary>
        /// <param name="first">Första ordet<see cref="string"/>.</param>
        /// <param name="second">Andra ordet<see cref="string"/>.</param>
        /// <returns>Ny sträng med bokstäverna blandade</returns>
        public string VarannanBokstav(string first, string second)
        {
            string resultat = "";

            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------
            var max = first.Length < second.Length ? second.Length : first.Length;
            for (int i = 0; i < max; i++)
            {
                if (first.Length > i) { resultat += first[i]; }
                if (second.Length > i) { resultat += second[i]; }
            }
            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"Bokstäver   : {resultat}");
            return resultat;
        }
    }
}
