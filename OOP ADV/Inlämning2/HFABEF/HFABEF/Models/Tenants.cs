using System.ComponentModel.DataAnnotations;

namespace HFABEF.Models
{
    public class Tenants
    {
        [Key]
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Tenant { get; set; }
        public string Location { get; set; }
    }
}