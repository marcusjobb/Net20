namespace CSharpRepetition.Net20.MarcusMedina
{
    using CSharpRepetition.MarcusKod;

    using System.Linq;

    /// <summary>
    /// Testa dina avancerade kunskaper i C#
    /// </summary>
    public class CSRepAvancerad
    {
        /// <summary>
        /// Hitta ordet som har en angiven längd, använd gärna LinQ
        /// </summary>
        /// <param name="words">Texten som ska sorteras</param>
        /// <param name="length">Längden på ordet vi söker</param>
        /// <returns>Det utvalda ordet</returns>
        public string FindWord(int length, params string[] words)
        {
            string magicWord = "";
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"FindWord    : {magicWord}");
            return magicWord;
        }

        /// <summary>
        /// Du får en serie med tal och du ska se om talserien är Leet (innehåller 1337)
        /// använd gärna LinQ
        /// </summary>
        /// <param name="numbers">Talen som ska kollas</param>
        /// <returns><see langword="true"/>om det är leet!</returns>
        public bool IsLeet(params int[] numbers)
        {
            bool isLeet = false;
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"IsLeet      : {isLeet}");
            return isLeet;
        }

        /// <summary>
        /// Ordna talen i storleksordning, den minsta först
        /// </summary>
        /// <param name="num1">Första talet</param>
        /// <param name="num2">Andra talet</param>
        /// <returns>Ny sträng med bokstäverna blandade</returns>
        public (int num1, int num2) LessIsFirst(int num1, int num2)
        {
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"LessIsFirst : {num1} & {num2}");
            return (num1, num2);
        }

        /// <summary>
        /// Räkna ut medelvärdet av talen som skickas in, använd LinQ för detta
        /// </summary>
        /// <param name="numbers">Tal som skickas in</param>
        /// <returns>Summan</returns>
        public double LinQAvg(params int[] numbers)
        {
            double avg = 0;
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------


            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"Average     : {avg}");
            return avg;
        }

        /// <summary>
        /// Du får en lista med poäng från olika spelare, välj det högsta värdet, använd LinQ för detta
        /// </summary>
        /// <param name="numbers">Tal som skickas in</param>
        /// <returns>Hi score!</returns>
        public int LinQHiscore(params int[] numbers)
        {
            int max = 0;
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------


            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"Highscore   : {max}");
            return max;
        }

        /// <summary>
        /// Räkna ut summan av talen som skickas in, använd LinQ för detta
        /// </summary>
        /// <param name="numbers">Tal som skickas in</param>
        /// <returns>Summan</returns>
        public int LinQSum(params int[] numbers)
        {
            int sum = 0;
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"Summa       : {sum}");
            return sum;
        }

        /// <summary>
        /// Du får en lista med poäng från olika spelare, välj det lägsta värdet, använd LinQ för detta
        /// </summary>
        /// <param name="numbers">Tal som skickas in</param>
        /// <returns>Worst score!</returns>
        public int LinQWorstPlayer(params int[] numbers)
        {
            int worst = 0;
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"Worst Score : {worst}");
            return worst;
        }

        /// <summary>
        /// Sortera bokstäverna i ett ord som skickas in, använd gärna LinQ
        /// </summary>
        /// <param name="text">Texten som ska sorteras</param>
        /// <returns>Den sorteade texten</returns>
        public string SortText(string text)
        {
            string sortedText = "";
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------


            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"SortText    : {sortedText}");
            return sortedText;
        }

        /// <summary>
        /// En klassiker, den byt plats på två variabler
        /// </summary>
        /// <param name="textA">Text som ska byta plats</param>
        /// <param name="textB">Text som ska byta plats</param>
        /// <returns>Texter som bytt plats</returns>
        public (string, string) Swap(string textA, string textB)
        {
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------


            // ---------------------------------------------------------------------------------

            NiceDebug.DebugThis($"Swap        : {textA} <-> {textB}");
            return (textA, textB);
        }
    }
}