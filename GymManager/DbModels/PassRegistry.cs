using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DbModels
{
    public class PassRegistry
    {
        [ForeignKey("AddedByUser")]
        public int? AddedBy { get; set; }

        public virtual User AddedByUser { get; set; }
        public string Comment { get; set; }
        public bool Continuation { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? EndDate { get; set; }
        public DateTime? EndSuspensionDate { get; set; }

        public virtual Member Member { get; set; }

        [ForeignKey("Member")]
        public int MemberID { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public virtual User ModifiedByUser { get; set; }

        public virtual Pass Pass { get; set; }

        [ForeignKey("Pass")]
        public int PassID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassRegistryID { get; set; }

        public DateTime? PaymentDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? StartSuspensionDate { get; set; }
        public bool Suspension { get; set; } = false;

        public PassRegistry Copy()
        {
            return (PassRegistry)MemberwiseClone();
        }
    }
}