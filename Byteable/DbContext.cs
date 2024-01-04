using Byteable.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Byteable
{
    public class ByteableDbContext : IdentityDbContext<ClubMembers>
    {
        public ByteableDbContext(DbContextOptions<ByteableDbContext> options) : base(options)
        {

        }

        public DbSet<RegComp> RegisterCompetitions { get; set; }

        public DbSet<Participants> Participants { get; set; }

        public DbSet<Events> Events { get; set; }

        public DbSet<Leaderboards> Leaderboards { get; set; }

    }
}
