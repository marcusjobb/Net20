namespace HusrumProject.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tenant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string TenantTag { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual DoorLocation Location { get; set; }
    }
}