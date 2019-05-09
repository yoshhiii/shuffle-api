using System;
using System.Collections.Generic;
using System.Text;

namespace Shuffle.Data.Entities
{
    public class UserTeamEntity

    {
        public int UserId { get; set; }
        public int TeamId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual TeamEntity Team { get; set; }
    }
}
