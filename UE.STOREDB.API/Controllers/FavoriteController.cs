﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UE.STOREDB.DOMAIN.Core.DTO;
using UE.STOREDB.DOMAIN.Core.Interfaces;

namespace UE.STOREDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            var favorites = await _favoriteService.GetAll(userId);
            if (favorites == null)
                return NotFound();
            return Ok(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(FavoriteInsertDTO favorite)
        {
            var result = await _favoriteService.Insert(favorite);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _favoriteService.Delete(id);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
