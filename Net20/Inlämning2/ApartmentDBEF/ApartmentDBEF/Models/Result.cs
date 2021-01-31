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
    public class Result
    {
        public string ID { get; set; }
        public string Time { get; set; }
        public string Tag { get; set; }
        public string Action { get; set; }
        public string Door { get; set; }
        public string Code { get; set; }
        public string Tenant { get; set; }
        public string Apartment { get; set; }
        public string Doorexp { get; set; }
        public string InorOut { get; set; }




    }
}
