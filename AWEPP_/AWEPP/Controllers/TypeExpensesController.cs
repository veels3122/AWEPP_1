using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeExpensesController : ControllerBase
    {
        private readonly ITypeExpensesServices _typeExpensesServices;

        public TypeExpensesController(ITypeExpensesServices typeExpensesServices)
        {
            _typeExpensesServices = typeExpensesServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeExpenses>>> GetAllTypeExpenses()
        {
            var TypeExpenses = await _typeExpensesServices.GetAllTypeExpensesAsync();
            return Ok(TypeExpenses);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeExpenses>> GetTypeExpensesById(int Id)
        {
            var TypeExpenses = await _typeExpensesServices.GetTypeExpensesByIdAsync(Id);
            if (TypeExpenses == null)
                return NotFound();
            return Ok(TypeExpenses);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeExpenses([FromBody] TypeExpenses TypeExpenses)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _typeExpensesServices.CreateTypeExpensesAsync(TypeExpenses);
            return CreatedAtAction(nameof(GetTypeExpensesById), new { id = TypeExpenses.Id }, TypeExpenses);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTypeExpenses(int Id, [FromBody] TypeExpenses TypeExpenses)
        {
            if (Id != TypeExpenses.Id)
                return BadRequest();
            var existingTypeExpenses = await _typeExpensesServices.GetTypeExpensesByIdAsync(Id);
            if (existingTypeExpenses == null)
                return NoContent();

            await _typeExpensesServices.UpdateTypeExpensesAsync(TypeExpenses);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteTypeExpenses(int Id)
        {
            var TypeExpenses = await _typeExpensesServices.GetTypeExpensesByIdAsync(Id);
            if (TypeExpenses == null)
                return NotFound();

            await _typeExpensesServices.SoftDeleteTypeExpensesAsync(Id);
            return NoContent();
        }
    }
}
