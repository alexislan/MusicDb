﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MusicLike.Models.Review.Dto;

namespace MusicLike.Models.Releases
{
    public class Releases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(typeof(DateTime), "2000-01-01", "2100-12-31")]
        public DateTime ReleaseDate { get; set; }
        public string UrlImage { get; set; }

        public string Description { get; set; }
        [Required]
        public int ReleaseTypeId { get; set; }
        [ForeignKey("ReleaseTypeId")]
        public ReleaseType.ReleaseType ReleaseType { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artists.Artist Artist { get; set; }
        [Required]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genres.Genres Genre { get; set; }
    }
}
