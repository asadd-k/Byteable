using Byteable.CodeRepo;
using Byteable.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Byteable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepo _accountRepository;

        public AccountsController(IAccountRepo accountRepository)
        {
            _accountRepository= accountRepository;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> JoinClub([FromBody]  Signup user)
        {
            var result = await _accountRepository.Joinclub(user);

            try
            {
                return Ok(result);
            }
            catch
            {
                return Unauthorized();
            }
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            var result = await _accountRepository.Login(login);

            try
            {
                return Ok(result);
            }
            catch
            {
                return Unauthorized();
            }
        }


        [HttpGet]
        [Authorize]
        public string GetData()
        {
            return "Authorized";
        }
    }
}

