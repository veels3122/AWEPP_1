using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeProductsController : ControllerBase
    {
        private readonly ITypeProductsServices _typeProductsService;

        public TypeProductsController(ITypeProductsServices typeProductsService)
        {
            _typeProductsService = typeProductsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeProduct>>> GetAllTypeProducts()
        {
            var typeProducts = await _typeProductsService.GetAllTypeProductsAsync();
            return Ok(typeProducts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeProduct>> GetTypeProductsById(int id)
        {
            var typeProducts = await _typeProductsService.GetTypeProductsByIdAsync(id);
            if (typeProducts == null)
            {
                return NotFound();
            }
            return Ok(typeProducts);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeProducts([FromBody] TypeProduct typeProducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _typeProductsService.CreateTypeProductsAsync(typeProducts);
                return CreatedAtAction(nameof(GetTypeProductsById), new { id = typeProducts.Id }, typeProducts);
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
        public async Task<IActionResult> UpdateTypeProducts(int id, [FromBody] TypeProduct typeProducts)
        {
            if (id != typeProducts.Id)
            {
                return BadRequest("El ID en la URL y en el cuerpo de la solicitud no coinciden.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTypeProducts = await _typeProductsService.UpdateTypeProductsAsync(typeProducts);

            if (updatedTypeProducts == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTypeProducts(int id)
        {
            if (id <= 0)
            {
                return NotFound("El ID debe ser un número positivo.");
            }

            await _typeProductsService.SoftDeleteTypeProductsAsync(id);
            return NoContent();
        }
    }
}