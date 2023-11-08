using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Gender;
using MusicLike.Services;
using System.Linq.Expressions;

namespace MusicLike.Repositories
{
    public interface IGenderRepository
    {
        Task<Gender> GetByIdAsync(int id);
        Task<IEnumerable<Gender>> GetAllAsync();
        Task<IEnumerable<Gender>> FindAsync(Expression<Func<Gender, bool>> predicate);
        Task AddAsync(Gender gender);
        void Update(Gender gender);
        void Remove(Gender gender);
    }
    public class GenderRepository : IGenderRepository
    {
        private readonly MusicDbContext _context;

        public GenderRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<Gender> GetByIdAsync(int id)
        {
            return await _context.Set<Gender>().FindAsync(id);
        }

        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
            return await _context.Set<Gender>().ToListAsync();
        }

        public async Task<IEnumerable<Gender>> FindAsync(Expression<Func<Gender, bool>> predicate)
        {
            return await _context.Set<Gender>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Gender gender)
        {
            await _context.Set<Gender>().AddAsync(gender);
        }

        public void Update(Gender gender)
        {
            _context.Entry(gender).State = EntityState.Modified;
        }

        public void Remove(Gender gender)
        {
            _context.Set<Gender>().Remove(gender);
        }
    }
}
