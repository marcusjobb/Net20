using SaganLinq.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaganLinq.Database
{
    public class Sagan : DbContext
    {

        public DbSet<Händelse> Händelser { get; set; }
        public DbSet<Koppling> Koppling { get; set; }
        public DbSet<Person> Personer { get; set; }
        public DbSet<Sak> Saker { get; set; }
        static string DatabaseFile { get; set; } = @"sagan.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = " + DatabaseFile + ";");
        }
    }
}
