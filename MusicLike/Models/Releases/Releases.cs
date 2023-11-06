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
        [MaxLength(50)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int Score { get; set; }
        public int Ratings { get; set; }
        public List<Genres.Genres> Genres { get; set;}
        [Required]
        public int ReleaseTypeId { get; set; }
        [ForeignKey("ReleaseTypeId")]
        public ReleaseType.ReleaseType ReleaseType { get; set; }
    }

    public class ReleaseArtist
    {
        public int ArtistId { get; set; }
        public int ReleaseId { get; set; }
    }
}
