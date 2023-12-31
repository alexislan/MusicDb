﻿using System.ComponentModel.DataAnnotations;

namespace MusicLike.Models.Users.Dto
{
    public class CreateUser
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        public int UserTypeId { get; } = 1;//aca se cambia para ser admin o user
        [Required]
        public int CountryId { get; set; }

        [Required]
        public int GenderId { get; set; }
    }
}
