using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProductsController : ControllerBase
    {
        private readonly ITypeProductsServices _typeProductsServices;

        public TypeProductsController(ITypeProductsServices typeProductsServices)
        {
            _typeProductsServices = typeProductsServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypeProducts>>> GetAllTypeProducts()
        {
            var TypeProducts = await _typeProductsServices.GetAllTypeProductsAsync();
            return Ok(TypeProducts);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeProducts>> GetTypeProductsById(int Id)
        {
            var TypeProducts = await _typeProductsServices.GetTypeProductsByIdAsync(Id);
            if (TypeProducts == null)
                return NotFound();
            return Ok(TypeProducts);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTypeProducts([FromBody] TypeProducts TypeProducts)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _typeProductsServices.CreateTypeProductsAsync(TypeProducts);
            return CreatedAtAction(nameof(GetTypeProductsById), new { id = TypeProducts.Id }, TypeProducts);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTypeProducts(int Id, [FromBody] TypeProducts TypeProducts)
        {
            if (Id != TypeProducts.Id)
                return BadRequest();
            var existingTypeProducts = await _typeProductsServices.GetTypeProductsByIdAsync(Id);
            if (existingTypeProducts == null)
                return NoContent();

            await _typeProductsServices.UpdateTypeProductsAsync(TypeProducts);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteTypeProducts(int Id)
        {
            var TypeProducts = await _typeProductsServices.GetTypeProductsByIdAsync(Id);
            if (TypeProducts == null)
                return NotFound();

            await _typeProductsServices.SoftDeleteTypeProductsAsync(Id);
            return NoContent();
        }
    }
}







