using MusicLike.Models.Genres;
using MusicLike.Services;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Genres.GenresDto;

namespace MusicLike.Repositories
{
    public interface IGenresRepository 
    {
        Task<Genres> GetByIdAsync(int id);
        Task<List<Genres>> GetAllAsync();
        Task<List<Genres>> FindAsync(Expression<Func<Genres, bool>> predicate);
        Task AddAsync(Genres genre);
        Task UpdateAsync(Genres genre);
        Task DeleteAsync(Genres genre);
        //Task<List<Genres>> GetGenresByReleaseId(int releaseId);
    }
    public class GenresRepository : IGenresRepository
    {
        private readonly MusicDbContext _db;

        public GenresRepository(MusicDbContext db)
        {
            _db = db;
        }
        //public async Task<List<Genres>> GetGenresByReleaseId(int releaseId)
        //{
        //    // Realiza una consulta para obtener los géneros asociados al lanzamiento por su ID
        //    var genres = await _db.Genres
        //        .Where(g => g.Releases.Any(rg => rg.Id == releaseId))
        //        .Select(g => new Genres
        //        {
        //            Id = g.Id,
        //            Name = g.Name,
        //        })
        //        .ToListAsync();

        //    return genres;
        //}
        public async Task<Genres> GetByIdAsync(int id)
        {
            return await _db.Genres.FindAsync(id);
        }

        public async Task<List<Genres>> GetAllAsync()
        {
            return await _db.Genres.ToListAsync();
        }

        public async Task<List<Genres>> FindAsync(Expression<Func<Genres, bool>> predicate)
        {
            return await _db.Genres.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Genres genre)
        {
            _db.Genres.Add(genre);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genres genre)
        {
            _db.Genres.Update(genre);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genres genre)
        {
            _db.Genres.Remove(genre);
            await _db.SaveChangesAsync();
        }
    }
}
