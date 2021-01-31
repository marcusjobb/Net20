namespace Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Name { get; set; }
    }
}