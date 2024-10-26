using AWEPP.Model;
using AWEPP.Modelo;
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

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
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
            return NoContent();
        }
    }
}








