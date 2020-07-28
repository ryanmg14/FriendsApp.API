using System.ComponentModel.DataAnnotations;

namespace FriendApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be 8 - 16 characters")]
        public string Password { get; set; }

    }
}