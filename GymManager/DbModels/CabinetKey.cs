using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DbModels
{
    [Index(nameof(Name), IsUnique = true)]
    public class CabinetKey
    {
        [ForeignKey("AddedByUser")]
        public int? AddedBy { get; set; }

        public virtual User AddedByUser { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CabinetKeyID { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime? DateModified { get; set; }
        public virtual Gender Gender { get; set; }

        [ForeignKey("Gender")]
        public int? GenderID { get; set; }

        [DefaultValue("true")]
        public bool IsAcive { get; set; } = true;

        public DateTime LastUsedDate { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public virtual User ModifiedByUser { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public CabinetKey Copy()
        {
            return (CabinetKey)MemberwiseClone();
        }
    }
}