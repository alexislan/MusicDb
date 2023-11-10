using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLike.Models.Genres.GenresDto;
using MusicLike.Models.Releases.Dto;
using MusicLike.Models.Review.Dto;
using MusicLike.Models.Users.Dto;
using MusicLike.Repositories;
using MusicLike.Services;

namespace MusicLike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly ReviewService _userService;
        private readonly MusicDbContext _Db;

        public ReviewController( ReviewService userService, MusicDbContext db)
        {

            _userService = userService;
            _Db = db;
        }


        [HttpPost("CreateReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CreateReviewDto>> CreateReview([FromBody] CreateReviewDto usersDto)
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
        public async Task<ActionResult<ReviewDto>> GetReview(int id) 
        {
            try
            {
                return Ok(await _userService.GetById(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound(new { message = $"No user with Id = {id}" });
            }
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ReviewDto>> Put(int id, [FromBody] ReviewDto reviewDto)
        {
            try
            {
                var ArtistUpdate = await _userService.UpdateById(id, reviewDto);
                return Ok(ArtistUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
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
        [HttpGet("GetReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ReviewResponseDto>> GetReviews()
        {
            return Ok(_Db.Reviews.ToList());
        }
    }
}
