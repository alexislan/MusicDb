using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Artists;
using MusicLike.Services;

namespace MusicLike.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist> Update(Artist entity);
        Task<List<Artist>> GetAllWithRelatedData();
    }
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly MusicDbContext _db;

        public ArtistRepository(MusicDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<Artist> Update(Artist entity)
        {
            _db.Artists.Update(entity);
            await Save();
            return entity;
        }
        public async Task<List<Artist>> GetAllWithRelatedData()
        {
            return await _db.Artists
                .Include(a => a.Gender)
                .Include(a => a.Country)
                .ToListAsync();
        }
    }
}
