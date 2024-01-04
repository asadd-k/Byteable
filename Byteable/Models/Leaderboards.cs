using System.ComponentModel.DataAnnotations;

namespace Byteable.Models
{
    public class Leaderboards
    {
        [Key]
        public int ID { get; set; }

        public string TeamName { get; set; } = string.Empty;

        public Competition CompetitionType { get; set; }

        public int TotalPoints { get; set; }

        public int Trophies { get; set; }

        public string University { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

    }
}
