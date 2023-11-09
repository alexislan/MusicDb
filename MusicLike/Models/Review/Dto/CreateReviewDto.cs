using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Review.Dto
{
    public class CreateReviewDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ReleaseId { get; set; }
        [Required]
        public int RatingId { get; set; }
    }
}
