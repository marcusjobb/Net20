namespace ooa_2_husrum_ef.Models
{
  using System;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  /// <summary>
  /// An occurance of a tag interacting with a door. 
  /// </summary>
  public class LogEntry
  {
    [Key, Column(Order = 0)]
    public DateTime When { get; set; }

    [Key, ForeignKey("Tag"), Column(Order = 1)]
    public string TagId { get; set; }

    [ForeignKey("Door"), Column(Order = 2)]
    public string DoorId { get; set; }

    [ForeignKey("Event"), Column(Order = 3)]
    public string EventId { get; set; }

    public virtual Tag Tag { get; set; }
    public virtual Door Door { get; set; }
    public virtual Event Event { get; set; }
  }
}
