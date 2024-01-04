using Microsoft.AspNetCore.Identity;

namespace Byteable.Models
{
    public class ClubMembers : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AnyPreviousClub { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string School { get; set; }
    }
}
