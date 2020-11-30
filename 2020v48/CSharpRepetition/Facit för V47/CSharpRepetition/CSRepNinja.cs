namespace CSharpRepetition.Net20.MarcusMedina
{
    using CSharpRepetition.MarcusKod;

    using System;
    using System.Text;

    /// <summary>
    /// Testa dina kodninjakunskaper
    /// </summary>
    public class CSRepNinja
    {
        /// <summary>
        /// Den här metoden krypterar en textsträng enligt Caesarchiffer,
        /// enbart åäö, bokstäver, siffror, punkt, komma och mellanslag är godkända
        /// för input, övrigt ska ignoreras
        /// Nyckeln talar om hur många positioner en bokstav eller ett nummer ska flyttas
        /// nyckel:3 --> a=c, b=d, c=e
        /// </summary>
        /// <param name="code">Text som ska krypteras</param>
        /// <param name="key">Nyckel som ska användas till kryptering</param>
        /// <returns>Krypterad sträng</returns>
        public string Caesarchiffer(string code, int key)
        {
            string resultat = "";
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------
            var chars = new StringBuilder();
            for (int i = 'a'; i <= 'z'; i++) { chars.Append((char)i); }
            chars.Append("åäö");
            chars.Append(chars.ToString().ToUpper());
            chars.Append("0123456789 .,");

            string allChars = chars.ToString();

            for (int i = 0; i < code.Length; i++)
            {
                var symbol = code[i];
                var pos = allChars.IndexOf(symbol);
                if (pos >= 0)
                {
                    pos += key;
                    if (pos >= allChars.Length) { pos -= allChars.Length; }
                    if (pos < 0) { pos += allChars.Length; }

                    resultat += (char)allChars[pos];
                }
            }

            // ---------------------------------------------------------------------------------
            NiceDebug.DebugThis("Caesar :" + resultat);
            return resultat;
        }
        /// <summary>
        /// Dechifrerar text
        /// </summary>
        /// <param name="code">Texten</param>
        /// <param name="key">Nyckel</param>
        /// <returns>Dechifrerad text</returns>
        public string Caesardechiffer(string code, int key)
        {
            // ---------------------------------------------------------------------------------
            // Skriv din kod nedan
            // ---------------------------------------------------------------------------------

            string resultat = Caesarchiffer(code, -key);

            // ---------------------------------------------------------------------------------
            return resultat;
        }
    }
}
