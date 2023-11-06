using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Artists.Dto
{
    public class ArtistDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
    }
}
