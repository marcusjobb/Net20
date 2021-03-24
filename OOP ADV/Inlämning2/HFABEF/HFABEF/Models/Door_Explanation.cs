using System.ComponentModel.DataAnnotations;

namespace HFABEF.Models
{
    public class Door_Explanation
    {
        [Key]
        public string Door_Name { get; set; }
        public string Explanation { get; set; }
    }
}
