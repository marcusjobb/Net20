using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentDBEF.Database
{
    class ApartmentDB : DbContext
    {

        // Sträng som talar om vad filnamnet på databasen.
        public string databaseLocation { get; set; } = "ApartmentDBEF.db";


        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<Models.Apartment> Apartments { get; set; }
        public DbSet<Models.Code> Codes { get; set; }
        public DbSet<Models.Door> Doors { get; set; }
        public DbSet<Models.Event> Events { get; set; }
        public DbSet<Models.Tag> Tags { get; set; }
        public DbSet<Models.Tenant> Tenants { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "VSDatabase");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, databaseLocation);


            optionsBuilder.UseSqlite(@"Data Source = " + path + ";");




        }
    }

}