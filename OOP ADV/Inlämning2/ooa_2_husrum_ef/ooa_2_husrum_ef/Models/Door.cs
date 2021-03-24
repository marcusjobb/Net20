namespace ooa_2_husrum_ef.Models
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  /// <summary>
  /// Door accessed by tags. 
  /// </summary>
  public class Door
  {
    [Key, Column(Order = 0)]
    public string Id { get; set; }

    [Column(Order = 1)]
    public string Description { get; set; }

    [ForeignKey("Location"), Column(Order = 2)]
    public string LocationId { get; set; }

    public virtual Location Location { get; set; }
    public virtual ICollection<LogEntry> LogEntries { get; set; }
  }
}
