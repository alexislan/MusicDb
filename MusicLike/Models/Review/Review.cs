using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MusicLike.Models.Review
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users.Users User { get; set; }
        [Required]
        public int ReleaseId { get; set; }
        [ForeignKey("ReleaseId")]
        public Releases.Releases Release { get; set; }
        [Required]
        public int RatingId { get; set; }
        [ForeignKey("RatingId")]
        public Rating.Rating Rating { get; set; }

    }
}
