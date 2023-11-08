using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Country;
using MusicLike.Services;
using System.Linq.Expressions;

namespace MusicLike.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> GetByIdAsync(int id);
        Task<IEnumerable<Country>> GetAllAsync();
        Task<IEnumerable<Country>> FindAsync(Expression<Func<Country, bool>> predicate);
        Task AddAsync(Country country);
        void Update(Country country);
        void Remove(Country country);
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly MusicDbContext _context;

        public CountryRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Set<Country>().FindAsync(id);
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Set<Country>().ToListAsync();
        }

        public async Task<IEnumerable<Country>> FindAsync(Expression<Func<Country, bool>> predicate)
        {
            return await _context.Set<Country>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Country country)
        {
            await _context.Set<Country>().AddAsync(country);
        }

        public void Update(Country country)
        {
            _context.Entry(country).State = EntityState.Modified;
        }

        public void Remove(Country country)
        {
            _context.Set<Country>().Remove(country);
        }
    }
}
