using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework_HFAB.Models
{
    class Event
    {
        //Properties for the class
        [Key]
        public int ID { get; set; }
        public string EventName { get; set; }

    }
}
