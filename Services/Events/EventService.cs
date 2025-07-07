using Microsoft.EntityFrameworkCore.ChangeTracking;
using precio_summer_project.Dtos.Requests.Events;
using precio_summer_project.Exceptions;
using precio_summer_project.Mappers;
using precio_summer_project.Models;
using precio_summer_project.Repositories.Events;

namespace precio_summer_project.Services.Events;

public class EventService(IEventRepository repository) : IEventService
{
    public async Task CreateEventAsync(AddEventRequest request)
    {
        var dateStart = request.EventDateStart;
        var dateEnd = request.EventDateEnd;

        if (string.IsNullOrWhiteSpace(request.Name))
            throw new EventNameEmptyException();

        if (string.IsNullOrWhiteSpace(request.Description))
            throw new EventDescriptionEmptyException();

        if (string.IsNullOrWhiteSpace(request.Location))
            throw new EventLocationEmptyException();

        if (dateStart.CompareTo(DateTime.Today) < 0)
            throw new EventStartDateException();

        if (dateStart.Hour.CompareTo(DateTime.Today.Hour) < 0)
            throw new EventStartTimeException();

        if (dateEnd.CompareTo(DateTime.Today) == 0 && dateEnd.Hour.CompareTo(dateStart.Hour) < 0)
            throw new EventEndTimeException();

        if (dateEnd.CompareTo(dateStart) < 0)
            throw new EventEndDateException();

        // var calendarEvent = EventMapper.ToModel<AddEventRequest>(request);

        var calendarEvent = GenericMapper<Event>.Map(request);

        await repository.AddAsync(calendarEvent);
    }
}
