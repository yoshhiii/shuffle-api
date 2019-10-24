
namespace Shuffle.Core.Models
{
    public class TeamRecord
    {
        public int TeamId { get; set; }
        public int RulesetId { get; set; }
        public int Elo { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}