using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.ReleaseType.Dto
{
    public class ReleaseTypeDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
