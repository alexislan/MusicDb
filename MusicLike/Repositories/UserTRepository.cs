using Microsoft.EntityFrameworkCore;
using MusicLike.Models.UserType;
using MusicLike.Services;
using System.Linq.Expressions;


namespace MusicLike.Repositories
{
    public interface IUserTypeRepository
    {
        Task<UserType> GetByIdAsync(int id);
        Task<IEnumerable<UserType>> GetAllAsync();
        Task<IEnumerable<UserType>> FindAsync(Expression<Func<UserType, bool>> predicate);
        Task AddAsync(UserType userType);
        void Update(UserType userType);
        void Remove(UserType userType);
    }
    public class UserTRepository : IUserTypeRepository
    {
        private readonly MusicDbContext _context;

        public UserTRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<UserType> GetByIdAsync(int id)
        {
            return await _context.UserTypes.FindAsync(id);
        }

        public async Task<IEnumerable<UserType>> GetAllAsync()
        {
            return await _context.UserTypes.ToListAsync();
        }

        public async Task<IEnumerable<UserType>> FindAsync(Expression<Func<UserType, bool>> predicate)
        {
            return await _context.UserTypes.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(UserType userType)
        {
            _context.UserTypes.Add(userType);
            await _context.SaveChangesAsync();
        }

        public void Update(UserType userType)
        {
            _context.UserTypes.Update(userType);
            _context.SaveChanges();
        }

        public void Remove(UserType userType)
        {
            _context.UserTypes.Remove(userType);
            _context.SaveChanges();
        }
    }
}
