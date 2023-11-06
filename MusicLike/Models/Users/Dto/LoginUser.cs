using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Users.Dto
{
    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
