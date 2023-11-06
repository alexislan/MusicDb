namespace MusicLike.Services
{
    public interface IEncoderService
    {
        string Encode(string str);
        bool Verify(string str, string strHash);
    }

    public class EncoderService : IEncoderService
    {
        public string Encode(string str)
        {
            string salt = BC.GenerateSalt(13);
            return BC.HashPassword(str, salt);
        }

        public bool Verify(string str, string strHash)
        {
            return BC.Verify(str, strHash);
        }
    }
}
