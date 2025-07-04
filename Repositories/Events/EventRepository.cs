using Microsoft.EntityFrameworkCore.ChangeTracking;
using precio_summer_project.Data;
using precio_summer_project.Dtos.Requests.Events;
using precio_summer_project.Models;

namespace precio_summer_project.Repositories.Events;

public class EventRepository(AppDbContext context) : IEventRepository
{
    public async Task AddEventAsync(Event calendarEvent)
    {
        context.Events.Add(calendarEvent); //** Better than AddAsync for EF.
        await context.SaveChangesAsync();
    }
}
