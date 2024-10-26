using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeAccesUserController : ControllerBase
    {
        private readonly ITypeAccesUserServices _typeAccesUserServices;

        public TypeAccesUserController(ITypeAccesUserServices typeAccesUserServices)
        {
            _typeAccesUserServices = typeAccesUserServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeAccesUser>>> GetAllTypeAccesUser()
        {
            var TypeAccesUser = await _typeAccesUserServices.GetAllTypeAccesUserAsync();
            return Ok(TypeAccesUser);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeAccesUser>> GetTypeAccesUserById(int Id)
        {
            var TypeAccesUser = await _typeAccesUserServices.GetTypeAccesUserByIdAsync(Id);
            if (TypeAccesUser == null)
                return NotFound();
            return Ok(TypeAccesUser);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeAccesUser([FromBody] TypeAccesUser TypeAccessUsers)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _typeAccesUserServices.CreateTypeAccesUserAsync(TypeAccessUsers);
            return CreatedAtAction(nameof(GetTypeAccesUserById), new { id = TypeAccessUsers.Id }, TypeAccessUsers);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTypeAccesUser(int Id, [FromBody] TypeAccesUser TypeAccessUsers)
        {
            if (Id != TypeAccessUsers.Id)
                return BadRequest();
            var existingTypeAccesUser = await _typeAccesUserServices.GetTypeAccesUserByIdAsync(Id);
            if (existingTypeAccesUser == null)
                return NoContent();

            await _typeAccesUserServices.UpdateTypeAccesUserAsync(TypeAccessUsers);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteTypeAccesUser(int Id)
        {
            var TypeAccesUser = await _typeAccesUserServices.GetTypeAccesUserByIdAsync(Id);
            if (TypeAccesUser == null)
                return NotFound();

            await _typeAccesUserServices.SoftDeleteTypeAccesUserAsync(Id);
            return NoContent();
        }
    }
}
