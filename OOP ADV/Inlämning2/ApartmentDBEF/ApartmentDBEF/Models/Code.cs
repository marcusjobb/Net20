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
    public class Code
    {
        
        public int ID { get; set; }

        public string Codes { get; set; }

        public string Explanation { get; set; }


    }
}
