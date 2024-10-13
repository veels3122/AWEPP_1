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
        private readonly IContactsServices _contactServices;

        public ContactsController(IContactsServices contactServices)
        {
            _contactServices = contactServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Contacts>>> GetAllContacts()
        {
            var contacts = await _contactServices.GetAllContactsAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Contacts>> GetContactById(int id)
        {
            var contact = await _contactServices.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contacts>> CreateContact([FromBody] Contacts contacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newContact = await _contactServices.CreateContactAsync(contacts);
                return CreatedAtAction(nameof(GetContactById), new { id = newContact.Id }, newContact);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateContact(int id, [FromBody] Contacts contacts)
        {
            if (id != contacts.Id)
            {
                return BadRequest("El ID en la URL y en el cuerpo de la solicitud no coinciden.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatecity = await _contactServices.UpdateContactAsync(contacts);

            if (updatecity == null)
            {
                return NotFound();
            }

            return NoContent();
        
    }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteContact(int id)
        {
            if (id <= 0)
            {
                return NotFound("el numero debe ser un numero positivo");
            }
            await _contactServices.SoftDeleteContactAsync(id);
            return NoContent();
        }
    }
}