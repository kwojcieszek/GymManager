using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DataModel.Models
{
    [Index(nameof(Key), IsUnique = true)]
    public class Identifier
    {
        [ForeignKey("AddedByUser")]
        public int? AddedBy { get; set; }

        public virtual User AddedByUser { get; set; }

        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public DateTime? DateModified { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdentifierID { get; set; }

        [DefaultValue("true")]
        public bool IsAcive { get; set; }

        [Required]
        [StringLength(50)]
        public string Key { get; set; }

        public virtual MediaCarrier MediaCarrier { get; set; }

        [ForeignKey("MediaCarrier")]
        public int MediaCarrierID { get; set; }

        public virtual Member Member { get; set; }

        [ForeignKey("Member")]
        public int MemberID { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public virtual User ModifiedByUser { get; set; }

        public Identifier Copy()
        {
            return (Identifier)MemberwiseClone();
        }
    }
}