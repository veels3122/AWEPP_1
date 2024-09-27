using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BanksController : ControllerBase
{
    private readonly IBankServices _bankService;


    public BanksController(IBankServices bankService)
    {
        _bankService = bankService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Bank>>> GetAllBanks()
    {
        var banks = await _bankService.GetAllBanksAsync();
        return Ok(banks);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Bank>>
 GetBankById(int id)
    {
        var bank = await _bankService.GetBankByIdAsync(id);
        if (bank == null)
        {
            return NotFound();
        }
        return Ok(bank);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> CreateBank([FromBody] Bank bank)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _bankService.CreateBankAsync(bank);
            return CreatedAtAction(nameof(GetBankById), new { id = bank.Id }, bank);
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
    public async Task<IActionResult> UpdateBank(int id, [FromBody] Bank bank)
    {
        if (id != bank.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var existingBank = await _bankService.GetBankByIdAsync(id);
            if (existingBank == null)
            {
                return NotFound();
            }

            await _bankService.UpdateBankAsync(bank);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public
 async Task<IActionResult> SoftDeleteBank(int id)
    {
        var bank = await _bankService.GetBankByIdAsync(id);
        if (bank == null)
        {
            return NotFound();
        }

        await _bankService.SoftDeleteBankAsync(id);
        return NoContent();
    }
}