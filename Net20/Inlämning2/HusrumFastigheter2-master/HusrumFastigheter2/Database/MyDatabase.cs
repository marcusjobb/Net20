using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HusrumFastigheter2.Database
{
    class MyDatabase : DbContext
    {
        static string DatabaseFile { get; set; } = @"DataLog.db";

        public DbSet<Models.Door> Doors { get; set; }
        
        public DbSet<Models.Event> Events { get; set; }

        public DbSet<Models.Location> Locations { get; set; }

        public DbSet<Models.Tenant> Tenants { get; set; }

        public DbSet<Models.Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "VSDatabase");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DatabaseFile);

            optionsBuilder.UseSqlite(@"Data Source = " + path + ";");
        }
    }
}
