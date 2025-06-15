using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoAtributoValorsController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public ProductoAtributoValorsController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/ProductoAtributoValors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoAtributoValorDTO>>> GetProductoAtributoValors()
        {
            return await _context.ProductoAtributoValors
                .Select(x => new ProductoAtributoValorDTO
                {
                    ProductoId = x.ProductoId,
                    AtributoId = x.AtributoId,
                    Valor = x.Valor
                })
                .ToListAsync();
        }

        // GET: api/ProductoAtributoValors/5/6
        [HttpGet("{productoId}/{atributoId}")]
        public async Task<ActionResult<ProductoAtributoValorDTO>> GetProductoAtributoValor(int productoId, int atributoId)
        {
            var productoAtributoValor = await _context.ProductoAtributoValors.FindAsync(productoId, atributoId);

            if (productoAtributoValor == null)
            {
                return NotFound();
            }

            return new ProductoAtributoValorDTO
            {
                ProductoId = productoAtributoValor.ProductoId,
                AtributoId = productoAtributoValor.AtributoId,
                Valor = productoAtributoValor.Valor
            };
        }

        // PUT: api/ProductoAtributoValors/5/6
        [HttpPut("{productoId}/{atributoId}")]
        public async Task<IActionResult> PutProductoAtributoValor(int productoId, int atributoId, ProductoAtributoValorDTO productoAtributoValorDTO)
        {
            if (productoId != productoAtributoValorDTO.ProductoId || atributoId != productoAtributoValorDTO.AtributoId)
            {
                return BadRequest();
            }

            var productoAtributoValor = await _context.ProductoAtributoValors.FindAsync(productoId, atributoId);
            if (productoAtributoValor == null)
            {
                return NotFound();
            }

            productoAtributoValor.Valor = productoAtributoValorDTO.Valor;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoAtributoValorExists(productoId, atributoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductoAtributoValors
        [HttpPost]
        public async Task<ActionResult<ProductoAtributoValorDTO>> PostProductoAtributoValor(ProductoAtributoValorDTO productoAtributoValorDTO)
        {
            var productoAtributoValor = new ProductoAtributoValor
            {
                ProductoId = productoAtributoValorDTO.ProductoId,
                AtributoId = productoAtributoValorDTO.AtributoId,
                Valor = productoAtributoValorDTO.Valor
            };

            _context.ProductoAtributoValors.Add(productoAtributoValor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductoAtributoValorExists(productoAtributoValor.ProductoId, productoAtributoValor.AtributoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductoAtributoValor", new { productoId = productoAtributoValor.ProductoId, atributoId = productoAtributoValor.AtributoId }, productoAtributoValorDTO);
        }

        // DELETE: api/ProductoAtributoValors/5/6
        [HttpDelete("{productoId}/{atributoId}")]
        public async Task<IActionResult> DeleteProductoAtributoValor(int productoId, int atributoId)
        {
            var productoAtributoValor = await _context.ProductoAtributoValors.FindAsync(productoId, atributoId);
            if (productoAtributoValor == null)
            {
                return NotFound();
            }

            _context.ProductoAtributoValors.Remove(productoAtributoValor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoAtributoValorExists(int productoId, int atributoId)
        {
            return _context.ProductoAtributoValors.Any(e => e.ProductoId == productoId && e.AtributoId == atributoId);
        }
    }
}