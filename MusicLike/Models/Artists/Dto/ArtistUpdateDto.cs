using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Artists.Dto
{
    public class ArtistUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        public int GenderId { get; set; }
        public int CountryId { get; set; }

    }
}
