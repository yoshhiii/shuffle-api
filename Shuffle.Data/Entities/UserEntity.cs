using System;
using System.Collections.Generic;
using System.Text;

namespace Shuffle.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AuthId { get; set; }
        public string FcmToken { get; set; }
        public ICollection<UserTeamEntity> UserTeams { get; set; } = new List<UserTeamEntity>();
    }
}
