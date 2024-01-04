using Byteable.CodeRepo;
using Byteable.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Byteable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEvents _eventRepo;

        public EventsController(IEvents eventRepo)
        {
            _eventRepo= eventRepo;
        }

        [HttpGet("getallevents")]
        public IActionResult GetAllEvents()
        {
            try
            {
                return Ok(_eventRepo.GetAllEvents());
            }
            catch (Exception ex)
            {

                return Ok(ex.ToString());
            }
        }

        [HttpGet("geteventsbyid/{id}")]
        public IActionResult GetEventsByID(int id)
        {
            var result = _eventRepo.ViewEventDetails(id);

            if (result==null)
            {
                //204 No Content
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost("addevent")]
        public IActionResult AddEvent([FromBody] Events events)
        {
            try
            {
                _eventRepo.AddNewEvent(events);
                return Ok("New Event has been added");
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }

        [HttpDelete("deleteEvent/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            try
            {
                _eventRepo.RemoveEvent(id);
                return Ok("Event has been deleted");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateEventByID/{id}")]
        public IActionResult UpdateCompetition([FromBody] Events events, int id)
        {
            try
            {
                _eventRepo.UpdateEvent(id, events);
                return Ok("Details have been updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
