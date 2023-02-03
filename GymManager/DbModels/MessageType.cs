using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.DbModels;

public class MessageType
{
    [DefaultValue("true")]
    public bool IsAcive { get; set; } = true;

    [DefaultValue("false")]
    public bool IsEmail { get; set; } = false;

    [DefaultValue("false")]
    public bool IsSms { get; set; } = false;

    public string Message { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MessageTypeID { get; set; }

    [Required]
    public string Name { get; set; }

    public Message Copy()
    {
        return (Message)MemberwiseClone();
    }
}