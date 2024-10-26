using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsertypeController : ControllerBase
    {
        private readonly IUsertypeServices _usertypeServices;

        public UsertypeController(IUsertypeServices usertypeServices)
        {
            _usertypeServices = usertypeServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Usertype>>> GetAllUsertype()
        {
            var Usertype = await _usertypeServices.GetAllUsertypeAsync();
            return Ok(Usertype);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Usertype>> GetUsertypeById(int Id)
        {
            var Usertype = await _usertypeServices.GetUsertypeByIdAsync(Id);
            if (Usertype == null)
                return NotFound();
            return Ok(Usertype);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUsertype([FromBody] Usertype Usertype)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usertypeServices.CreateUsertypeAsync(Usertype);
            return CreatedAtAction(nameof(GetUsertypeById), new { id = Usertype.Id }, Usertype);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUsertype(int Id, [FromBody] Usertype Usertype)
        {
            if (Id != Usertype.Id)
                return BadRequest();
            var existingUsertype = await _usertypeServices.GetUsertypeByIdAsync(Id);
            if (existingUsertype == null)
                return NoContent();

            await _usertypeServices.UpdateUsertypeAsync(Usertype);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteUsertype(int Id)
        {
            var Usertype = await _usertypeServices.GetUsertypeByIdAsync(Id);
            if (Usertype == null)
                return NotFound();

            await _usertypeServices.SoftDeleteUsertypeAsync(Id);
            return NoContent();
        }
    }
}

