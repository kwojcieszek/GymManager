using System.ComponentModel.DataAnnotations;

namespace GymManager.Common;

public enum CabinetKeyMode
{
    [Display(Name = "PIERWSZY DOSTĘPNY")]
    FirstAvailable = 0,

    [Display(Name = "W PĘTLI")]
    InLoop = 1
}