using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DbModels;

public class Photo
{
    [ForeignKey("AddedByUser")]
    public int? AddedBy { get; set; }

    public virtual User AddedByUser { get; set; }
    public byte[] Data { get; set; }

    [Required]
    public DateTime DateAdded { get; set; } = DateTime.Now;

    public DateTime? DateModified { get; set; }

    public virtual Member Member { get; set; }

    [ForeignKey("Member")]
    public int MemberID { get; set; }

    [ForeignKey("ModifiedByUser")]
    public int? ModifiedBy { get; set; }

    public virtual User ModifiedByUser { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PhotoID { get; set; }

    public Identifier Copy()
    {
        return (Identifier)MemberwiseClone();
    }
}