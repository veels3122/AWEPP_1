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
    public class TypeAccountsController : ControllerBase
    {

        private readonly ITypeAccountsService _typeAccountsService;
        private readonly AuditService _auditLogService;

        public TypeAccountsController(ITypeAccountsService typeAccountsService, IAuditService auditService)
        {
            _typeAccountsService = typeAccountsService;
            _auditLogService = (AuditService?)auditService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeAccounts>>> GetAllTypeAccounts()
        {
            var TypeAccounts = await _typeAccountsService.GetAllTypeAccountsAsync();
            return Ok(TypeAccounts);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeAccounts>> GetTypeAccountsById(int Id)
        {
            var TypeAccounts = await _typeAccountsService.GetTypeAccountsByIdAsync(Id);
            if (TypeAccounts == null)
                return NotFound();
            return Ok(TypeAccounts);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeAccounts([FromBody] TypeAccounts typeAccounts)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _typeAccountsService.CreateTypeAccountsAsync(typeAccounts);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateTypeAccounts",
                TableName = "TypeAccounts",
                RecordId = typeAccounts.Id.ToString(),
                Changes = $"TypeAccounts {typeAccounts.Accounts} creado.",
                UserName = typeAccounts.Accounts,
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return CreatedAtAction(nameof(GetTypeAccountsById), new { id = typeAccounts.Id }, typeAccounts);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTypeAccounts(int Id, [FromBody] TypeAccounts typeAccounts)
        {
            if (Id != typeAccounts.Id)
                return BadRequest();
            var existingTypeAccounts = await _typeAccountsService.GetTypeAccountsByIdAsync(Id);
            if (existingTypeAccounts == null)
                return NoContent();

            await _typeAccountsService.UpdateTypeAccountsAsync(typeAccounts);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateTypeAccounts",
                TableName = "TypeAccounts",
                RecordId = typeAccounts.Id.ToString(),
                Changes = $"TypeAccounts {typeAccounts.Accounts} actualizado.",
                UserName = typeAccounts.Accounts,
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteTypeAccounts(int Id)
        {
            var typeAccounts = await _typeAccountsService.GetTypeAccountsByIdAsync(Id);
            if (typeAccounts == null)
                return NotFound();

            await _typeAccountsService.SoftDeleteTypeAccountsAsync(Id);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "SoftTypeAccounts",
                TableName = "TypeAccounts",
                RecordId = typeAccounts.Id.ToString(),
                Changes = $"TypeAccounts {typeAccounts.Accounts} marca como eliminado.",
                UserName = typeAccounts.Accounts,
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
    }

}