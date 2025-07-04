using System.Text.Json.Serialization;

namespace precio_summer_project.Models;

public class Location
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string LocationName = string.Empty;
    public User User { get; set; } = null!;
}
