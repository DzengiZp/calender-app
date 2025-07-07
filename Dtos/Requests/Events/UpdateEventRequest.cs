namespace precio_summer_project.Dtos.Requests.Events;

public class UpdateEventRequest
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public DateTime? EventDateStart { get; set; }
    public DateTime? EventDateEnd { get; set; }
    public bool? IsInPerson { get; set; }
}

/*

Dag 1 Event skapas och är false

Dag 2 Event ändras till true

Dag 3 Even description ändras

*/
