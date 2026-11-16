using System.ComponentModel.DataAnnotations;

namespace Forma1WebApp.Data.Entities;

public class Team
{
    // Az azonosítót az adatbázis generálja.
    public int Id { get; set; }

    [MaxLength(15)]
    public string Name { get; set; } = string.Empty;

    public int YearOfFoundation { get; set; }

    public int WonOfChampionship { get; set; }

    public bool IsPaid { get; set; }
}
