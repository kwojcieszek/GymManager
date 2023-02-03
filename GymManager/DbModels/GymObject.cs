using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DbModels;

public class GymObject
{
    [ForeignKey("AddedByUser")]
    public int? AddedBy { get; set; }

    public virtual User AddedByUser { get; set; }

    [Required]
    [StringLength(50)]
    public string City { get; set; }

    [Required]
    public DateTime DateAdded { get; set; } = DateTime.Now;

    public DateTime? DateModified { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = string.Empty;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GymObjectID { get; set; }

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

    public GymObject Copy()
    {
        return (GymObject)MemberwiseClone();
    }
}