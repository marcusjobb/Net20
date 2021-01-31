namespace IU2_Test.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tenant
    {
        /// <summary>
        /// Tabellen Tenants skapas i DB.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string ApartmentNum { get; set; }
    }
}
