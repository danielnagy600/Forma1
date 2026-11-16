using System.ComponentModel.DataAnnotations;
using Forma1WebApp.Data.Entities;

namespace Forma1WebApp.ViewModels;

public class TeamViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A sor kitöltése kötelező!")]
    [StringLength(15, ErrorMessage = "Maximum {1} karakteres név adható meg.")]
    [Display(Name = "Csapatnév")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "A sor kitöltése kötelező!")]
    [Display(Name = "Alapítás éve")]
    [Range(1950, 2020, ErrorMessage = "A megadott értéknek {1} és {2} között kell lennie.")]
    public int YearOfFoundation { get; set; }

    [Required(ErrorMessage = "A sor kitöltése kötelező!")]
    [Display(Name = "Megnyert világbajnokságok száma")]
    [Range(0, 50, ErrorMessage = "Az értéknek {1} és {2} között kell lennie.")]
    public int WonOfChampionship { get; set; }

    [Display(Name = "Nevezési díj megléte")]
    public bool IsPaid { get; set; }

    public static TeamViewModel FromEntity(Team team) => new()
    {
        Id = team.Id,
        Name = team.Name,
        YearOfFoundation = team.YearOfFoundation,
        WonOfChampionship = team.WonOfChampionship,
        IsPaid = team.IsPaid
    };

    /// <summary>
    /// A szerkeszthető mezőket másolja az entitásba; az azonosítót szándékosan nem.
    /// </summary>
    public void ApplyTo(Team team)
    {
        team.Name = Name;
        team.YearOfFoundation = YearOfFoundation;
        team.WonOfChampionship = WonOfChampionship;
        team.IsPaid = IsPaid;
    }
}
