using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Byteable.Models
{
    public class Events
    {
        [Key]
        public int ID { get; set; }

        public string EventName { get; set; } = string.Empty;

        public string EventType { get; set; } = string.Empty;

        public Competition _competitontype { get; set; }

        public string CompetitionType { get; set; } = string.Empty;

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;
        
        public string Month { get; set; } = string.Empty;
        
        public string Year { get; set; } = string.Empty;
        
        public string EventColor { get; set; } = string.Empty;

    }
}
