using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DbModels;

[Index(nameof(Name), IsUnique = false)]
public class PermissionList
{
    [Required]
    public string Name { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PermissionListID { get; set; }

    public User Copy()
    {
        return (User)MemberwiseClone();
    }
}