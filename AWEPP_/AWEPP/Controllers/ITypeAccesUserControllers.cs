using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeAccesUsersController : ControllerBase
    {
        private readonly ITypeAccesUserServices _typeAccesUserService;

        public TypeAccesUsersController(ITypeAccesUserServices typeAccesUserService)
        {
            _typeAccesUserService = typeAccesUserService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeAccesUser>>> GetAllTypeAccesUsers()
        {
            var typeAccesUsers = await _typeAccesUserService.GetAllTypeAccesUsersAsync();
            return Ok(typeAccesUsers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeAccesUser>> GetTypeAccesUserById(int id)
        {
            var typeAccesUser = await _typeAccesUserService.GetTypeAccesUserByIdAsync(id);
            if (typeAccesUser == null)
            {
                return NotFound();
            }
            return Ok(typeAccesUser);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeAccesUser>> CreateTypeAccesUser([FromBody] TypeAccesUser typeAccesUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTypeAccesUser = await _typeAccesUserService.CreateTypeAccesUserAsync(typeAccesUser);
            return CreatedAtAction(nameof(GetTypeAccesUserById), new { id = newTypeAccesUser.Id }, newTypeAccesUser);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTypeAccesUser(int id, [FromBody] TypeAccesUser typeAccesUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTypeAccesUser = await _typeAccesUserService.UpdateTypeAccesUserAsync(typeAccesUser);
            if (updatedTypeAccesUser == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTypeAccesUser(int id)
        {
            await _typeAccesUserService.SoftDeleteTypeAccesUserAsync(id);
            return NoContent();
        }
    }
}