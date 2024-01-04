using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Byteable.Models;
using Byteable.CodeRepo;

namespace Byteable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegCompController : ControllerBase
    {
        private readonly IRegComp _reg;

        public RegCompController(IRegComp reg)
        {
            _reg=reg;
        }

        [HttpPost("AddTeam")]
        public IActionResult AddTeam(RegCompDTO regComp)
        {
            _reg.AddTeam(regComp);
            return Ok(regComp);
        }

        [HttpPost("AddParticipants")]
        public IActionResult AddParticipant(ParticipantDTO participant)
        {
            _reg.AddParticipants(participant);
            return Ok(participant);
        }
    }
}
