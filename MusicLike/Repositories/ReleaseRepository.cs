using MusicLike.Models.Artists;
using MusicLike.Models.Releases;
using MusicLike.Services;

namespace MusicLike.Repositories
{
    public interface IReleasesRepository : IRepository<Releases>
    {
        Task<Releases> Update(Releases entity);
    }
    public class ReleaseRepository : Repository<Releases>, IReleasesRepository
    {
        private readonly MusicDbContext _db;

        public ReleaseRepository(MusicDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Releases> Update(Releases entity)
        {
            _db.Releases.Update(entity);
            await Save();
            return entity;
        }

    }
}
