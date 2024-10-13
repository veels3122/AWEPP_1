using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeExpensesController : ControllerBase
    {
        private readonly ITypeExpensesServices _typeExpensesServices;

        public TypeExpensesController(ITypeExpensesServices typeExpensesServices)
        {
            _typeExpensesServices= typeExpensesServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeExpenses>>> GetAllTypeExpenses()
        {
            var typeExpenses = await _typeExpensesServices.GetAllTypeExpensesAsync();
            return Ok(typeExpenses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeExpenses>> GetTypeExpensesById(int id)
        {
            var typeExpenses = await _typeExpensesServices.GetTypeExpensesByIdAsync(id);
            if (typeExpenses == null)
            {
                return NotFound();
            }
            return Ok(typeExpenses);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeExpenses([FromBody] TypeExpenses typeExpenses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _typeExpensesServices.CreateTypeExpensesAsync(typeExpenses);
                return CreatedAtAction(nameof(GetTypeExpensesById), new { id = typeExpenses.Id }, typeExpenses);
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
        public async Task<IActionResult> UpdateTypeExpenses(int id, [FromBody] TypeExpenses typeExpenses)
        {
            if (id != typeExpenses.Id)
            {
                return BadRequest("El ID en la URL y en el cuerpo de la solicitud no coinciden.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTypeExpenses = await _typeExpensesServices.UpdateTypeExpensesAsync(typeExpenses);

            if (updatedTypeExpenses == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTypeExpenses(int id)
        {
            if (id <= 0)
            {
                return NotFound("El ID debe ser un número positivo.");
            }

            await _typeExpensesServices.SoftDeleteTypeExpensesAsync(id);
            return NoContent();
        }
    }
}