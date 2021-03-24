namespace EFStarWarsFamilyTree.Models
{
    using EFStarWarsFamilyTree.Database;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics;
    using System.Linq;

    public class Person
    {
        [NotMapped]
        public Person Father
        {
            get
            {
                if (FatherId == null || FatherId == 0) return null;
                using var db = new StarWarsFamilyTree();
                return db.Person.FirstOrDefault(p => p.Id == FatherId);
            }
            set
            {
                FatherId = value == null ? (long?)null : value.Id;
            }
        }

        public Person Children
        {
            get
            {
                using var db = new StarWarsFamilyTree();
                return db.Person.FirstOrDefault(p => p.FatherId == Id || p.MotherId == Id);
            }
        }

        [ForeignKey(nameof(FatherId))]
        public long? FatherId { get; set; }

        [Key]
        public long Id { get; set; }

        [NotMapped]
        public Person Mother
        {
            get
            {
                if (MotherId == null || MotherId == 0) return null;
                using var db = new StarWarsFamilyTree();
                return db.Person.FirstOrDefault(p => p.Id == MotherId);
            }
            set
            {
                MotherId = value == null ? (long?)null : value.Id;
            }
        }

        [ForeignKey(nameof(MotherId))]
        public long? MotherId { get; set; }

        [DebuggerDisplay("{Name}")]
        public string Name { get; set; }
    }
}