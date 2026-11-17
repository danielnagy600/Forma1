using System.ComponentModel.DataAnnotations;
using Forma1WebApp.Data.Entities;

namespace Forma1WebApp.ViewModels;

public class TeamViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "This field is required!")]
    [StringLength(15, ErrorMessage = "The name can be at most {1} characters long.")]
    [Display(Name = "Team name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "This field is required!")]
    [Display(Name = "Year of foundation")]
    [Range(1950, 2020, ErrorMessage = "The value must be between {1} and {2}.")]
    public int YearOfFoundation { get; set; }

    [Required(ErrorMessage = "This field is required!")]
    [Display(Name = "Championships won")]
    [Range(0, 50, ErrorMessage = "The value must be between {1} and {2}.")]
    public int WonOfChampionship { get; set; }

    [Display(Name = "Entry fee paid")]
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
    /// Copies the editable fields to the entity; the identifier is intentionally not copied.
    /// </summary>
    public void ApplyTo(Team team)
    {
        team.Name = Name;
        team.YearOfFoundation = YearOfFoundation;
        team.WonOfChampionship = WonOfChampionship;
        team.IsPaid = IsPaid;
    }
}
