using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLike.Models.Artists.Dto
{
    public class ArtistDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [ForeignKey("GenderId")]
        public Gender.Gender Gender { get; set; }
        [ForeignKey("CountryId")]
        public Country.Country Country { get; set; }
        public List<Releases.Releases> Releases { get; set; } = null!;
    }
}
