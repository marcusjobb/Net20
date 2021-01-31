using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentDBEF.Models
{
    public class Tag
    {
        
        public int ID { get; set; }

        public string Tagnumber { get; set; }

        public int IDTenant { get; set; }

        public int IDApartment { get; set; }

    }
}
