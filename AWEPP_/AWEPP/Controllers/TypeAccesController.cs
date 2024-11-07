using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeAccesController : ControllerBase
    {
        private readonly ITypeAccesServices _typeAccesServices;

        public TypeAccesController(ITypeAccesServices typeAccesServices)
        {
            _typeAccesServices = typeAccesServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeAcces>>> GetAllTypeAcces()
        {
            var TypeAcces = await _typeAccesServices.GetAllTypeAccesAsync();
            return Ok(TypeAcces);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeAcces>> GetTypeAccesById(int Id)
        {
            var TypeAcces = await _typeAccesServices.GetTypeAccesByIdAsync(Id);
            if (TypeAcces == null)
                return NotFound();
            return Ok(TypeAcces);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeAcces([FromBody] TypeAcces TypeAccesses)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _typeAccesServices.CreateTypeAccesAsync(TypeAccesses);
            return CreatedAtAction(nameof(GetTypeAccesById), new { id = TypeAccesses.Id }, TypeAccesses);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTypeAcces(int Id, [FromBody] TypeAcces TypeAccesses)
        {
            if (Id != TypeAccesses.Id)
                return BadRequest();
            var existingTypeAcces = await _typeAccesServices.GetTypeAccesByIdAsync(Id);
            if (existingTypeAcces == null)
                return NoContent();

            await _typeAccesServices.UpdateTypeAccesAsync(TypeAccesses);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteTypeAcces(int Id)
        {
            var TypeAcces = await _typeAccesServices.GetTypeAccesByIdAsync(Id);
            if (TypeAcces == null)
                return NotFound();

            await _typeAccesServices.SoftDeleteTypeAccesAsync(Id);
            return NoContent();
        }
    }
}


