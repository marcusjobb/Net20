using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HusrumFastigheter2.Models
{
   public class Door
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public long ID { get; set; }

        public string DoorName { get; set; }
    }
}
