using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaganLinq.Models
{
    public class Koppling
    {
        public int ID { get; set; }
        public int Person1{ get; set; }
        public int Person2 { get; set; }
        public int Sak { get; set; }
        public int Handling { get; set; }

    }
}
