
namespace Shuffle.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AuthId { get; set; }
        public string FcmToken { get; set; }
    }
}