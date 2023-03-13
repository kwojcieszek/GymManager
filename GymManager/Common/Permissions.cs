using System.ComponentModel.DataAnnotations;

namespace GymManager.Common
{
    public enum Permissions
    {
        [Display(Name = "DOSTĘP CZŁONKOWIE")]
        AccessMembers = 1,

        [Display(Name = "DODAWANIE CZŁONKÓW")]
        AddMembers = 2,

        [Display(Name = "EDYCJA CZŁONKÓW")]
        EditMembers = 3,

        [Display(Name = "USWANIE CZŁONKÓW")]
        DeleteMembers = 4,

        [Display(Name = "DOSTĘP KARNETY CZŁONKOW")]
        AccessPassesRegistry = 5,

        [Display(Name = "DODAWANIE KARNETÓW CZŁONKÓW")]
        AddPassesRegistry = 6,

        [Display(Name = "EDYCJA KARNETÓW CZŁONKÓW")]
        EditPassesRegistry = 7,

        [Display(Name = "USWANIE KARNETÓW CZŁONKÓW")]
        DeletePassesRegistry = 8,

        [Display(Name = "DOSTĘP KLCUZE")]
        AccessCabinetKeys = 9,

        [Display(Name = "DODAWANIE KLUCZY")]
        AddCabinetKeys = 10,

        [Display(Name = "EDYCJA KLUCZY")]
        EditCabinetKeys = 11,

        [Display(Name = "USWANIE KLUCZY")]
        DeleteCabinetKeys = 12,

        [Display(Name = "DOSTĘP KARNETY")]
        AccessPasses = 13,

        [Display(Name = "DODAWANIE KARNETÓW")]
        AddPasses = 14,

        [Display(Name = "EDYCJA KARNETÓW")]
        EditPasses = 15,

        [Display(Name = "USWANIE KARNETÓW")]
        DeletePasses = 16,

        [Display(Name = "DOSTĘP UŻYTKOWNICY")]
        AccessUsers = 17,

        [Display(Name = "DODAWANIE UŻYTKOWNKÓW")]
        AddUsers = 18,

        [Display(Name = "EDYCJA UŻYTKOWNKÓW")]
        EditUsers = 19,

        [Display(Name = "USWANIE UŻYTKOWNKÓW")]
        DeleteUsers = 20,

        [Display(Name = "DOSTĘP OSOBY W OBIEKCIE")]
        AccessPersonsInGym = 21,

        [Display(Name = "DOSTĘP WIADOMOŚCI")]
        AccesMessages = 22,

        [Display(Name = "DOSTĘP REJESTR WEJŚĆ")]
        AccessEntriesRegistryView = 23,

        [Display(Name = "DOSTĘP REJESTR OPERACJI")]
        AccessDataTrackings = 24,

        [Display(Name = "DOSTĘP USTAWIENIA")]
        AccessSettings = 25,

        [Display(Name = "ZAMYKANIE WEJŚCIA CZŁONKÓW W OBIEKCIE")]
        CloseMembersInGym = 26,

        [Display(Name = "DODAJ WEJŚCIE/WYJŚCIE BEZ IDENTYFIKATORA")]
        AddEntryWithoutIdentifier = 27,

        [Display(Name = "PODGLĄD CZŁONKÓW")]
        PreviewMembers = 28
    }
}