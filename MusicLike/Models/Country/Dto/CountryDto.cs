using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Country.Dto
{
    public class CountryDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
