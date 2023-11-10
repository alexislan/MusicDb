using AutoMapper;
using MusicLike.Models.Artists.Dto;
using MusicLike.Models.Artists;
using MusicLike.Repositories;
using System.Net;
using System.Web.Http;
using MusicLike.Models.Releases.Dto;
using MusicLike.Models.Releases;
using MusicLike.Models.Rating;
using MusicLike.Models.Genres;

namespace MusicLike.Services
{
    public class ReleaseService
    {
        private readonly IReleasesRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IReleaseTypeRepo _releaseTypeRepo;
        private readonly IGenresRepository _genreRepository;


        public ReleaseService(IReleasesRepository userRepo, IMapper mapper, IRatingRepository ratingRepository, IArtistRepository artistRepository, IReleaseTypeRepo releaseTypeRepo, IGenresRepository genreRepository)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _artistRepository = artistRepository;
            _releaseTypeRepo = releaseTypeRepo;
            _genreRepository = genreRepository;
        }
        private async Task<Releases> GetOneByIdOrException(int id)
        {
            var release = await _userRepo.GetOne(r => r.Id == id);

            if (release == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return release;
        }
        public async Task<CreateReleaseDto> Create(CreateReleaseDto release)
        {
            var releases = _mapper.Map<Releases>(release);

            await _userRepo.Add(releases);
            return _mapper.Map<CreateReleaseDto>(releases);
        }
        public async Task<ReleaseUpdateDto> UpdateById(int id, ReleaseUpdateDto updateReleaseDto)
        {
            var release = await GetOneByIdOrException(id);

            release.Name = updateReleaseDto.Name;
            release.ReleaseDate = updateReleaseDto.ReleaseDate;
            release.ArtistId = updateReleaseDto.ArtistId;
            release.ReleaseTypeId = updateReleaseDto.ReleaseTypeId;
            release.GenreId = updateReleaseDto.GenreId;
            release.UrlImage = updateReleaseDto.UrlImage;

            await _userRepo.Update(release);

            return _mapper.Map<ReleaseUpdateDto>(release);
        }
        public async Task<ReleasesDto> GetById(int id)
        {
            var release = await GetOneByIdOrException(id);

            if (release != null)
            {
                release.Artist = await _artistRepository.GetOne(r => r.Id == release.ArtistId);
                release.ReleaseType = await _releaseTypeRepo.GetReleaseTypeByIdAsync(release.ReleaseTypeId);
                release.Genre = await _genreRepository.GetByIdAsync(release.GenreId);
            }

            var mapped = _mapper.Map<ReleasesDto>(release);

            return mapped;
        }
        public async Task DeleteById(int id)
        {
            var user = await GetOneByIdOrException(id);

            await _userRepo.Delete(user);
        }
        public async Task<List<ReleaseGetDto>> GetAllWithRelatedData()
        {
            var users = await _userRepo.GetAllWithRelatedData();

            return _mapper.Map<List<ReleaseGetDto>>(users);
        }
    }
}
