using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DataModel.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Tax
    {
        public DateTime DateAdded { get; set; }

        [DefaultValue("true")]
        public bool IsAcive { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Rate { get; set; }

        [Key]
        public int TaxID { get; set; }

        public Tax Copy()
        {
            return (Tax)MemberwiseClone();
        }
    }
}