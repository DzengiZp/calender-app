using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using precio_summer_project.Dtos.Requests.Events;
using precio_summer_project.Models;
using precio_summer_project.Services.Events;

namespace precio_summer_project.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(IEventService eventService, ILogger<EventController> logger)
    : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] AddEventRequest request)
    {
        try
        {
            await eventService.ValidateEventDataAsync(request);

            return Ok(ApiResponse.Success(200, "Successfully added event"));
        }
        catch (DbUpdateException ex)
        {
            var error = "Something went wrong while adding an event";
            logger.LogError("{error} exception: {ex}", error, ex);
            return BadRequest(ApiResponse.Error(400, error));
        }
        catch (Exception ex)
        {
            var error = "Something went wrong while adding an event";
            logger.LogError("{error} exception: {ex}", error, ex);
            return BadRequest(ApiResponse.Error(400, error));
        }
    }
}
