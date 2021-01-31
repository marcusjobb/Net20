namespace IU2_Test.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Relation
    {
        /// <summary>
        /// Kopplingstabell i databasen.
        /// Hämtar klasserna och de får en ID i databasen.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public long ID { get; set; }
        public Tenant tenant { get; set; }
        public DoorType doorType { get; set; }
        public Event eventType { get; set; }
        public string Date { get; set; }
    }
}
