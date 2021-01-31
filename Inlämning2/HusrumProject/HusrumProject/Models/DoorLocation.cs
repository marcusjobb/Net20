namespace HusrumProject.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class DoorLocation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Name { get; set; }
    }
}