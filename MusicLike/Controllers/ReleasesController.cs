using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLike.Models.Artists.Dto;
using MusicLike.Models.Releases.Dto;
using MusicLike.Repositories;
using MusicLike.Services;

namespace MusicLike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleasesController : ControllerBase
    {
        private readonly MusicDbContext _Db;
        private readonly IEncoderService _EncoderService;
        private readonly AuthService _authService;
        private readonly ReleaseService _userService;
        private readonly ICountryRepository _countryRepo;
        private readonly IGenderRepository _genderRepo;
        private readonly IUserTypeRepository _userTypeRepo;
        public ReleasesController(MusicDbContext db, IEncoderService encoderService, AuthService authService, ReleaseService userService, ICountryRepository countryRepository, IGenderRepository genderRepository, IUserTypeRepository userTypeRepository)
        {
            _Db = db;
            _EncoderService = encoderService;
            _authService = authService;
            _userService = userService;
            _countryRepo = countryRepository;
            _genderRepo = genderRepository;
            _userTypeRepo = userTypeRepository;
        }
        [HttpPost("CreateRelease")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CreateReleaseDto>> CreateArtist([FromBody] CreateReleaseDto usersDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var ReleaseCreate = await _userService.Create(usersDto);
                return Created("GetUser", ReleaseCreate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(new { message = "Error al crear el Release" });
            }
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReleasesDto>> Get(int id)
        {
            try
            {
                return Ok(await _userService.GetById(id));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound(new { message = $"No user with Id = {id}" });
            }
        }
        [HttpPut("{id:int}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ReleaseUpdateDto>> Put(int id, [FromBody] ReleaseUpdateDto updatEReleadseDto)
        {
            try
            {
                var ArtistUpdate = await _userService.UpdateById(id, updatEReleadseDto);
                return Ok(ArtistUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
