using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Users;
using System.Linq.Expressions;
using System.Linq;
using MusicLike.Services;
using MusicLike.Models.Country;

namespace MusicLike.Repositories
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> Update(Users entity);
        Task<List<Users>> GetAllWithRelatedData();
    }
    public class UserRepository : Repository<Users>, IUserRepository
    {
        private readonly MusicDbContext _db;

        public UserRepository(MusicDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Users> Update(Users entity)
        {
            _db.Users.Update(entity);
            await Save();
            return entity;
        }
        public async Task<List<Users>> GetAllWithRelatedData()
        {
            return await _db.Users
                .Include(u => u.UserType)
                .Include(u => u.Gender)
                .Include(u => u.Country)
                .ToListAsync();
        }
    }
}
