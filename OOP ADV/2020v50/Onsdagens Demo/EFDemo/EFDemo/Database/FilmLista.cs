using Microsoft.EntityFrameworkCore;

using System;
using System.IO;

namespace EFDemo.Database
{
    public class FilmLista:DbContext
    {
        public string DatabaseFile { get; set; } = "MinaFilmer.db";

        public DbSet<Models.Film> Filmer { get; set; }

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
