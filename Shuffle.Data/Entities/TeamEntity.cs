using System;
using System.Collections.Generic;
using System.Text;

namespace Shuffle.Data.Entities
{
    public class TeamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserTeamEntity> UserTeams { get; set; } = new List<UserTeamEntity>();
        public virtual ICollection<MatchEntity> ChallengerMatches { get; set; } = new List<MatchEntity>();
        public virtual ICollection<MatchEntity> OppositionMatches { get; set; } = new List<MatchEntity>();
        public virtual ICollection<TeamRecordEntity> TeamRecords { get; set; } = new List<TeamRecordEntity>();
    }
}
