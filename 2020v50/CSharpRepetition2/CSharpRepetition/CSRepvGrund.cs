namespace CSharpRepetition.Net20.MarcusMedina
{
    using CSharpRepetition.MarcusKod;

    /// <summary>
    /// Testa dina grundkunskaper i C#
    /// </summary>
    public class CSRepvGrund
    {
        /// <summary>
        /// En lärare ska räkna ut statistik på sina elever och behöver en metod som
        /// räknar antal G och VG som klassen fått
        /// Varning: Läraren är slarvig och skriver betygen G,VG,VG,g,G,vG, Gv osv
        /// Varning2: Läraren är en smula slarvig med bokstavsordning så VG kan mycket väl bli GV
        ///           eller vara V
        /// </summary>
        /// <param name="betyg">Betygen som ska kontrolleras</param>
        /// <returns>Antal elever som fick G och antal som fick VG.</returns>
        public (int, int) EleversBetyg(params string[] betyg)
        {
            int gBetyg = 0;
            int vgBetyg = 0;

            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"G & VG     : {gBetyg} & {vgBetyg}");
            return (gBetyg, vgBetyg);
        }

        /// <summary>
        /// Du får ett värden till en loop, varje runda loopen kör ska du
        /// lägga till tecknet i variabeln "symbol" till en sträng.
        /// length talar om för dig hur lång loopen ska vara (0 till length)
        /// skip talar om hur ofta du ska skippa att lägga till symbolen i strängen
        /// (Om skip är två ska symbolen inte läggas till varannan varv i loopen)
        /// (Om skip är fem ska symbolen inte läggas till femte varv i loopen)
        /// </summary>
        /// <param name="length">Längden på din loop</param>
        /// <param name="skipEvery">Efter hur många steg ska den skippa</param>
        /// <param name="symbol">Symbolen som ska läggas till i strängen</param>
        /// <returns>Strängen som genererats</returns>
        public string ForSkip(int length, int skipEvery, char symbol)
        {
            string retVal = string.Empty;
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis("ForSkip    : " + retVal);
            return retVal;
        }

        /// <summary>
        /// Du kommer att få en array med strängar och en int med max
        /// antal strängar du ska slå ihop
        /// Om du har arrayen {"Hej","Hallå","Bye","Ciao"]
        /// max 2 --> HejHallå
        /// max 3 --> HejHallåGoodbye
        /// OBS: Om du får ett max värde som är längre än arrayen får programmet
        /// inte krascha!
        /// max 500 -> HejHallåByeCiao
        /// </summary>
        /// <param name="max">Max antal värden i arrayen som ska behandlas</param>
        /// <param name="input">En array med olika antal värden som ska bearbetas</param>
        /// <returns>Summan av alla tal i strängen.</returns>
        public string FörstaVärden(int max, params string[] input)
        {
            string retVal = "";
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis("Första     : " + retVal);
            return retVal;
        }

        /// <summary>
        /// Skriv ordet baklänges
        /// </summary>
        /// <param name="ord">Ordet som ska vändas på</param>
        /// <returns></returns>
        public string VändPåOrdet(string ord)
        {
            string retVal = "";
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"Vänd Ordet : {retVal} ({ord})");
            return retVal;
        }
    }
}