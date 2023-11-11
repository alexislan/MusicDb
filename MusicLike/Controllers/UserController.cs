using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLike.Models.Users.Dto;
using MusicLike.Models.Users;
using MusicLike.Services;
using MusicLike.Models.UserType;
using MusicLike.Repositories;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace MusicLike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MusicDbContext _Db;
        private readonly IEncoderService _EncoderService;
        private readonly AuthService _authService;
        private readonly UserService _userService;
        private readonly ICountryRepository _countryRepo;
        private readonly IGenderRepository _genderRepo;
        private readonly IUserTypeRepository _userTypeRepo;
        public UserController(MusicDbContext db, IEncoderService encoderService, AuthService authService, UserService userService, ICountryRepository countryRepository, IGenderRepository genderRepository, IUserTypeRepository userTypeRepository) 
        { 
            _Db = db;
            _EncoderService = encoderService;
            _authService = authService;
            _userService = userService;
            _countryRepo = countryRepository;
            _genderRepo = genderRepository;
            _userTypeRepo = userTypeRepository;
        }
        
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CreateUser>> CreateUser([FromBody] CreateUser usersDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (_Db.Users.FirstOrDefault(u => u.Email.ToLower() == usersDto.Email.ToLower()) != null)
                {
                    ModelState.AddModelError("email ya existe", "El Email ingresado ya existe");
                    return BadRequest(ModelState);
                }
                if (_Db.Users.FirstOrDefault(u => u.UserName.ToLower() == usersDto.UserName.ToLower()) != null)
                {
                    ModelState.AddModelError("UserName ya existe", "El Username ingresado ya existe");
                    return BadRequest(ModelState);
                }
                if (usersDto == null)
                {
                    return BadRequest(usersDto);
                }
                var UserCreate = await _userService.Create(usersDto);
                if (UserCreate != null)
                {
                    return Created("GetUser", UserCreate);
                }
                else
                {
                    return BadRequest(new { message = "Error al crear el usuario" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new { message = "Ocurrio un error con el servidor" });
            }
        }
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LoginUser>> LoginUser([FromBody] LoginUser loginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (loginUser.UserName == null)
            {
                ModelState.AddModelError("Error", "credentials incorrectas");
                return BadRequest(ModelState);
            }
            var User = await _userService.GetByUsernameOrEmail(loginUser.UserName);
            var Country1 = await _countryRepo.GetByIdAsync(User.CountryId);
            var Gender1 = await _genderRepo.GetByIdAsync(User.GenderId);
            var UserType1 = await _userTypeRepo.GetByIdAsync(User.UserTypeId);

            if (User == null) 
            {
                ModelState.AddModelError("Error", "credentials incorrectas");
                return BadRequest(ModelState);
            }
            //if (User.Password != loginUser.Password)
            if(!_EncoderService.Verify(loginUser.Password, User.Password))
            {
                ModelState.AddModelError("Error", "credentials incorrectas");
                return BadRequest(ModelState);
            }
            var Modelo = new UsersDto
            {
               Id = User.Id,
               Name = User.UserName,
               Email = User.Email,
               UserName = User.UserName,
               UserType = UserType1,
               Gender = Gender1,
               Country = Country1,
            };
            var Token = _authService.GenerateJwtToken(User);
            return Ok(new LoginResponse { Token = Token, User = Modelo });

        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsersDto>> Get(int id)
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
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UpdateDto>> Put(int id, [FromBody] UpdateDto updateUserDto)
        {
            try
            {
                var userUpdated = await _userService.UpdateById(id, updateUserDto);
                return Ok(userUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
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
        [HttpGet("GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UsersDto>> GetUsers()
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
