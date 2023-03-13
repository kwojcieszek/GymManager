using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DbModels
{
    public class DataTracking
    {
        [ForeignKey("AddedByUser")]
        public int? AddedBy { get; set; }

        public virtual User AddedByUser { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DataTrackingID { get; set; }

        public DataTrackingOperation DataTrackingOperation { get; set; }

        [ForeignKey("DataTrackingOperation")]
        public int DataTrackingOperationID { get; set; }

        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public virtual User ModifiedByUser { get; set; }

        [StringLength(50)]
        public string PrimaryKey { get; set; }

        [Required]
        [StringLength(50)]
        public string TableName { get; set; }

        public DataTracking Copy()
        {
            return (DataTracking)MemberwiseClone();
        }
    }
}