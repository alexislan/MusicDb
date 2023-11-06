using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Genres.GenresDto
{
    public class GenresDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
