using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Artists.Dto
{
    public class CreateArtistDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
