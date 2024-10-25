using Microsoft.AspNetCore.Identity;

namespace TP3__FlappyBirb.Models
{
    public class User : IdentityUser
    {
        public List<Scores> scores { get; set; } = null!;
    }
}
