using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;
using ModHub.Shared.Entities;

namespace ModHub.API.Controllers
{
    [Route("api/gamescategories")]
    [ApiController]
    public class GamesCategoriesController : ControllerBase
    {
        private readonly DataContext _Context;

        public GamesCategoriesController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gamecategory = await _Context.GamesCategories.ToListAsync();
            return Ok(gamecategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _Context.GamesCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> GameCategories([FromBody] GameCategory gameCategory)
        {
            _Context.GamesCategories.Add(gameCategory);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = gameCategory.Id }, gameCategory);
        }

        [HttpPut]
        public async Task<IActionResult> Put(GameCategory gameCategory)
        {
            _Context.GamesCategories.Update(gameCategory);
            await _Context.SaveChangesAsync();
            return Ok(gameCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var FilasAfectadas = await _Context.GamesCategories
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