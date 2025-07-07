using Microsoft.EntityFrameworkCore.ChangeTracking;
using precio_summer_project.Models;

namespace precio_summer_project.Repositories.Events;

public interface IEventRepository
{
    public Task AddAsync(Event calendarEvent);
    public Task<int> DeleteAsync(Guid id);
    public Task<Event?> GetAsync(Guid id);
    public Task UpdateAsync(Event calendarEvent);
}
