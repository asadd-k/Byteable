using Byteable.Models;

namespace Byteable.CodeRepo
{
    public class LeaderboardsRepo : ILeaderboardsRepo
    {
        private readonly ByteableDbContext _context;

        public LeaderboardsRepo(ByteableDbContext byteableDbContext)
        {
            _context = byteableDbContext;
        }

        public void AddTeam(Leaderboards team)
        {
            try
            {
                _context.Add(team);
                _context.SaveChanges();
            }
            catch
            {

                throw new InvalidOperationException();
            }

        }

        public List<Leaderboards> GetTeams(Competition comptype)
        {
            List<Leaderboards> Teams = new List<Leaderboards>();
            var allTeams = _context.Leaderboards.ToList();

            foreach (var team in allTeams)
            {
                if (team.CompetitionType == comptype)
                {
                    Teams.Add(team);
                }
            }

            if (Teams == null)
            {
                return null;
            }

            return Teams;
        }

    }
}
