using System.ComponentModel.DataAnnotations;

namespace HFABEF.Models
{
    public class Event
    {
        [Key]
        public string Code { get; set; }
        public string Explanation { get; set; }
    }
}