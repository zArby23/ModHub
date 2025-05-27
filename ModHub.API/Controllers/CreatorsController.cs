using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;
using ModHub.Shared.Entities;

namespace ModHub.API.Controllers
{
    [Route("api/creators")]
    [ApiController]
    public class CreatorsController : ControllerBase
    {
        private readonly DataContext _Context;

        public CreatorsController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var creators = await _Context.Creators.ToListAsync();
            return Ok(creators);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var creator = await _Context.Creators.FirstOrDefaultAsync(x => x.Id == id);
            if (creator == null)
            {
                return NotFound();
            }
            return Ok(creator);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Creator creator)
        {
            _Context.Creators.Add(creator);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = creator.Id }, creator);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Creator creator)
        {
            _Context.Creators.Update(creator);
            await _Context.SaveChangesAsync();
            return Ok(creator);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var creator = await _Context.Creators.FirstOrDefaultAsync(x => x.Id == id);
            var reports = _Context.Reports.Where(r => r.CreatorId == id).ToList();
            var mods = _Context.Mods.Where(m => m.CreatorId == id).ToList();
            foreach (var report in reports)
            {
                report.CreatorName = "[Deleted Creator]";
                report.CreatorId = null;
            }
            foreach (var mod in mods)
            {
                mod.CreatorName = "[Deleted Creator]";
                mod.CreatorId = null;
            }
            await _Context.SaveChangesAsync();

            var FilasAfectadas = await _Context.Creators
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
