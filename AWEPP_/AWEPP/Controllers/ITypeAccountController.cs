using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeAccountsController : ControllerBase
    {
        private readonly ITypeAccountServices _typeAccountService;

        public TypeAccountsController(ITypeAccountServices typeAccountService)
        {
            _typeAccountService = typeAccountService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeAccount>>> GetAllTypeAccounts()
        {
            var typeAccounts = await _typeAccountService.GetAllTypeAccountsAsync();
            return Ok(typeAccounts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeAccount>> GetTypeAccountById(int id)
        {
            var typeAccount = await _typeAccountService.GetTypeAccountByIdAsync(id);
            if (typeAccount == null)
            {
                return NotFound();
            }
            return Ok(typeAccount);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeAccount>> CreateTypeAccount([FromBody] TypeAccount typeAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTypeAccount = await _typeAccountService.CreateTypeAccountAsync(typeAccount);
            return CreatedAtAction(nameof(GetTypeAccountById), new { id = newTypeAccount.Id }, newTypeAccount);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTypeAccount(int id, [FromBody] TypeAccount typeAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTypeAccount = await _typeAccountService.UpdateTypeAccountAsync(typeAccount);
            if (updatedTypeAccount == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTypeAccount(int id)
        {
            await _typeAccountService.SoftDeleteTypeAccountAsync(id);
            return NoContent();
        }
    }
}