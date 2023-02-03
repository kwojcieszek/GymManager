using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DbModels;

[Index(nameof(Name), IsUnique = true)]
public class Gender
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GenderID { get; set; }

    [Required]
    public string Name { get; set; }

    public Gender Copy()
    {
        return (Gender)MemberwiseClone();
    }
}