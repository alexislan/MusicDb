using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Review.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
