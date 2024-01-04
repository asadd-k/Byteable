using System.ComponentModel.DataAnnotations; 

namespace Byteable.Models
{
    public class RegComp
    {
        [Key]
        public int ID { get; set; }

        public string TeamName { get; set; } = string.Empty;

        public int ParticipantNo { get; set; }

        public string CompetitionType { get; set; } = string.Empty;

        public bool ClubMember { get; set; }

        public int RegistrationFee { get; set; }

        public byte[] ?PaymentReceipt { get; set; }

        public List<Participants> ?Participants { get; set; }
 
    }

    public enum Competition
    {
        SpeedProgramming = 1,
        SpeedDebugging,
        AppDevelopment,
        WebDevelopment,
        CTF
    }

    public class Participants
    {
        [Key]
        public int ID { get; set; }

        public RegComp Team { get; set; } 

        public string TeamName { get; set; } = string.Empty;

        public string ParticipantName { get; set; } = string.Empty; 

        public string ParticipantEmail { get; set; } = string.Empty; 

        public string ParticipantPhone { get; set; }

    }

    public class RegCompDTO
    {
        public string TeamName { get; set; } = string.Empty;

        public int ParticipantNo { get; set; }

        public Competition _CompetitionType { get; set; }

        public bool ClubMember { get; set; }
    }

    public class ParticipantDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; }
    }


}
