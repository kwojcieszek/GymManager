using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DbModels
{
    [Index(nameof(Name), IsUnique = true)]
    public class PassTime
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassTimeID { get; set; }

        public PassTime Copy()
        {
            return (PassTime)MemberwiseClone();
        }
    }
}