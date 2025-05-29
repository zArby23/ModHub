using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;
using ModHub.Shared.Entities;

namespace ModHub.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/forums")]
    [ApiController]
    public class ForumsController : ControllerBase
    {
        private readonly DataContext _Context;

        public ForumsController(DataContext context)
        {
            _Context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var forums = await _Context.Forums.ToListAsync();
            return Ok(forums);
        }
        [AllowAnonymous]
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
        public async Task<IActionResult> Post([FromBody] Forum forum)
        {
            _Context.Forums.Add(forum);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = forum.Id }, forum);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Forum forum)
        {
            _Context.Forums.Update(forum);
            await _Context.SaveChangesAsync();
            return Ok(forum);
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