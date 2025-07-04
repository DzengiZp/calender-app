using Microsoft.AspNetCore.Identity;

namespace precio_summer_project.Models
{
    public class User : IdentityUser
    {
        public ICollection<Event> Events { get; set; } = [];
        public ICollection<Location> Locations { get; set; } = [];
    }
}
