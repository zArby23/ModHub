using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;
using ModHub.Shared.Entities;
namespace ModHub.API.Controllers
{

    [ApiController]
    [Route("/api/user")]
    public class UserController:ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }


        //GET para obtener una lista de resultados
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Users.ToListAsync());  //200
        }


        //Get por parametro

        [HttpGet("{Id:int}")]
        public async Task<ActionResult> Get(int Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);//200
            if (user == null)
            {
                return NotFound();//404
            }

            return Ok(user);//200

        }

        //Insertar datos / crear registros
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok(user);

        }

        //Actualizar o modificar datos

        [HttpPut]
        public async Task<ActionResult> Put(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return Ok(user);

        }

        [HttpDelete]
        [HttpGet("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var filasAfectadas = await _context.Users   //200

                .Where(x => x.Id == Id)
                .ExecuteDeleteAsync();


            if (filasAfectadas == 0)
            {
                return NotFound();//404
            }

            return NoContent();//204

        }

    }
}
