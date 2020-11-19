#pragma warning disable RCS1163 // Unused parameter.
#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable RCS1118 // Mark local variable as const.
namespace CSharpRepetition.Net20.MarcusMedina
{
    using CSharpRepetition.MarcusKod;

    using System;

    /// <summary>
    /// Testa dina avancerade kunskaper i C#.
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

            int resultat = 0;

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"Antal dagar : {resultat}");
            return resultat;
        }

        /// <summary>
        /// Den här metoden lägger till x antal månader till det datumet som skickats in.
        /// </summary>
        /// <param name="date">The date<see cref="DateTime"/>.</param>
        /// <param name="month">The month<see cref="int"/>.</param>
        /// <returns>Det nya datumet.</returns>
        public DateTime LäggTillMånad(DateTime date, int month)
        {
            DateTime resultat = new DateTime();
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

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
        /// <returns>Ny sträng med bokstäverna blandade.</returns>
        public string VarannanBokstav(string first, string second)
        {
            string resultat = "";

            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"Bokstäver   : {resultat}");
            return resultat;
        }
    }
}
#pragma warning restore RCS1118 // Mark local variable as const.
#pragma warning restore IDE0060 // Remove unused parameter
#pragma warning restore RCS1163 // Unused parameter.
