using Byteable.Models;
using Microsoft.AspNetCore.Identity;

namespace Byteable.CodeRepo
{
    public interface IAccountRepo
    {
        public Task<IdentityResult> Joinclub(Signup user);

        public Task<string> Login(Login login);

    }
}
