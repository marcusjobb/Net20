namespace ooa_2_husrum_ef.Models
{
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  /// <summary>
  /// Resident of an apartment/location and owner of a tag. 
  /// </summary>
  public class Tenant
  {
    [Key, Column(Order = 0)]
    public string Id { get; set; }

    [Column(Order = 1)]
    public string Name { get; set; }

    [ForeignKey("Apartment"), Column(Order = 2)]
    public string ApartmentId { get; set; }

    public virtual Location Apartment { get; set; }
  }
}
