using precio_summer_project.Dtos.Requests.Events;
using precio_summer_project.Models;

namespace precio_summer_project.Mappers;

public static class EventMapper
{
    //** ADD GENERIC REFLECTION BASED MAPPER LATER ON
    public static Event ToModel<T>(AddEventRequest dto)
    {
        return new Event
        {
            Name = dto.Name,
            Description = dto.Description,
            Location = dto.Location,
            EventDateStart = dto.EventDateStart.ToUniversalTime(),
            EventDateEnd = dto.EventDateEnd.ToUniversalTime(),
            IsInPerson = dto.IsInPerson,
        };
    }
}
