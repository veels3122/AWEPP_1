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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        private readonly AuditService _auditLogService;

        public ProductsController(IProductsService productsService, IAuditService auditService)
        {
            _productsService = productsService;
            _auditLogService = (AuditService?)auditService;
            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            var Products = await _productsService.GetAllProductsAsync();
            return Ok(Products);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Products>> GetProductsById(int Id)
        {
            var Products = await _productsService.GetProductsByIdAsync(Id);
            if (Products == null)
                return NotFound();
            return Ok(Products);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProducts([FromBody] Products products)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productsService.CreateProductsAsync(products);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateProduct",
                TableName = "Product",
                RecordId = products.Id.ToString(),
                Changes = $"product {products.Customer},{products.Account},{products.NumberAccount} creado.",
                UserName = products.Account, 
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return CreatedAtAction(nameof(GetProductsById), new { id = products.Id }, products);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProducts(int Id, [FromBody] Products products)
        {
            if (Id != products.Id)
                return BadRequest();
            var existingProducts = await _productsService.GetProductsByIdAsync(Id);
            if (existingProducts == null)
                return NoContent();

            await _productsService.UpdateProductsAsync(products);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateProduct",
                TableName = "Product",
                RecordId = products.Id.ToString(),
                Changes = $"product {products.Customer},{products.Account},{products.NumberAccount} actualizado.",
                UserName = products.Account,
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();

        }
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteProducts(int Id)
        {
            var products = await _productsService.GetProductsByIdAsync(Id);
            if (products == null)
                return NotFound();

            await _productsService.SoftDeleteProductsAsync(Id);

            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "SoftProduct",
                TableName = "Product",
                RecordId = products.Id.ToString(),
                Changes = $"product {products.Customer},{products.Account},{products.NumberAccount} marca como eliminado.",
                UserName = products.Account,
                Date = DateTime.UtcNow.AddHours(-5)
            }); 
            return NoContent();
        }
        
    }
}