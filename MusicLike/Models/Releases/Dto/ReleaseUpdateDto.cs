using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLike.Models.Releases.Dto
{
    public class ReleaseUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(typeof(DateTime), "2000-01-01", "2100-12-31")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int Score { get; set; }
        public int RatingId { get; set; }
        [Required]
        public int ReleaseTypeId { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public int GenreId { get; set; }

    }
}
