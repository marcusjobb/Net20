namespace EFStarWarsFamilyTree.Database
{
    using EFStarWarsFamilyTree.Models;

    using Microsoft.EntityFrameworkCore;

    using System.IO;

    internal class StarWarsFamilyTree : DbContext
    {
        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myDocs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(myDocs, "Databases");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, "StarWarsFamilyTree.db");

            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}