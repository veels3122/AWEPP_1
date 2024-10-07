using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeAccesController : ControllerBase
    {
        private readonly ITypeAccesServices _typeAccesService;

        public TypeAccesController(ITypeAccesServices typeAccesService)
        {
            _typeAccesService = typeAccesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeAcces>>> GetAllTypeAcces()
        {
            var typeAcces = await _typeAccesService.GetAllTypeAccesAsync();
            return Ok(typeAcces);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async
 Task<ActionResult<TypeAcces>> GetTypeAccesById(int id)
        {
            var typeAcces = await _typeAccesService.GetTypeAccesByIdAsync(id);
            if (typeAcces == null)
            {
                return NotFound();
            }
            return Ok(typeAcces);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeAcces([FromBody] TypeAcces typeAcces)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _typeAccesService.CreateTypeAccesAsync(typeAcces);
                return CreatedAtAction(nameof(GetTypeAccesById), new { id = typeAcces.Id }, typeAcces);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTypeAcces(int id, [FromBody] TypeAcces typeAcces)
        {
            if (id != typeAcces.Id)
            {
                return BadRequest("El ID en la URL y en el cuerpo de la solicitud no coinciden.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTypeAcces = await _typeAccesService.UpdateTypeAccesAsync(typeAcces);

            if (updatedTypeAcces == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public
 async Task<IActionResult> SoftDeleteTypeAcces(int id)
        {
            if (id <= 0)
            {
                return NotFound("El ID debe ser un número positivo.");
            }

            await _typeAccesService.SoftDeleteTypeAccesAsync(id);
            return NoContent();
        }
    }
}