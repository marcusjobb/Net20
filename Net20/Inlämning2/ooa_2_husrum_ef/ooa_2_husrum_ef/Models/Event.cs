namespace ooa_2_husrum_ef.Models
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  /// <summary>
  /// Describes what happened when a tag interacted with a door. 
  /// </summary>
  public class Event
  {
    [Key, Column(Order = 0)]
    public string Id { get; set; }

    [Column(Order = 1)]
    public string Description { get; set; }

    public virtual ICollection<LogEntry> LogEntries { get; set; }
  }
}
