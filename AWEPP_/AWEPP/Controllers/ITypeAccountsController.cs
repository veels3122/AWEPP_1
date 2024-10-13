using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeAccountsController : ControllerBase
    {
        private readonly ITypeAccountsServices _typeAccountsServices;

        public TypeAccountsController(ITypeAccountsServices typeAccountsServices)
        {
            _typeAccountsServices = typeAccountsServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeAccounts>>> GetAllTypeAccounts()
        {
            var typeAccounts = await _typeAccountsServices.GetAllTypeAccountsAsync();
            return Ok(typeAccounts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeAccounts>> GetTypeAccountById(int id)
        {
            var typeAccounts = await _typeAccountsServices.GetTypeAccountByIdAsync(id);
            if (typeAccounts == null)
            {
                return NotFound();
            }
            return Ok(typeAccounts);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeAccounts>> CreateTypeAccount([FromBody] TypeAccounts typeAccounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTypeAccount = await _typeAccountsServices.CreateTypeAccountAsync(typeAccounts);
            return CreatedAtAction(nameof(GetTypeAccountById), new { id = newTypeAccount.Id }, newTypeAccount);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTypeAccount(int id, [FromBody] TypeAccounts typeAccounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTypeAccount = await _typeAccountsServices.UpdateTypeAccountAsync(typeAccounts);
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
            await _typeAccountsServices.SoftDeleteTypeAccountAsync(id);
            return NoContent();
        }
    }
}