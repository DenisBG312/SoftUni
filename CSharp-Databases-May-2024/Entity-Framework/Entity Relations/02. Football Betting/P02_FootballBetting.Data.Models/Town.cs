namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Town
{
    public Town()
    {
        this.Teams = new HashSet<Team>();
        this.Players = new HashSet<Player>();
    }

    [Key]
    public int TownId { get; set; }

    [Required]
    [MaxLength(58)]
    public string Name { get; set; } = null!;

    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; }

    // added new ICollection<Player> Players because of Judge's unit tests
    public virtual ICollection<Player> Players { get; set; }
}
