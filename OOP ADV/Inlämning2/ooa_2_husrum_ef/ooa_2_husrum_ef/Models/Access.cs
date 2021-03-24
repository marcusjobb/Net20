namespace ooa_2_husrum_ef.Models
{
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  /// <summary>
  /// Defines tags access to doors.
  /// </summary>
  public class Access
  {
    [Key, ForeignKey("Tag"), Column(Order = 0)]
    public string TagId { get; set; }
    [Key, ForeignKey("Door"), Column(Order = 1)]
    public string DoorId { get; set; }

    public virtual Tag Tag { get; set; }
    public virtual Door Door { get; set; }
  }
}
