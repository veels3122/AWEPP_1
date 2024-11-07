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
    public class BankController : ControllerBase
    {
        private readonly IBankServices _bankServices;
        private readonly AuditService _auditLogService;

        public BankController(IBankServices bankServices, IAuditService auditService)
        {
            _bankServices = bankServices;
            _auditLogService = (AuditService?)auditService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Bank>>> GetAllBank()
        {
            var Bank = await _bankServices.GetAllBankAsync();
            return Ok(Bank);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bank>> GetBankById(int Id)
        {
            var Bank = await _bankServices.GetBankByIdAsync(Id);
            if (Bank == null)
                return NotFound();
            return Ok(Bank);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreateBank([FromBody] Bank Banks)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _bankServices.CreateBankAsync(Banks);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateBank",
                TableName = "Bank",
                RecordId = Banks.Id.ToString(),
                Changes = $"Bank {Banks.Banks} creado.",
                UserName = "Admin", // Reemplaza con el usuario autenticado
                Date = DateTime.UtcNow.AddHours(-5)
            });

            return CreatedAtAction(nameof(GetBankById), new { id = Banks.Id }, Banks);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateBank(int Id, [FromBody] Bank Banks)
        {
            if (Id != Banks.Id)
                return BadRequest();
            var existingBank = await _bankServices.GetBankByIdAsync(Id);
            if (existingBank == null)
                return NoContent();

            await _bankServices.UpdateBankAsync(Banks);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateBank",
                TableName = "Bank",
                RecordId = Banks.Id.ToString(),
                Changes = $"Bank {Banks.Banks} actualizado.",
                UserName = "Admin", // Reemplaza con el usuario autenticado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteBank(int Id)
        {
            var Banks = await _bankServices.GetBankByIdAsync(Id);
            if (Banks == null)
                return NotFound();

            await _bankServices.SoftDeleteBankAsync(Id);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "SoftBank",
                TableName = "Bank",
                RecordId = Banks.Id.ToString(),
                Changes = $"Bank {Banks.Banks} marca como eliminado.",
                UserName = "Admin", // Reemplaza con el usuario autenticado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
    }
}
