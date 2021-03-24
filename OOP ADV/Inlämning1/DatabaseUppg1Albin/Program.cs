using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DatabaseUppg1Albin
{
    class Program
    {
        // Main metoden är minimal och kallar på andra metoder.
        public static void Main(string[] args)
        {
            GenerateDB.SkapaDB();
            UserInterface.Interface();
        }
    }
}