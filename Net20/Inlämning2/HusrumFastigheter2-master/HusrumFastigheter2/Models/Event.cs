using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HusrumFastigheter2.Models
{
   public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ID { get; set; }

        public string Code { get; set; }
    }
}
