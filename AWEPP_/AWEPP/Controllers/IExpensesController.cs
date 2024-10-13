using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesServices _expensesServices;

        public ExpensesController(IExpensesServices expenseServices)
        {
            _expensesServices = expenseServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Expenses>>> GetAllExpenses()
        {
            var expenses = await _expensesServices.GetAllExpensesAsync();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Expenses>> GetExpenseById(int id)
        {
            var expenses = await _expensesServices.GetExpenseByIdAsync(id);
            if (expenses == null)
            {
                return NotFound();
            }
            return Ok(expenses);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Expenses>> CreateExpense([FromBody] Expenses expenses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newExpenses = await _expensesServices.CreateExpenseAsync(expenses);
            return CreatedAtAction(nameof(GetExpenseById), new { id = newExpenses.Id }, newExpenses);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateExpense(int id, [FromBody] Expenses expenses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedExpense = await _expensesServices.UpdateExpenseAsync(expenses);
            if (updatedExpense == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteExpense(int id)
        {
            await _expensesServices.SoftDeleteExpenseAsync(id);
            return NoContent();
        }
    }
}