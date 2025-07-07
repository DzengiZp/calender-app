using Microsoft.EntityFrameworkCore.ChangeTracking;
using precio_summer_project.Dtos.Requests.Events;
using precio_summer_project.Models;

namespace precio_summer_project.Services.Events;

public interface IEventService
{
    public Task CreateEventAsync(AddEventRequest request);
    public Task DeleteEventAsync(Guid id);
    public Task PatchEventAsync(UpdateEventRequest request);
}
