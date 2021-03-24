using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework_HFAB.Models
{
    public class Tenant
    {
        //Properties for the class
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Tag { get; set; }   
    
    }
}
