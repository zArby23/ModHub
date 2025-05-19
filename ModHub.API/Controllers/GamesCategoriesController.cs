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
        public async Task<IActionResult> GameCategories([FromBody] GameCategory gamecategory)
        {
            _Context.GamesCategories.Add(gamecategory);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = gamecategory.Id }, gamecategory);
        }

        [HttpPut]
        public async Task<IActionResult> Put(GameCategory gamecategory)
        {
            _Context.GamesCategories.Update(gamecategory);
            await _Context.SaveChangesAsync();
            return Ok(gamecategory);
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