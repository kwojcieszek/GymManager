using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DataModel.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(ModifiedBy), IsUnique = false)]
    public class User
    {
        [ForeignKey("AddedByUser")]
        public int? AddedBy { get; set; }

        public virtual User AddedByUser { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public DateTime? DateModified { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DefaultValue("true")]
        public bool IsAcive { get; set; } = true;

        [DefaultValue("false")]
        public bool IsAdmin { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public virtual User ModifiedByUser { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public User Copy()
        {
            return (User)MemberwiseClone();
        }
    }
}