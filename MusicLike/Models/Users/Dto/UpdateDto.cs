using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Users.Dto
{
    public class UpdateDto
    {
        [MaxLength(40)]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}
