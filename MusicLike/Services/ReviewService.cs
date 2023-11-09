using AutoMapper;
using MusicLike.Models.Releases.Dto;
using MusicLike.Models.Releases;
using MusicLike.Repositories;
using System.Net;
using System.Web.Http;
using MusicLike.Models.Review.Dto;
using MusicLike.Models.Review;

namespace MusicLike.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IReleaseTypeRepo _releaseTypeRepo;
        private readonly IGenresRepository _genreRepository;

        public ReviewService(IReviewRepository userRepo, IMapper mapper, IRatingRepository ratingRepository, IArtistRepository artistRepository, IReleaseTypeRepo releaseTypeRepo, IGenresRepository genreRepository)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _artistRepository = artistRepository;
            _releaseTypeRepo = releaseTypeRepo;
            _genreRepository = genreRepository;
        }
        private async Task<Review> GetOneByIdOrException(int id)
        {
            var release = await _userRepo.GetOne(r => r.Id == id);

            if (release == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return release;
        }
        public async Task<CreateReviewDto> Create(CreateReviewDto review)
        {
            var reviews = _mapper.Map<Review>(review);

            await _userRepo.Add(reviews);
            return _mapper.Map<CreateReviewDto>(review);
        }
        public async Task<ReviewDto> UpdateById(int id, ReviewDto updateReviewDto)
        {
            var review = await GetOneByIdOrException(id);
            review.Text = updateReviewDto.Text;

            await _userRepo.Update(review);

            return _mapper.Map<ReviewDto>(review);
        }
        public async Task<ReviewResponseDto> GetById(int id)
        {
            var review = await GetOneByIdOrException(id);

            var mapped = _mapper.Map<ReviewResponseDto>(review);

            return mapped;
        }
        //public async Task<ReviewResponseDto> GetByReleaseId(int id)
        //{
        //    var review = await GetOneByIdOrException(id);

        //    var mapped = _mapper.Map<ReviewResponseDto>(review);

        //    return mapped;
        //}
        public async Task DeleteById(int id)
        {
            var user = await GetOneByIdOrException(id);

            await _userRepo.Delete(user);
        }
        //public async Task<List<ReleaseGetDto>> GetAllWithRelatedData()
        //{
        //    var users = await _userRepo.GetAllWithRelatedData();

        //    return _mapper.Map<List<ReleaseGetDto>>(users);
        //}
    }
}
