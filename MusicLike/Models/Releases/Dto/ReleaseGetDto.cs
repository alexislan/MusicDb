using MusicLike.Models.Artists.Dto;
using MusicLike.Models.Genres.GenresDto;
using MusicLike.Models.Rating.Dto;
using MusicLike.Models.Review.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLike.Models.Releases.Dto
{
    public class ReleaseGetDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(typeof(DateTime), "2000-01-01", "2100-12-31")]
        public DateTime ReleaseDate { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; }
        public ArtistDto Artist { get; set; }
        public GenresDto Genre { get; set; }
    }
}
