using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;
using ModHub.Shared.Entities;

namespace ModHub.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/mods")]
    [ApiController]
    public class ModsController : ControllerBase
    {
        private readonly DataContext _Context;

        public ModsController(DataContext context)
        {
            _Context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var mods = await _Context.Mods.ToListAsync();
            return Ok(mods);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mod = await _Context.Mods.FirstOrDefaultAsync(x=> x.Id == id);
            if (mod == null)
            {
                return NotFound();
            }
            return Ok(mod);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Mod mod)
        {
            _Context.Mods.Add(mod);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = mod.Id }, mod);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Mod mod)
        {
            mod.UpdateDate = DateTime.Now;
            _Context.Mods.Update(mod);
            await _Context.SaveChangesAsync();
            return Ok(mod);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mod = await _Context.Mods.FirstOrDefaultAsync(x => x.Id == id);
            var reports = _Context.Reports.Where(r => r.ModId == id);
            _Context.Reports.RemoveRange(reports);
            await _Context.SaveChangesAsync();

            var FilasAfectadas = await _Context.Mods
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
