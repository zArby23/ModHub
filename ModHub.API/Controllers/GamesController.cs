using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;
using ModHub.Shared.DTOs;
using ModHub.Shared.Entities;

namespace ModHub.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly DataContext _Context;

        public GamesController(DataContext context)
        {
            _Context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _Context.Games.ToListAsync();
            return Ok(games);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var game = await _Context.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Game game)
        {
            _Context.Games.Add(game);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
        }

        [HttpPost("with-categories")]
        public async Task<IActionResult> CreateWithCategories([FromBody] GameWithCategoriesDto dto)
        {
            if (dto == null || dto.Game == null)
                return BadRequest();

            // 1. Crear el juego (o actualizar si ya existe)
            var game = dto.Game;
            _Context.Games.Add(game);
            await _Context.SaveChangesAsync();

            // 2. Eliminar relaciones previas si es edición
            var existingRelations = _Context.GamesCategories.Where(gc => gc.GameId == game.Id);
            _Context.GamesCategories.RemoveRange(existingRelations);

            // 3. Crear nuevas relaciones
            foreach (var categoryId in dto.CategoryIds.Distinct())
            {
                _Context.GamesCategories.Add(new GameCategory
                {
                    GameId = game.Id,
                    CategoryId = categoryId
                });
            }

            await _Context.SaveChangesAsync();

            return Ok(game);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Game game)
        {
            _Context.Games.Update(game);
            await _Context.SaveChangesAsync();
            return Ok(game);
        }

        [HttpPut("with-categories")]
        public async Task<IActionResult> PutWithCategories([FromBody] GameWithCategoriesDto dto)
        {
            if (dto == null || dto.Game == null)
                return BadRequest();

            // 1. Verifica si el juego existe
            var existingGame = await _Context.Games.FindAsync(dto.Game.Id);
            if (existingGame == null)
                return NotFound();

            // 2. Actualiza los campos del juego
            existingGame.FullName = dto.Game.FullName;
            existingGame.Description = dto.Game.Description;
            // Agrega aquí otros campos si los hay

            // 3. Elimina relaciones antiguas
            var oldRelations = _Context.GamesCategories.Where(gc => gc.GameId == existingGame.Id);
            _Context.GamesCategories.RemoveRange(oldRelations);

            // 4. Agrega nuevas relaciones
            foreach (var categoryId in dto.CategoryIds.Distinct())
            {
                _Context.GamesCategories.Add(new GameCategory
                {
                    GameId = existingGame.Id,
                    CategoryId = categoryId
                });
            }

            await _Context.SaveChangesAsync();

            return Ok(existingGame);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var FilasAfectadas = await _Context.Games
                    .Where(x => x.Id == id)
                    .ExecuteDeleteAsync();
            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
