using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SavingsController : ControllerBase
    {
        private readonly ISavingServices _savingService;

        public SavingsController(ISavingServices savingService)
        {
            _savingService = savingService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Saving>>> GetAllSavings()
        {
            var savings = await _savingService.GetAllSavingsAsync();
            return Ok(savings);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Saving>> GetSavingById(int id)
        {
            var saving = await _savingService.GetSavingByIdAsync(id);
            if (saving == null)
            {
                return NotFound();
            }
            return Ok(saving);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Saving>> CreateSaving([FromBody] Saving saving)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSaving = await _savingService.CreateSavingAsync(saving);
            return CreatedAtAction(nameof(GetSavingById), new { id = newSaving.Id }, newSaving);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSaving(int id, [FromBody] Saving saving)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedSaving = await _savingService.UpdateSavingAsync(saving);
            if (updatedSaving == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteSaving(int id)
        {
            await _savingService.SoftDeleteSavingAsync(id);
            return NoContent();
        }
    }
}