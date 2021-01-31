namespace Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Code { get; set; }
    }
}