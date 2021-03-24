// ----------------------------------------------------------------------
// Awesome code by Marcus Medina (for educational purposes)
// © 2021, Codic Education, http://codic.se
// ----------------------------------------------------------------------

namespace TestingTheTests.Helpers
{
    using System;
    using TestingTheTests.Interfaces;

    /// <summary>
    /// Defines the <see cref="ConsoleWrapper" />.
    /// </summary>
    public class ConsoleWrapper : IConsole
    {
        /// <summary>
        /// The ReadLine override
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// The Write override
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public void Write(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// The WriteLine override
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
