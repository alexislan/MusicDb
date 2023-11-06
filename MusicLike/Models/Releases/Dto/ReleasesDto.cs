using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Releases.Dto
{
    public class ReleasesDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public Decimal Score { get; set; }
        public int Ratings { get; set; }
    }
}
