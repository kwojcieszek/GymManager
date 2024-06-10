using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DataModel.Models
{
    public class Company
    {
        [ForeignKey("AddedByUser")]
        public int? AddedBy { get; set; }
        public virtual User AddedByUser { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyID { get; set; }
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime? DateModified { get; set; }
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        [DefaultValue("true")]
        public bool IsAcive { get; set; } = true;
        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public string Name { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string PostCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Street1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Street2 { get; set; } = string.Empty;
        public string TaxIdNumber { get; set; }

        public Company Copy()
        {
            return (Company)MemberwiseClone();
        }
    }
}