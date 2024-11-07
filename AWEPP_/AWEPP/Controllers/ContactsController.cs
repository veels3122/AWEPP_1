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
    public class ContactsController : ControllerBase
    {

        private readonly IContactsServices _contactsServices;
        private readonly AuditService _auditLogService;

        public ContactsController(IContactsServices contactsServices, IAuditService auditService)
        {
            _contactsServices = contactsServices;
            _auditLogService = (AuditService?)auditService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Contacts>>> GetAllContacts()
        {
            var Contacts = await _contactsServices.GetAllContactsAsync();
            return Ok(Contacts);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Contacts>> GetContactsById(int Id)
        {
            var Contacts = await _contactsServices.GetContactsByIdAsync(Id);
            if (Contacts == null)
                return NotFound();
            return Ok(Contacts);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateContacts([FromBody] Contacts Contacts)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactsServices.CreateContactsAsync(Contacts);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateContact",
                TableName = "Contact",
                RecordId = Contacts.Id.ToString(),
                Changes = $"Contact {Contacts.Contact} creado.",
                UserName = Contacts.Contact, // O el contacto que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return CreatedAtAction(nameof(GetContactsById), new { id = Contacts.Id }, Contacts);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateCities(int Id, [FromBody] Contacts Contacts)
        {
            if (Id != Contacts.Id)
                return BadRequest();
            var existingContacts = await _contactsServices.GetContactsByIdAsync(Id);
            if (existingContacts == null)
                return NoContent();

            await _contactsServices.UpdateContactsAsync(Contacts);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateContact",
                TableName = "Contact",
                RecordId = Contacts.Id.ToString(),
                Changes = $"Contact {Contacts.Contact} actualizado.",
                UserName = Contacts.Contact, // O el contacto que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteBank(int Id)
        {
            var Contacts = await _contactsServices.GetContactsByIdAsync(Id);
            if (Contacts == null)
                return NotFound();

            await _contactsServices.SoftDeleteContactsAsync(Id);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "softContact",
                TableName = "Contact",
                RecordId = Contacts.Id.ToString(),
                Changes = $"Contact {Contacts.Contact} marca como eliminado.",
                UserName = Contacts.Contact, // O el contacto que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
    }
}




   
    





