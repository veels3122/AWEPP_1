using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Models;
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
        private readonly AuditService _auditLogService;

        public TypeProductsController(ITypeProductsServices typeProductsServices, IAuditService auditService)
        {
            _typeProductsServices = typeProductsServices;
            _auditLogService = (AuditService?)auditService;
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateTypeProducts",
                TableName = "TypeProducts",
                RecordId = TypeProducts.Id.ToString(),
                Changes = $"TypeProducts {TypeProducts.Producd},{TypeProducts.Description} creado.",
                UserName = TypeProducts.Description,
                Date = DateTime.UtcNow.AddHours(-5)
            });
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateTypeProducts",
                TableName = "TypeProducts",
                RecordId = TypeProducts.Id.ToString(),
                Changes = $"TypeProducts {TypeProducts.Producd},{TypeProducts.Description} actualizado.",
                UserName = TypeProducts.Description,
                Date = DateTime.UtcNow.AddHours(-5)
            });
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
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "SoftTypeProducts",
                TableName = "TypeProducts",
                RecordId = TypeProducts.Id.ToString(),
                Changes = $"TypeProducts {TypeProducts.Producd},{TypeProducts.Description} marca como eliminado.",
                UserName = TypeProducts.Description,
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
    }
}







