namespace HusrumProject.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class DoorEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Code { get; set; }
    }
}