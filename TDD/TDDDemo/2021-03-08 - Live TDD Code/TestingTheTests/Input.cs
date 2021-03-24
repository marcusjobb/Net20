namespace TestingTheTests
{
    using System;

    /// <summary>
    /// Defines the <see cref="InputHandler" />.
    /// </summary>
    public class InputHandler
    {
        /// <summary>
        /// Gets or sets the Input.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// The AskForInfo.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public void AskForInfo(string message)
        {
            Console.Write(message);
            Input = Console.ReadLine();
        }
    }
}
