using Clase.Models;
using Clase.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Clase.Controllers
{
    [Route("[controller]")]

    public class AnimalesController : ControllerBase
    {
        private readonly IAnimalService _service;
        private readonly UsersContextPostgres _context;
        private readonly ILogger<AnimalesController> _logger;
        public AnimalesController(IAnimalService service, UsersContextPostgres context, ILogger<AnimalesController> logger)
        {
            _service = service;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Animales>> GetAllAnimal([FromQuery] string filterProperty, [FromQuery] string filterValue, [FromQuery] string orderProperty, [FromQuery] string order)
        {
            var animales = _service.GetAllAnimales(filterProperty, filterValue, orderProperty, order);
            if (!animales.Any())
            {
                return NotFound("Animales no encontrados");
            }

            return Ok(animales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animales>> GetAnimal(int id)
        {
            var animal = await _service.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound("Animal no encontrado");
            }

            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<Animales>> CreateAnimal([FromBody] Animales animal)
        {
            var nuevoAnimal = await _service.CreateAnimal(animal);
            return Ok(nuevoAnimal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Animales>> DeleteAnimal(int id)
        {
            var animal = await _service.DeleteAnimalById(id);
            if (animal == null)
            {
                return NotFound("Animal no encontrado");
            }
            return Ok(animal);
        }

        [HttpPut]
        public async Task<ActionResult<Animales>> EditAnimal([FromBody] Animales animal)
        {
            var nuevoAnimal = await _service.EditAnimal(animal);
            return Ok(nuevoAnimal);
        }
    }
}