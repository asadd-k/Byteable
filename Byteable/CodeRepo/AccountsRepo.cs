using Byteable.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Byteable.CodeRepo
{
    public class AccountsRepo : IAccountRepo
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ClubMembers> userManager;
        private readonly SignInManager<ClubMembers> loginmanager;

        public AccountsRepo(IConfiguration configuration,
            UserManager<ClubMembers> usermgr, SignInManager<ClubMembers> _login)
        {
            _configuration = configuration;
            userManager = usermgr;
            loginmanager = _login;
        }

        public async Task<IdentityResult> Joinclub(Signup user)
        {
            var newuser = new ClubMembers()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.EmailAddress,
                UserName = user.EmailAddress,
                PhoneNumber= user.PhoneNumber,
                AnyPreviousClub = user.AnyPreviousClub,
                City = user.City,
                Address = user.Address,
                School = user.School
            };
            //SendEmail(newuser.Email, newuser.FirstName);
            return await userManager.CreateAsync(newuser, user.Password);
        }

        public async Task<string> Login(Login login)
        {
            var result = await loginmanager.PasswordSignInAsync(login.Email, login.Password, false, false);

            if (result.Succeeded)
            {
                var authCliams = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var authsignkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authCliams,
                    signingCredentials: new SigningCredentials(authsignkey, SecurityAlgorithms.HmacSha256Signature)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            else
            {
                return null;
            }
        }
    }
}
