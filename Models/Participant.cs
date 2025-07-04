using System.Text.Json.Serialization;

namespace precio_summer_project.Models;

public class Participant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public ICollection<User> Users { get; set; } = [];

    [JsonIgnore]
    public Event Event { get; set; } = null!;
}
