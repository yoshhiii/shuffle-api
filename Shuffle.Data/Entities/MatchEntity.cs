using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shuffle.Data.Entities
{
    public class MatchEntity
    {
        public int Id { get; set; }
        public int ChallengerId { get; set; }
        public int OppositionId { get; set; }
        public int ChallengerScore { get; set; }
        public int OppositionScore { get; set; }
        public DateTime MatchDate { get; set; }
        public int RulesetId { get; set; }

        public virtual TeamEntity Challenger { get; set; }
        public virtual TeamEntity Opposition { get; set; }
        public virtual RulesetEntity Ruleset { get; set; }
    }
}
