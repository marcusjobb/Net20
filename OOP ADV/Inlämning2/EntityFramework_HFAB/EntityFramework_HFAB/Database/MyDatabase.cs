using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EntityFramework_HFAB.Database
{
    class MyDatabase : DbContext
    {
        /// <summary>
        /// Creates a DB in MyFolder on user computer
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myDocs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(myDocs, "EFDatabases");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, "HRAB.db");
            var password = "";
            if (File.Exists("MyDatabase.Password.txt"))
                password = File.ReadAllText("MyDatabase.Password.txt");

            optionsBuilder.UseSqlite("Filename=" + path);
        }

        //Properties for the class
        public DbSet<Models.Tenant> Tenants { get; set; }
        public DbSet<Models.Door> Doors { get; set; }
        public DbSet<Models.Event> Events { get; set; }
        public DbSet<Models.LogEntry> LogEntries { get; set; }
    }
}
