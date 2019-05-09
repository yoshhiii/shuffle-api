
using System;

namespace Shuffle.Core.Models
{
    public class Match
    {
        public int? Id { get; set; }
        public int ChallengerId { get; set; }
        public int OppositionId { get; set; }
        public int? ChallengerScore { get; set; }
        public int? OppositionScore { get; set; }
        public string ChallengerName { get; set; }
        public string OppositionName { get; set; }
        public DateTime MatchDate { get; set; }
        public int RulesetId { get; set; }
    }
}