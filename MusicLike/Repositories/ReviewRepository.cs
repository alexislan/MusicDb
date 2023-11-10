using MusicLike.Models.Review.Dto;
using MusicLike.Models.Review;
using AutoMapper;
using MusicLike.Services;
using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Users;

namespace MusicLike.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<Review> Update(Review entity);
        //Task<List<ReviewDto>> GetAllByUserId(int userId);
    }
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly MusicDbContext _db;
        private readonly IMapper _mapper;

        public ReviewRepository(MusicDbContext db, IMapper mapper) : base(db)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Review> Update(Review entity)
        {
            _db.Reviews.Update(entity);
            await Save();
            return entity;
        }
    }
}
