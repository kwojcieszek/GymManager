using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DbModels
{
    public class Message
    {
        [ForeignKey("AddedByUser")]
        public int? AddedBy { get; set; }

        public virtual User AddedByUser { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        [DefaultValue("true")]
        public bool IsAcive { get; set; } = true;

        [DefaultValue("false")]
        public bool IsEmail { get; set; } = false;

        [DefaultValue("false")]
        public bool IsSms { get; set; } = false;

        [Required]
        public string MessageContent { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }

        public virtual MessageType MessageType { get; set; }

        [ForeignKey("MessageType")]
        public int MessageTypeID { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public virtual User ModifiedByUser { get; set; }

        public Message Copy()
        {
            return (Message)MemberwiseClone();
        }
    }
}