using System.ComponentModel.DataAnnotations;

namespace HFABEF.Models
{
    public class Doors
    {
        [Key]
        public string Door { get; set; }
        public string Location { get; set; }
    }
}