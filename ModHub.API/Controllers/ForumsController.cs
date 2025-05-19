using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;
using ModHub.Shared.Entities;

namespace ModHub.API.Controllers
{
    [Route("api/forums")]
    [ApiController]
    public class ForumsController : ControllerBase
    {
        private readonly DataContext _Context;

        public ForumsController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var forums = await _Context.Forums.ToListAsync();
            return Ok(forums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var forums = await _Context.Forums.FirstOrDefaultAsync(x => x.Id == id);
            if (forums == null)
            {
                return NotFound();
            }
            return Ok(forums);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Forums forums)
        {
            _Context.Foros.Add(forums);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = forums.Id }, forums);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Forums forums)
        {
            _Context.Foros.Update(forums);
            await _Context.SaveChangesAsync();
            return Ok(forums);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var FilasAfectadas = await _Context.Forums
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