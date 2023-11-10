using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Artists;
using MusicLike.Models.Artists.Dto;
using MusicLike.Models.Releases;
using MusicLike.Models.Releases.Dto;
using MusicLike.Models.Users;
using MusicLike.Services;

namespace MusicLike.Repositories
{
    public interface IReleasesRepository : IRepository<Releases>
    {
        Task<List<ReleaseGetDto>> GetAllWithRelatedData();
        Task<Releases> Update(Releases entity);
        Task<List<ReleaseGetDto>> GetAllByUserId(int artistId);
    }
    public class ReleaseRepository : Repository<Releases>, IReleasesRepository
    {
        private readonly MusicDbContext _db;

        private readonly IMapper _mapper;
        public ReleaseRepository(MusicDbContext db, IMapper mapper) : base(db)
        {
            _db = db;
 
            _mapper = mapper;
        }
        public async Task<List<ReleaseGetDto>> GetAllWithRelatedData()
        {
            var releases = await _db.Releases
                .Include(u => u.ReleaseType)
                .Include(u => u.Artist)
                .Include(u => u.Genre)
                .ToListAsync();

            // Realiza el mapeo de las entidades Releases a ReleaseGetDto
            var releaseDtos = _mapper.Map<List<ReleaseGetDto>>(releases);

            return releaseDtos;
        }
        public async Task<List<ReleaseGetDto>> GetAllByUserId(int artistId)
        {
            var lista = await GetAll(r => r.ArtistId == artistId);
            var result = lista.Select(release => new ReleaseGetDto
            {
                Id = release.Id,
                Name = release.Name,
                ReleaseDate = release.ReleaseDate,
                UrlImage = release.UrlImage,
                Description = release.Description,
            }).ToList();
            return result;
        }
        public async Task<Releases> Update(Releases entity)
        {
            _db.Releases.Update(entity);
            await Save();
            return entity;
        }

    }
}
