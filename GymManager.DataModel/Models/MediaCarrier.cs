using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DataModel.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class MediaCarrier
    {
        [DefaultValue("true")]
        public bool IsAcive { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaCarrierID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public MediaCarrier Copy()
        {
            return (MediaCarrier)MemberwiseClone();
        }
    }
}