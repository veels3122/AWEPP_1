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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        private readonly AuditService _auditLogService;

        public CustomerController(ICustomerServices customerServices, IAuditService auditService)
        {
            _customerServices = customerServices;
            _auditLogService = (AuditService?)auditService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer()
        {
            var Customer = await _customerServices.GetAllCustomerAsync();
            return Ok(Customer);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Customer>> GetCustomerById(int Id)
        {
            var Customer = await _customerServices.GetCustomerByIdAsync(Id);
            if (Customer == null)
                return NotFound();
            return Ok(Customer);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCustomer([FromBody] Customer Customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _customerServices.CreateCustomerAsync(Customer);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateCustomer",
                TableName = "Customer",
                RecordId = Customer.Id.ToString(),
                Changes = $"Customer {Customer.Name},{Customer.LastName} creado.",
                UserName = Customer.Name, // O el usuario que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return CreatedAtAction(nameof(GetCustomerById), new { id = Customer.Id }, Customer);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateCities(int Id, [FromBody] Customer Customer)
        {
            if (Id != Customer.Id)
                return BadRequest();
            var existingCustomer = await _customerServices.GetCustomerByIdAsync(Id);
            if (existingCustomer == null)
                return NoContent();

            await _customerServices.UpdateCustomerAsync(Customer);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "updateCustomer",
                TableName = "Customer",
                RecordId = Customer.Id.ToString(),
                Changes = $"Customer {Customer.Name},{Customer.LastName} actualizado.",
                UserName = Customer.Name, // O el usuario que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteBank(int Id)
        {
            var Customer = await _customerServices.GetCustomerByIdAsync(Id);
            if (Customer == null)
                return NotFound();

            await _customerServices.SoftDeleteCustomerAsync(Id);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "softCustomer",
                TableName = "Customer",
                RecordId = Customer.Id.ToString(),
                Changes = $"Customer {Customer.Name},{Customer.LastName} marca como eliminado.",
                UserName = Customer.Name, // O el usuario que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
    }
}








