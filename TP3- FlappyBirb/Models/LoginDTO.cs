using System.ComponentModel.DataAnnotations;

namespace TP3__FlappyBirb.Models
{
    public class LoginDTO
    {
        [Required]
        public String Username { get; set; } = null!;
        [Required]
        public String Password { get; set; } = null!;

    }
}
