namespace TestingTheTests
{
    using System;
    using TestingTheTests.Helpers;
    using TestingTheTests.Interfaces;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The Main method
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
        {
            //UseIConsole();
            UseInputHandler();
        }

        /// <summary>
        /// The AskUserName method, initialized with an interface
        /// </summary>
        /// <param name="console">The console<see cref="IConsole"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string AskUserName(IConsole console)
        {
            return console.ReadLine();
        }

        /// <summary>
        /// Demo of UseIConsole 
        /// </summary>
        private static void UseIConsole()
        {
            IConsole c = new ConsoleWrapper();
            Console.WriteLine(AskUserName(c));

            c = new ConsoleWrapperFake();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(AskUserName(c));
            }
        }

        /// <summary>
        /// The UseInputHandler.
        /// </summary>
        private static void UseInputHandler()
        {
            var test = true;
            var i = new InputHandler();

            if (test)
                i.Input = "Katt";
            else
                i.AskForInfo("Your name:");

            Console.WriteLine("Hello " + i.Input);
        }
    }
}
