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
        public async Task<ActionResult<IEnumerable<Customer>>>
 GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>>
 GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]

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
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();

            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            try
            {
                await _customerService.UpdateCustomerAsync(customer);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCustomer(int id)
        {
            await _customerService.SoftDeleteCustomerAsync(id);
            return NoContent();
        }
    }
}