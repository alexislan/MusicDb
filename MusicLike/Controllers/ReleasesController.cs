﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLike.Models.Artists.Dto;
using MusicLike.Models.Releases;
using MusicLike.Models.Releases.Dto;
using MusicLike.Models.Users.Dto;
using MusicLike.Repositories;
using MusicLike.Services;

namespace MusicLike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleasesController : ControllerBase
    {
        private readonly ReleaseService _userService;

        public ReleasesController(MusicDbContext db, IEncoderService encoderService, AuthService authService, ReleaseService userService, ICountryRepository countryRepository, IGenderRepository genderRepository, IUserTypeRepository userTypeRepository)
        {
            _userService = userService;
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
        [Authorize(Roles = "Admin")]
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
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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

        [HttpGet("GetRelease")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UsersDto>> GetReleases()
        {
            var Releases = await _userService.GetAllWithRelatedData();
            if (Releases == null || Releases.Count == 0)
            {
                return NotFound();
            }
            return Ok(Releases);
        }
    }
}
