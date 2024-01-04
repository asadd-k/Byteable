using Byteable.Models; 

namespace Byteable.CodeRepo
{
    public interface IRegComp
    {
        public void AddTeam(RegCompDTO team);
        public void AddParticipants(ParticipantDTO participants); 
    }
}
