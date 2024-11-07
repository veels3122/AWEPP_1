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
    public class TypeIdentyController : ControllerBase
    {
        private readonly ITypeIdentyServices _typeIdentyServices;
        private readonly AuditService _auditLogService;

        public TypeIdentyController(ITypeIdentyServices typeIdentyServices, IAuditService auditService)
        {
            _typeIdentyServices = typeIdentyServices;
            _auditLogService = (AuditService?)auditService;
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateTypeIdenty",
                TableName = "TypeIdenty",
                RecordId = TypeIdentities.Id.ToString(),
                Changes = $"TypeIdenty {TypeIdentities.TipoIdenty} creado.",
                UserName = TypeIdentities.TipoIdenty,
                Date = DateTime.UtcNow.AddHours(-5)
            });
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateTypeIdenty",
                TableName = "TypeIdenty",
                RecordId = TypeIdentities.Id.ToString(),
                Changes = $"TypeIdenty {TypeIdentities.TipoIdenty} actualizado.",
                UserName = TypeIdentities.TipoIdenty,
                Date = DateTime.UtcNow.AddHours(-5)
            });
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "SoftTypeIdenty",
                TableName = "TypeIdenty",
                RecordId = TypeIdenty.Id.ToString(),
                Changes = $"TypeIdenty {TypeIdenty.TipoIdenty} marca como leido.",
                UserName = TypeIdenty.TipoIdenty,
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
    }
}
