namespace HusrumProject.Database
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.IO;

    internal class DatabaseFilePath : DbContext
    {
        private static string DatabaseFile { get; set; } = @"DoorsEventLog.db";

        public DbSet<Models.Tenant> Tenants { get; set; }
        public DbSet<Models.DoorLocation> DoorLocations { get; set; }
        public DbSet<Models.DoorEvent> DoorEvents { get; set; }
        public DbSet<Models.DoorName> DoorNames { get; set; }
        public DbSet<Models.EventLog> EventLogs { get; set; }

        /// <summary>
        /// Configure database and location
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment
                .GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path
                .Combine(path, "HusrumDatabase");
            Directory
                .CreateDirectory(path);
            path = Path
                .Combine(path, DatabaseFile);

            optionsBuilder
                .UseSqlite(@"Data Source = " + path + ";");
        }
    }
}