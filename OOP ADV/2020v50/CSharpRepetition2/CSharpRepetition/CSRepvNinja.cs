namespace CSharpRepetition.Net20.MarcusMedina
{
    using CSharpRepetition.MarcusKod;

    /// <summary>
    /// Testa dina kodninjakunskaper
    /// </summary>
    public class CSRepvNinja
    {
        /// <summary>
        /// Du kommer att få en array med 3 rader och 3 tecken i var rad, och symbol för spelaren
        /// Det är spelplanen för luffarshack. Du kommer även att på coordinater
        /// för nästa drag som X gör.
        /// Spelaren vinner om tre av samma symbol ligger i rad, vertikalt, horizontellt eller diagonalt
        /// 
        /// Planen kan se ut såhär
        ///
        ///  rows[0]="XOX
        ///  rows[1]=" OX"
        ///  rows[2]="X O"
        ///
        /// Om X vinner ska metoden returnera "X wins"
        /// Om O vinner ska metoden returnera "O wins"
        /// Om positionen som önskas är redan upptagen ska metoden returnera "error"
        /// Om avgjort ska metoden returnera "draw"
        /// Om inte alla rutor är fyllda och ingen har vunnit ska metoden returnera en "next move"
        ///
        /// </summary>
        /// <param name="rows">rader med spelplan</param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="player">Spelarens symbol</param>
        /// <returns></returns>
        public string TicTacToe(string[] rows, int row, int col, char player)
        {
            var resultat = string.Empty;
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis($"TicTacToe : {resultat}");
            return resultat;
        }
    }
}