using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework_HFAB.Models
{
    class LogEntry
    {
        //Properties for the class
        [key]
        public int ID { get; set; }
        public string Date { get; set; }
        public string Door { get; set; }
        public string Tag { get; set; }
        public string Event { get; set; }

    }
}
