namespace HusrumProject.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string DateTime { get; set; }
        public virtual DoorName DoorName { get; set; }
        public virtual DoorEvent DoorEvent { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}