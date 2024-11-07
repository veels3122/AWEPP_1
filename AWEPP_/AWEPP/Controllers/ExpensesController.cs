using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Models;
using AWEPP.Repositories;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesService _expensesService;
        private readonly AuditService _auditLogService;

        public ExpensesController(IExpensesService expensesService, IAuditService auditService)
        {
            _expensesService = expensesService;
            _auditLogService = (AuditService?)auditService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Expenses>>> GetAllExpenses()
        {
            var Expenses = await _expensesService.GetAllExpensesAsync();
            return Ok(Expenses);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Expenses>> GetExpenseById(int Id)
        {
            var Expenses = await _expensesService.GetExpensesByIdAsync(Id);
            if (Expenses == null)
                return NotFound();
            return Ok(Expenses);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateExpenses([FromBody] Expenses expenses)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _expensesService.CreateExpensesAsync(expenses);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateExpense",
                TableName = "Expense",
                RecordId = expenses.Id.ToString(),
                Changes = $"Expense {expenses.Id} creado.",
                UserName = expenses.Description, // O el usuario que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });

            return CreatedAtAction(nameof(GetExpenseById), new {id = expenses.Id}, expenses);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateExpenses(int Id, [FromBody] Expenses expenses)
        {
            if(Id != expenses.Id)
                return BadRequest();
            var existingExpenses = await _expensesService.GetExpensesByIdAsync(Id);
            if (existingExpenses == null)
                return NoContent();

            await _expensesService.UpdateExpensesAsync(expenses);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "updateExpense",
                TableName = "Expense",
                RecordId = expenses.Id.ToString(),
                Changes = $"Expense {expenses.Id} actualizado.",
                UserName = expenses.Description, // O el usuario que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteExpenses(int Id)
        {
            var expenses = await _expensesService.GetExpensesByIdAsync(Id);
            if(expenses == null)
                return NotFound();

            await _expensesService.SoftDeleteExpensesAsync(Id);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "softExpense",
                TableName = "Expense",
                RecordId = expenses.Id.ToString(),
                Changes = $"Expense {expenses.Id} marca como eliminado.",
                UserName = expenses.Description, // O el usuario que esté logueado
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
        
    }
}
