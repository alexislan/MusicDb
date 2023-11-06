using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Rating.Dto
{
    public class RatingDto
    {
        [Required]
        [StringLength(50)]
        public string Ratingg { get; set; }
    }
}
