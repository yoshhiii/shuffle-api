using System;
using System.Collections.Generic;
using System.Text;

namespace Shuffle.Data.Entities
{
    public class TeamRecordEntity
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int RulesetId { get; set; }
        public int Elo { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public virtual TeamEntity Team { get; set; }
        public virtual RulesetEntity Ruleset { get; set; }
    }
}
