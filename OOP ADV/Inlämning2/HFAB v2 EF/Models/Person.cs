namespace Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tag { get; set; }
        public virtual Location Location { get; set; }
    }
}