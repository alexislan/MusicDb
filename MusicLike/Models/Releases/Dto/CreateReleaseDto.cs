using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace MusicLike.Models.Releases.Dto
{
    public class CreateReleaseDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(typeof(DateTime), "2000-01-01", "2100-12-31")]
        public DateTime ReleaseDate { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; }
        [Required]
        public int ReleaseTypeId { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public int GenreId { get; set; }

    }
}
