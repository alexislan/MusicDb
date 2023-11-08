namespace MusicLike.Models.Users.Dto
{
    public class LoginResponse
    {
        public string Token { get; set; } = null!;
        public UsersDto User { get; set; } = null!;
    }
}
