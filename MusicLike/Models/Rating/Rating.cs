using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Rating
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Ratingg { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users.Users User { get; set; }
        [Required]
        public int ReleaseId { get; set; }
        [ForeignKey("ReleaseId")]
        public Releases.Releases Releases { get; set; }
    }   
}
