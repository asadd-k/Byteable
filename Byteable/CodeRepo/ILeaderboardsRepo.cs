using Byteable.Models;

namespace Byteable.CodeRepo
{
    public interface ILeaderboardsRepo
    {
        public void AddTeam(Leaderboards team);

        public List<Leaderboards> GetTeams(Competition comptype);
    }
}
