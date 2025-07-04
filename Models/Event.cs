using System.Text.Json.Serialization;
using precio_summer_project.Dtos.Requests.Events;

namespace precio_summer_project.Models;

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime EventDateStart { get; set; }
    public DateTime EventDateEnd { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsInPerson { get; set; }
    public User User { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Participant> Participants { get; set; } = [];

    public Event(
        string name,
        string description,
        string location,
        DateTime eventDateStart,
        DateTime eventDateEnd,
        bool isInPerson
    )
    {
        Name = name;
        Description = description;
        Location = location;
        EventDateStart = eventDateStart;
        EventDateEnd = eventDateEnd;
        IsInPerson = isInPerson;
    }

    public Event() { }
}
