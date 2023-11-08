using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Users.Dto
{
    public class CreateResponseDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public UserType.UserType UserType { get; set; }
        [Required]
        public Gender.Gender Gender { get; set; }
        [Required]
        public Country.Country Country { get; set; }

    }
}
