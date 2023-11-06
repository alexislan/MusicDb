using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Users
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; } = null!;
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public int UserTypeId { get; set; }
        [ForeignKey("UserTypeId")]
        public UserType.UserType UserType { get; set; }

        [Required]
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender.Gender Gender { get; set; }

        [Required]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country.Country Country { get; set; }
    }
}
