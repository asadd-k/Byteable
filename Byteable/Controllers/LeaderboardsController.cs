using Byteable.Models;
using Byteable.CodeRepo;
using Microsoft.AspNetCore.Mvc;

namespace ByteableAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardsController : ControllerBase
    {
        private readonly ILeaderboardsRepo _repo;

        public LeaderboardsController(ILeaderboardsRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("AddTeam")]
        public IActionResult AddNewTeam(Leaderboards team)
        {
            try
            {
                _repo.AddTeam(team);
                return Ok("Team has been added to the leaderboard database");
            }
            catch (InvalidOperationException e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("getTeams/{type}")]
        public IActionResult GetTeams(int type)
        {
            Competition CompType = (Competition)type;

            var result = _repo.GetTeams(CompType);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
