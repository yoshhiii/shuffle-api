using System;
using System.Collections.Generic;
using System.Text;

namespace Shuffle.Data.Entities
{
    public class RulesetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MatchEntity> Matches {get; set;}
        public virtual ICollection<TeamRecordEntity> TeamRecords { get; set; }
    }
}
