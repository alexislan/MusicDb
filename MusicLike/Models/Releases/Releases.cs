using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Releases
{
    public class Releases
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
        [Required]
        public int Score { get; set; }
        public int RatingId { get; set; }
        [ForeignKey("RatingId")]
        public Rating.Rating Rating { get; set; }
        public List<Genres.Genres> Genres { get; set;}
        [Required]
        public int ReleaseTypeId { get; set; }
        [ForeignKey("ReleaseTypeId")]
        public ReleaseType.ReleaseType ReleaseType { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artists.Artist Artist { get; set; }
    }
}
