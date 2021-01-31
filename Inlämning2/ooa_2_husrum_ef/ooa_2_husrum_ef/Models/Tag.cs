namespace ooa_2_husrum_ef.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  /// <summary>
  /// A tag identifies a tenant who wishes to interact with a door. 
  /// </summary>
  public class Tag
  {
    [Key, Column(Order = 0)]
    public string Id { get; set; }

    [ForeignKey("Tenant"), Column(Order = 1)]
    public string TenantId { get; set; }

    [Column(Order = 2)]
    public DateTime? Activate { get; set; }

    [Column(Order = 3)]
    public DateTime? Expire { get; set; }

    public virtual Tenant Tenant { get; set; }
    public virtual ICollection<LogEntry> LogEntries { get; set; }
  } 
}
