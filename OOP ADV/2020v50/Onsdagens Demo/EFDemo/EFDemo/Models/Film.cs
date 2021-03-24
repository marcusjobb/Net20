using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Models
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string EngTitel { get; set; }
        public int Betyg { get; set; }
        public int Url { get; set; }
        public string Genre { get; set; }
    }
}
