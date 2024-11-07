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
    public class SavingController : ControllerBase
    {
        private readonly ISavingService _savingService;
        private readonly AuditService _auditLogService;

        public SavingController(ISavingService savingService, IAuditService auditService)
        {
            _savingService = savingService;
            _auditLogService = (AuditService?)auditService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Saving>>> GetAllSaving()
        {
            var Saving = await _savingService.GetAllSavingAsync();
            return Ok(Saving);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Saving>> GetSavingById(int Id)
        {
            var Saving = await _savingService.GetSavingByIdAsync(Id);
            if (Saving == null)
                return NotFound();
            return Ok(Saving);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateSaving([FromBody] Saving saving)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _savingService.CreateSavingAsync(saving);

            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateSavings",
                TableName = "Saving",
                RecordId = saving.Id.ToString(),
                Changes = $"saving {saving.Bank},{saving.Customer},{saving.Products},{saving.Description} creado.",
                UserName = saving.Description,
                Date = DateTime.UtcNow.AddHours(-5)
            }); 
            return CreatedAtAction(nameof(GetSavingById), new { id = saving.Id }, saving);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateSaving(int Id, [FromBody] Saving saving)
        {
            if (Id != saving.Id)
                return BadRequest();
            var existingSaving = await _savingService.GetSavingByIdAsync(Id);
            if (existingSaving == null)
                return NoContent();

            await _savingService.UpdateSavingAsync(saving);

            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateSavings",
                TableName = "Saving",
                RecordId = saving.Id.ToString(),
                Changes = $"Saving {saving.Bank},{saving.Customer},{saving.Products},{saving.Description} actualizado.",
                UserName = saving.Description,
                Date = DateTime.UtcNow.AddHours(-5)
            }); 
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteSaving(int Id)
        {
            var saving = await _savingService.GetSavingByIdAsync(Id);
            if (saving == null)
                return NotFound();

            await _savingService.SoftDeleteSavingAsync(Id);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "SoftSavings",
                TableName = "Saving",
                RecordId = saving.Id.ToString(),
                Changes = $"Saving {saving.Bank},{saving.Customer},{saving.Products},{saving.Description} marca como eliminado.",
                UserName = saving.Description,
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }

    }
    }

