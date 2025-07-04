namespace precio_summer_project.Models;

public class Participant
{
    public Guid Id { get; set; }
    public ICollection<User> Users { get; set; } = [];
    public Event Event { get; set; } = null!;
}
