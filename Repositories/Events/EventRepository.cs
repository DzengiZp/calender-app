using precio_summer_project.Data;
using precio_summer_project.Models;

namespace precio_summer_project.Repositories.Events;

public class EventRepository(AppDbContext context) : IEventRepository
{
    public async Task AddAsync(Event calendarEvent)
    {
        context.Events.Add(calendarEvent); //** Better than AddAsync for EF.
        await context.SaveChangesAsync();
    }
}
