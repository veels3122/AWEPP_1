using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeIdentyController : ControllerBase
    {
        private readonly ITypeIdentyServices _typeIdentyServices;

        public TypeIdentyController(ITypeIdentyServices typeIdentyServices)
        {
            _typeIdentyServices = typeIdentyServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeIdenty>>> GetAllTypeIdenty()
        {
            var TypeIdenty = await _typeIdentyServices.GetAllTypeIdentyAsync();
            return Ok(TypeIdenty);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeIdenty>> GetTypeIdentyById(int Id)
        {
            var TypeIdenty = await _typeIdentyServices.GetTypeIdentyByIdAsync(Id);
            if (TypeIdenty == null)
                return NotFound();
            return Ok(TypeIdenty);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeIdenty([FromBody] TypeIdenty TypeIdentities)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _typeIdentyServices.CreateTypeIdentyAsync(TypeIdentities);
            return CreatedAtAction(nameof(GetTypeIdentyById), new { id = TypeIdentities.Id }, TypeIdentities);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTypeIdenty(int Id, [FromBody] TypeIdenty TypeIdentities)
        {
            if (Id != TypeIdentities.Id)
                return BadRequest();
            var existingTypeIdenty = await _typeIdentyServices.GetTypeIdentyByIdAsync(Id);
            if (existingTypeIdenty == null)
                return NoContent();

            await _typeIdentyServices.UpdateTypeIdentyAsync(TypeIdentities);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteTypeIdenty(int Id)
        {
            var TypeIdenty = await _typeIdentyServices.GetTypeIdentyByIdAsync(Id);
            if (TypeIdenty == null)
                return NotFound();

            await _typeIdentyServices.SoftDeleteTypeIdentyAsync(Id);
            return NoContent();
        }
    }
}
