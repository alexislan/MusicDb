using AutoMapper;
using MusicLike.Models.Artists.Dto;
using MusicLike.Models.Artists;
using MusicLike.Repositories;
using System.Net;
using System.Web.Http;
using MusicLike.Models.Releases.Dto;
using MusicLike.Models.Releases;
using MusicLike.Models.Rating;

namespace MusicLike.Services
{
    public class ReleaseService
    {
        private readonly IReleasesRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IReleaseTypeRepo _releaseTypeRepo;


        public ReleaseService(IReleasesRepository userRepo, IMapper mapper, IRatingRepository ratingRepository, IArtistRepository artistRepository, IReleaseTypeRepo releaseTypeRepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _artistRepository = artistRepository;
            _releaseTypeRepo = releaseTypeRepo;
        }
        private async Task<ReleasesDto> GetOneByIdOrException(int id)
        {
            var release = await _userRepo.GetOne(r => r.Id == id);

            if (release == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var rating = await _ratingRepository.GetRatingById(release.RatingId);
            var artist = await _artistRepository.GetOne(r => r.Id == release.ArtistId);
            //var releaseType = await _releaseTypeRepo.GetReleaseTypeByIdAsync(release.ReleaseTypeId);
            var art = new CreateArtistDto
            {
                FullName = artist.FullName,
                GenderId = artist.GenderId,
                CountryId = artist.CountryId,
            };
            var releaseDto = new ReleasesDto
            {
                Name = release.Name,
                ReleaseDate = release.ReleaseDate,
                Score = release.Score,
                Artist = art,
                ReleaseType = release.ReleaseType,
                Rating = rating,
            };

            return releaseDto;
        }
        public async Task<CreateReleaseDto> Create(CreateReleaseDto createReleaseDto)
        {
            var release = _mapper.Map<Releases>(createReleaseDto);

            await _userRepo.Add(release);

            return _mapper.Map<CreateReleaseDto>(release);
        }
        public async Task<ReleaseUpdateDto> UpdateById(int id, ReleaseUpdateDto updateReleaseDto)
        {
            var release = await GetOneByIdOrException(id);

            var updated = _mapper.Map(updateReleaseDto, release);
            var up = new Releases
            {
                Name = updateReleaseDto.Name,
                ReleaseDate = updateReleaseDto.ReleaseDate,
                Score = updateReleaseDto.Score,
                ArtistId = updateReleaseDto.ArtistId,
                ReleaseTypeId = updateReleaseDto.ReleaseTypeId,
                RatingId = updateReleaseDto.RatingId,
            };

            return _mapper.Map<ReleaseUpdateDto>(await _userRepo.Update(up));
        }
        public async Task<ReleasesDto> GetById(int id)
        {
            var release = await GetOneByIdOrException(id);

            var mapped = _mapper.Map<ReleasesDto>(release);

            return mapped;
        }
        //public async Task DeleteById(int id)
        //{
        //    var user = await GetOneByIdOrException(id);

        //    await _userRepo.Delete(user);
        //}
        //public async Task<List<ArtistDto>> GetAllWithRelatedData()
        //{
        //    var users = await _userRepo.GetAllWithRelatedData();

        //    return _mapper.Map<List<ArtistDto>>(users);
        //}
    }
    }
