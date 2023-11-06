using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLike.Models.Country.Dto;
using MusicLike.Models.Gender.Dto;
using MusicLike.Models.Genres.GenresDto;
using MusicLike.Models.Users.Dto;
using MusicLike.Services;

namespace MusicLike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly MusicDbContext _Db;

        public GetController(MusicDbContext db)
        {
            _Db = db;
        }

        [HttpGet("GetGender")]
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
    }
}
