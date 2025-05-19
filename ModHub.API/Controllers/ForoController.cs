using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;
using ModHub.Shared.Entities;

namespace ModHub.API.Controllers
{

    [Route("api/foros")]
    [ApiController]
    public class ForoController : ControllerBase
    {
        private readonly DataContext _Context;

        public ForoController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var foro = await _Context.Foros.ToListAsync();
            return Ok(foro);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var foro = await _Context.Foros.FirstOrDefaultAsync(x => x.Id == id);
            if (foro == null)
            {
                return NotFound();
            }
            return Ok(foro);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Foro foro)
        {
            _Context.Foros.Add(foro);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = foro.Id }, foro);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Foro foro)
        {
            _Context.Foros.Update(foro);
            await _Context.SaveChangesAsync();
            return Ok(foro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var FilasAfectadas = await _Context.Foros
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
