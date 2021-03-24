using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework_HFAB.Models
{
    class Door
    {
        //Properties for the class
        [Key]
        public int ID { get; set; }
        public string DoorName { get; set; }
        public string Location { get; set; }

    }
}
