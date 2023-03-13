using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DbModels
{
    public class MessageRegistry
    {
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public DateTime? EmailSentDate { get; set; }
        public string ErrorMessage { get; set; }

        [DefaultValue("true")]
        public bool IsAcive { get; set; } = true;

        [DefaultValue("false")]
        public bool IsEmail { get; set; } = false;

        public bool IsError { get; set; } = false;

        [DefaultValue("false")]
        public bool IsSms { get; set; } = false;

        public virtual Member Member { get; set; }

        [ForeignKey("Member")]
        public int MemberID { get; set; }

        public virtual Message Message { get; set; }

        [Required]
        public string MessageContnet { get; set; }

        [ForeignKey("Message")]
        public int MessageID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageRegistryID { get; set; }

        public DateTime? SmsSentDate { get; set; }

        public MessageRegistry Copy()
        {
            return (MessageRegistry)MemberwiseClone();
        }
    }
}