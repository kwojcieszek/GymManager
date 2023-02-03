using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DbModels;

[Index(nameof(Id), IsUnique = true)]
public class Member
{
    [ForeignKey("AddedByUser")]
    public int? AddedBy { get; set; }

    public virtual User AddedByUser { get; set; }

    public DateTime? BirthDate { get; set; }

    [Required]
    [StringLength(50)]
    public string City { get; set; }

    [Required]
    public DateTime DateAdded { get; set; } = DateTime.Now;

    public DateTime? DateModified { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    public virtual Gender Gender { get; set; }

    [ForeignKey("Gender")]
    [DefaultValue(1)]
    public int? GenderID { get; set; }

    [Required]
    [StringLength(50)]
    public string Id { get; set; }

    [DefaultValue("true")]
    public bool IsAcive { get; set; } = true;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MemberID { get; set; }

    [ForeignKey("ModifiedByUser")]
    public int? ModifiedBy { get; set; }

    public virtual User ModifiedByUser { get; set; }

    public virtual Pass Pass { get; set; }

    [ForeignKey("Pass")]
    public int? PassID { get; set; }

    [StringLength(50)]
    public string Pesel { get; set; }

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

    public Member Copy()
    {
        return (Member)MemberwiseClone();
    }
}