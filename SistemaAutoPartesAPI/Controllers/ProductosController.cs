using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAutoPartesAPI.Models;
using SistemaAutoPartesAPI.Models.DTOs;

namespace SistemaAutoPartesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly SistemaAutoPartesContext _context;

        public ProductosController(SistemaAutoPartesContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            var productos = await _context.Productos
                .Select(p => new ProductoDTO
                {
                    ProductoId = p.ProductoId,
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Marca = p.Marca,
                    CategoriaId = p.CategoriaId,
                    Precio = p.Precio,
                    ImagenUrl = p.ImagenUrl,
                    Activo = p.Activo
                })
                .ToListAsync();

            return Ok(productos);
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            var productoDTO = new ProductoDTO
            {
                ProductoId = producto.ProductoId,
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Marca = producto.Marca,
                CategoriaId = producto.CategoriaId,
                Precio = producto.Precio,
                ImagenUrl = producto.ImagenUrl,
                Activo = producto.Activo
            };

            return Ok(productoDTO);
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> PostProducto(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                Codigo = productoDTO.Codigo,
                Nombre = productoDTO.Nombre,
                Descripcion = productoDTO.Descripcion,
                Marca = productoDTO.Marca,
                CategoriaId = productoDTO.CategoriaId,
                Precio = productoDTO.Precio,
                ImagenUrl = productoDTO.ImagenUrl,
                Activo = productoDTO.Activo
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            productoDTO.ProductoId = producto.ProductoId; // Update DTO with generated ID

            return CreatedAtAction("GetProducto", new { id = producto.ProductoId }, productoDTO);
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductoDTO productoDTO)
        {
            if (id != productoDTO.ProductoId)
            {
                return BadRequest();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            producto.Codigo = productoDTO.Codigo;
            producto.Nombre = productoDTO.Nombre;
            producto.Descripcion = productoDTO.Descripcion;
            producto.Marca = productoDTO.Marca;
            producto.CategoriaId = productoDTO.CategoriaId;
            producto.Precio = productoDTO.Precio;
            producto.ImagenUrl = productoDTO.ImagenUrl;
            producto.Activo = productoDTO.Activo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }
    }
}