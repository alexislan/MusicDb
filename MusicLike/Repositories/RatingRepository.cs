using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Rating;
using MusicLike.Services;

namespace MusicLike.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingById(int id);
        Task<IEnumerable<Rating>> GetAllRatings();
        Task AddRating(Rating rating);
        Task UpdateRating(Rating rating);
        Task DeleteRating(int id);
    }
    public class RatingRepository : IRatingRepository
    {
        private readonly MusicDbContext _db;

        public RatingRepository(MusicDbContext context)
        {
            _db = context;
        }

        public async Task<Rating> GetRatingById(int id)
        {
            return await _db.Rating.FindAsync(id);
        }

        public async Task<IEnumerable<Rating>> GetAllRatings()
        {
            return await _db.Rating.ToListAsync();
        }

        public async Task AddRating(Rating rating)
        {
            _db.Rating.Add(rating);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRating(Rating rating)
        {
            _db.Entry(rating).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRating(int id)
        {
            var rating = await _db.Rating.FindAsync(id);
            if (rating != null)
            {
                _db.Rating.Remove(rating);
                await _db.SaveChangesAsync();
            }
        }
    }
}
