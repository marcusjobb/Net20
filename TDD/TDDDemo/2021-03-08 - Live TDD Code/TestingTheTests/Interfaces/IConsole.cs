// ----------------------------------------------------------------------
// Awesome code by Marcus Medina (for educational purposes)
// © 2021, Codic Education, http://codic.se
// ----------------------------------------------------------------------

namespace TestingTheTests.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IConsole" />.
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// The ReadLine.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        string ReadLine();

        // Blatanty stolen from https://stackoverflow.com/a/3161371/15032536
        /// <summary>
        /// The Write.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        void Write(string message);

        /// <summary>
        /// The WriteLine.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        void WriteLine(string message);
    }
}
