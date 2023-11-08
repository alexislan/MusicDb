using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Artists.Dto
{
    public class ArtistUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
    }
}
