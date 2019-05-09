
using System.Collections.Generic;

namespace Shuffle.Core.Models
{
    public class Team   
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<User> Users { get; set; }
    }
}