using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DbModels
{
    [Index(nameof(Name), IsUnique = true)]
    public class Pass
    {
        public DateTime? AccessTimeFrom { get; set; }
        public DateTime? AccessTimeTo { get; set; }

        [ForeignKey("AddedByUser")]
        public int? AddedBy { get; set; }

        public virtual User AddedByUser { get; set; }
        public bool? AskAddEntry { get; set; }
        public bool Continuation { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public DateTime? DateModified { get; set; }

        [Required]
        public string Description { get; set; }

        public int EentryNumberOfMonths { get; set; } = 1;

        [Column(TypeName = "decimal(9,2)")]
        public decimal EntryNetPrice { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal EntryPrice { get; set; }

        public bool IsAcive { get; set; } = true;

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public virtual User ModifiedByUser { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal NetPrice { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassID { get; set; }

        public virtual PassTime PassTime { get; set; }
        public int? PassTimeDays { get; set; }

        [ForeignKey("PassTime")]
        public int PassTimeID { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; }

        public virtual Tax Tax { get; set; }

        [ForeignKey("Tax")]
        public int TaxID { get; set; }

        public Pass Copy()
        {
            return (Pass)MemberwiseClone();
        }
    }
}