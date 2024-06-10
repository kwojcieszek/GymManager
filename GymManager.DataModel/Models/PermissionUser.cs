using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DataModel.Models
{
    public class PermissionUser
    {
        [ForeignKey("AddedByUser")]
        public int? AddedBy { get; set; }

        public virtual User AddedByUser { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public virtual PermissionList PermissionList { get; set; }

        [Required]
        [ForeignKey("PermissionList")]
        public int PermissionListID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionUserID { get; set; }

        public User User { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public User Copy()
        {
            return (User)MemberwiseClone();
        }
    }
}