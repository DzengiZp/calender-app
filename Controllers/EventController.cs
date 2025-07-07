using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using precio_summer_project.Dtos.Requests.Events;
using precio_summer_project.Exceptions;
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
            await eventService.CreateEventAsync(request);

            return Ok(ApiResponse.Success(200, "Successfully added event"));
        }
        catch (EventNameEmptyException ex)
        {
            return BadRequest(ApiResponse.Error(400, ex.Message));
        }
        catch (EventDescriptionEmptyException ex)
        {
            return BadRequest(ApiResponse.Error(400, ex.Message));
        }
        catch (EventLocationEmptyException ex)
        {
            return BadRequest(ApiResponse.Error(400, ex.Message));
        }
        catch (EventStartDateException ex)
        {
            return BadRequest(ApiResponse.Error(400, ex.Message));
        }
        catch (EventStartTimeException ex)
        {
            return BadRequest(ApiResponse.Error(400, ex.Message));
        }
        catch (EventEndTimeException ex)
        {
            return BadRequest(ApiResponse.Error(400, ex.Message));
        }
        catch (EventEndDateException ex)
        {
            return BadRequest(ApiResponse.Error(400, ex.Message));
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

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await eventService.DeleteEventAsync(id);

            return Ok(ApiResponse.Success(200, "Succesfully deleted event"));
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ApiResponse.Error(400, ex.Message));
        }
        catch (EventNotFoundException ex)
        {
            return NotFound(ApiResponse.Error(404, ex.Message));
        }
        catch (Exception ex)
        {
            var error = "Something went wrong while deleting an event";
            logger.LogError("{error} exception: {ex}", error, ex);
            return BadRequest(ApiResponse.Error(400, error));
        }
    }

    [HttpPatch("patch")]
    public async Task<IActionResult> Patch([FromBody] UpdateEventRequest request)
    {
        try
        {
            await eventService.PatchEventAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
