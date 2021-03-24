using System.ComponentModel.DataAnnotations;

namespace HFABEF.Models
{
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        public Tenants Tenant { get; set; }
        public Doors Door { get; set; }
        public Event Event { get; set; }
        public string Date { get; set; }
    }
}