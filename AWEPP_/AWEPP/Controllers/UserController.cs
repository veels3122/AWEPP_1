using AWEPP.DTOs;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Models;
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
        private readonly AuditService _auditLogService;

        public UserController(IUserServices userServices, IAuditService auditService)
        {
            _userServices = userServices;
            _auditLogService = (AuditService?)auditService;
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateUser",
                TableName = "User",
                RecordId = Users.Id.ToString(),
                Changes = $"User {Users.Name} creado.",
                UserName = Users.UserName, 
                Date = DateTime.UtcNow.AddHours(-5)
            });

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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateUser",
                TableName = "User",
                RecordId = Users.Id.ToString(),
                Changes = $"User {Users.Name} actualizado.",
                UserName = Users.UserName, 
                Date = DateTime.UtcNow.AddHours(-5)
            });
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "SoftDeleteUser",
                TableName = "User",
                RecordId = Id.ToString(),
                Changes = $"User {User.Name} marcado como eliminado.",
                UserName = User.UserName, // O el usuario que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Validación de datos de entrada
            }

            try
            {
                var user = await _userServices.LoginAsync(loginDto.Email, loginDto.Password);

                if (user == null)
                {
                    return Unauthorized("Credenciales inválidas.");
                }

                // Aquí podrías generar un token JWT o similar, pero por ahora retornamos los datos del usuario
                return Ok(new { message = "Inicio de sesión exitoso", userId = user.Id });
            }
            catch (Exception ex)
            {
                // Loguear el error para revisión futura
                Console.WriteLine($"Error en el login: {ex.Message}");
                return StatusCode(500, "Ocurrió un error en el servidor.");
            }
        }

    }
}



