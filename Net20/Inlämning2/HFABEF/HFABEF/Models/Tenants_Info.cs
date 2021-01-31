using System.ComponentModel.DataAnnotations;

namespace HFABEF.Models
{
    public class Tenants_Info
    {
        [Key]
        public string Name { get; set; }
        public string Info { get; set; }
    }
}