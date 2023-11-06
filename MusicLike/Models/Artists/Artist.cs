using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLike.Models.Artists
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender.Gender Gender { get; set; }
        [Required]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country.Country Country { get; set; }
        public List<Releases.Releases> Releases { get; set; } = null!;
    }
}
