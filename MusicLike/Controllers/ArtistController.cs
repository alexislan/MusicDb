using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLike.Models.Artists.Dto;
using MusicLike.Models.Users.Dto;
using MusicLike.Repositories;
using MusicLike.Services;

namespace MusicLike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
       
        private readonly MusicDbContext _Db;
        private readonly IEncoderService _EncoderService;
        private readonly AuthService _authService;
        private readonly ArtistService _userService;
        private readonly ICountryRepository _countryRepo;
        private readonly IGenderRepository _genderRepo;
        private readonly IUserTypeRepository _userTypeRepo;
        public ArtistController(MusicDbContext db, IEncoderService encoderService, AuthService authService, ArtistService userService, ICountryRepository countryRepository, IGenderRepository genderRepository, IUserTypeRepository userTypeRepository)
        {
            _Db = db;
            _EncoderService = encoderService;
            _authService = authService;
            _userService = userService;
            _countryRepo = countryRepository;
            _genderRepo = genderRepository;
            _userTypeRepo = userTypeRepository;
        }
        [HttpPost("CreateArtist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CreateArtistResponseDto>> CreateArtist([FromBody] CreateArtistDto usersDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var UserCreate = await _userService.Create(usersDto);
                return Created("GetUser", UserCreate);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return BadRequest(new { message = "Error al crear el artista" });
            }
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArtistDto>> Get(int id)
        {
            try
            {
                return Ok(await _userService.GetById(id));
            }
            catch
            {
                return NotFound(new { message = $"No user with Id = {id}" });
            }
        }
        [HttpPut("{id:int}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ArtistUpdateDto>> Put(int id, [FromBody] ArtistUpdateDto updateArtistDto)
        {
            try
            {
                var ArtistUpdate = await _userService.UpdateById(id, updateArtistDto);
                return Ok(ArtistUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteById(id);
                // Se puede retornar un No content (204)
                return Ok(new
                {
                    message = $"User with Id = {id} was deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetArtists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ArtistDto>> GetUsers()
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
