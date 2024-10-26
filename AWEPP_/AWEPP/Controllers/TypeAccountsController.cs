using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeAccountsController : ControllerBase
    {

        private readonly ITypeAccountsService _typeAccountsService;

        public TypeAccountsController(ITypeAccountsService typeAccountsService)
        {
            _typeAccountsService = typeAccountsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeAccounts>>> GetAllTypeAccounts()
        {
            var TypeAccounts = await _typeAccountsService.GetAllTypeAccountsAsync();
            return Ok(TypeAccounts);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeAccounts>> GetTypeAccountsById(int Id)
        {
            var TypeAccounts = await _typeAccountsService.GetTypeAccountsByIdAsync(Id);
            if (TypeAccounts == null)
                return NotFound();
            return Ok(TypeAccounts);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeAccounts([FromBody] TypeAccounts typeAccounts)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _typeAccountsService.CreateTypeAccountsAsync(typeAccounts);
            return CreatedAtAction(nameof(GetTypeAccountsById), new { id = typeAccounts.Id }, typeAccounts);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTypeAccounts(int Id, [FromBody] TypeAccounts typeAccounts)
        {
            if (Id != typeAccounts.Id)
                return BadRequest();
            var existingTypeAccounts = await _typeAccountsService.GetTypeAccountsByIdAsync(Id);
            if (existingTypeAccounts == null)
                return NoContent();

            await _typeAccountsService.UpdateTypeAccountsAsync(typeAccounts);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteTypeAccounts(int Id)
        {
            var typeAccounts = await _typeAccountsService.GetTypeAccountsByIdAsync(Id);
            if (typeAccounts == null)
                return NotFound();

            await _typeAccountsService.SoftDeleteTypeAccountsAsync(Id);
            return NoContent();
        }
    }

}