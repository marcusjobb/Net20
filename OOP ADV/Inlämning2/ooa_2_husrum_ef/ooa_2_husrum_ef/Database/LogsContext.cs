namespace ooa_2_husrum_ef.Database
{
  using Microsoft.EntityFrameworkCore;
  using ooa_2_husrum_ef.Models;
  using System;
  using System.IO;

  public class LogsContext : DbContext
  {
    #region DbSet entities
    public DbSet<Access> Accesses { get; set; }
    public DbSet<Door> Doors { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<LogEntry> LogEntries { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Tenant> Tenants { get; set; } 
    #endregion

    private static string DbFileName { get; set; } = @"DoorEventsLog.db";
    private static string DbFolderName { get; set; } = @"DoorEventsLogDB";

    public LogsContext() : base() 
    {
    }

    /// <summary>
    /// Setup folder, file, and connection string for db. 
    /// </summary>
    /// <param name="optionsBuilder">API for configuring db options.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // Set path for connection string.
      string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      string path = Path.Combine(myDocs, DbFolderName);
      Directory.CreateDirectory(path);
      path = Path.Combine(path, DbFileName);

      // Connection string
      optionsBuilder.UseSqlite($"filename = {path}");
    }

    /// <summary>
    /// Database/entities definition and relations setup. 
    /// </summary>
    /// <param name="modelBuilder">Fluent API builder object</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Composite primary keys.
      modelBuilder.Entity<Access>()
        .HasKey(a => new { a.TagId, a.DoorId });

      modelBuilder.Entity<LogEntry>()
        .HasKey(a => new { a.TagId, a.When });
    }
  }
}
