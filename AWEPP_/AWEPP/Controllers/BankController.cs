using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankServices _bankServices;

        public BankController(IBankServices bankServices)
        {
            _bankServices = bankServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Bank>>> GetAllBank()
        {
            var Bank = await _bankServices.GetAllBankAsync();
            return Ok(Bank);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bank>> GetBankById(int Id)
        {
            var Bank = await _bankServices.GetBankByIdAsync(Id);
            if (Bank == null)
                return NotFound();
            return Ok(Bank);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreateBank([FromBody] Bank Banks)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _bankServices.CreateBankAsync(Banks);
            return CreatedAtAction(nameof(GetBankById), new { id = Banks.Id },(Banks.IsDeleted=false));

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateBank(int Id, [FromBody] Bank Banks)
        {
            if (Id != Banks.Id)
                return BadRequest();
            var existingBank = await _bankServices.GetBankByIdAsync(Id);
            if (existingBank == null)
                return NoContent();

            await _bankServices.UpdateBankAsync(Banks);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteBank(int Id)
        {
            var Banks = await _bankServices.GetBankByIdAsync(Id);
            if (Banks == null)
                return NotFound();

            await _bankServices.SoftDeleteBankAsync(Id);
            return NoContent();
        }
    }
}
