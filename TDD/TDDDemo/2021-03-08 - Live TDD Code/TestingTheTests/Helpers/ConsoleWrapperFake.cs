// ----------------------------------------------------------------------
// Awesome code by Marcus Medina (for educational purposes)
// © 2021, Codic Education, http://codic.se
// ----------------------------------------------------------------------
namespace TestingTheTests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using TestingTheTests.Interfaces;

    /// <summary>Definition of <see cref="ConsoleWrapperFake" />.</summary>
    internal class ConsoleWrapperFake : IConsole
    {
        public string Output { get; set; }

        public List<String> LinesToRead = new List<String>
        {
            "Marcus","Robin","Jesper","Katt","345","127","1337"
        };

        public void Write(string message)
        {
            Output = message;
        }

        public void WriteLine(string message)
        {
            Output = message;
        }

        public string ReadLine()
        {
            string result = LinesToRead[0];
            LinesToRead.RemoveAt(0);
            return result;
        }
    }
}

