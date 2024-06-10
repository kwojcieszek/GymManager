using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DataModel.Models
{
    public class DataTrackingDefinition
    {
        public string ColumnName { get; set; }
        public DataTracking DataTracking { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DataTrackingDefinitionID { get; set; }
        [ForeignKey("DataTracking")]
        public int DataTrackingID { get; set; }
        [Required]
        public string NewData { get; set; }
        [Required]
        public string OldData { get; set; }

        public DataTrackingDefinition Copy()
        {
            return (DataTrackingDefinition)MemberwiseClone();
        }
    }
}