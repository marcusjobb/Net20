namespace TestingTheTests
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="StringHelper" />.
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// The GetWord.
        /// </summary>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <param name="x">The x<see cref="int"/>.</param>
        /// <param name="separator">The separator<see cref="char"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetWord(string text, int x, char separator = ' ')
        {
            if (x < 0 || string.IsNullOrEmpty(text)) return "";

            var split = text.Split(separator);

            return x >= split.Length ? "" : split[x];
        }

        /// <summary>
        /// The StringToList.
        /// </summary>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <param name="separator">The separator<see cref="char"/>.</param>
        /// <returns>The <see cref="List{string}"/>.</returns>
        public List<string> StringToList(string text, char separator = ' ')
        {
            if (string.IsNullOrEmpty(text)) return new List<string>();
            return new List<string>(text.Split(separator));
        }
    }
}
