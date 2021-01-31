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
    public class Door
    {
        
        public int ID { get; set; }

        public string Doorname { get; set; }

        public string Explanation { get; set; }

        public int ApartmentID { get; set; }


    }
}
