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
    public class TypeAccesController : ControllerBase
    {
        private readonly ITypeAccesServices _typeAccesServices;
        private readonly AuditService _auditLogService;
        public TypeAccesController(ITypeAccesServices typeAccesServices, IAuditService auditService)
        {
            _typeAccesServices = typeAccesServices;
            _auditLogService = (AuditService?)auditService;
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateTypeAcces",
                TableName = "TypeAcces",
                RecordId = TypeAccesses.Id.ToString(),
                Changes = $"TypeAcces {TypeAccesses.Typeacces} creado.",
                UserName = TypeAccesses.Typeacces,
                Date = DateTime.UtcNow.AddHours(-5)
            });
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateTypeAcces",
                TableName = "TypeAcces",
                RecordId = TypeAccesses.Id.ToString(),
                Changes = $"TypeAcces {TypeAccesses.Typeacces} actualiado.",
                UserName = TypeAccesses.Typeacces,
                Date = DateTime.UtcNow.AddHours(-5)
            });
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "SoftTypeAcces",
                TableName = "TypeAcces",
                RecordId = TypeAcces.Id.ToString(),
                Changes = $"TypeAcces {TypeAcces.Typeacces} marca como eliminado.",
                UserName = TypeAcces.Typeacces,
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
    }
}


