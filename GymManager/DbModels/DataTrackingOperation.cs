using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DbModels;

[Index(nameof(Name), IsUnique = true)]
public class DataTrackingOperation
{
    [Key]
    public int DataTrackingOperationID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public DataTrackingOperation Copy()
    {
        return (DataTrackingOperation)MemberwiseClone();
    }
}