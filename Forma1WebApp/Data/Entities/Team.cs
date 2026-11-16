using System.ComponentModel.DataAnnotations;

namespace Forma1WebApp.Data.Entities;

public class Team
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A sor kitöltése kötelező!")]
    [StringLength(15, ErrorMessage = "Maximum {1} karakteres név adható meg.")]
    [Display(Name = "Csapatnév")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "A sor kitöltése kötelező!")]
    [Display(Name = "Alapítás éve")]
    [Range(1950, 2020, ErrorMessage = "A megadott értéknk nem {1} és {2} között van.")]
    public int YearOfFoundation { get; set; }

    [Required(ErrorMessage = "A sor kitöltése kötelező!")]
    [Display(Name = "Megnyert világbajnokságok száma")]
    [Range(0, 50, ErrorMessage = "Az értéknke {1} és {2} között kell lennie.")]
    public int WonOfChampionship { get; set; }

    [Display(Name = "Nevezési díj megléte")]
    public bool IsPaid { get; set; }
}
