namespace precio_summer_project.Models;

public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime EventDateStart { get; set; }
    public DateTime EventDateEnd { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsInPerson { get; set; } = false;
    public User User { get; set; } = null!;
    public ICollection<Participant> Participants { get; set; } = [];
}
