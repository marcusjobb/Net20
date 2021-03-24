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
    public class Tenant
    {
        
        public int ID { get; set; }

        public string Name { get; set; }

        public int IDTag { get; set; }

        public int IDApartment { get; set; }

    }
}
