using MusicLike.Models.Users.Dto;
using MusicLike.Models.Users;
using AutoMapper;
using MusicLike.Repositories;
using MusicLike.Models.Artists.Dto;
using MusicLike.Models.Artists;
using System.Net;
using System.Web.Http;
using MusicLike.Models;
using MusicLike.Models.Releases.Dto;


namespace MusicLike.Services
{
    public class ArtistService
    {
        private readonly IArtistRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepo;
        private readonly IGenderRepository _genderRepo;
        private readonly IReleasesRepository _releasesRepo;


        public ArtistService(IArtistRepository userRepo, IMapper mapper, ICountryRepository countryRepository, IGenderRepository genderRepository, IReleasesRepository releasesRepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _countryRepo = countryRepository;
            _genderRepo = genderRepository;
            _releasesRepo = releasesRepo; 

        }
        private async Task<Artist> GetOneByIdOrException(int id)
        {
            var artist = await _userRepo.GetOne(u => u.Id == id);

            if (artist == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return artist;
        }
        public async Task<CreateArtistResponseDto> Create(CreateArtistDto createArtistDto)
        {
            var Artist = _mapper.Map<Artist>(createArtistDto);

            await _userRepo.Add(Artist);

            return _mapper.Map<CreateArtistResponseDto>(Artist);
        }
        public async Task<ArtistUpdateDto> UpdateById(int id, ArtistUpdateDto updateUserDto)
        {
            var artist = await GetOneByIdOrException(id);

            var updated = _mapper.Map(updateUserDto, artist);

            return _mapper.Map<ArtistUpdateDto>(await _userRepo.Update(updated));
        }
        public async Task<ArtistDto> GetById(int id)
        {
            var artist = await GetOneByIdOrException(id);

            var release = await _releasesRepo.GetAllByUserId(id);
            artist.Country = await _countryRepo.GetByIdAsync(artist.CountryId);
            artist.Gender = await _genderRepo.GetByIdAsync(artist.GenderId);

            var mapped = _mapper.Map<ArtistDto>(artist);

            mapped.Releases = release;
            return mapped;
        }
        public async Task DeleteById(int id)
        {
            var user = await GetOneByIdOrException(id);

            await _userRepo.Delete(user);
        }
        public async Task<List<ArtistDto>> GetAllWithRelatedData()
        {
            var users = await _userRepo.GetAllWithRelatedData();
            return _mapper.Map<List<ArtistDto>>(users);
        }
    }
}
