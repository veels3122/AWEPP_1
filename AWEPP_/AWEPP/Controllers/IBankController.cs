using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class BanksController : ControllerBase
{
    public readonly IBankServices _bankService;


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
    public async Task<ActionResult<Bank>>GetBankById(int id)
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
            return BadRequest("El ID en la URL y en el cuerpo de la solicitud no coinciden.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedBank = await _bankService.UpdateBankAsync( bank);

        if (updatedBank == null)
        {
            return NotFound();
        }

        return NoContent();
    }





    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]


    public
     async Task<IActionResult> SoftDeleteBank(int id)
    {
       if(id <= 0  )
        {
            return NotFound("el numero debe ser un numero positivo");
        }
        if(_bankService.SoftDeleteBankAsync == null)
        {
            return NotFound("el dato del banco no existe");
        }
        await _bankService.SoftDeleteBankAsync(id);
        return NoContent();
    }
}