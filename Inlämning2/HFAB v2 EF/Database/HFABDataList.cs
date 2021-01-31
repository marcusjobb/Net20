namespace HFAB_v2_EF.Database
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.IO;

    internal class HFABDataList : DbContext
    {
        public string DatabaseFile { get; set; } = "HFABLogg.db";

        public DbSet<Models.DoorName> DoorNames { get; set; }
        public DbSet<Models.Event> Events { get; set; }
        public DbSet<Models.Location> Locations { get; set; }
        public DbSet<Models.Logg> Loggs { get; set; }
        public DbSet<Models.Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "VSDatabase");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DatabaseFile);

            optionsBuilder.UseSqlite("Data Source = " + path + ";");
        }
    }
}