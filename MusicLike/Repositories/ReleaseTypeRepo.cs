using Microsoft.EntityFrameworkCore;
using MusicLike.Models.ReleaseType;
using MusicLike.Services;

namespace MusicLike.Repositories
{
    public interface IReleaseTypeRepo 
    {
        Task<IEnumerable<ReleaseType>> GetAllReleaseTypesAsync();
        Task<ReleaseType> GetReleaseTypeByIdAsync(int id);
        Task AddReleaseTypeAsync(ReleaseType releaseType);
        Task UpdateReleaseTypeAsync(ReleaseType releaseType);
        Task DeleteReleaseTypeAsync(int id);
    }
    public class ReleaseTypeRepo : IReleaseTypeRepo
    {
        private readonly MusicDbContext _db;

        public ReleaseTypeRepo(MusicDbContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<ReleaseType>> GetAllReleaseTypesAsync()
        {
            return await _db.ReleaseType.ToListAsync();
        }

        public async Task<ReleaseType> GetReleaseTypeByIdAsync(int id)
        {
            return await _db.ReleaseType.FindAsync(id);
        }

        public async Task AddReleaseTypeAsync(ReleaseType releaseType)
        {
            _db.ReleaseType.Add(releaseType);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateReleaseTypeAsync(ReleaseType releaseType)
        {
            _db.Entry(releaseType).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteReleaseTypeAsync(int id)
        {
            var releaseType = await _db.ReleaseType.FindAsync(id);
            if (releaseType != null)
            {
                _db.ReleaseType.Remove(releaseType);
                await _db.SaveChangesAsync();
            }
        }
    }
}
