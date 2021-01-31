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
    public class Event
    {
        
        public int ID { get; set; }

        public DateTime CreatedAt { get; set; }

        public int IDTag { get; set; }

        public int IDAction { get; set; }

        public int IDDoor { get; set; }

        public int IDCode { get; set; }

    }
}
