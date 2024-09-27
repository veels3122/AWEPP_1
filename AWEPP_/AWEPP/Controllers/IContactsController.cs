using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsServices _contactsServices;

        public ContactsController(IContactsServices contactsServices)
        {
            _contactsServices = contactsServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacts>>> GetAllContacts()
        {
            var contacts = await _contactsServices.GetAllContactsAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contacts>> GetContactById(int id)
        {
            var contact = await _contactsServices.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contacts>> CreateContact([FromBody] Contacts contacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newContact = await _contactsServices.CreateContactAsync(contacts);
                return CreatedAtAction(nameof(GetContactById), new { id = newContact.Id }, newContact);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] Contacts contacts)
        {
            if (id != contacts.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _contactsServices.UpdateContactAsync(contacts);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteContact(int id)
        {
            await _contactsServices.SoftDeleteContactAsync(id);
            return NoContent();
        }
    }
}