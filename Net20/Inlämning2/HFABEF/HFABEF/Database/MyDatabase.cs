using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace HFABEF.Database
{
    public class MyDatabase : DbContext
    {
        private static string DatabaseFile { get; } = "HFABEF.db"; //<-- databasens namn

        public DbSet<Models.Door_Explanation> Door_Explanation { get; set; }
        public DbSet<Models.Doors> Doors { get; set; }
        public DbSet<Models.Event> Event { get; set; }
        public DbSet<Models.Logs> Logs { get; set; }
        public DbSet<Models.Tenants> Tenants { get; set; }
        public DbSet<Models.Tenants_Info> Tenants_Info { get; set; }

        /// <summary>
        /// Metod som hanterar path till databasen samt data source
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //<-- My documents
            path = Path.Combine(path, "VSDatabase");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DatabaseFile);

            optionsBuilder.UseSqlite("Data Source = " + path + ";");
        }
    }
}