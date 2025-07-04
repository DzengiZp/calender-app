namespace precio_summer_project.Models;

public class Location
{
    public Guid Id { get; set; }
    public string LocationName = string.Empty;
    public User User { get; set; } = null!;
}
