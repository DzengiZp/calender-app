using Microsoft.EntityFrameworkCore;
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

    public async Task<int> DeleteAsync(Guid id)
    {
        return await context.Events.Where(e => e.Id == id).ExecuteDeleteAsync();
    }

    public async Task<Event?> GetAsync(Guid id)
    {
        return await context.Events.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Event calendarEvent)
    {
        context.Events.Update(calendarEvent);
        await context.SaveChangesAsync();
    }
}
