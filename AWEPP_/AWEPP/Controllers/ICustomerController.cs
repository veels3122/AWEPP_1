using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerService;

        public CustomersController(ICustomerServices customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            try
            {
                var newCustomer = await _customerService.CreateCustomerAsync(customer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
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
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
           

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var updatecustomer = await _customerService.UpdateCustomerAsync(customer);

            if (updatecustomer == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteCustomer(int id)
        {
            if (id <= 0)
            {
                return NotFound("el numero debe ser un numero positivo");
            }
            await _customerService.SoftDeleteCustomerAsync(id);
            return NoContent();
        }
    }
}