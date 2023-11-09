using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Releases.Dto
{
    public class ReleasesDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(typeof(DateTime), "2000-01-01", "2100-12-31")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public Decimal Score { get; set; }
        public Artists.Dto.CreateArtistDto Artist { get; set; }
        public ReleaseType.ReleaseType ReleaseType { get; set; }
        public Rating.Rating Rating { get; set; }
        public List<Genres.Genres> Genre { get; set; }
    }
}
