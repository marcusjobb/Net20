using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HusrumFastigheter2.Models
{
    public class Tenant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Tag { get; set; }

        public Location Location{ get; set; }
    }
}
