using Microsoft.EntityFrameworkCore.ChangeTracking;
using precio_summer_project.Models;

namespace precio_summer_project.Repositories.Events;

public interface IEventRepository
{
    Task AddEventAsync(Event calendarEvent);
}
