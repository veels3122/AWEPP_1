using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsertypesController : ControllerBase
    {
        private readonly IUsertypeServices _usertypeService;

        public UsertypesController(IUsertypeServices usertypeService)
        {
            _usertypeService = usertypeService;
        }

        // Obtener todos los tipos de usuario
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Usertype>>> GetAllUsertypes()
        {
            var usertypes = await _usertypeService.GetAllUsertypesAsync();
            return Ok(usertypes);
        }

        // Obtener un tipo de usuario por ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async
 Task<ActionResult<Usertype>> GetUsertypeById(int id)
        {
            var usertype = await _usertypeService.GetUsertypeByIdAsync(id);
            if (usertype == null)
            {
                return NotFound();
            }
            return Ok(usertype);
        }

        // Crear un nuevo tipo de usuario
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult>
 CreateUsertype([FromBody] Usertype usertype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _usertypeService.CreateUsertypeAsync(usertype);
                return CreatedAtAction(nameof(GetUsertypeById), new { id = usertype.Id }, usertype);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Actualizar un tipo de usuario
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateUsertype(int id, [FromBody] Usertype usertype)
        {
            if (id != usertype.Id)
            {
                return BadRequest("El ID en la URL y en el cuerpo de la solicitud no coinciden.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedUsertype = await _usertypeService.UpdateUsertypeAsync(usertype);

            if (updatedUsertype == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Eliminar (soft delete) un tipo de usuario
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public
 async Task<IActionResult> SoftDeleteUsertype(int id)
        {
            if (id <= 0)
            {
                return NotFound("El ID debe ser un número positivo.");
            }

            await _usertypeService.SoftDeleteUsertypeAsync(id);
            return NoContent();
        }
    }
}