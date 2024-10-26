using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            var User = await _userServices.GetAllUserAsync();
            return Ok(User);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserById(int Id)
        {
            var User = await _userServices.GetUserByIdAsync(Id);
            if (User == null)
                return NotFound();
            return Ok(User);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser([FromBody] User Users)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userServices.CreateUserAsync(Users);
            return CreatedAtAction(nameof(GetUserById), new { id = Users.Id }, Users);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUser(int Id, [FromBody] User Users)
        {
            if (Id != Users.Id)
                return BadRequest();
            var existingUser = await _userServices.GetUserByIdAsync(Id);
            if (existingUser == null)
                return NoContent();

            await _userServices.UpdateUserAsync(Users);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteUser(int Id)
        {
            var User = await _userServices.GetUserByIdAsync(Id);
            if (User == null)
                return NotFound();

            await _userServices.SoftDeleteUserAsync(Id);
            return NoContent();
        }
    }
}



