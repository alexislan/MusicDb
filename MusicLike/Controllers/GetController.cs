using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLike.Models.Country.Dto;
using MusicLike.Models.Gender.Dto;
using MusicLike.Models.Genres.GenresDto;
using MusicLike.Models.Users.Dto;
using MusicLike.Repositories;
using MusicLike.Services;

namespace MusicLike.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly MusicDbContext _Db;
        private readonly ICountryRepository _countryRepo;
        private readonly IGenderRepository _genderRepo;
        private readonly IUserTypeRepository _userTypeRepo;
        private readonly UserService _userService;

        public GetController(MusicDbContext db, ICountryRepository countryRepository, IGenderRepository genderRepository, IUserTypeRepository userTypeRepository, UserService userService)
        {
            _Db = db;
            _countryRepo = countryRepository;
            _genderRepo = genderRepository;
            _userTypeRepo = userTypeRepository;
            _userService = userService;
            _userService = userService;
        }

        [HttpGet("GetGender")]
        [Authorize( Roles = "User" )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GenderDto>> GetGender()
        {
            return Ok(_Db.Gender.ToList());
        }

        [HttpGet("GetCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CountryDto>> GetCountry()
        {
            return Ok(_Db.Country.ToList());
        }
        [HttpGet("GetGenres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GenresDto>> GetGenre()
        {
            return Ok(_Db.Genres.ToList());
        }
        [HttpGet("GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task< ActionResult<UsersDto>> GetUsers()
        {
            var users = await _userService.GetAllWithRelatedData();

            if (users == null || users.Count == 0)
            {
                return NotFound();
            }
            return Ok(users);
        }
    }
}
