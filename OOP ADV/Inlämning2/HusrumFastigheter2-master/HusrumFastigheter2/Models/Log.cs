using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HusrumFastigheter2.Models
{
   public class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ID { get; set; }

        public string Date { get; set; }

        public virtual Door Door { get; set; }

        public virtual Event Event { get; set; }

        public virtual Tenant Tenant { get; set; }

    }
}
