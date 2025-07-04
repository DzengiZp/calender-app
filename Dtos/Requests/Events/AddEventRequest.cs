namespace precio_summer_project.Dtos.Requests.Events;

public record AddEventRequest(
    string Name,
    string Description,
    string Location,
    DateTime EventDateStart,
    DateTime EventDateEnd,
    bool IsInPerson
);
