using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingController : ControllerBase
    {
        private readonly ISavingService _savingService;

        public SavingController(ISavingService savingService)
        {
            _savingService = savingService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Saving>>> GetAllSaving()
        {
            var Saving = await _savingService.GetAllSavingAsync();
            return Ok(Saving);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Saving>> GetSavingById(int Id)
        {
            var Saving = await _savingService.GetSavingByIdAsync(Id);
            if (Saving == null)
                return NotFound();
            return Ok(Saving);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateSaving([FromBody] Saving saving)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _savingService.CreateSavingAsync(saving);
            return CreatedAtAction(nameof(GetSavingById), new { id = saving.Id }, saving);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateSaving(int Id, [FromBody] Saving saving)
        {
            if (Id != saving.Id)
                return BadRequest();
            var existingSaving = await _savingService.GetSavingByIdAsync(Id);
            if (existingSaving == null)
                return NoContent();

            await _savingService.UpdateSavingAsync(saving);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteSaving(int Id)
        {
            var saving = await _savingService.GetSavingByIdAsync(Id);
            if (saving == null)
                return NotFound();

            await _savingService.SoftDeleteSavingAsync(Id);
            return NoContent();
        }

    }
    }

