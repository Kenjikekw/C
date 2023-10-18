using Clase.Models;
using Clase.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Clase.Controllers
{
    [Route("[controller]")]

    public class  EnfermedadesController : ControllerBase
    {
        private readonly IEnfermedadService _service;
        private readonly UsersContextMySql _context;
        private readonly ILogger<EnfermedadesController> _logger;
        public EnfermedadesController(IEnfermedadService service, UsersContextMySql context, ILogger<EnfermedadesController> logger)
        {
            _service = service;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Enfermedades>> GetAllEnfermedades([FromQuery] string filterProperty, [FromQuery] string filterValue, [FromQuery] string orderProperty, [FromQuery] string order)
        {
            var enfermedades = _service.GetAllEnfermedades(filterProperty, filterValue, orderProperty, order);
            if (!enfermedades.Any())
            {
                return NotFound("Enfermedades no encontradas");
            }

            return Ok(enfermedades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enfermedades>> GetEnfermedad(int id)
        {
            var enfermedad = await _service.GetEnfermedadById(id);
            if (enfermedad == null)
            {
                return NotFound("Enfermedad no encontrada");
            }

            return Ok(enfermedad);
        }

        [HttpPost]
        public async Task<ActionResult<Enfermedades>> CreateEnfermedad([FromBody] Enfermedades enfermedad)
        {
            var nuevaEnfermedad = await _service.CreateEnfermedad(enfermedad);
            return Ok(nuevaEnfermedad);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Enfermedades>> DeleteEnfermedad(int id)
        {
            var enfermedad = await _service.DeleteEnfermedadById(id);
            if (enfermedad == null)
            {
                return NotFound("Enfermedad no encontrada");
            }
            return Ok(enfermedad);
        }

        [HttpPut]
        public async Task<ActionResult<Enfermedades>> EditJuego([FromBody] Enfermedades enfermedad)
        {
            var nuevaEnfermedad = await _service.EditEnfermedad(enfermedad);
            return Ok(nuevaEnfermedad);
        }
    }
}