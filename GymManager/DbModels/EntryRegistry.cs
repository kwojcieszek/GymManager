using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DbModels
{
    public class EntryRegistry
    {
        public virtual CabinetKey CabinetKey { get; set; }

        [ForeignKey("CabinetKey")]
        public int? CabinetKeyID { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntryRegistryID { get; set; }

        public DateTime? ExitDate { get; set; }

        [DefaultValue("true")]
        public bool IsAcive { get; set; } = true;

        public virtual Member Member { get; set; }

        [ForeignKey("Member")]
        public int MemberID { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public virtual User ModifiedByUser { get; set; }

        public virtual Pass Pass { get; set; }

        [ForeignKey("Pass")]
        public int? PassID { get; set; }

        public int? VisitTime { get; set; }

        public EntryRegistry Copy()
        {
            return (EntryRegistry)MemberwiseClone();
        }
    }
}