namespace IU2_Test.Database
{
    using IU2_Test.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.IO;
    public class MyDatabase : DbContext
    {
        /// <summary>
        /// DatabasFile ger namnet på databasfilen.
        /// Som läggs i mappen "Test Databaser"
        /// </summary>
        public static string DatabaseFile { get; set; } = @"HFAB_DB.db";
        /// <summary>
        /// Nedan (DbSet) definieras tabellerna i databasen.
        /// DbSet<Klassen> <-- Namnges i plural.
        /// Modellerna namnges i singular.
        /// </summary>
        public DbSet<Tenant> Tenants { get; set; }     
        public DbSet<DoorType> DoorTypes { get; set; } 
        public DbSet<Event> Events { get; set; }       
        public DbSet<Relation> Relations { get; set; } 

        /// <summary>
        /// Nedan definieras vart vi ska skapa databas mappen,
        /// Databasen skapas i Mina dokument filen.
        /// </summary>
        /// <param name="optionsBuilder">Connection sträng.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "Test Databaser");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DatabaseFile);

            optionsBuilder.UseSqlite(@"Data Source = " + path + ";");
        }
    }
}
