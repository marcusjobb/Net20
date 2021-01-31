namespace ooa_2_husrum_ef.Models
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  /// <summary>
  /// A location with one or more doors and possibly tenants. 
  /// </summary>
  public class Location
  {
    [Key, Column(Order = 0)]
    public string Id { get; set; }

    public virtual ICollection<Tenant> Tenants { get; set; }
    public virtual ICollection<Door> Doors { get; set; }
  }
}
