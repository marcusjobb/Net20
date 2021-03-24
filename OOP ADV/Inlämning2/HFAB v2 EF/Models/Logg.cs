namespace Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Logg
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Date { get; set; }
        public virtual DoorName Door { get; set; }
        public virtual Event Event { get; set; }
        public virtual Person Person { get; set; }
    }
}