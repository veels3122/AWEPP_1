using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeIdentyController : ControllerBase
    {
        private readonly ITypeIdentyServices _typeIdentyService;

        public TypeIdentyController(ITypeIdentyServices typeIdentyService)
        {
            _typeIdentyService = typeIdentyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeIdenty>>> GetAllTypeIdenty()
        {
            var typeIdenty = await _typeIdentyService.GetAllTypeIdentyAsync();
            return Ok(typeIdenty);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeIdenty>> GetTypeIdentyById(int id)
        {
            var typeIdenty = await _typeIdentyService.GetTypeIdentyByIdAsync(id);
            if (typeIdenty == null)
            {
                return NotFound();
            }
            return Ok(typeIdenty);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeIdenty([FromBody] TypeIdenty typeIdenty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _typeIdentyService.CreateTypeIdentyAsync(typeIdenty);
                return CreatedAtAction(nameof(GetTypeIdentyById), new { id = typeIdenty.Id }, typeIdenty);
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
        public async Task<IActionResult> UpdateTypeIdenty(int id, [FromBody] TypeIdenty typeIdenty)
        {
            if (id != typeIdenty.Id)
            {
                return BadRequest("El ID en la URL y en el cuerpo de la solicitud no coinciden.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTypeIdenty = await _typeIdentyService.UpdateTypeIdentyAsync(typeIdenty);

            if (updatedTypeIdenty == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTypeIdenty(int id)
        {
            if (id <= 0)
            {
                return NotFound("El ID debe ser un número positivo.");
            }

            await _typeIdentyService.SoftDeleteTypeIdentyAsync(id);
            return NoContent();
        }
    }
}