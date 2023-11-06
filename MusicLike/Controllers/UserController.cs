using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLike.Models.Users.Dto;
using MusicLike.Models.Users;
using MusicLike.Services;

namespace MusicLike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MusicDbContext _Db;
        private readonly IEncoderService _EncoderService;
        public UserController(MusicDbContext db, IEncoderService encoderService) 
        { 
            _Db = db;
            _EncoderService = encoderService;
        }
        
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<CreateUser> CreateUser([FromBody] CreateUser usersDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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

            //var hashedPass = _EncoderService.Encode(usersDto.Password);
            usersDto.Password = _EncoderService.Encode(usersDto.Password);

            Users Modelo = new()
            {
                Name = usersDto.Name,
                Email = usersDto.Email,
                UserName = usersDto.UserName,
                Password = usersDto.Password,
                UserTypeId = usersDto.UserTypeId,
                GenderId = usersDto.GenderId,
                CountryId = usersDto.CountryId
            };

            _Db.Users.Add(Modelo);
            _Db.SaveChanges();
            return Created("GetUser", usersDto);
        }
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LoginUser> LoginUser([FromBody] LoginUser loginUser)
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
            var User = _Db.Users.FirstOrDefault(u => u.UserName.ToLower() == loginUser.UserName.ToLower());

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
               Password = User.Password,
               UserTypeId = User.UserTypeId,
               GenderId = User.GenderId,
               CountryId = User.CountryId,
            };
            return Ok(Modelo);
        }
    }
}
