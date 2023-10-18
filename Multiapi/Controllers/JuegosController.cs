using Clase.Models;
using Clase.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Clase.Controllers
{
    [Route("[controller]")]

    public class JuegosController : ControllerBase
    {
        private readonly IJuegoService _service;
        private readonly UsersContextSqlServer _context;
        private readonly ILogger<JuegosController> _logger;
        public JuegosController(IJuegoService service, UsersContextSqlServer context, ILogger<JuegosController> logger)
        {
            _service = service;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Juegos>> GetAllJuego([FromQuery] string filterProperty, [FromQuery] string filterValue, [FromQuery] string orderProperty, [FromQuery] string order)
        {
            var juegos = _service.GetAllJuegos(filterProperty, filterValue, orderProperty, order);
            if (!juegos.Any())
            {
                return NotFound("Juegos no encontrados");
            }

            return Ok(juegos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Juegos>> GetJuego(int id)
        {
            var juego = await _service.GetJuegoById(id);
            if (juego == null)
            {
                return NotFound("Juego no encontrado");
            }

            return Ok(juego);
        }

        [HttpPost]
        public async Task<ActionResult<Juegos>> CreateJuego([FromBody] Juegos juego)
        {
            var nuevoJuego = await _service.CreateJuego(juego);
            return Ok(nuevoJuego);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Juegos>> DeleteJuego(int id)
        {
            var juego = await _service.DeleteJuegoById(id);
            if (juego == null)
            {
                return NotFound("Juego no encontrado");
            }
            return Ok(juego);
        }

        [HttpPut]
        public async Task<ActionResult<Juegos>> EditJuego([FromBody] Juegos juego)
        {
            var nuevoJuego = await _service.EditJuego(juego);
            return Ok(nuevoJuego);
        }
    }
}