﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;
using ModHub.Shared.Entities;

namespace ModHub.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly DataContext _Context;

        public ReportsController(DataContext context)
        {
            _Context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var report = await _Context.Reports.ToListAsync();
            return Ok(report);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _Context.Reports.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Report([FromBody] Report report)
        {
            _Context.Reports.Add(report);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = report.Id }, report);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Report report)
        {
            _Context.Reports.Update(report);
            await _Context.SaveChangesAsync();
            return Ok(report);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var FilasAfectadas = await _Context.Reports
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